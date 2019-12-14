// DlinnayaArifm.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include < iostream >
#include < fstream >
#include < string > 
#include < stdio.h >
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	ifstream fi;
	fi.open("input.txt", ios::in);
	ofstream fo;
	fo.open("output.txt", ios::out);

	

	string number1, number2;
	fi >> number1;
	fi >> number2;
	
	short int a[1000];
	short int b[1000];
	short int c[1000];


	a[0] = number1.length();
	b[0] = number2.length();

	for (int i = 1, j = 1; i < a[0], j < b[0]; i++, j++)
	{
		a[i] = number1[i];
		b[j] = number2[j];
	}

	for (int i = (a[0] - 1), j = (b[0] - 1); i >= 0, j >= 0; i--, j--)
	{
		if (a[i] + b[j] >= 10)
			c[i] = (a[i] + b[j]) % 10;
		else
			c[i] = a[i] + b[j];
	}

	for (int i = 1; i < a[0]; i++)
	{
		fo << c[i];
	}

	fi.close();
	fo.close();
	cin.get();
}

