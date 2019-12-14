#include <iostream>
#include <fstream>
#include <vector>
#include <string>

using namespace std;
int const N = 100;
int points[N + 2][N + 2];
string ans = "";

void fillLab(int i, int j, int n)
{
	if (points[i][j] == -1)
	{
		return;
	}

	points[i][j] = n;
	if (points[i + 1][j] == 0)
		fillLab(i + 1, j, n + 1);

	if (points[i][j + 1] == 0)
		fillLab(i, j + 1, n + 1);

	if (points[i - 1][j] == 0)
		fillLab(i - 1, j, n + 1);

	if (points[i][j - 1] == 0)
		fillLab(i, j - 1, n + 1);

}

void exitLab(int i, int j, int n)
{

	if (points[i + 1][j] == n - 1)
	{
		ans += "S";
		exitLab(i + 1, j, n - 1);
		return;
	}
	else if (points[i][j + 1] == n - 1)
	{
		ans += "E";
		exitLab(i, j + 1, n - 1);
		return;
	}
	else if (points[i - 1][j] == n - 1)
	{
		ans += "N";
		exitLab(i - 1, j, n - 1);
		return;
	}
	else if (points[i][j - 1] == n - 1)
	{
		ans += "W";
		exitLab(i, j - 1, n - 1);
		return;
	}
}

int main()
{

	ifstream cin("input.txt");

	int n, m, begx, begy, endx, endy;
	cin >> n >> m >> begx >> begy >> endx >> endy;
	for (int i = 0; i <= n + 1; i++)
	{
		points[i][m + 1] = -1;
		points[i][0] = -1;
	}

	for (int i = 0; i <= m + 1; i++)
	{
		points[0][i] = -1;
		points[n + 1][i] = -1;
	}

	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		{
			int temp;
			cin >> temp;
			if (temp == 1)
			{
				points[i][j] = -1;
			}
			else
			{
				points[i][j] = 0;
			}
		}
	}
	
	fillLab(endx, endy, 1);
	
	if (points[begx][begy] == 0)
	{
		cout << -1 << endl;
	}
	else
	{
		exitLab(begx, begy, points[begx][begy]);
		cout << ans << endl;
	}	
	return 0;
	
}



