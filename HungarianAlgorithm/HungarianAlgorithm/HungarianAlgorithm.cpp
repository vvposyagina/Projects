// HungarianAlgorithm.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <vector>
#include <fstream>
#include <Windows.h>
#define INF 1000000000
#define mn 300

using namespace std;

int i, j, n, x, mi, mj, k, d, sum;

vector<int> g[mn], u(mn), v(mn), mInd(mn, -1);

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	cin >> n;	

	int x = 0;

	for (i = 0; i < n; i++)
	{
		for (j = 0; j < n; j++)
		{
			x = rand() % 100 + 2;			
			g[i].push_back(x);
			cout << x << " ";
		}
		cout << endl;
	}

	for (i = 0; i < n; i++)
	{
		vector<int> links(n, -1), mins(n, INF), used(n);

		mi = i,	mj = -1;

		while (mi != -1)
		{
			j = -1;

			for (k = 0; k < n; k++)
			if (!used[k])
			{
				if (g[mi][k] - u[mi] - v[k] < mins[k])
				{
					mins[k] = g[mi][k] - u[mi] - v[k];
					links[k] = mj;
				}

				if (j == -1 || mins[k] < mins[j])
					j = k;
			}

			d = mins[j];

			for (k = 0; k < n; k++)
			if (used[k])
				u[mInd[k]] += d, v[k] -= d;
			else
				mins[k] -= d;

			u[i] += d;
			used[j] = 1;
			mj = j;
			mi = mInd[j];
		}

			for (; links[j] != -1; j = links[j])			
				mInd[j] = mInd[links[j]];
			
			mInd[j] = i;		
	}

	for (j = 0; j < n; j++)
	{
		if (mInd[j] != -1)
		{
			sum += g[mInd[j]][j];
			cout << mInd[j] + 1 << " - " << j + 1 << endl;
		}
	}

	cout << "Минимальная сумма: " << sum << endl;
	return 0;
}

