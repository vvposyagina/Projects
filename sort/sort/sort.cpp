// sort.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int n;
	int a[10000];

	cin >> n;

	for (int i = 0; i < n; i++)
	{
		cin >> a[i];
	}

	


	for (int i = 0; i < n; i++)
	{
		cout << a[i];
	}

	cin.get();
	return 0;
}

/*for (int i = 0, j = n - 1; i < j; i++, j--)
{
if (a[i] > a[j])
swap(a[i], a[j]);
if (a[i] == a[j])
{
if (a[i] == 0)
{
swap(a[j], a[i + 1]);
j += 1;
}
else
{
swap(a[i], a[j - 1]);
i -= 1;
}
}
}*/