
#include <iostream>

using namespace std;
int compare(const void * a, const void * b)
{
	return (*(unsigned int*)a - *(unsigned int*)b);
}
int main()
{
	int const N = 1000;
	unsigned int n, a[N][N], k = 0, s = 0, dor[N], dorI = 0, a2[N][N], dorK;

	cin >> n;
	dorK = (n * (n - 1)) / 2;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cin >> a[i][j];
			if (j > i)
			{
				dor[dorI] = a[i][j];
				dorI++;
			}
		}
	}

	for (int i = 0; i < n; i++)
	{
		for (int j = i; j < n; j++)
		{
			if ((i == j) && (a[i][j] == 0))
			{
				k++;
			}
			if ((a[i][j] == a[j][i]) && (a[i][j] != 0))
			{
				s++;
			}
		}
	}

	qsort(dor, dorK, sizeof(unsigned int), compare);
	/*
	for (int i = 0; i < dorK; i++)
	{
		cout << dor[i] << " ";
	}

	cout << endl;
	*/
	int nI = n - 1, nJ = 1;
	dorI = 0;


	for (; ; nI--, nJ++)
	{
		int i = 0, j = nJ;
		while ((i < nI) && (j < n))
		{
			a2[i][j] = dor[dorI];
			i++;
			j++;
			dorI++;
		}
		if (dorI == dorK)
		{
			break;
		}
	}
	/*
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout << a2[i][j] << " ";

		}
		cout << endl;
	}
	*/
	int x = 0, p = 0;

	for (int i = 0; i < n; i++)
	{
		for (int j = i + 2; j < n; j++)
		{
			for (int q = i; q < j; q++)
			{
				x += a2[q][q + 1];
			}
			
			if (a2[i][j] == x)
			{
				p++;
				x = 0;
			}
		}
	}

	if ((k == n) && (s == n*(n - 1) / 2) && (p == (n*n - 3*n +2)/ 2))
		cout << "JA" << endl;
	else
		cout << "NEIN" << endl;

	return 0;
}

