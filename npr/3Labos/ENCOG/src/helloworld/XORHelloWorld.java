package helloworld;

import org.encog.engine.network.activation.ActivationBipolarSteepenedSigmoid;
import org.encog.engine.network.activation.ActivationSigmoid;
import org.encog.engine.network.activation.ActivationSteepenedSigmoid;
import org.encog.ml.data.MLData;
import org.encog.ml.data.MLDataPair;
import org.encog.ml.data.MLDataSet;
import org.encog.ml.data.basic.BasicMLDataSet;
import org.encog.ml.train.MLTrain;
import org.encog.neural.networks.BasicNetwork;
import org.encog.neural.networks.layers.BasicLayer;
import org.encog.neural.networks.training.propagation.back.Backpropagation;
import org.encog.neural.networks.training.propagation.resilient.ResilientPropagation;

public class XORHelloWorld {

	private static int rows = 10;
	private static int columns = 2;
	public static final int MAX = 2000;
	public static final int MIN = 100;

	public static String InputString[][] = { {"Lara","ime"},{"prosinac","mjesec"},{"Guild Wars 2","igra"},{"kolajna","nakit"},{"usb","tehnika"},{"prsten","nakit"},{"kuca","stambeni objekt"},{"travanj","mjesec"},{"gitara","instrument"}, {"java","programski jezik"}};

	public static double Input[][] = new double[10][2];
	public static double InputZaMrezu[][] = new double[10][2];
	public static double Output[][] = { {0.1},{0.2},{0.3},{0.4},{0.5},{0.4},{0.6},{0.2},{0.7},{0.8}};

	private static double[][] getInputInDouble(String inputString[][]){

		for (int i = 0; i < rows; i++){
			for (int j = 0; j < columns; j++){

				double vrijednost = 0;

				String s = InputString[i][j];

				for (int k = 0; k < InputString[i][j].length(); k++) {
					char c = InputString[i][j].charAt(k);

					double temp = (double)c;
					vrijednost += temp;
				}
				Input[i][j] = vrijednost;
				//Input[i][j] = Double.parseDouble(InputString[i][j]);
			}
		}

		return Input;
	}

	private static double [][] getNormaliziraniDouble(double input[][]){
		for (int i = 0; i < rows; i++){
			for (int j = 0; j < columns; j++){
				double vrijednost = 0;
				//$normalized = ($value - $min) / ($max - $min);
				vrijednost = (input[i][j] - MIN) / (MAX - MIN);
				input[i][j] = vrijednost;
			}
		}

		return input;
	}

	/**
	 * The main method.
	 * @param args No arguments are used.
	 */
	public static void main(final String args[]) {

		Input = getInputInDouble(InputString);
		InputZaMrezu = getNormaliziraniDouble(Input);

		// create a neural network, without using a factory
		BasicNetwork network = new BasicNetwork();

		network.addLayer(new BasicLayer(null,false,2));
		//network.addLayer(new BasicLayer(new ActivationBipolarSteepenedSigmoid(),true,2));
		network.addLayer(new BasicLayer(new ActivationSigmoid(),false,10));
		//network.addLayer(new BasicLayer(new ActivationSigmoid(),true,7));

		network.addLayer(new BasicLayer(new ActivationSigmoid(),true,1));
		network.getStructure().finalizeStructure();
		network.reset();

		// create training data
		MLDataSet trainingSet = new BasicMLDataSet(InputZaMrezu, Output);
 
		// train the neural network
		//final MLTrain train = new Backpropagation(network, trainingSet, 0.7, 0.8);
		final ResilientPropagation train = new ResilientPropagation(network, trainingSet);
 
		int epoch = 1;
 
		do {
			train.iteration();
			System.out
					.println("Epoch #" + epoch + " Error:" + train.getError());
			epoch++;
		} while(train.getError() > 0.0002);
 
		// test the neural network
		System.out.println("Neural Network Results:");
		for(MLDataPair pair: trainingSet ) {
			final MLData output = network.compute(pair.getInput());
			System.out.println(pair.getInput().getData(0) + "," + pair.getInput().getData(1)
					+ ", actual=" + output.getData(0) + ",ideal=" + pair.getIdeal().getData(0));
		}
	}
}
