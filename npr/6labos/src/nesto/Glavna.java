package nesto;

import net.sourceforge.jFuzzyLogic.FIS;
import net.sourceforge.jFuzzyLogic.FunctionBlock;
import net.sourceforge.jFuzzyLogic.plot.JFuzzyChart;
import net.sourceforge.jFuzzyLogic.rule.Rule;

public class Glavna {

	public static void main(String[] args) {
		String fileName = "fcl/datoteka.fcl";
		FIS fis = FIS.load(fileName, true);
		if (fis == null) {
			System.err.println("Can't load file: '" + fileName + "'");
			return;
		}
		//fis.chart();
		//JFuzzyChart.get().chart(fis);
		FunctionBlock fb = fis.getFunctionBlock("bolesti_disnih_puteva");
		
		fb.setVariable("kihanje", 0);
		fb.setVariable("suzenje", 0);
		fb.setVariable("kasljanje", 0);
		fb.setVariable("grlobolja", 0);
		fb.setVariable("promuklost", 0);
		fb.setVariable("otezano_disanje", 0);
		fb.setVariable("glavobolja", 0);
		fb.setVariable("visina_temperature", 0);
		fb.setVariable("bol_u_plucima", 0);
		fb.setVariable("promuklost", 0);
		fb.setVariable("hripanje", 0);
		fb.setVariable("zacepljen_nos", 0);
		fb.setVariable("gubitak_apetita", 0);
		fb.setVariable("slabost_tijela", 5);
		fb.setVariable("krvav_ispljuvak", 9);
		
		fb.evaluate();
		fb.getVariable("odluka").defuzzify();
		//JFuzzyChart.get().chart(fb);
		System.out.println(fb);
		System.out.println("REZULTAT:");
		System.out.println(fb.getVariable("odluka").getValue());
		for (Rule r : fb.getFuzzyRuleBlock("bolesti_pravila").getRules()) {
			System.out.println(r);
		}
		JFuzzyChart.get().chart(fb);
		
		/*fis.setVariable("kasljanje", 3);
		fis.setVariable("grlobolja", 8);
		fis.setVariable("promuklost", 2);
		fis.setVariable("kihanje", 3);
		fis.setVariable("otezano_disanje", 0);
		fis.setVariable("glavobolja", 0);
		fis.setVariable("visina_temperature", 0);
		fis.setVariable("bol_u_plucima", 0);
		fis.setVariable("promuklost", 0);
		fis.setVariable("hripanje", 0);
		fis.setVariable("zacepljen_nos", 0);
		fis.setVariable("gubitak_apetita", 0);
		fis.setVariable("slabost_tijela", 0);
		fis.setVariable("suzenje", 0);
		fis.setVariable("krvav_ispljuvak", 0);
		
		fis.evaluate();
		//fis.getVariable("odluka").chartDefuzzifier(true);
		System.out.println(fis);
		System.out.println("REZULTAT:");
		System.out.println(fis.getVariable("odluka").getValue());
		for (Rule r : fis.getFunctionBlock("bolesti_disnih_puteva").getFuzzyRuleBlock("bolesti_pravila").getRules()) {
			System.out.println(r);
		}*/
	}
}
