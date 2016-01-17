import java.util.Arrays;
import java.util.Collections;
import java.util.HashSet;
import java.util.List;
import java.util.Random;
import java.util.Set;

import org.jgap.Chromosome;
import org.jgap.Configuration;
import org.jgap.FitnessFunction;
import org.jgap.Gene;
import org.jgap.Genotype;
import org.jgap.IChromosome;
import org.jgap.InvalidConfigurationException;
import org.jgap.Population;
import org.jgap.impl.AveragingCrossoverOperator;
import org.jgap.impl.CrossoverOperator;
import org.jgap.impl.DefaultConfiguration;
import org.jgap.impl.GaussianMutationOperator;
import org.jgap.impl.IntegerGene;
import org.jgap.impl.MutationOperator;

/**
 * Created by tinop on 17.1.2016..
 */
public class Main {

    public static final int NUMBER_OF_EVOLUTIONS = 10;
    public static final int POPULATION_SIZE = 10;
    public static final int BROJ_SEGMENATA = 4;

    public static void main(String[] args) {
        int velSeg = 0;

        try {
            velSeg = (int) Math.sqrt(BROJ_SEGMENATA);
        } catch (ArithmeticException e) {
            System.out.println("Nepravilan oblik sudoku krizaljke!");
        }

		 /* int[][] sudoku = new int[][] {

		  { 7, 6, 5, 3, 8, 4, 1, 2, 9 },
		  { 9, 3, 2, 7, 1, 5, 4, 6, 8 },
		  { 8, 4, 1, 2, 9, 6, 3, 5, 7 },
		  { 6, 2, 7, 8, 3, 1, 5, 9, 4 },
		  { 1, 5, 9, 4, 6, 7, 8, 3, 2 },
		  { 3, 8, 4, 5, 2, 9, 6, 7, 1 },
		  { 5, 1, 3, 9, 7, 8, 2, 4, 6 },
		  { 4, 9, 8, 6, 5, 2, 7, 1, 3 },
		  { 2, 7, 6, 1, 4, 3, 9, 8, 5 }

		  };*/
        int[][] sudoku = new int[][] {

                { 4,1,3,2 },
                { 3,2,4,1 },
                { 1,4,2,3 },
                { 2,3,1,4 }

        };
		/*int[][] sudoku = new int[][] {

				{ 7, 8, 4, 16, 9, 1, 12, 3, 10, 11, 5, 14, 13, 2, 6, 15 },
				{ 5, 13, 15, 3, 2, 6, 14, 16, 8, 1, 9, 7, 10, 12, 11, 4 },
				{ 2, 12, 11, 14, 4, 10, 7, 8, 3, 6, 13, 15, 1, 16, 5, 9 },
				{ 1, 9, 10, 6, 11, 13, 15, 5, 16, 2, 4, 12, 7, 8, 3, 14 },
				{ 6, 4, 9, 8, 13, 12, 10, 15, 14, 16, 3, 2, 11, 1, 7, 5 },
				{ 14, 15, 16, 11, 1, 7, 6, 9, 4, 12, 8, 5, 3, 10, 2, 13 },
				{ 12, 1, 2, 7, 8, 5, 3, 11, 15, 9, 10, 13, 16, 4, 14, 6 },
				{ 10, 3, 5, 13, 16, 2, 4, 14, 1, 7, 11, 6, 15, 9, 8, 12 },
				{ 13, 7, 12, 4, 3, 16, 11, 2, 6, 5, 1, 8, 9, 14, 16, 10 },
				{ 15, 16, 8, 2, 6, 4, 13, 10, 9, 3, 14, 11, 12, 5, 1, 7 },
				{ 3, 10, 14, 1, 15, 9, 5, 7, 2, 13, 12, 16, 6, 11, 4, 8 },
				{ 11, 5, 6, 9, 14, 8, 1, 12, 7, 4, 15, 10, 2, 3, 13, 16 },
				{ 16, 14, 7, 5, 12, 11, 2, 4, 13, 10, 6, 3, 8, 15, 9, 1 },
				{ 8, 11, 1, 10, 7, 15, 9, 6, 12, 14, 2, 4, 5, 13, 16, 3 },
				{ 9, 6, 3, 12, 5, 14, 8, 13, 11, 15, 16, 1, 4, 7, 10, 2 },
				{ 4, 2, 13, 15, 10, 3, 16, 1, 5, 8, 7, 9, 14, 6, 12, 11 }

		};*/

        try {
            // DODAVANJE SEGMENATA U SET
            Set<SudokuSegment> segmentSet = new HashSet<>();
            SudokuSegment[] segmentPoljePravilno = new SudokuSegment[BROJ_SEGMENATA];
            SudokuSegment[] segmentPoljeIzmjesano = new SudokuSegment[BROJ_SEGMENATA];
            int br = 0;
            int[] temp = new int[BROJ_SEGMENATA];

            for (int l = 0; l < velSeg; l++)
                for (int i = 0; i < velSeg; i++) {
                    int m = 0;
                    for (int j = velSeg * l; j < velSeg * (l + 1); j++)
                        for (int k = velSeg * i; k < velSeg * (i + 1); k++) {
                            temp[m++] = sudoku[j][k];
                        }

                    SudokuSegmentConfiguration segmentConf = new SudokuSegmentConfiguration();
                    segmentConf.addGeneticOperator(new SudokuSegmentMutationOperator(br));
                    segmentPoljePravilno[br] = new SudokuSegment(segmentConf, temp, br);
                    segmentSet.add(new SudokuSegment(new Configuration(), temp, br));
                    br++;
                }

            // DOHVACANJE SEGMENATA IZ SETA I SPREMANJE U POLJE

            int j = 0;
            for (SudokuSegment segment : segmentSet) {
                int[] tmpPolje = segment.getSegment();
                Random rand = new Random();

                for (int i = 0; i < 6; i++) {
                    int x = rand.nextInt(BROJ_SEGMENATA);
                    int y = rand.nextInt(BROJ_SEGMENATA);
                    int tmpX = tmpPolje[x];
                    tmpPolje[x] = tmpPolje[y];
                    tmpPolje[y] = tmpX;
                }

                segment.setSegment(tmpPolje);
                Configuration conf = new DefaultConfiguration("Sudoku segmentconfiguration" + segment.getRedniBrojSegmenta(), "primary configuration");
                SudokuSegment tmpSeg = new SudokuSegment(conf, segment.getSegment(), segment.getRedniBrojSegmenta());
                segmentPoljeIzmjesano[j] = tmpSeg;
                j++;
            }

            // ISPIS PRAVILNE I IZMJESANE SUDOKU LISTE
			/*
			 * System.out.println("Izmjesana:"); for (SudokuSegment seg:
			 * segmentPoljeIzmjesano) seg.ispisiSegment();
			 *
			 * System.out.println();
			 *
			 * System.out.println("Pravilna:"); for (SudokuSegment seg:
			 * segmentPoljePravilno) seg.ispisiSegment();
			 */

            // DEFINIRANJE RANDOM POPULACIJE
            SudokuFitness sudokuFitness = new SudokuFitness(
                    segmentPoljePravilno);
            SudokuSegmentConfiguration sudokuSegmentConfiguration = new SudokuSegmentConfiguration();

            sudokuSegmentConfiguration.setFitnessFunction(sudokuFitness);
            sudokuSegmentConfiguration.setPopulationSize(POPULATION_SIZE);
            sudokuSegmentConfiguration.setKeepPopulationSizeConstant(true);
            sudokuSegmentConfiguration.setPreservFittestIndividual(true);

            Population tempPopulation = generateRandomPopulation(sudokuSegmentConfiguration, BROJ_SEGMENATA, segmentPoljeIzmjesano);
            sudokuSegmentConfiguration.setSampleChromosome(tempPopulation.toChromosomes()[0]);
            Genotype populationSudoku = new Genotype(sudokuSegmentConfiguration, tempPopulation);

            // RJEŠAVANJE SUDOKU KRIZALJKE (BROJEVI U SVAKOM SEGMENTU)
            long Time = 0;
            Time -= System.currentTimeMillis();

            System.out.println("Traženje pojedinog segmenta sudoku krizaljke:");

            for (int k = 0; k < BROJ_SEGMENATA; k++) {
                IChromosome bestSolutionSoFar = null;

                FitnessFunction segmentFit = new SudokuSegmentFitness(segmentPoljePravilno[k].getSegment(), segmentPoljePravilno[k].getRedniBrojSegmenta());

                Configuration.reset();
                Configuration conf = new DefaultConfiguration();
                // conf.addGeneticOperator(new CrossoverOperator(conf));
                GaussianMutationOperator mu = new GaussianMutationOperator(conf);
                //MutationOperator mu = new MutationOperator(conf);
                //mu.setMutationRate(2);
                conf.addGeneticOperator(mu);
                conf.addGeneticOperator(new CrossoverOperator(conf));
                conf.setKeepPopulationSizeConstant(false);
                conf.setPreservFittestIndividual(true);
                conf.setFitnessFunction(segmentFit);

                Gene[] genesSeg = new Gene[BROJ_SEGMENATA];

                for (int l = 0; l < BROJ_SEGMENATA; l++)
                    genesSeg[l] = new IntegerGene(conf, 1, BROJ_SEGMENATA);

                Chromosome chrom = new Chromosome(conf, genesSeg);

                conf.setSampleChromosome(chrom);
                conf.setPopulationSize(POPULATION_SIZE);

                Genotype populationSegment = Genotype.randomInitialGenotype(conf);

                int[] tempProvjera = new int[BROJ_SEGMENATA];

                System.out.println("Tražim rješenje za " + (k + 1) + ". segment!");
                for (int i = 0; i < NUMBER_OF_EVOLUTIONS; i++) {
                    bestSolutionSoFar = populationSegment.getFittestChromosome();
                    populationSegment.evolve();

                }

                int[] tempPolje = new int[BROJ_SEGMENATA];
                for (int m = 0; m < bestSolutionSoFar.size(); m++)
                    tempPolje[m] = (Integer) bestSolutionSoFar.getGene(m).getAllele();

                for (int n = 0; n < BROJ_SEGMENATA; n++) {
                    if (segmentPoljeIzmjesano[n].getRedniBrojSegmenta() == segmentPoljePravilno[k].getRedniBrojSegmenta())
                        segmentPoljeIzmjesano[n].setAllele(tempPolje);
                }

                for (int l = 0; l < bestSolutionSoFar.size(); l++) {
                    tempProvjera[l] = (Integer) bestSolutionSoFar.getGene(l).getAllele();
                    // System.out.print(((Integer)bestSolutionSoFar.getGene(l).getAllele()).intValue()
                    // + ", ");
                }
                if (segmentPoljePravilno[k].compareTo(tempProvjera) == 0) {
                    System.out.println("Pronašao rješenje " + (k + 1) + ". segmenta!");
                }

                System.out.println();
            }
			/*
			 * Time += System.currentTimeMillis();
			 *
			 * System.out.println("\nUkupno vrijeme trajanja : " + ((double)
			 * Time / 1000) + " sekundi");
			 */
            System.out.println("Završeno traženje svih segmenata sudoku krizaljke!\n");
            System.out.println("Traženje ispravnog redoslijeda segmenata u sudoku krizaljci:");

            IChromosome bestSolutionSoFar = null;

            // RJEŠAVANJE SUDOKU KRIZALJKE (RASPORED SEGMENATA)
            Time = 0;
            Time -= System.currentTimeMillis();

            for (int i = 0; i < NUMBER_OF_EVOLUTIONS; i++) {
                bestSolutionSoFar = populationSudoku.getFittestChromosome();
                System.out.print("\nRješenje (fitness) nakon " + (i + 1) + ". evolucije: ");
                printSolution(bestSolutionSoFar, BROJ_SEGMENATA);
                populationSudoku.evolve();
                System.out.println();
            }

            // PROVJERA ISPRAVNOSTI GENETSKI RJEŠENOG SUDOKUA
            boolean razliciti = false;
            System.out.println("provjera");
            SudokuSegment[] tempSeg = new SudokuSegment[BROJ_SEGMENATA];
            for (int l = 0; l < bestSolutionSoFar.size(); l++) {
                tempSeg[l] = (SudokuSegment) bestSolutionSoFar.getGene(l);
                if (tempSeg[l].compareTo(segmentPoljePravilno[l].getSegment()) != 0) {
                    razliciti = true;
                }
            }

            if (!razliciti)
                System.out.println("Pronašao sam rješenje!");
            else
                System.out.println("Nisam pronašao rješenje!");

            Time += System.currentTimeMillis();

            System.out.println("\nUkupno vrijeme trajanja : " + ((double) Time / 1000) + " sekundi");
            // USPOREDBA ISPRAVNOG SUDOKUA SA RIJEŠENIM
			/*
			 * for (SudokuSegment seg: segmentPoljePravilno)
			 * seg.ispisiSegment();
			 *
			 * System.out.println();
			 *
			 * for (SudokuSegment seg: tempSeg) seg.ispisiSegment();
			 */
        } catch (InvalidConfigurationException e) {
            e.printStackTrace();
        }

    }

    private static Population generateRandomPopulation(SudokuSegmentConfiguration conf, int numberOfSegments, SudokuSegment[] sudokuSegments) throws InvalidConfigurationException {
        IChromosome[] chromosomes = new Chromosome[POPULATION_SIZE];
        for (int i = 0; i < POPULATION_SIZE; i++) {
            SudokuSegment[] genes = new SudokuSegment[numberOfSegments];
            List<SudokuSegment> sudokuSegmentList = Arrays.asList(sudokuSegments);
            Collections.shuffle(sudokuSegmentList);
            int n = 0;
            for (SudokuSegment segment : sudokuSegmentList) {
                genes[n] = segment;
                n++;
            }
            Chromosome newChromosome = new Chromosome(conf, genes);
            chromosomes[i] = newChromosome;
        }
        Population population = new Population(conf, chromosomes);
        return population;
    }

    private static void printSolution(IChromosome solution, int length) {
		/*SudokuSegment tempSeg;

		for (int i = 0; i < solution.size(); i++) {
			tempSeg = ((SudokuSegment) solution.getGene(i));
			tempSeg.ispisiSegment();
			if ((i + 1) % length == 0)
				System.out.println();
		}*/

        System.out.print(solution.getFitnessValue());
    }
}