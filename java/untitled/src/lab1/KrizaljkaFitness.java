/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab1;

import org.jgap.FitnessFunction;
import org.jgap.IChromosome;

/**
 *
 * @author tbrabec
 */
public class KrizaljkaFitness extends FitnessFunction{

        private Krizaljka krizaljka;
        
         public KrizaljkaFitness(){
        }
    
        public KrizaljkaFitness(Krizaljka k){
            this.krizaljka = k;
        }
    
	@Override
	protected double evaluate(IChromosome potencijelnoRjesenje) {
		
                double fitness = 0;
                double diff;
                double possibleEl;
                
                int[] krizaljkaASCI = krizaljka.getASCI(krizaljka);
                
                
                for (int i = 0; i < potencijelnoRjesenje.size(); i++)
                    {
                    possibleEl = ((Integer) potencijelnoRjesenje.getGene(i).getAllele()).intValue();
                    diff = Math.abs(krizaljkaASCI[i] - possibleEl);
                    fitness += krizaljkaASCI[i] - diff;
                }
               
                return fitness;
            
	}
	
}