import java.util.Scanner;

/**
 * Created by tinop on 06-Dec-15.
 */
public class Crossroad {

    private String[][] values;
    private int rows;
    private int columns;

    public Crossroad(int rows, int columns){
        super();
        this.rows = rows;
        this.columns = columns;
        this.values = new String[rows][columns];

        System.out.println("Enter values : ");
        Scanner scanner = new Scanner(System.in);
        for (int i = 0; i < rows; i++){
            for(int j = 0; j < columns; j++){
                values[i][j] = scanner.nextLine();
            }
        }
    }

    public int[] getAsci(Crossroad crossroad){
        int[] crossroadAsci = new int[crossroad.rows * crossroad.columns];
        int k = 0;
        for (int i = 0; i < crossroad.rows; i++){
            for(int j = 0; j < crossroad.columns; j++){
                char c = crossroad.getValues()[i][j].charAt(0);
                crossroadAsci[k++] = (int)c;
            }
        }
        return crossroadAsci;
    }

    public int getRows() {
        return rows;
    }

    public void setRows(int rows) {
        this.rows = rows;
    }

    public int getColumns() {
        return columns;
    }

    public void setColumns(int columns) {
        this.columns = columns;
    }

    public String[][] getValues() {
        return values;
    }

    public void setValues(String[][] values) {
        this.values = values;
    }

    public int size(){
        return rows * columns;
    }
}
