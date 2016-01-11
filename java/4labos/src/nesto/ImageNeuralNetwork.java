/*
 * Encog(tm) Examples v3.0 - Java Version
 * http://www.heatonresearch.com/encog/
 * http://code.google.com/p/encog-java/
 
 * Copyright 2008-2011 Heaton Research, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *   
 * For more information on Heaton Research copyrights, licenses 
 * and trademarks visit:
 * http://www.heatonresearch.com/copyright
 */
package nesto;

import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.StringTokenizer;

import javax.imageio.ImageIO;

import org.encog.Encog;
import org.encog.EncogError;
import org.encog.ml.data.MLData;
import org.encog.ml.data.basic.BasicMLData;
import org.encog.ml.train.strategy.ResetStrategy;
import org.encog.neural.networks.BasicNetwork;
import org.encog.neural.networks.training.propagation.back.Backpropagation;
import org.encog.neural.networks.training.propagation.quick.QuickPropagation;
import org.encog.neural.networks.training.propagation.resilient.ResilientPropagation;
import org.encog.platformspecific.j2se.TrainingDialog;
import org.encog.platformspecific.j2se.data.image.ImageMLData;
import org.encog.platformspecific.j2se.data.image.ImageMLDataSet;
import org.encog.util.downsample.Downsample;
import org.encog.util.downsample.RGBDownsample;
import org.encog.util.downsample.SimpleIntensityDownsample;
import org.encog.util.simple.EncogUtility;

/**
 * Should have an input file similar to:
 * 
 * CreateTraining: width:16,height:16,type:RGB 
 * Input: image:./coins/dime.png, identity:dime 
 * Input: image:./coins/dollar.png, identity:dollar 
 * Input: image:./coins/half.png, identity:half dollar 
 * Input: image:./coins/nickle.png, identity:nickle 
 * Input: image:./coins/penny.png, identity:penny 
 * Input: image:./coins/quarter.png, identity:quarter 
 * Network: hidden1:100, hidden2:0
 * Train: Mode:console, Minutes:1, StrategyError:0.25, StrategyCycles:50 
 * Whatis: image:./coins/dime.png 
 * Whatis: image:./coins/half.png 
 * Whatis: image:./coins/testcoin.png
 * 
 */
public class ImageNeuralNetwork {

	class ImagePair {
		private final File file;
		private final int identity;

		public ImagePair(final File file, final int identity) {
			super();
			this.file = file;
			this.identity = identity;
		}

		public File getFile() {
			return this.file;
		}

		public int getIdentity() {
			return this.identity;
		}
	}

	public static void main(final String[] args) throws IOException {

		try {
			final ImageNeuralNetwork program = new ImageNeuralNetwork();
			program.execute("command.txt");
		} catch (final Exception e) {
			e.printStackTrace();
		}


		Encog.getInstance().shutdown();
	}

	private final List<ImagePair> imageList = new ArrayList<ImagePair>();
	private final Map<String, String> args = new HashMap<String, String>();
	private final Map<String, Integer> identity2neuron = new HashMap<String, Integer>();
	private final Map<Integer, String> neuron2identity = new HashMap<Integer, String>();
	private ImageMLDataSet training;
	private String line;
	private int outputCount;
	private int downsampleWidth;
	private int downsampleHeight;
	private BasicNetwork network;

	private Downsample downsample;

	private int assignIdentity(final String identity) {

		if (this.identity2neuron.containsKey(identity.toLowerCase())) {
			return this.identity2neuron.get(identity.toLowerCase());
		}

		final int result = this.outputCount;
		this.identity2neuron.put(identity.toLowerCase(), result);
		this.neuron2identity.put(result, identity.toLowerCase());
		this.outputCount++;
		return result;
	}

	public void execute(final String file) throws IOException {
		final FileInputStream fstream = new FileInputStream(file);
		final DataInputStream in = new DataInputStream(fstream);
		final BufferedReader br = new BufferedReader(new InputStreamReader(in));

		while ((this.line = br.readLine()) != null) {
			executeLine();
		}
		in.close();
	}

	private void executeCommand(final String command, final Map<String, String> args) throws IOException {
		if (command.equals("input")) {
			processInput();
		} else if (command.equals("createtraining")) {
			processCreateTraining();
		} else if (command.equals("train")) {
			processTrain();
		} else if (command.equals("network")) {
			processNetwork();
		} else if (command.equals("whatis")) {
			processWhatIs();
		}

	}

	public void executeLine() throws IOException {
		final int index = this.line.indexOf(':');
		if (index == -1) {
			throw new EncogError("Invalid command: " + this.line);
		}

		final String command = this.line.substring(0, index).toLowerCase().trim();
		final String argsStr = this.line.substring(index + 1).trim();
		final StringTokenizer tok = new StringTokenizer(argsStr, ",");
		this.args.clear();
		while (tok.hasMoreTokens()) {
			final String arg = tok.nextToken();
			final int index2 = arg.indexOf(':');
			if (index2 == -1) {
				throw new EncogError("Invalid command: " + this.line);
			}
			final String key = arg.substring(0, index2).toLowerCase().trim();
			final String value = arg.substring(index2 + 1).trim();
			this.args.put(key, value);
		}

		executeCommand(command, this.args);
	}

	private String getArg(final String name) {
		final String result = this.args.get(name);
		if (result == null) {
			throw new EncogError("Missing argument " + name + " on line: " + this.line);
		}
		return result;
	}

