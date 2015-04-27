#include <iostream>
#include "proizvodi.h"

using namespace std;

//void ispisiProizvod(Proizvod p)
//{
//	cout << p.ime() << ", " << p.netto() << endl;
//	for (int i = 0; i < p.velicinaSastava(); ++i)
//		cout << " " << p.itiSastav(i) << " (" << p.itiPostotak(i) << "%)" << endl;
//}

int main()
{
	Proizvod ml1("mlijeko1", 0.2); // 0.2kg mlijeka
	Proizvod ml2("mlijeko2", 1); // 1kg mlijeka

	ml1.dodajSadrzaj("mlijeko2", 0.5); // npr. mlijeko1 je napola razrijeðeno mlijeko2

	ml2.dodajSadrzaj("mlijeko1", 0.5);
	ml2.dodajSadrzaj("mast", 0.01); // npr. mlijeko2 je mlijeko1+ jos 1% masti :)
	// ovo je napisano da se vidi da pri ocjeni cijene sastojaka, 
	//nemorate od sastojaka ponovo gledati njegove sastojke, nego samo direktne	sastojke.

	ml2.dodajSadrzaj("mlijeko1", 0.99);

	cout << "Velicina sastava : " << ml1.velicinaSastava() << endl;

	cout << "Velicina sastava : " << ml2.velicinaSastava() << endl;

	Trgovina t1;// = new Trgovina();
	t1.dodajProizvod(ml1, 3); // 0.2kg mlijeka1 kosta 3 kn

	cout << "CIjena proizvoda : " << t1.cijenaProizvoda("mlijeko1") << endl; // 3
	cout << "CIjena po kilogramu : " << t1.cijenaPoKilogramu("mlijeko1") << endl; // 15
	cout << "Cijena sastava : " << t1.cijenaSastava("mlijeko1") << endl; // -1

	t1.dodajProizvod(ml2, 10);
	cout << "Cijena sastava : " << t1.cijenaSastava("mlijeko1") << endl; // 1

	t1.dodajProizvod(ml2, 20);
	cout << "Cijena sastava : " << t1.cijenaSastava("mlijeko1") << endl; // 2
	cout << "Broj proivoda u trgovini : " << t1.brojProizvoda() << endl;

	int a;
	cin >> a;
	return 0;
}