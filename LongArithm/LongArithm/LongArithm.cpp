// LongArithm.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include < iostream >
#include < fstream >
#include < string.h > 

using namespace std;

void back(int *n, char *a)
{
	for (int i = 0, j = *n - 1; i < j; i++, j--)
	{
		swap(a[i], a[j]);
	}
}

void CharToInt(int a1[], char a[], int n)
{
	for (int i = 0; i < n; i++)
	{
		a1[i] = (((int)(a[i])) - 48);
	}
}

void Null(int *c[], int n)
{
	for (int i = 0; i < n; i++)
	{
		c[i] = 0;
	}
}

void Addition(int x, int y, int a1[], int b1[], int *c[])
{
	if (x < y)
	{
		for (int i = 0; i < x; i++)
		{
			if ((a1[i] + b1[i]) >= 10)
			{
				*c[i] += (a1[i] + b1[i]) % 10;
				*c[i + 1] = 1;
			}
			else
			{
				*c[i] += a1[i] + b1[i];
			}
		}

		for (int i = x; i < y; i++)
		{
			if ((b1[i] + *c[i]) >= 10)
			{
				*c[i] += b1[i] % 10;
				*c[i + 1] = 1;
			}
			else
			{
				*c[i] += b1[i];
			}
		}
	}
	else
	{
		for (int i = 0; i < y; i++)
		{
			if ((a1[i] + b1[i]) >= 10)
			{
				*c[i] += (a1[i] + b1[i]) % 10;
				*c[i + 1] = 1;
			}
			else
			{
				*c[i] += a1[i] + b1[i];
			}
		}

		for (int i = y; i < x; i++)
		{
			if ((a1[i] + *c[i]) >= 10)
			{
				*c[i] += a1[i] % 10;
				*c[i + 1] = 1;
			}
			else
			{
				*c[i] += a1[i];
			}
		}
	}
}


int _tmain(int argc, _TCHAR* argv[])
{
	ifstream ifile("input.txt");
	ofstream ofile("output.txt");

	int alen, blen, max;
	char a;
	char b;
	int a1[100];
	int b1[100];
	int c[101];

	ifile >> a >> b;

	alen = strlen(&a);
	blen = strlen(&b);

	back(&alen, &a);
	back(&blen, &b);

	if (alen < blen)
		max = blen + 1;
	else
		max = alen + 1;



	CharToInt(a1, &a, alen);
	CharToInt(b1, &b, blen);

	Addition(alen, blen, a1, b1, c);

	if (max - 1 == 0)
	{
		for (int i = 0; i < max - 1; i++)
		{
			ofile << c[i];
		}
	}
	else
	{
		for (int i = 0; i < max; i++)
		{
			ofile << c[i];
		}
	}		
}

