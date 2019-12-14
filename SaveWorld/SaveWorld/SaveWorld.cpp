// SaveWorld.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>

using namespace std;


int _tmain()
{
	int n;
	cin >> n;

	if ((n % 4 == 0) || (n % 4 == 3))
		cout << "black" << endl;
	else
		cout << "grimy" << endl;

	cin.get();
}

