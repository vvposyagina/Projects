// Trans.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>

using namespace std;


void _tmain(int argc, _TCHAR* argv[])
{
	ifstream ifile("input.txt");
	ofstream ofile("output.txt");

	int a[100][100];
	int n;

	ifile >> n;

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			ifile >> a[i][j];
		}
	}

	/*
	for (int i = 0; i < (n -1); i++)
	{
		for (int j = 0; j < n - 1 - i; j++)
		{
			swap(a[i][j], a[n - 1 - j][n - 1 - i]);
		
	}
	*/
	for (int i = 0; i < (n - 1); i++)
	{
		for (int j = i; j < n - 1 - i; j++)
		{
			swap(a[i][j], a[j][n - 1 - i]);
			swap(a[j][n - 1 - i], a[n - 1 - i][n - j - 1]);
			swap(a[n - i - 1][n - j - 1], a[n - j - 1][i]);

		}
	}
	
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			ofile << a[i][j] << " ";
		}
		ofile << endl;
	}
	



}

