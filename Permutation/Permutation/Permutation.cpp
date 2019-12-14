// Permutation.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>

using namespace std;

int Fact(int n)
{
	if (n == 0)
		return 1;
	else
		return n*Fact(n - 1);
}


int _tmain(int argc, _TCHAR* argv[])
{
	ifstream ifile("input.txt");
	ofstream ofile("output.txt");

	int n, count;
	int a[100];

	cin >> n;

	for (int i = 0; i < n; i++)
	{
		cin >> a[i];
	}

	count = Fact(n - 2);

	for (int i = 0; i < ; i++)
	{
		for (int j = n - 1; j > 0; j--)
		{
			swap(a[j], a[j - 1]);
			for (int k = 0; k < n; k++)
			{
				cout << a[k] << " ";
			}
			cout << endl;
		}
	}

	return 0;
}

