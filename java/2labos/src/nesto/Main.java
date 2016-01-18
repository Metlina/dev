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
import org.jgap.impl.*;

/**
 * Created by tinop on 17.1.2016..
 */
public class Main {

    public static final int NUMBER_OF_EVOLUTIONS = 100;
    public static final int POPULATION_SIZE = 150;
    public static final int BROJ_SEGMENATA = 9;

    public static void main(String[] args) {
        int velSeg = 0;

        try {
            velSeg = (int) Math.sqrt(BROJ_SEGMENATA);
        } catch (ArithmeticException e) {
            System.out.println("Nepravilan oblik sudoku krizaljke!");
        }

		 int[][] sudoku = new int[][] {
		    { 7, 6, 5, 3, 8, 4, 1, 2, 9 },
		    { 9, 3, 2, 7, 1, 5, 4, 6, 8 },
		    { 8, 4, 1, 2, 9, 6, 3, 5, 7 },
		    { 6, 2, 7, 8, 3, 1, 5, 9, 4 },
		    { 1, 5, 9, 4, 6, 7, 8, 3, 2 },
		    { 3, 8, 4, 5, 2, 9, 6, 7, 1 },
		    { 5, 1, 3, 9, 7, 8, 2, 4, 6 },
		    { 4, 9, 8, 6, 5, 2, 7, 1, 3 },
		    { 2, 7, 6, 1, 4, 3, 9, 8, 5 }
	    };

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

            // DEFINIRANJE RANDOM POPULACIJE
            SudokuFitness sudokuFitness = new SudokuFitness(segmentPoljePravilno);
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

                //postavke
                Configuration.reset();
                Configuration conf = new DefaultConfiguration();
                //operator mutacije
                //GaussianMutationOperator mutationOperator = new GaussianMutationOperator(conf);
                SwappingMutationOperator mutationOperator = new SwappingMutationOperator(conf);
                //MutationOperator mutationOperator = new MutationOperator(conf);
                //SudokuSegmentMutationOperator mutationOperator = new SudokuSegmentMutationOperator(conf);
                //postotak mutacije
                //mutationOperator.setMutationRate(2);
                //operator rekombinacije
                conf.addGeneticOperator(mutationOperator);
                conf.addGeneticOperator(new AveragingCrossoverOperator(conf));
                //conf.addGeneticOperator(new CrossoverOperator(conf));
                conf.setKeepPopulationSizeConstant(true);
                conf.setPreservFittestIndividual(false);
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
            System.out.println("Završeno traženje svih segmenata sudoku krizaljke!\n");
            System.out.println("Traženje ispravnog redoslijeda segmenata u sudoku krizaljci:");

            IChromosome bestSolutionSoFar = null;

            // RJEŠAVANJE SUDOKU KRIZALJKE (RASPORED SEGMENATA)
            Time = 0;
            Time -= System.currentTimeMillis();

            for (int i = 0; i < NUMBER_OF_EVOLUTIONS; i++) {
                bestSolutionSoFar = populationSudoku.getFittestChromosome();
                System.out.print("\nRješenje (fitness) nakon " + (i + 1) + ". evolucije: \n");
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
		SudokuSegment tempSeg;

		for (int i = 0; i < solution.size(); i++) {
			tempSeg = ((SudokuSegment) solution.getGene(i));
			tempSeg.ispisiSegment();
			if ((i + 1) % length == 0)
				System.out.println();
		}

        System.out.print(solution.getFitnessValue());
    }
}