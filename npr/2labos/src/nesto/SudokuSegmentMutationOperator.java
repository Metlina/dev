import org.jgap.*;

import java.util.List;
import java.util.Random;

/**
 * Created by tinop on 17.1.2016..
 */
public class SudokuSegmentMutationOperator implements GeneticOperator{

    private int brojSegmenta;
    private Configuration configuration;

    public SudokuSegmentMutationOperator(){

    }

    public SudokuSegmentMutationOperator(Configuration configuration){
        this.configuration = configuration;
    }

    public SudokuSegmentMutationOperator(int brojSegmenta){
        this.brojSegmenta = brojSegmenta;
    }

    @Override
    public void operate(Population population, List list) {
        Random random = new Random();
        int x = random.nextInt(Main.BROJ_SEGMENATA);
        int y = random.nextInt(Main.BROJ_SEGMENATA);

        IChromosome tempChromosome = population.getChromosome(brojSegmenta);

        Gene[] genes = tempChromosome.getGenes();

        Gene tempGene = genes[x];
        genes[x] = genes[y];
        genes[y] = tempGene;

        list.add(tempChromosome);
    }
}
