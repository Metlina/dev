import org.jgap.Genotype;
import org.jgap.impl.DefaultConfiguration;

/**
 * Created by tinop on 05-Nov-15.
 */
public class Main {
    Fitness fitness = new Fitness();

    DefaultConfiguration defaultConfiguration = new DefaultConfiguration();

    Genotype genotype = Genotype.randomInitialGenotype(defaultConfiguration);
}
