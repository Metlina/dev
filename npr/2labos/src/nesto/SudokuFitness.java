import org.jgap.FitnessFunction;
import org.jgap.IChromosome;

/**
 * Created by tinop on 17.1.2016..
 */
public class SudokuFitness extends FitnessFunction {

    private SudokuSegment[] sudokuSegments;

    public SudokuFitness(SudokuSegment[] sudokuSegments){
        this.sudokuSegments = new SudokuSegment[sudokuSegments.length];
        this.sudokuSegments = sudokuSegments;
    }

    @Override
    protected double evaluate(IChromosome iChromosome) {
        double fitness = 0;
        double diff;
        double possibleElement;

        for (int i = 0; i < iChromosome.size(); i++){
            possibleElement = ((SudokuSegment) iChromosome.getGene(i)).getRedniBrojSegmenta();
            diff = Math.abs(sudokuSegments[i].getRedniBrojSegmenta() - possibleElement);
            fitness += sudokuSegments.length - diff;
        }

        if (fitness < 0){
            fitness = 0;
        }

        return fitness;
    }
}
