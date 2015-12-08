import org.jgap.*;

import java.io.Serializable;

/**
 * Created by tinop on 07-Dec-15.
 */
public class SegmentGene extends BaseGene implements Gene, Serializable{
    private int[] _segment;
    private int _redniBroj;

    public SegmentGene(Configuration a_configuration, int[] segment, int redniBroj) throws InvalidConfigurationException {
        super(a_configuration);
        _segment = segment;
        _redniBroj = redniBroj;
    }

    @Override
    public int compareTo(Object o) {
        SegmentGene pom = (SegmentGene) o;
        for (int i = 0; i < _segment.length; i++){
            if (_segment[i] != pom._segment[i]){
                return 1;
            }
        }
        return 0;
    }

    @Override
    public void setAllele(Object o) {
        _segment = ((int[]) o).clone();
    }

    @Override
    protected Object getInternalValue() {
        return _segment;
    }

    @Override
    protected Gene newGeneInternal() {
        return this;
    }

    @Override
    public String getPersistentRepresentation() throws UnsupportedOperationException {
        return null;
    }

    @Override
    public void setValueFromPersistentRepresentation(String s) throws UnsupportedOperationException, UnsupportedRepresentationException {

    }

    @Override
    public void setToRandomValue(RandomGenerator randomGenerator) {

    }

    @Override
    public void applyMutation(int i, double v) {

    }

    public int get_redniBroj() {
        return _redniBroj;
    }

    public void set_redniBroj(int _redniBroj) {
        this._redniBroj = _redniBroj;
    }

    public int[] get_segment() {
        return _segment;
    }

    public void set_segment(int[] _segment) {
        this._segment = _segment;
    }
}