	private void processCreateTraining() {
		final String strWidth = getArg("width");
		final String strHeight = getArg("height");
		final String strType = getArg("type");

		this.downsampleHeight = Integer.parseInt(strHeight);
		this.downsampleWidth = Integer.parseInt(strWidth);

		if (strType.equals("RGB")) {
			this.downsample = new RGBDownsample();
		} else {
			this.downsample = new SimpleIntensityDownsample();
		}

		this.training = new ImageMLDataSet(this.downsample, false, 1, -1);
		System.out.println("Training set created");
	}

	private void processInput() throws IOException {
		final String image = getArg("image");
		final String identity = getArg("identity");

		final int idx = assignIdentity(identity);
		final File file = new File(image);

		this.imageList.add(new ImagePair(file, idx));

		System.out.println("Added input image:" + image);
	}

	private void processNetwork() throws IOException {
		System.out.println("Downsampling images...");

		for (final ImagePair pair : this.imageList) {
			final MLData ideal = new BasicMLData(this.outputCount);
			final int idx = pair.getIdentity();
			for (int i = 0; i < this.outputCount; i++) {
				if (i == idx) {
					ideal.setData(i, 1);
				} else {
					ideal.setData(i, -1);
				}
			}

			final Image img = ImageIO.read(pair.getFile());
			final ImageMLData data = new ImageMLData(img);
			this.training.add(data, ideal);
		}

		final String strHidden1 = getArg("hidden1");
		final String strHidden2 = getArg("hidden2");

		this.training.downsample(this.downsampleHeight, this.downsampleWidth);

		final int hidden1 = Integer.parseInt(strHidden1);
		final int hidden2 = Integer.parseInt(strHidden2);

		this.network = EncogUtility.simpleFeedForward(this.training.getInputSize(), hidden1, hidden2,
				this.training.getIdealSize(), true);
		System.out.println("Created network: " + this.network.toString());
	}

	private void processTrain() throws IOException {
		final String strMode = getArg("mode");
		final String strMinutes = getArg("minutes");
		final String strStrategyError = getArg("strategyerror");
		final String strStrategyCycles = getArg("strategycycles");

		System.out.println("Training Beginning... Output patterns=" + this.outputCount);

		final double strategyError = Double.parseDouble(strStrategyError);
		final int strategyCycles = Integer.parseInt(strStrategyCycles);

		//propagation klasa
		final Backpropagation train = new Backpropagation(this.network, this.training);
		train.addStrategy(new ResetStrategy(strategyError, strategyCycles));

		if (strMode.equalsIgnoreCase("gui")) {
			TrainingDialog.trainDialog(train, this.network, this.training);
		} else {
			final int minutes = Integer.parseInt(strMinutes);
			EncogUtility.trainConsole(train, this.network, this.training, minutes);
		}
		System.out.println("Training Stopped...");
	}

	public void processWhatIs() throws IOException {
		final String filename = getArg("image");
		final File file = new File(filename);

		FileInputStream fis = new FileInputStream(file);
		// Pozivanje metode za èitanje slike
		BufferedImage image = ImageIO.read(fis);

		// Definiranje broja redaka i stupaca slike
		// 1 redak i 11 stupaca za broj znakova telefonskog broja
		// "091/111-222"
		int rows = 1;
		int cols = 11;
		int chunks = rows * cols;

		// odreðivanje velièine jednog dijela
		int chunkWidth = image.getWidth() / cols;
		int chunkHeight = image.getHeight() / rows;
		// Definiranje polja koje sadrži dijelove slika
		int count = 0;
		BufferedImage imgs[] = new BufferedImage[chunks];

		for (int x = 0; x < rows; x++) {
			for (int y = 0; y < cols; y++) {
				// Inicijalizacija polja s dijelovima slike
				imgs[count] = new BufferedImage(chunkWidth, chunkHeight, image.getType());
				// "Crtanje" pojedinih dijelova slike
				Graphics2D gr = imgs[count++].createGraphics();
				gr.drawImage(image, 0, 0, chunkWidth, chunkHeight, chunkWidth * y, chunkHeight * x, chunkWidth * y + chunkWidth, chunkHeight * x + chunkHeight, null);
				gr.dispose();
			}
		}

		//System.out.println("Rezanje slike je završeno.");

		// Zapisivanje dijelova slika u zasebne datoteke
		for (int i = 0; i < imgs.length; i++) {
			ImageIO.write(imgs[i], "jpg", new File("seemstobe" + i + ".jpg"));
		}
		//System.out.println("Kreiranje slika je završeno.");

		System.out.print("What is: " + filename + ", it seems to be: ");

		for (int i = 0; i < 11; i++){
			String tmp = "seemstobe" + i + ".jpg";
			File tmpFile = new File(tmp);
			final Image img = ImageIO.read(tmpFile);
			final ImageMLData input = new ImageMLData(img);
			input.downsample(this.downsample, false, this.downsampleHeight, this.downsampleWidth, 1, -1);
			final int winner = this.network.winner(input);
			if(!this.neuron2identity.get(winner).equals("/") && !this.neuron2identity.get(winner).equals("-")){
				System.out.print(this.neuron2identity.get(winner));
			}
			//System.out.println("What is: " + filename + ", it seems to be: " + this.neuron2identity.get(winner));
		}
		System.out.println();
	}
}
