// Fibonacci.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int fibonacci(int n)
{
	if ((n == 1) || (n == 2))
	{
		return 1;
	}

	return fibonacci(n - 1) + fibonacci(n - 2);
}


int _tmain(int argc, _TCHAR* argv[])
{
	int n;
	cin >> n;

	cout << fibonacci(n);
	cin.get();
	system("pause");
	return 0;
}

