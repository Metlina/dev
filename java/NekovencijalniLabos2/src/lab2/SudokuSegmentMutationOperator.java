import org.jgap.*;

import java.util.List;
import java.util.Random;

/**
 * Created by tinop on 07-Dec-15.
 */
public class SudokuSegmentMutationOperator implements GeneticOperator{

    private int _mutationCount = 1;

    @Override
    public void operate(Population a_population, List a_candidateChromosomes) {
        Random random = new Random();
        List<IChromosome> chromosomes = a_population.getChromosomes();
        for (int i = 0; i < chromosomes.size(); i++){
            IChromosome chromosome = chromosomes.get(i);
            try {
                Gene[] genes = chromosome.getGenes();

                int count = _mutationCount;

                while (count-- != 0){
                    invoked++;
                    int first = 0;
                    int second = 0;
                    do{
                        first = random.nextInt(9);
                        second = random.nextInt(9);
                    }while (first == second);

                    Gene temp = genes[first].newGene();
                    genes[first] = genes[second].newGene();
                    genes[second] = temp;

                    ((SegmentGene) genes[first]).set_redniBroj(first);
                    ((SegmentGene) genes[second]).set_redniBroj(second);
                }

                Chromosome newChromose = new Chromosome(chromosome.getConfiguration(), genes);

                a_candidateChromosomes.set(i, newChromose);
            }
            catch (Exception e){
                e.printStackTrace();
            }
        }
    }

    public int get_mutationCount() {
        return _mutationCount;
    }

    public void set_mutationCount(int _mutationCount) {
        this._mutationCount = _mutationCount;
    }

    public static long invoked = 0;
}
