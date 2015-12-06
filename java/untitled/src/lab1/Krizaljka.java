/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab1;

/**
 *
 * @author tbrabec
 */

import java.util.Scanner;

public class Krizaljka {
    
	private String[][] values;
	private int rows;
	private int columns;
	
	public Krizaljka(int rows, int columns) {
		super();
		this.rows = rows;
		this.columns = columns;
                this.values = new String[rows][columns];
		
		System.out.println("Unesite vrijednosti krizaljke:");
		Scanner unos = new Scanner(System.in);
		for(int i = 0; i<rows; i++)
                    for(int j = 0; j<columns; j++){
			values[i][j] = unos.nextLine();
		}	
	}

	public String[][] getValues() {
		return values;
	}

	public void setValues(String[][] values) {
		this.values = values;
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
	
        public int[] getASCI(Krizaljka krizaljka){
              int[] krizaljkaASCI = new int[krizaljka.rows * krizaljka.columns];
                int k=0;
               
                for(int i = 0; i < krizaljka.rows; i++){
                        for(int j = 0; j < krizaljka.columns; j++){
                        char c = krizaljka.getValues()[i][j].charAt(0);
                        krizaljkaASCI[k++] = (int)c;
                    }
                }    
                return krizaljkaASCI;
        }
        
       public int size(){
           return rows*columns;
       }
}

