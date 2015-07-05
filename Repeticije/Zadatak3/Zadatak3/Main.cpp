#include <iostream>
#include <list>
#include "warrior.h"

using namespace std;

void printWarriorList() {
    /*list<Warrior *> listaRatnika = Warrior::getWarriorList();
    list<Warrior *>::iterator it;
    for (it = listaRatnika.begin(); it != listaRatnika.end(); ++it) {
        cout << (*it)->name() << " " << (*it)->health() << endl;
    }
    cout << endl;*/
}

int main() {
    Warrior W("winko");
    Dwarf D("darko");
    Paladin P("pero");

    W.attack(P).attack(P).specialAttack(D).specialAttack(D);
    D.attack(W).specialAttack(W);
    P.specialAttack(D).attack(W).attack(W);

    printWarriorList();
    // darko 45
    // pero 80
    // winko 50

    P.defend();
    W.attack(P);
    D.specialAttack(P);
	
    printWarriorList();
    // darko 45
    // pero 80
    // winko 50

    P.defend();
    W.attack(P);

    printWarriorList();
    // darko 45
    // pero 70
    // winko 50

    P.regenerate();
    D.crazyDwarfSuicide();

    printWarriorList();
    // darko 0
    // pero 100
    // winko 50

	int a;
	cin >> a;

    return 0;
}