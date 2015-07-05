#include <iostream>
#include <list>

using namespace std;

class Auto
{
private:
	int prijedeniPut;
	int vr;
	string imeVozaca;
public:
	Auto(){}
	Auto(string ime)
	{
		imeVozaca = ime;
		prijedeniPut = 0;
		vr = 0;
	}

	string ime()
	{
		return imeVozaca;
	}
	int polozaj()
	{
		return prijedeniPut;
	}
	int vrijeme()
	{
		return vr;
	}

	Auto& odvozi()
	{
		Auto a;
		//a.imeVozaca = this->imeVozaca;
		//a.prijedeniPut = polozaj();
		//a.vr = vrijeme();
		a.prijedeniPut += 10;
		a.vr += 4;
		return a;
	}
	Auto& nitro()
	{
		Auto a;
		a.prijedeniPut = polozaj();
		a.vr = vrijeme();
		a.prijedeniPut += 10;
		a.vr += 3;
		return a;
	}
	bool sudar(Auto& a)
	{
		if (this->prijedeniPut == a.polozaj())
		{
			return true;
		}
		else
			return false;
	}

	static list<Auto *> sviAutomobili()
	{
		list<Auto *> pom;
		
		return pom;
	}
};

class Ferrari : public Auto
{
private:
	int prijedeniPut;
	int vr;
public:
	Ferrari() : Auto(){}
	Ferrari(string ime) : Auto(ime)
	{
		prijedeniPut = 0;
		vr = 0;
	}

	Auto& odvoziPuno()
	{
		//mice se 30 km u vremenu od 15 minuta
		Ferrari a;
		a.prijedeniPut = polozaj();
		a.vr = vrijeme();
		a.prijedeniPut += 30;
		a.vr += 15;
		return a;
	}

	Auto& nitro()
	{
		//pride 10 km u 2 min
		Ferrari a;
		a.prijedeniPut = polozaj();
		a.vr = vrijeme();
		a.prijedeniPut += 10;
		a.vr += 2;
		return a;
	}
};

class Lamborghini : public Auto
{
private:
	int prijedeniPut;
	int vr;
public:
	Lamborghini() : Auto(){}
	Lamborghini(string ime) : Auto(ime)
	{
		prijedeniPut = 0;
		vr = 0;
	}
	
	Auto& odvoziMalo()
	{
		//mice ce 5 km u vremenu od 2 minute
		Lamborghini a;
		a.prijedeniPut = polozaj();
		a.vr = vrijeme();
		a.prijedeniPut += 5;
		a.vr += 2;
		return a;
	}

	Auto& nitro()
	{
		//pride 10 km u 1 min
		Lamborghini a;
		a.prijedeniPut = polozaj();
		a.vr = vrijeme();
		a.prijedeniPut += 10;
		a.vr += 1;
		return a;
	}
};