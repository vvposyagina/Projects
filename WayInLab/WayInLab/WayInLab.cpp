// Lab.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int lab[100][100];

struct point
{
	int x, y;
};

string Way(int begx, int begy)
{	
	string way = "";
	int dist = lab[begx][begy], x = begx, y = begy;

	while (dist > 1)
	{
		if (lab[x - 1][y] == dist - 1)
		{
			way += 'N';
			x--;
		}
		else if (lab[x + 1][y] == dist - 1)
		{
			way += 'S';
			x++;
		}
		else if (lab[x][y - 1] == dist - 1)
		{
			way += 'W';
			y--;
		}
		else if (lab[x][y + 1] == dist - 1)
		{
			way += 'E';
			y++;
		}
		dist--;
	}
	return way;
}

bool labyrinth(int begx, int begy, int endx, int endy)
{
	lab[endx][endy] = 1;
	point wave1[100], wave2[100];
	int numW1 = 1, numW2 = 0;
	wave1[0].x = endx;
	wave1[0].y = endy;
	int q = 0;

	bool flag = true;

	while (flag == true && lab[begx][begy] == 0)
	{
		flag = false;
		if (numW2 != 0)
		{
			for (int i = 0; i < numW2; i++)
			{
				wave1[i].x = wave2[i].x;
				wave1[i].y = wave2[i].y;
				wave2[i].x = 0;
				wave2[i].y = 0;
			}
			swap(numW1, numW2);
			numW2 = 0;
			q = 0;
		}

		for (int i = 0; i < numW1; i++)
		{
			if (lab[wave1[i].x + 1][wave1[i].y] == 0)
			{
				lab[wave1[i].x + 1][wave1[i].y] = lab[wave1[i].x][wave1[i].y] + 1;
				wave2[q].x = wave1[i].x + 1;
				wave2[q].y = wave1[i].y;
				numW2++;
				q++;
				flag = true;
			}
			if (lab[wave1[i].x][wave1[i].y + 1] == 0)
			{
				lab[wave1[i].x][wave1[i].y + 1] = lab[wave1[i].x][wave1[i].y] + 1;
				wave2[q].x = wave1[i].x;
				wave2[q].y = wave1[i].y + 1;
				numW2++;
				q++;
				flag = true;
			}
			if (lab[wave1[i].x - 1][wave1[i].y] == 0)
			{
				lab[wave1[i].x - 1][wave1[i].y] = lab[wave1[i].x][wave1[i].y] + 1;
				wave2[q].x = wave1[i].x - 1;
				wave2[q].y = wave1[i].y;
				numW2++;
				q++;
				flag = true;
			}
			if (lab[wave1[i].x][wave1[i].y - 1] == 0)
			{
				lab[wave1[i].x][wave1[i].y - 1] = lab[wave1[i].x][wave1[i].y] + 1;
				wave2[q].x = wave1[i].x;
				wave2[q].y = wave1[i].y - 1;
				numW2++;
				q++;
				flag = true;
			}
		}
	}
	if (lab[begx][begy] == 0)
		return false;
	else
		return true;
}

int main()
{
	ifstream cin("input.txt");

	int n, m, begx, begy, endx, endy;
	cin >> n >> m >> begx >> begy >> endx >> endy;

	for (int i = 0; i <= n + 1; i++)
	{
		lab[i][m + 1] = -1;
		lab[i][0] = -1;
	}

	for (int i = 0; i <= m + 1; i++)
	{
		lab[0][i] = -1;
		lab[n + 1][i] = -1;
	}

	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		{
			int temp;
			cin >> temp;
			if (temp == 1)
			{
				lab[i][j] = -1;
			}
			else
			{
				lab[i][j] = 0;
			}
		}
	}
	
	if (labyrinth(begx, begy, endx, endy) == false)
		cout << "No Way" << endl;
	else
		cout << Way(begx, begy) << endl;    

	return 0;
}

