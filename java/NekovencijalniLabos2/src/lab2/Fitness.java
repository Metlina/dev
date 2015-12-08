import org.jgap.FitnessFunction;
import org.jgap.IChromosome;

import java.util.List;

/**
 * Created by tinop on 07-Dec-15.
 */
public class Fitness extends FitnessFunction {
    private List<int[]> segments;

    public Fitness(List<int[]> segments) {
        this.segments = segments;
    }

    @Override
    protected double evaluate(IChromosome iChromosome) {
        double diff = 1.0;

        for (int i = 0; i < 9; i++) {
            invoked++;

            SegmentGene segmentGene = (SegmentGene) iChromosome.getGene(i);
            int position = segmentGene.get_redniBroj();
            int target = 0;

            for (int j = 0; j < 9; j++) {
                int[] first = (int[]) segmentGene.getAllele();
                int[] second = segments.get(j);
                boolean equal = true;

                for (int k = 0; k < 9; k++) {
                    if (first[k] != second[k]) {
                        equal = false;
                    }
                }

                if (!equal) continue;

                target = j;
                break;
            }
            diff += Math.abs(target - position);
        }

        return 1.0 / diff;
    }

    public static long invoked = 0;
}
