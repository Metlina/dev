#include "halloween.h"

void Halloween::dodaj(string ime, int novac)
{
	if (novac > 0)
	{
		kuce.push_back(make_pair(ime, novac));
		dobri.push_back(make_pair(ime, novac));
	}
	else if (novac < 0)
	{
		kuce.push_back(make_pair(ime, novac));
		losi.push_back(make_pair(ime, novac));
	}
}

void Halloween::izbrisi(string ime)
{
	list<pair<string, int>>::iterator it;
	pair<string, int> pomocni;
	for (it = kuce.begin(); it != kuce.end();)
	{
		if ((*it).first.compare(ime) == 0)
		{
			it = kuce.erase(it);
		}
		else
			it++;
	}
}

string Halloween::izbjegavatIme(void)
{
	list<pair<string, int>>::iterator it;
	int najvise = 0;
	string najgori = "";
	for (it = kuce.begin(); it != kuce.end(); it++)
	{
		if ((*it).second < najvise)
		{
			najgori = (*it).first;
			najvise = (*it).second;
		}
	}
	return najgori;
}

int Halloween::ukupnoKuna(string pocetak, string kraj, int pocetniIznos)
{
	list<pair<string, int>>::iterator it;
	int kuna = pocetniIznos;

	for (it = kuce.begin(); it != kuce.end(); it++)
	{
		if ((*it).first == pocetak)
			break;
	}

	for (it; it != kuce.end(); it++)
	{
		kuna += it->second;
		if ((*it).first == kraj)
		{
			break;
		}
	}

	return kuna;
}

map<string, int> Halloween::dobriJudi(void)
{
	list<pair<string, int>>::iterator it;
	map<string, int> test;

	for (it = kuce.begin(); it != kuce.end(); it++)
	{
		if (it->second > 0)
		{
			test.insert(*it);
		}
	}
	return test;
}

set<string> Halloween::pronadjiImena(string substr, int novac)
{
	list<pair<string, int>>::iterator it;
	set<string> pomocni;

	for (it = kuce.begin(); it != kuce.end(); it++)
	{
		if (it->second > 0 && it->second > novac && it->first.find(substr) != string::npos)
		{
			//pomocni.insert((*it).first);
			pomocni.insert(it->first);
		}
	}

	return pomocni;
}

pair <string, string> Halloween::pametniObilazak(int pocetniIznos)
{
	list<pair<string, int>>::iterator it;
	list<pair<string, int>>::iterator it2;
	pair<string, string> rjesenje;

	list<pair<pair<string, string>, int>> pomoc;
	list<pair<pair<string, string>, int>>::iterator it3;

	int najveci = pocetniIznos;

	for (it = kuce.begin(); it != kuce.end(); it++)
	{
		najveci = pocetniIznos + it->second;
		for (it2 = it; it2 != kuce.end(); it2++)
		{
			if (it->first == it2->first)
			{
				continue;
			}
			pomoc.push_back(make_pair((make_pair(it->first, it2->first)), najveci += it2->second));
		}
	}

	for (it3 = pomoc.begin(); it3 != pomoc.end(); it3++)
	{
		if (najveci < it3->second)
		{
			rjesenje.first = it3->first.first;
			rjesenje.second = it3->first.second;
			najveci = it3->second;
		}
	}

	return rjesenje;
}