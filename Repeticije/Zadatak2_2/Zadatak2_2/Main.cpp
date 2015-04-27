#include "gameofscores.h"
#include <iostream>
#include <map>
#include <vector>
#include <list>
#include <utility>
using namespace std;
void ispisiListu(list<pair<int, int> > L)
{
	list<pair<int, int> >::iterator it;
	for (it = L.begin(); it != L.end(); it++)
		cout << it->first << " " << it->second << " ";
}
void ispisiMap(map<int, int> M)
{
	map<int, int>::iterator it;
	for (it = M.begin(); it != M.end(); it++)
		cout << it->first << " " << it->second << " ";
}
void ispisiVector(vector<pair<int, int> > V)
{
	for (int i = 0; i < V.size(); i++)
		cout << V[i].first << " " << V[i].second << " ";
}
int main(void)
{
	GameOfScores game;
	game.dodajPolje(112, -4); game.dodajPolje(226, 5); game.dodajPolje(327, 2);
	game.dodajPolje(158, -3); game.dodajPolje(445, 5); game.dodajPolje(649, 7);
	game.dodajPolje(654, 4); game.dodajPolje(120, -2); game.dodajPolje(821, -4);
	game.dodajPolje(415, -1); game.dodajPolje(117, 4); game.dodajPolje(926, 1);
	game.dodajPolje(258, -15); game.dodajPolje(202, 6); game.izbrisiPolje(445);
	cout << "Ispisi listu : 112 -4 226 5 327 2 158 -3 649 7 654 4 120 -2 821 -4 415 -1 117 4 926 1 258 -15 202 6" << endl;
	ispisiListu(game.vratiListu());
	// 112 -4 226 5 327 2 158 -3 649 7 654 4 120 -2 821 -4 415 -1 117 4 926 1 258 -15 202 6
	cout << endl;

	cout << endl;
	cout << "Ispisivanje vektora : 112 -4 226 5 158 -3 654 4 120 -2 926 1 258 -15 202 6" << endl;
	ispisiVector(game.polja(1));
	// 112 -4 226 5 158 -3 654 4 120 -2 926 1 258 -15 202 6
	cout << endl;

	cout << endl;
	cout << "Ispisivanje vektora : 327 2 649 7 821 -4 415 -1 117 4" << endl;
	ispisiVector(game.polja(2));
	// 327 2 649 7 821 -4 415 -1 117 4
	cout << endl;

	cout << endl;
	cout << "Ispisivanje mape : 117 4 202 6 226 5 649 7 654 4" << endl;
	ispisiMap(game.viseOd(2));
	// 117 4 202 6 226 5 649 7 654 4
	cout << endl;

	cout << "Pobjednik je 2" << endl;
	cout << game.pobjednik(226, 120, 649, 117) << endl;
	// 2
	pair<int, int> p = game.optimalnaIgra(1);

	cout << endl;
	cout << "Optimalna igra :  226 654" << endl;
	cout << p.first << " " << p.second << endl;
	// 226 654
	p = game.optimalnaIgra(2);

	cout << endl;
	cout << "Optimalna igra :  327 649" << endl;
	cout << p.first << " " << p.second << endl;
	// 327 649

	int nesto;
	cin >> nesto;

	cout << "KRAJ PROGRAMA !!!!!!!!!!!!!!!!!!!!!!!!!!!" << endl; 

	return 0;
}