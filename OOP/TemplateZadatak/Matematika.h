#include <iostream>

using namespace std;

class Matematika
{
public:
	template<class T1, class T2>
	auto suma(T1 first, T2 second) -> decltype (first + second)
	{
		return first + second;
	}
};
