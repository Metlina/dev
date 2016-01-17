import org.jgap.FitnessFunction;
import org.jgap.IChromosome;

/**
 * Created by tinop on 18.1.2016..
 */
public class SudokuSegmentFitness extends FitnessFunction{

    private int[] segment;
    private int redniBrojSegmenta;

    public SudokuSegmentFitness(int[] segment, int redniBrojSegmenta){
        this.segment = new int[segment.length];
        for (int i = 0; i<segment.length; i++){
            this.segment[i] = segment[i];
        }

        this.redniBrojSegmenta = redniBrojSegmenta;
    }

    @Override
    protected double evaluate(IChromosome iChromosome) {
        double fitness = 0;
        double diff;
        double possibleElement;

        for (int i = 0; i < iChromosome.size(); i++) {
            possibleElement = (Integer) iChromosome.getGene(i).getAllele();
            diff = Math.abs(segment[i] - possibleElement);
            fitness += segment[i] - diff;
        }

        if (fitness < 0){
            fitness = 0;
        }

        return fitness;
    }

}
