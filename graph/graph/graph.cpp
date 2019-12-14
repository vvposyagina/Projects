// граф.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <queue>

using namespace std;

const int N = 100;
int i, j;

int g[N][N];

void an()
{
	cout << " 1 " << " 2 " << " 4" << " 3 " << endl;		
}

void Gen()
{

	for (i = 0; i < N; i++)
	{
		for (j = 0; j < N; j++)
		{
			if (i == j)
				g[i][j] = 0;
			else
				g[i][j] = rand() % 2;
		}
	}

}

int Func(int s, int l, int ord[N])
{
	int len = 1;

	queue<int> q;
	q.push(s);
	vector <bool> vis(N);
	vector <int> d(N), p(N);
	vis[s] = true;
	p[s] = -1;
	
	while (!q.empty())
	{
		int v = q.front();
		q.pop();
		for (int i = 0; i<N; ++i)
		{
			int to = g[v][i];
			if (!vis[to])
			{
				vis[to] = true;
				q.push(to);
				d[to] = d[v] + 1;
				p[to] = v;
			}
		}
	}

	if
		(!vis[l]) return N * 2;
	else
	{
		vector<int> path;
		for (int v = l; v != -1; v = p[v])
			path.push_back(v);
		reverse(path.begin(), path.end());


		for (size_t i = 0; i<path.size(); ++i)
			ord[i] = path[i] + 1;

		len = path.size();

	}

	return len;

};

int main()
{
	setlocale(LC_ALL, "RUS");
	ofstream fin("OUTPUT.txt");
	ifstream fout("INPUT.txt");

	int s;
	cout << "Стартовая вершина: ";
	cin >> s;
	bool *vis = new bool[N];


	//Gen();
	int n;	
	fout >> n;

	for (int q = 0; q < n; q++)
	{
		for (int z = 0; z < n; z++)
		{
			fout >> g[q][z];
		}
	}

	
	fin << "Матрица смежности: " << endl;
	for (i = 0; i < N; i++)
	{
		vis[i] = false;
		for (j = 0; j < N; j++)
			fin << " " << g[i][j];
		fin << endl;
	}

	int minlen = N * 3, a[N], minpath[N];
	
	for (i = 0; i<N; i++)
	{
		if (g[s - 1][i] != 0)

		if (minlen > Func(s - 1, i, a))
		{
			if (Func(s - 1, i, a) != 1)
			{
				minlen = Func(s - 1, i, a);
				for (int y = 0; y < minlen; y++)
					minpath[y] = a[y];
			}
			else
			{
				minlen = 2;
				minpath[0] = s;
				minpath[1] = i + 1;
			}
		}
	}

	if (minlen<N)
	{
		cout << "Порядок обхода кратчайчего цикла: ";
		an();
		for (int y = 0; y < minlen; y++)
			cout << minpath[y] << " ";
		cout << s << endl;
	}

	else cout << "Цикла нет" << endl;
	delete[]vis;


	return 0;
}

