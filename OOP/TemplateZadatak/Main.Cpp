#include  <iostream>
#include "Matematika.h"
#include "Kompleksni.h"

using namespace std;

ostream& operator<<(ostream& lhs, const Kompleksni& rhs)
{
	lhs << rhs._re << " " << rhs._im << "i";
	return lhs;
}

int main() {
	Matematika Racun;
	cout << Racun.suma(2, 4.3) << endl; // 6.3
	cout << Racun.suma(2.3, 4) << endl; // 6.3
	cout << Racun.suma(Kompleksni(2.5, 1), 4) << endl; // 6.5 1i

	system("PAUSE");
	return 0;
}