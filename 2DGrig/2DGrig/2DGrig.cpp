#include <iostream>
#include <fstream>
#include <iomanip>

using namespace std;


int main()
{

	//ifstream cin("input.txt");
	//ofstream cout("output.txt");
	int n, m;
	int const N = 105;
	int a[N + 2][N + 3], a2[N + 2][N + 3];
	cin >> n >> m;

	for (int i = 0; i <= n + 1; i++)
	{
		a[i][0] = 0;
		a[i][m + 1] = 0;
		a2[i][0] = 0;
		a2[i][m + 1] = 0;
		a2[i][m + 2] = 0;
		//a3[i][0] = 0;
		//a3[i][m + 1] = 0;
	}

	for (int i = 0; i <= m + 2; i++)
	{
		a[0][i] = 0;
		a[n + 1][i] = 0;
		a2[0][i] = 0;
		a2[n + 1][i] = 0;
		a2[n + 2][i] = 0;
		//a3[0][i] = 0;
		//a3[n + 1][i] = 0;
	}

	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		{
			int temp;
			cin >> temp;
			if (temp == 1)
			{
				a[i][j] = 1;
				a2[i][j] = 0;
			}
			else if (temp == 0)
			{
				a[i][j] = 0;
				a2[i][j] = 0;
			}
			else if (temp == -1 || temp == 2)
			{
				a[i][j] = 0;
				a2[i][j] = temp;
			}
			//a3[i][j] = 0;
		}
	}

	int tempJ = 1;
	for (int i = 1; i <= n; i++)
	{
		for (int j = tempJ; j <= m; j++)
		{

			if (j != tempJ && (a2[i][j] == -1 || a2[i][j] == -2))
			{
				for (int k = j + 1; k <= m; k++)
				{
					if (a2[i][k] != -1)
					{
						a2[i][k] = -2;
					}

				}
			}
			else if ((a2[i][j] == -1 || a2[i][j] == -2) && ((a2[i - 1][j] == -1 || a2[i - 1][j] == -2) || (a2[i - 1][j + 1] == -1 || a2[i - 1][j + 1] == -2)))
			{
				for (int k = j + 1; k <= m; k++)
				{
					if (a2[i][k] != -1)
					{
						a2[i][k] = -2;
					}
				}
			}
			if (j == tempJ && (a2[i][j] == -1 || a2[i][j] == -2))
			{
				for (int k = i + 1; k <= n; k++)
				{
					if (a2[k][j] != -1)
					{
						a2[k][j] = -2;
					}
				}
				tempJ++;
			}

		}
	}
	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		{
			/*
			for (int i = 1; i <= n; i++)
			{
			for (int j = 1; j <= m; j++)
			{
			cout << a2[i][j] << " ";
			}
			cout << endl;
			}
			cout << endl;
			*/
			if ((a2[i - 1][j] == 3 || a2[i][j - 1] == 3) && a2[i][j] != -1)
			{
				a2[i][j] = 3;
			}
			if ((a2[i + 1][j] == -2 || a2[i][j + 1] == -2) && a2[i][j] != -1 && a2[i][j] != -2)
			{
				if (a2[i + 1][j] == -2)
				{
					a2[i + 1][j] = 3;
				}
				else if (a2[i][j + 1] == -2)
				{
					a2[i][j + 1] = 3;
				}

			}
			if (a2[i][j] == 2)
			{
				for (int k = i + 2; k <= n; k++)
				{
					if (a2[k][j] == -1)
					{
						break;
					}
					a2[k][j] = 3;


				}
				for (int k = j + 2; k <= m; k++)
				{
					if (a2[i][k] == -1)
					{
						break;
					}
					a2[i][k] = 3;
				}


			}

		}
	}
	/*
	for (int i = 1; i <= n; i++)
	{
	for (int j = 1; j <= m; j++)
	{
	cout << a2[i][j] << " ";
	}
	cout << endl;
	}
	return 0;
	*/
	int max = 0;
	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		{
			if (a2[i][j] == -1 || a2[i][j] == -2)
			{
				continue;
			}
			if ((a2[i][j + 1] != -1 && a2[i][j + 1] != -2) && (a[i][j + 1] < a[i][j + 1] - a[i - 2][j + 1] + a[i][j]) && (a2[i - 1][j + 1] == -1 || a2[i - 1][j + 1] == -2))
			{
				a[i][j + 1] = a[i][j + 1] - a[i - 2][j + 1] + a[i][j];
			}
			else if ((a[i][j + 1] < a[i][j + 1] - a[i - 1][j + 1] + a[i][j]) && (a2[i][j + 1] != -1 && a2[i][j + 1] != -2))
			{
				a[i][j + 1] = a[i][j + 1] - a[i - 1][j + 1] + a[i][j];

			}

			if (a2[i + 1][j] != -1 && a2[i + 1][j] != -2)
			{
				a[i + 1][j] += a[i][j];
			}


			if (a2[i][j] == 2)
			{
				if ((a[i][j + 2] < a[i][j + 2] - a[i - 1][j + 2] + a[i][j]) && (a2[i][j + 2] != -1 && a2[i][j + 2] != -2 && (a2[i][j + 1] == -1 || a2[i][j + 1] == -2)))
				{
					a[i][j + 2] = a[i][j + 2] - a[i - 1][j + 2] + a[i][j];

				}
				if (a2[i + 2][j] != -1 && a2[i + 2][j] != -2 && (a2[i + 1][j] == -1 || a2[i + 1][j] == -2))
				{
					a[i + 2][j] += a[i][j];
				}

			}

			if (a[i][j] > max && a2[i][j] != -1 && a2[i][j] != -2)
			{
				max = a[i][j];
			}
		}
	}
	


	for (int i = 0; i <= n + 2; i++)
	{
	for (int j = 0; j <= m + 2; j++)
	{
	cout << setw(3) << setprecision(3) << a2[i][j] << " ";
	}
	cout << endl;
	}
	cout << endl;
	for (int i = 0; i <= n + 2; i++)
	{
	for (int j = 0; j <= m + 2; j++)
	{
	cout << setw(3) << setprecision(3) << a[i][j] << " ";
	}
	cout << endl;
	}
	cout << endl;
	
	cout << max << endl;;

	return 0;
}

