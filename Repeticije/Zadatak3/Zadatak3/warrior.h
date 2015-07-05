#pragma once
#include <iostream>
#include <list>

using namespace std;

class Warrior
{
private:
	int zdravlje;
	string ime;
public:
	Warrior(){}
	Warrior(string ime)
	{
		this->ime = ime;
		this->zdravlje = 100;
	}

	string name()
	{
		return ime;
	}
	int health()
	{
		return zdravlje;
	}
	
	Warrior& attack(Warrior& w)
	{
		w.zdravlje = health();
		w.zdravlje -= 10;
		return w;
	}
	Warrior& specialAttack(Warrior& w)
	{
		//sikda 15 poena
		w.zdravlje = health();
		w.zdravlje -= 15;

		return w;
	}
	Warrior& defend()
	{
		//iduci napad nema utjecaj
	}

	static list<Warrior *> getWarriorList()
	{

	}
};

class Paladin : public Warrior
{
private:
	int zdravlje;
public:
	Paladin(string ime) : Warrior(ime)
	{
		this->zdravlje = 100;
	}

	void regenerate() //klasa paladin
	{
		this->zdravlje = 100;
	}

	Warrior& specialAttack(Warrior& w)
	{
		//skida 25 poena
		
		return w;
	}

	Warrior& defend()
	{
		//iduca 2 napada nemaju utjecaj
		Warrior w;
		return w;
	}
};

class Dwarf : public Warrior
{
private:
	int zdravlje;
public:
	Dwarf(string ime) : Warrior(ime)
	{
		this->zdravlje = 100;
	}

	void crazyDwarfSuicide() //klasa dwarf
	{
		this->zdravlje = 0;
	}

	Warrior& specialAttack(Warrior& w)
	{
		//skida 20 poena
		return w;
	}

	Warrior& defend()
	{
		//iduca 3 napada nemaju utjecaj
		Warrior w;
		return w;
	}
};
