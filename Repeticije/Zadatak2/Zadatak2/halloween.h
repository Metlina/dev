#pragma once
#include <iostream>
#include <list>
#include <map>
#include <set>

using namespace std;

struct Halloween
{
	list<pair<string, int>> kuce;
	
	list<pair<string, int>> losi;
	list<pair<string, int>> dobri;

	list<pair<string, int>> vratiListu(void) { return kuce; }

	void dodaj(string ime, int novac);

	void izbrisi(string ime);

	string izbjegavatIme(void);

	int ukupnoKuna(string pocetak, string kraj, int pocetniIznos);

	map<string, int> dobriJudi(void);

	set<string> pronadjiImena(string substr, int novac);

	pair <string, string> pametniObilazak(int pocetniIznos);
};

