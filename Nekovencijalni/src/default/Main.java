import org.jgap.Configuration;
import org.jgap.FitnessFunction;
import org.jgap.InvalidConfigurationException;
import org.jgap.impl.CrossoverOperator;
import org.jgap.impl.DefaultConfiguration;

/**
 * Created by tinop on 05-Nov-15.
 */
public class Main {

    public static final int NUMBER_OF_EVOLUTIONS = 200;
    public static final int POPULATION_SIZE = 50000;

    public static void main (String[] args) {
        Configuration conf = new DefaultConfiguration();
        FitnessFunction fitnessFunction = new Fitness();


        try {
            conf.setFitnessFunction(fitnessFunction);
            conf.addGeneticOperator(new CrossoverOperator(conf));
        }
        catch (InvalidConfigurationException ex) {
            ex.printStackTrace();
        }
    }
}
