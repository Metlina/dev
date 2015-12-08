import org.jgap.Chromosome;
import org.jgap.IChromosome;
import org.jgap.InvalidConfigurationException;
import org.jgap.Population;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

/**
 * Created by tinop on 07-Dec-15.
 */
public class Main {

    public static final int POPULATION_SIZE = 100;

    public static void Main(String[] args){

    }

    private static Population generateRandomPopulation(SudokuConfiguration conf, int numberOfSegments, SegmentGene[] sudokuSegments) throws InvalidConfigurationException {
        IChromosome[] chromosomes = new Chromosome[POPULATION_SIZE];

        for (int i = 0; i < POPULATION_SIZE; i++) {
            SegmentGene[] genes = new SegmentGene[numberOfSegments];
            List<SegmentGene> sudokuSegmentList = Arrays.asList(sudokuSegments);
            Collections.shuffle(sudokuSegmentList);

            int n = 0;
            for(SegmentGene segment : sudokuSegmentList) {
                genes[n] = segment;
                n++;
            }

            Chromosome newChromosome = new Chromosome(conf, genes);
            chromosomes[i] = newChromosome;
        }

        Population population = new Population(conf, chromosomes);
        return population;
    }
}
