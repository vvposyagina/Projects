#include <iostream>
#include <cstdio>
#include <ctime>
#include <cmath>
#include <cstdlib>
#include <algorithm>
#include <utility>
#define _CRT_SECURE_NO_WARNINGS
using namespace std;
const int N = 1000;
int a[N][N];
int main()
{
	int n, count = 0, z = 0;
	cin >> n;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cin >> a[i][j];
		}
	}

	for (int matrix = 2; matrix <= n; matrix++)
	{
		for (int x = 0; x <= n - matrix; x++)
		{
			for (int y = 0; y <= n - matrix; y++)
			{
				z = matrix % 2;
				for (int i = 0; i < matrix / 2 + z; i++)
					count += ((a[x][y + i]) * (a[x + i][y + matrix - 1]) * (a[x + matrix - 1][y + matrix - 1 - i]) * (a[x + matrix - 1 - i][y]));

			}
		}
	}
	cout << count << endl;
	return 0;
}

