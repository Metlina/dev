#pragma once
#include <iostream>
#include <list>
#include <vector>
#include <map>

using namespace std;

struct GameOfScores
{
	list<pair<int, int> > listaPolja;

	vector<pair<int, int>> parni;
	vector<pair<int, int>> neparni;


	list<pair<int, int> > vratiListu(void) { return listaPolja; }
	void dodajPolje(int ID, int bodovi);
	void izbrisiPolje(int ID);
	vector<pair<int, int> > polja(int igrac);
	map<int, int> viseOd(int bodovi);
	int pobjednik(int poc1, int kraj1, int poc2, int kraj2);
	pair<int, int> optimalnaIgra(int igrac);
};

