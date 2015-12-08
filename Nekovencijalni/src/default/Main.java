import org.jgap.*;
import org.jgap.impl.*;
import org.jgap.Genotype;

import java.util.Scanner;

/**
 * Created by tinop on 05-Nov-15.
 */
public class Main {

    public static final int NUMBER_OF_EVOLUTIONS = 50;
    public static final int POPULATION_SIZE = 5000;

    public static void main (String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Enter number of rows :");
        int rows = scanner.nextInt();
        System.out.println("Enter number of columns :");
        int columns = scanner.nextInt();

        Crossroad crossroad = new Crossroad(rows, columns);
        FitnessFunction fitnessFunction = new Fitness(crossroad);
        Configuration conf = new DefaultConfiguration();

        try {
            conf.addGeneticOperator(new MutationOperator(conf));
            conf.addGeneticOperator(new AveragingCrossoverOperator(conf));
            conf.setKeepPopulationSizeConstant(true);
            conf.setPreservFittestIndividual(false);
            conf.setFitnessFunction(fitnessFunction);

            Gene[] genes = new Gene[crossroad.size()];

            for (int i = 0; i < crossroad.size(); i++){
                genes[i] = new IntegerGene(conf, 65, 122);
            }

            Chromosome chromosome = new Chromosome(conf, genes);

            conf.setSampleChromosome(chromosome);
            conf.setPopulationSize(POPULATION_SIZE);

            Genotype population = Genotype.randomInitialGenotype(conf);

            long startTime = System.currentTimeMillis();

            for (int i = 0; i < NUMBER_OF_EVOLUTIONS; i++){
                IChromosome bestSolution = population.getFittestChromosome();

                System.out.println("Best solution after " + i + " evolution : ");
                printSolution(bestSolution, crossroad.size());

                population.evolve();

                System.out.println();
            }

            long endTime = System.currentTimeMillis();

            System.out.println("Total time : " + (((double) endTime - startTime) / 1000) + "seconds");
        }
        catch (InvalidConfigurationException ex) {
            ex.printStackTrace();
        }

        //System.out.println("Calling brute");
        //callBrute();
    }

    private static void callBrute() {
        char[] alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'};

        //char[] myArray = {'K', 'L', 'U', 'B', 'R', 'A','D', 'A', 'A', 'R', 'A', 'K','J', 'A', 'V', 'A'};
        char[] myArray = {'K', 'L', 'U', 'B', 'R', 'A'};
        String tmp = "";
        for(char chr : myArray){
            tmp += chr;
        }
        long timeStart = System.currentTimeMillis();
        Brute.possibleStrings(myArray.length, alphabet, "", tmp);
        System.out.println("Brute time : " + (Brute.timeEnd - timeStart));
    }

    private static void printSolution(IChromosome solution, int length) {
        for(int i = 0; i < solution.size(); i++){
            int allele = (Integer) solution.getGene(i).getAllele();
            System.out.print((char) allele + " ");
            if((i+1) % length  == 0) System.out.println();
        }

        System.out.println("\nFitness: " + solution.getFitnessValue());
    }
}
