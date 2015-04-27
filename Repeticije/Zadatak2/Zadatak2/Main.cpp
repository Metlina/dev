#include <iostream>
#include <map>
#include <set>
#include <list>
#include <string>
#include <utility>
#include "halloween.h"

using namespace std;

void ispisiListu(list<pair<string, int> > L)
{
	list<pair<string, int> >::iterator it;
	for (it = L.begin(); it != L.end(); it++)
		cout << it->first << " " << it->second << " ";
}
void ispisiSkup(set<string> S)
{
	set<string>::iterator it;
	for (it = S.begin(); it != S.end(); it++)
		cout << *it << " ";
}
void ispisiMap(map<string, int> M)
{
	map<string, int>::iterator it;
	for (it = M.begin(); it != M.end(); it++)
		cout << it->first << " " << it->second << " ";
}
int main(void)
{
	Halloween mask;
	mask.dodaj("ante", 5); mask.dodaj("josip", -2); mask.dodaj("bosko", 3);
	mask.dodaj("ana", -4); mask.dodaj("ivana", 1); mask.dodaj("marko", 2);
	mask.dodaj("mate", 3); mask.dodaj("jelena", -3); mask.dodaj("filip", 5);
	mask.dodaj("petar", -1); mask.dodaj("karlo", 1); mask.dodaj("maja", -10);
	mask.dodaj("igor", -1); mask.dodaj("tonci", 2); mask.dodaj("kristina", -1);
	mask.dodaj("alma", 7); mask.izbrisi("bosko");
		
	cout << "Ispisi cilu listu" << endl;
	ispisiListu(mask.vratiListu());
	// ante 5 josip -2 ana -4 ivana 1 marko 2 mate 3 jelena -3 filip 5 petar -1 karlo 1 maja -10 igor -1
	//tonci 2 kristina - 1 alma 7
	cout << endl;
	cout << endl;
	cout << "Izbjegavat Ime ce biti maja" << endl;
	cout << mask.izbjegavatIme() << endl;
	// maja
	cout << endl;
	cout << "Ukupno kuna ce biti 17" << endl;
	cout << mask.ukupnoKuna("josip", "marko", 20) << endl;
	// 17
	cout << endl;
	cout << "Ukupno kuna ce biti -2" << endl;
	cout << mask.ukupnoKuna("josip", "marko", 1) << endl;
	// 3
	cout << endl;
	cout << "Ispisati sve dobre ljude" << endl;
	ispisiMap(mask.dobriJudi());
	// alma 7 ante 5 filip 5 ivana 1 karlo 1 marko 2 mate 3 tonci 2
	cout << endl;
	cout << endl;
	cout << "Pronadji imena koja su alma i mate" << endl;
	ispisiSkup(mask.pronadjiImena("ma", 2));
	// alma mate
	cout << endl;
	cout << endl;
	pair<string, string> p = mask.pametniObilazak(100);
	cout << "Pametni obilazak je ivana i filip" << endl;
	cout << p.first << " " << p.second << endl;
	// ivana filip

	cout << endl;
	int nesto;
	cout << "KRAJ PROGRAMA !!!!!!!!!!!!!!!!!!!!!!!!!!!!" << endl;
	cin >> nesto;

	return 0;
}