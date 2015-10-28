#pragma once
#include <malloc.h>

template <class T>
class MyContainer
{
private:
	T* elementi;
	int current;
public:
	MyContainer()
	{
		current = 0;
		elementi = (T*)malloc(sizeof(T) * 100);
	}
	void add(T item)
	{
		elementi[current++] = item;
	}
};

