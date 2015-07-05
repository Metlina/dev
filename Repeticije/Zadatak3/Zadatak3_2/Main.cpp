#include <iostream>
#include <list>
#include "auto.h"

using namespace std;

void ispisiListuAutomobila() {
    /*list<Auto *> listaAuta = Auto::sviAutomobili();
    list<Auto *>::iterator it;
    for (it = listaAuta.begin(); it != listaAuta.end(); ++it) {
        cout << (*it)->ime() << " " << (*it)->polozaj() << "km " << (*it)->vrijeme() << "min" << endl;
    }
    cout << endl;*/
}

int main() {
    Auto A("ante");
    Lamborghini L("luka");
    Ferrari F("frane");

    A.odvozi().odvozi().odvozi().odvozi().odvozi();
    F.odvozi().nitro();
    L.odvozi().nitro().nitro().odvozi();

    ispisiListuAutomobila();
    // ante 50km 20min
    // frane 20km 6min
    // luka 40km 10min
    
    F.odvoziPuno();
    L.odvoziMalo();

    ispisiListuAutomobila();
    // ante 50km 20min
    // frane 50km 21min
    // luka 45km 12min

    cout << A.sudar(F) << endl << endl;
    // 1

    A.odvozi().odvozi();
    F.nitro();
    L.nitro();

	int a;
	cin >> a;
    ispisiListuAutomobila();
    // ante 50km 20min
    // frane 50km 21min
    // luka 55km 13min

    return 0;
}