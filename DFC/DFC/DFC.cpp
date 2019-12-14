#include <iostream>
#include <vector>
#include <fstream>
#include <stack>
#include <set>
#define mp make_pair
#define mn 100001

using namespace std;

int i, j, k, n, m, u, v, c;
vector<int> g[mn], vis(mn);
set<pair<int, int>> d;
stack<int> s;

void dfs(int u, int c, int t = 0)
{
	int i, v;
	vis[u] = c;

	for (i = 0; i < g[u].size(); i++)
	{
		v = g[u][i];

		if (t)
		{
			if (vis[v] && vis[v] != c)
				cout << u << " " << v << endl;
			if (!vis[v] && !d.count(mp(u, v)))
				dfs(v, c, 1);
		}
		else
		if (!vis[v])
			d.insert(mp(u, v)), dfs(v, c);
	}
	if (!t) s.push(u);
}

int main()
{
	ifstream read("input.txt");
	ofstream write("output.txt");

	read >> n >> m;

	while (read >> u >> v)
	{
		g[u].push_back(v);
		g[v].push_back(u);
	}

	for (i = 1; i <= n; i++)
	{
		if (!vis[i])
			dfs(i, 1);
	}

	vis.assign(n + 1, 0);

	while (!s.empty())
	{
		u = s.top();
		s.pop();
		if (!vis[u])
			dfs(u, ++c, 1);
	}
	return 0;
}