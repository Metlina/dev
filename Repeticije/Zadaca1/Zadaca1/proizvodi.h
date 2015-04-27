#pragma once
#include <iostream>
#include <vector>

using namespace std;

struct Proizvod
{
private:
	string _ime;
	double _masa;
	string sastav[10];
	double postotakSastava[10];
	int _count;
public:
	Proizvod();
	Proizvod(string ime, double masa);

	string ime();

	double netto();

	void dodajSadrzaj(string ime, double postotak);

	int velicinaSastava();

	string itiSastav(int i);

	double itiPostotak(int i);
};

struct Trgovina
{
private:
	Proizvod poljeProizvoda[1000];
	double _cijena;
	int _count;
public:
	Trgovina();

	void dodajProizvod(Proizvod p, double cijena);

	int brojProizvoda();

	Proizvod itiProizvod(int i);

	double cijenaProizvoda(string ime);

	double cijenaPoKilogramu(string ime);

	double cijenaSastava(string ime);
};