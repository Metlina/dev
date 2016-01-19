import org.jgap.*;

import java.io.Serializable;
import java.util.Arrays;

/**
 * Created by tinop on 17.1.2016..
 */
public class SudokuSegment extends BaseGene implements Gene, Serializable {

    private int[] segment;
    private int redniBrojSegmenta;

    public SudokuSegment(Configuration configuration) throws InvalidConfigurationException {
        super(configuration);
    }

    public SudokuSegment(Configuration configuration, int[] poljeZnamenkiSegment, int brojSegmenta) throws InvalidConfigurationException {
        super(configuration);

        segment = new int[poljeZnamenkiSegment.length];
        redniBrojSegmenta = brojSegmenta;
        for (int i = 0; i < poljeZnamenkiSegment.length; i++){
            segment[i] = poljeZnamenkiSegment[i];
        }
    }

    @Override
    public int compareTo(Object o) {
        int razliciti = 1;
        int[] drugiSegment = (int[])o;
        if(Arrays.equals(this.segment, drugiSegment))
            razliciti = 0;

        return razliciti;
    }

    @Override
    public void setAllele(Object o) {
        segment = (int[]) o;
    }

    @Override
    protected Object getInternalValue() {
        return segment;
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

    public int getRedniBrojSegmenta() {
        return redniBrojSegmenta;
    }

    public void setRedniBrojSegmenta(int redniBrojSegmenta) {
        this.redniBrojSegmenta = redniBrojSegmenta;
    }

    public int[] getSegment() {
        return segment;
    }

    public void setSegment(int[] segment) {
        this.segment = segment;
    }

    @Override
    public boolean equals(Object drugiSudokuSegment) {
        for(int i = 0; i < segment.length; i++)
            if (this.segment[i] != ((SudokuSegment)drugiSudokuSegment).getSegment()[i])
                return false;
            else
                return true;
        return true;
    }

    public void ispisiSegment(){
        for (int broj : this.segment)
            System.out.print(broj + ", ");

        System.out.println();
    }
}
