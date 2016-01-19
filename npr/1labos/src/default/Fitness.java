import org.jgap.FitnessFunction;
import org.jgap.IChromosome;

/**
 * Created by tinop on 05-Nov-15.
 */
public class Fitness extends FitnessFunction {

    private Crossroad crossroad;

    public Fitness(Crossroad crossroad) {
        this.crossroad = crossroad;
    }

    @Override
    protected double evaluate(IChromosome iChromosome) {
        double fittnes = 0;
        double diff;
        double possible;

        int[] crossroadAsci = crossroad.getAsci(crossroad);

        for (int i = 0; i < iChromosome.size(); i++){
            possible = (Integer) iChromosome.getGene(i).getAllele();
            diff = Math.abs(crossroadAsci[i] - possible);
            fittnes += crossroadAsci[i] - diff;
        }

        if (fittnes < 0){
            fittnes = 0;
        }

        return fittnes;
    }
}
