
// Turning.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>

using namespace std;


int _tmain(int argc, _TCHAR* argv[])
{
	int n, m, k;

	ifstream input_file("input.txt");
	ofstream file_object("output.txt"); 	

	int a[100][100];
	
   input_file >> n;
   input_file >> m;  

	for(int i = 0; i < m; i++)
	{
		for(int j = 0; j < n; j++)
		{			
			input_file >> a[i][j];
		}	
	}

	file_object << endl;


	for(int i = 0; i < n; i++)
	{
		for(int j = i; j < m - 1 - i; j++)
		{
			swap(a[i][j], a[j][n - 1 - i]);
			swap(a[j][n - 1 - i], a[n - 1 - i][n - 1 - j]);
			swap(a[n - 1 - i][n - 1 - j], a[n - 1 - j][i]);

		}

	}

	/*
	for(int i = 0; i < m; i++)
	{
		for(int j = i; j < n; j++)
		{	
			swap(a[i][j], a[j][m - i - 1]);
		}
		file_object << endl;
	}

	for(int i = 1; i < m; i++)
	{
		for(int j = i-1; j >= 0; j--)
		{	
			swap(a[i][j], a[i][m - j - 1]);
		}
		file_object << endl;
	}
	*/
	for(int i = 0; i < m; i++)
	{	
		for(int j = 0; j < n; j++)	
		{
			file_object << a[i][j]<< " ";	
		}	
		
		file_object << endl;
	}
}


