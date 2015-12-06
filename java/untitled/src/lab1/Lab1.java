/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab1;

import java.util.Scanner;
import org.jgap.Chromosome;
import org.jgap.Configuration;
import org.jgap.FitnessFunction;
import org.jgap.Gene;
import org.jgap.Genotype;
import org.jgap.IChromosome;
import org.jgap.InvalidConfigurationException;
import org.jgap.impl.CrossoverOperator;
import org.jgap.impl.DefaultConfiguration;
import org.jgap.impl.IntegerGene;
import org.jgap.impl.MutationOperator;

/**
 *
 * @author tbrabec
 */
public class Lab1 {

    public static final int NUMBER_OF_EVOLUTIONS = 200;
    public static final int POPULATION_SIZE = 5000;
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
                Scanner unos = new Scanner(System.in);
        
                System.out.println("Unesite broj redaka krizaljke:");
                int rows = unos.nextInt();
                System.out.println("Unesite broj stupaca krizaljke:");
                int columns = unos.nextInt();
                
                
       		Krizaljka krizaljka = new Krizaljka(rows,columns);
		
		FitnessFunction fitnessKrizaljka = new KrizaljkaFitness(krizaljka);
		
		Configuration conf = new DefaultConfiguration();
                
                try{
                    conf.addGeneticOperator(new CrossoverOperator(conf));
                    conf.addGeneticOperator(new MutationOperator(conf));
                    conf.setKeepPopulationSizeConstant(true);
                    conf.setPreservFittestIndividual(true);
                    conf.setFitnessFunction(fitnessKrizaljka);

                    Gene[] genes = new Gene[krizaljka.size()];
                    
                    for(int i=0; i < krizaljka.size();i++){
                        genes[i] = new IntegerGene(conf, 65, 122);
                    }
                    
                    Chromosome chrom = new Chromosome((Configuration)conf,genes);
                    
                    conf.setSampleChromosome(chrom);
                    conf.setPopulationSize(POPULATION_SIZE);
                    
                    Genotype population = Genotype.randomInitialGenotype(conf);
                    
                    long Time = 0;
                    Time -=  System.currentTimeMillis();

			for (int i = 0; i < NUMBER_OF_EVOLUTIONS; i++) {

				IChromosome bestSolutionSoFar = population.getFittestChromosome();

				System.out.println("\nNajbolje rješenje nakon " + i + ". evolucije:");
				printSolution(bestSolutionSoFar, krizaljka.size());
				
				population.evolve();

				System.out.println();
			}
			
			Time += System.currentTimeMillis();

			System.out.println("Ukupno vrijeme trajanja : "
					+ ((double) Time / 1000) + " sekundi");
                }
                catch(InvalidConfigurationException e){
                    e.printStackTrace();
                }
    }
    
    private static void printSolution(IChromosome solution, int length) {
 
                 for(int i = 0; i < solution.size(); i++){
                           int allel = ((Integer) solution.getGene(i).getAllele()).intValue();
                           System.out.print((char) allel + " ");
                           if((i+1) % length  == 0) System.out.println();
                        }
                 System.out.println("\nFitness: " + solution.getFitnessValue());
        }
}
