// unit.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int n, m, p, q;
	int a[10000];
	int b[10000];
	int c[10000];
	cin >> n >> m;

	for (int i = 0; i < n; i++)
	{
		cin >> a[i];
	}
	for (int i = 0; i < m; i++)
	{
		cin >> b[i];
	}

	p = b[0];
	q = a[0];

	for (int i = 0, j = 0, k = 0; i < n, j < m, k < (m+n);)
	{
		if (q <= p)
		{
			c[k] = a[i];
			p = b[j];
			q = a[i + 1];
			cout << c[k] << " ";
			i++;
			k++;			
		}
		else
		{
			c[k] = b[j];
			p = a[i];
			q = b[j + 1];
			cout << c[k] << " ";
			j++;
			k++;
		}
	}
	
	cin.get();
}

	