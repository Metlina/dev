#include "gameofscores.h"

void GameOfScores::dodajPolje(int ID, int bodovi)
{
	if (ID % 2 == 0)
	{
		parni.push_back(make_pair(ID, bodovi));
		listaPolja.push_back(make_pair(ID, bodovi));
	}
	else
	{
		neparni.push_back(make_pair(ID, bodovi));
		listaPolja.push_back(make_pair(ID, bodovi));
	}
}

void GameOfScores::izbrisiPolje(int ID)
{
	list<pair<int, int> >::iterator it;

	for (it = listaPolja.begin(); it != listaPolja.end(); )
	{
		if ((*it).first == ID)
		{
			it = listaPolja.erase(it);
		}
		else
			it++;
	}
}

vector<pair<int, int> > GameOfScores::polja(int igrac)
{
	vector <pair<int, int >> rjesenje;

	if (igrac == 1)
	{
		rjesenje = parni;
	}
	else if (igrac == 2)
	{
		rjesenje = neparni;
	}

	return rjesenje;
}

map<int, int> GameOfScores::viseOd(int bodovi)
{
	list<pair<int, int> >::iterator it;
	map <int, int> pomocna;

	for (it = listaPolja.begin(); it != listaPolja.end(); it++)
	{
		if (it->second > bodovi)
		{
			pomocna.insert(*it);
		}
	}

	return pomocna;
}

int GameOfScores::pobjednik(int poc1, int kraj1, int poc2, int kraj2)
{
	vector<pair<int, int> >::iterator it;

	int bodovi1 = 0, bodovi2 = 0;

	for (it = parni.begin(); it != parni.end(); it++)
	{
		if ((*it).first == poc1)
		{
			break;
		}
	}

	for (it; it != parni.end(); it++)
	{
		bodovi1 += it->second;
		if ((*it).first == kraj1)
		{
			break;
		}
	}

	for (it = neparni.begin(); it != neparni.end(); it++)
	{
		if ((*it).first == poc2)
		{
			break;
		}
	}

	for (it; it != neparni.end(); it++)
	{
		bodovi2 += it->second;
		if ((*it).first == kraj2)
		{
			break;
		}
	}

	if (bodovi1 > bodovi2)
		return 1;
	else if (bodovi1 < bodovi2)
		return 2;
	else
		return 0;
}

pair<int, int> GameOfScores::optimalnaIgra(int igrac)
{
	pair <int, int> rjesenje;

	vector<pair<pair<int, int>, int>> pomoc;
	vector<pair<pair<int, int>, int>>::iterator it3;

	vector<pair<int, int>>::iterator it;
	vector<pair<int, int>>::iterator it2;

	int bodovi = 0;

	if (igrac == 1)
	{
		for (it = parni.begin(); it != parni.end(); it++)
		{
			bodovi = it->second;
			for (it2 = it; it2 != parni.end(); it2++)
			{
				if (it->first == it2->first)
				{
					continue;
				}
				pomoc.push_back(make_pair((make_pair(it->first, it2->first)), bodovi += it2->second));

			}
		}
		for (it3 = pomoc.begin(); it3 != pomoc.end(); it3++)
		{
			if (bodovi <= it3->second)
			{
				rjesenje.first = it3->first.first;
				rjesenje.second = it3->first.second;
				bodovi = it3->second;
			}
		}
	}
	else if (igrac == 2)
	{
		for (it = neparni.begin(); it != neparni.end(); it++)
		{
			bodovi = it->second;
			for (it2 = it; it2 != neparni.end(); it2++)
			{
				if (it->first == it2->first)
				{
					continue;
				}
				pomoc.push_back(make_pair((make_pair(it->first, it2->first)), bodovi += it2->second));

			}
		}
		for (it3 = pomoc.begin(); it3 != pomoc.end(); it3++)
		{
			if (bodovi <= it3->second)
			{
				rjesenje.first = it3->first.first;
				rjesenje.second = it3->first.second;
				bodovi = it3->second;
			}
		}
	}

	return rjesenje;
}
