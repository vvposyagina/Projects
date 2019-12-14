#include <vector>
#include <stdio.h>
#include <queue>
#include <iostream>

using namespace std;

int main()
{
	vector < vector<int> > g; // граф
	const int n = 4; // число вершин
	int s = 0; // стартова€ вершина (вершины везде нумеруютс€ с нул€)
	// чтение графа
	int Adj[n][n] = {
		{ 0, 1, 0, 0 },
		{ 1, 0, 1, 0 },
		{ 0, 1, 0, 1 },
		{ 0, 0, 1, 0 } };
	for (int i = 0; i < n; i++)
	{
		g.push_back(vector<int>());
		for (int j = 0; j < n; j++)
		{
			g[i].push_back(0);
			g[i][j] = Adj[i][j];
		}
	}
	queue<int> q;
	q.push(s);
	vector<bool> used(n);
	vector<int> d(n), p(n);
	used[s] = true;
	p[s] = -1;
	while (!q.empty())
	{
		int v = q.front();
		for (size_t i = 0; i < g[v].size(); ++i)
		{
			if (!used[i] && g[v][i])
			{
				used[i] = true;
				q.push(i);
				d[i] = d[v] + 1; // рассто€ние;
				p[i] = v; // parent;
			}
		}
		q.pop();
	}
	for (int i = 0; i < n; i++)
		cout << d[i] << "  ";
	cout << endl;
	for (int i = 0; i < n; i++)
		cout << p[i] << "  ";

	cout << endl;
	system("pause");
	return 0;
}