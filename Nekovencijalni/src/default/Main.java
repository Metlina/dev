import org.jgap.*;
import org.jgap.impl.*;
import org.jgap.Genotype;

import java.util.Scanner;

/**
 * Created by tinop on 05-Nov-15.
 */
public class Main {

    public static final int NUMBER_OF_EVOLUTIONS = 100;
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
            conf.addGeneticOperator(new CrossoverOperator(conf));
            conf.addGeneticOperator(new MutationOperator(conf));
            conf.setKeepPopulationSizeConstant(true);
            conf.setPreservFittestIndividual(true);
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
