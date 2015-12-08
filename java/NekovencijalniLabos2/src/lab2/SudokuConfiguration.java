import org.jgap.Configuration;
import org.jgap.DefaultFitnessEvaluator;
import org.jgap.InvalidConfigurationException;
import org.jgap.event.EventManager;
import org.jgap.impl.BestChromosomesSelector;
import org.jgap.impl.ChromosomePool;
import org.jgap.impl.GABreeder;
import org.jgap.impl.StockRandomGenerator;


/**
 * Created by tinop on 07-Dec-15.
 */
public class SudokuConfiguration extends Configuration {
    public SudokuConfiguration() {
        super("Sudoku segments configuration", "second level");
        try {
            setBreeder(new GABreeder());
            setRandomGenerator(new StockRandomGenerator());
            setEventManager(new EventManager());
            BestChromosomesSelector bestChromosomesSelector = new BestChromosomesSelector(this, 0.90d);
            bestChromosomesSelector.setDoubletteChromosomesAllowed(true);
            addNaturalSelector(bestChromosomesSelector, false);
            setMinimumPopSizePercent(0);
            setSelectFromPrevGen(1.0d);
            setKeepPopulationSizeConstant(true);
            Configuration.reset("Sudoku segments configuration");
            setFitnessEvaluator(new DefaultFitnessEvaluator());
            setChromosomePool(new ChromosomePool());
            addGeneticOperator(new SudokuSegmentMutationOperator());
        }
        catch (InvalidConfigurationException e){
            throw new RuntimeException( "Fatal error: DefaultConfiguration class could not use its "
                    + "own stock configuration values. This should never happen. "
                    + "Please report this as a bug to the JGAP team.");
        }
    }
}
