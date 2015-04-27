#include "proizvodi.h"

Proizvod::Proizvod()
{
	_count = 0;
}
Proizvod::Proizvod(string ime, double masa)
{
	_ime = ime;
	_masa = masa;
	_count = 0;
}

string Proizvod::ime()
{
	return _ime;
}

double Proizvod::netto()
{
	return _masa;
}

void Proizvod::dodajSadrzaj(string ime, double postotak)
{
	for (int i = 0; i < _count; i++)
	{
		if (sastav[i] == ime)
		{
			postotakSastava[i] = postotak;
			return;
		}
	}
	sastav[_count] = ime;
	postotakSastava[_count] = postotak;
	_count++;
}

int Proizvod::velicinaSastava()
{
	return _count;
}

string Proizvod::itiSastav(int i)
{
	return sastav[i];
}

double Proizvod::itiPostotak(int i)
{
	return postotakSastava[i];
}

Trgovina::Trgovina()
{
	_count = 0;
}

void Trgovina::dodajProizvod(Proizvod p, double cijena)
{
	for (int i = 0; i < brojProizvoda(); i++)
	{
		if (poljeProizvoda[i].ime() == p.ime())
		{
			_cijena = cijena;
			return;
		}
	}
	poljeProizvoda[_count] = p;
	_cijena = cijena;
	_count++;
}

int Trgovina::brojProizvoda()
{
	return _count;
}

Proizvod Trgovina::itiProizvod(int i)
{
	return poljeProizvoda[i];
}

double Trgovina::cijenaProizvoda(string ime)
{
	for (int i = 0; i < brojProizvoda(); i++)
	{
		if (poljeProizvoda[i].ime() == ime)
			return _cijena;
	}

	return -1;
}

double Trgovina::cijenaPoKilogramu(string ime)
{
	double masa = 0;
	for (int i = 0; i < brojProizvoda(); i++)
	{
		if (poljeProizvoda[i].ime() == ime)
			return 1 / poljeProizvoda[i].netto() * _cijena;
	}

	return -1;
}

double Trgovina::cijenaSastava(string ime)
{
	//masa * postotak * cijena 
	double cijena = 0;
	for (int i = 0; i < brojProizvoda(); i++)
	{
		if (poljeProizvoda[i].ime() != ime)
			continue;

		Proizvod p = poljeProizvoda[i];

		for (int j = 0; j < p.velicinaSastava(); j++)
		{
			string sastavak = p.itiSastav(j);

			if (cijenaPoKilogramu(sastavak) == -1) return -1;

			cijena += _cijena * p.itiPostotak(j) * p.netto();
		}
		return cijena;
	}

	if (cijena = 0)
		return -1;

	return -1;
}