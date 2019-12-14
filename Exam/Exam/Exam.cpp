// Graph 20.05.15.cpp: определяет точку входа для консольного приложения.
//
#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <list>
#include <string>
#include <queue>
#include <vector>
#include <iterator>
using namespace std;

typedef pair<int, int> Pair;
const int MAX = 100000000;

struct Edge
{
	int initial;
	int finale;
	int weight;
};

struct NewEdge
{
	bool used;
	int initial;
	int finale;
	NewEdge()
	{
		used = false;
	}
};

class Graph
{
	vector<Edge> edges;
	int **A;
	bool MatrixTopicality;
	bool Matrix;
	bool Edges;
	int N, M;
public:
	Graph()
	{
		Edges = false;
		Matrix = false;
		M = 0;
		N = 0;
	}
	void ReadingOfMatrix(string filename)
	{
		ifstream file(filename);
		if (file.fail())
		{
			cout << "Error" << endl;
		}
		file >> N;
		A = new int*[N];
		for (int i = 0; i < N; i++)
			A[i] = new int[N];
		for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
		{
			file >> A[i][j];
			if (A[i][j] == 0)
				A[i][j] = MAX;
		}
		MatrixTopicality = true;
		file.close();
		Matrix = true;
		NecessaryConversions();
	}

	void PrintMatrix()
	{
		if (MatrixTopicality == false)
		{
			NecessaryConversions();
		}
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (A[i][j] == MAX)
				{
					cout << 0 << " ";
					continue;
				}
				cout << A[i][j] << " ";
			}
			cout << endl;
		}
		cout << endl;
	}

	void ReadingOfPairs(string filename)
	{
		ifstream file(filename);
		if (file.fail())
		{
			cout << "Error" << endl;
		}
		file >> M;
		for (int i = 0; i < M; i++)
		{
			Edge edge;
			file >> edge.initial;
			file >> edge.finale;
			file >> edge.weight;
			edges.push_back(edge);
		}
		file.close();
		Edges = true;
		NecessaryConversions();
	}

	void FromPairsToMatrix()
	{
		int max = 0;
		for (int i = 0; i < edges.size(); i++)
		{
			if (edges[i].initial>max)
			{
				max = edges[i].initial;
			}
			if (edges[i].finale > max)
			{
				max = edges[i].finale;
			}
		}
		N = max + 1;
		A = new int*[N];
		for (int i = 0; i < N; i++)
		{
			A[i] = new int[N];
		}

		for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
		{
			A[i][j] = MAX;
			for (int q = 0; q < edges.size(); q++)
			{
				if (i == edges[q].initial && j == edges[q].finale)
				{
					A[i][j] = edges[q].weight;
					break;
				}
			}
		}
		Matrix = true;
		MatrixTopicality = true;
	}

	void FromMatrixToPairs()
	{
		M = 0;
		for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
		{
			if (A[i][j] != MAX)
			{
				Edge edge;
				edge.initial = i;
				edge.finale = j;
				edge.weight = A[i][j];
				edges.push_back(edge);
				M++;
			}
		}
		Edges = true;
	}

	void PrintEdges()
	{
		for (int i = 0; i < edges.size(); i++)
		{
			cout << edges[i].initial << " " << edges[i].finale << " " << edges[i].weight << endl;
		}
		cout << endl;
	}

	void NecessaryConversions()
	{
		if (Edges == false)
		{
			FromMatrixToPairs();
		}
		if (Matrix == false)
		{
			FromPairsToMatrix();
		}
		if (MatrixTopicality == false && Matrix != false)
		{
			delete(A);
			FromPairsToMatrix();
		}
	}

	bool ChangeOfEdges(int u, int v, int weight)
	{
		int temp;
		bool edited = false;
		for (int i = 0; i < edges.size(); i++)
		{
			if (u == edges[i].initial && v == edges[i].finale)
			{
				edges[i].weight = weight;
				edited = true;
			}
			if (v == edges[i].initial && u == edges[i].finale)
			{
				edges[i].weight = weight;
				edited = true;
			}
		}
		if (edited == false)
		{
			return false;
		}
		MatrixTopicality = false;
		return true;
	}

	bool AddEdge(int u, int v, int weight)
	{
		Edge edge, redge;
		for (int q = 0; q < edges.size(); q++)
		{
			if (u == edges[q].initial && v == edges[q].finale)
			{
				return false;
			}
			if (v == edges[q].initial && u == edges[q].finale)
			{
				return false;
			}

		}
		if (weight < 0)
		{
			return false;
		}
		edge.initial = u;
		edge.finale = v;
		edge.weight = weight;
		redge.initial = v;
		redge.finale = u;
		redge.weight = weight;
		edges.push_back(edge);
		edges.push_back(redge);
		MatrixTopicality = false;
		return true;
	}

	bool DeleteEdge(int u, int v)
	{
		bool edited = false;
		for (int i = 0; i < edges.size(); i++)
		{
			if (u == edges[i].initial && v == edges[i].finale)
			{
				edges.erase(edges.begin() + i);
				MatrixTopicality = false;
				edited = true;
			}
			if (v == edges[i].initial && u == edges[i].finale)
			{
				edges.erase(edges.begin() + i);
				MatrixTopicality = false;
				edited = true;
			}
		}
		if (edited == false)return false;
		return true;
	}

	bool DeleteVertex(int u)
	{
		if (u > N || u < 0)return false;
		for (int i = edges.size() - 1; i >= 0; i--)
		{
			for (int j = 0; j < edges.size(); j++)
			{
				if (u == edges[j].finale || edges[j].initial == u)
				{
					edges.erase(edges.begin() + j);
				}

			}
		}
		N = N - 1;
		MatrixTopicality = false;
		for (int i = 0; i < edges.size(); i++)
		{
			if (edges[i].initial>u)
				edges[i].initial--;
			if (edges[i].finale > u)
				edges[i].finale--;
		}
		delete(A);
		FromPairsToMatrix();
		return true;
	}

	bool AddVertex()
	{
		delete(A);
		MatrixTopicality = false;
		int max = 0;
		for (int i = 0; i < edges.size(); i++)
		{
			if (edges[i].initial>max)
			{
				max = edges[i].initial;
			}
			if (edges[i].finale > max)
			{
				max = edges[i].finale;
			}
		}
		N = max + 2;
		A = new int*[N];
		for (int i = 0; i < N; i++)
		{
			A[i] = new int[N];
		}

		for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
		{
			A[i][j] = MAX;
			for (int q = 0; q < edges.size(); q++)
			{
				if (i == edges[q].initial && j == edges[q].finale)
				{
					A[i][j] = edges[q].weight;
					break;
				}
			}
		}
		Matrix = true;
		MatrixTopicality = true;
		return true;

	}


	bool GraphCohesion()
	{
		NecessaryConversions();
		bool *visited = new bool[N];
		for (int i = 0; i < N; i++)
		{
			visited[i] = false;
		}
		vector<int> C;
		vector<int> B;
		C.push_back(0);
		visited[0] = true;
		bool flag = true;
		while (flag == true)
		{
			for (int i = 0; i < C.size(); i++)
			for (int j = 0; j < N; j++)
			if (visited[j] != true && A[C[i]][j] != MAX)
			{
				B.push_back(j);
				visited[j] = true;
			}
			if (B.size() == 0)
				break;
			C.clear();
			swap(C, B);
			B.clear();
		}
		for (int i = 0; i < N; i++)
		{
			if (visited[i] == false)
				return false;
		}
		return true;
	}

	void DfsFindComps(int v, bool *&visited)
	{
		vector<int> C;
		vector<int> B;
		vector<int> comps;
		visited[v] = true;
		comps.push_back(v);
		C.push_back(v);
		bool flag = true;
		while (flag == true)
		{
			for (int i = 0; i < C.size(); i++)
			for (int j = 0; j < N; j++)
			if (visited[j] != true && A[C[i]][j] != MAX)
			{
				comps.push_back(j);
				B.push_back(j);
				visited[j] = true;
			}
			if (B.size() == 0)
				break;
			C.clear();
			swap(C, B);
			B.clear();
		}
		for (int i = 0; i < comps.size(); i++)
			cout << comps[i] << " ";
		cout << "\n\n";
	}

	void FindComps()
	{
		NecessaryConversions();
		bool *visited = new bool[N];
		for (int i = 0; i < N; i++)
		{
			visited[i] = false;
		}
		for (int i = 0; i < N; i++)
		if (visited[i] != true)
			DfsFindComps(i, visited);
	}

	vector<Edge> CruskalAlgorithm()
	{
		NecessaryConversions();
		int *a = new int[N];
		vector<Edge> CruskalEdges;
		for (int i = 0; i < N; i++)
			a[i] = i;
		for (int i = 0; i < edges.size(); i++)
		for (int j = 0; j < edges.size(); j++)
		if (edges[i].weight<edges[j].weight)
			swap(edges[i], edges[j]);

		for (int i = 0; i < edges.size(); i++)
		{
			if (a[edges[i].initial] != a[edges[i].finale])
			{
				a[edges[i].finale] = a[edges[i].initial];
				CruskalEdges.push_back(edges[i]);
			}
		}
		return CruskalEdges;

	}


	vector<Edge> NewPrimeAlgorithm()
	{
		bool *used = new bool[N];
		for (int i = 0; i < N; i++)
		{
			used[i] = false;
		}
		vector<Edge> PrimeEdges;
		vector<int> Vertexes;
		Vertexes.push_back(0);
		used[0] = true;
		int min = MAX;
		int index[2];
		bool flag;
		for (int i = 0;; i++)
		{
			flag = false;
			min = MAX;
			for (int j = 0; j < Vertexes.size(); j++)
			{
				for (int q = 0; q < N; q++)
				{
					if (A[Vertexes[j]][q] < min && used[q] != true)
					{
						min = A[Vertexes[j]][q];
						index[0] = j;
						index[1] = q;
						flag = true;
					}
				}
			}
			if (flag == false)break;
			used[index[1]] = true;
			Edge edge;
			edge.initial = Vertexes[index[0]];
			edge.finale = index[1];
			//edge.weight = A[Vertexes[index[0]]][index[1]];
			edge.weight = min;
			PrimeEdges.push_back(edge);
			Vertexes.push_back(index[1]);
		}
		return PrimeEdges;
		for (int i = 0; i < PrimeEdges.size(); i++)
		{
			cout << PrimeEdges[i].initial << " " << PrimeEdges[i].finale << " " << PrimeEdges[i].weight;
			cout << endl;
		}
		cout << endl;
	}

	void DFS(int node_index, bool *&used, int necessary_node, int *&parents, bool &flag)
	{
		if (flag == true)return;
		NecessaryConversions();
		used[node_index] = true;
		for (int f = 0; f < N; f++)
		{
			if (flag == true)return;
			if (f == necessary_node && A[node_index][f] != MAX)
			{
				parents[f] = node_index;
				flag = true;
				return;
			}
			if (!used[f] && A[node_index][f] != MAX)
			{
				parents[f] = node_index;
				DFS(f, used, necessary_node, parents, flag);
			}
		}
	}

	vector<Edge> ReturnEdges()
	{
		return edges;
	}

	bool dfs(int node_index, int &necessary_node, int *&parents, int *&coloured, vector<NewEdge> &newedges)
	{
		NecessaryConversions();
		coloured[node_index] = 1;
		for (int i = 0; i < N; i++)
		{
			if (coloured[i] == 0 && A[node_index][i] != MAX)
			{
				parents[i] = node_index;
				for (int j = 0; j < newedges.size(); j++)
				{
					if (newedges[j].initial == node_index && newedges[j].finale == i)
						newedges[j].used = true;
					if (newedges[j].initial == i && newedges[j].finale == node_index)
						newedges[j].used = true;
				}
				if (dfs(i, necessary_node, parents, coloured, newedges))
					return true;
			}
			else if (coloured[i] == 1 && A[node_index][i] != MAX && !VisitedEdge(node_index, i, newedges))
			{
				parents[i] = node_index;
				necessary_node = i;
				return true;
			}
		}
		coloured[node_index] = 2;
		return false;
	}


	int CheckOfCycle(int v, int to, int *&parents)
	{
		vector<int> cycle;
		for (int i = v; i != to; i = parents[i])
		{
			cycle.push_back(i);
		}
		reverse(cycle.begin(), cycle.end());
		return cycle.size();
	}

	bool NewDfs(int node_index, int &necessary_node, int *&parents, int *&coloured)
	{
		NecessaryConversions();
		coloured[node_index] = 1;
		for (int i = 0; i < N; i++)
		{
			if (coloured[i] == 0 && A[node_index][i] != MAX)
			{
				parents[i] = node_index;
				if (NewDfs(i, necessary_node, parents, coloured))
					return true;
			}
			else if (coloured[i] == 1 && A[node_index][i] != MAX)
			{
				if (CheckOfCycle(node_index, i, parents)>1)
				{
					parents[i] = node_index;
					necessary_node = i;
					return true;
				}
			}
		}
		coloured[node_index] = 2;
		return false;
	}

	int MinPath(int u, int w)
	{
		NecessaryConversions();
		if (u == w)
		{
			return 0;
		}
		int *parent;
		parent = new int[N];
		parent[u] = -1;
		bool *visited = new bool[N];
		for (int i = 0; i < N; i++)
		{
			visited[i] = false;
		}
		queue<Pair> q;
		q.push(Pair(u, 0));
		visited[u] = true;
		for (; !q.empty();)
		{
			Pair p = q.front();
			q.pop();
			for (int i = 0; i < N; i++)
			{
				if (A[p.first][i] == 1 && visited[i] == false)
				{
					if (i == w)
					{
						parent[i] = p.first;
						for (int i = w; i != -1; i = parent[i])
						{
							cout << i << " ";
						}
						cout << endl;
						return p.second + 1;
					}
					visited[i] = true;
					q.push(Pair(i, p.second + 1));
					parent[i] = p.first;
				}
			}
		}
		return -1;
	}

	int* Deikstra(int u)
	{
		int* P = new int[5];
		const int MAX = 100000000;
		NecessaryConversions();
		bool* used = new bool[N];
		P[u] = u;
		for (int i = 0; i < N; i++)
			used[i] = false;
		int* W = new int[N];
		for (int i = 0; i < N; i++)
		{
			if (i == u)
			{
				W[i] = 0;
				continue;
			}
			W[i] = MAX;
		}
		queue<int> q;
		q.push(u);
		for (; !q.empty();)
		{
			//bool edited = false;
			int min = MAX;
			int h;
			int index = -1;
			h = q.back();
			q.pop();
			for (int i = 0; i < N; i++)
			{
				if (A[h][i] != MAX &&!used[i] && (A[h][i] + W[h]) < W[i])
				{
					//edited = true;
					P[i] = h;
					W[i] = A[h][i] + W[h];
					if (W[i] < min)
					{
						index = i;
						min = W[i];
					}
				}
			}
			//if (edited == false)break;
			used[h] = true;
			q.push(index);
			if (index == -1)q.pop();
		}
		for (int i = 0; i < 5; i++)
			cout << P[i] << " ";
		cout << "\n\n";
		vector<vector<int>> parents(N);
		for (int i = 0; i < N; i++)
		{
			int f;
			int h = i;
			parents[i].push_back(h);
			while (h != u)
			{
				h = P[h];
				parents[i].push_back(h);
			}
		}

		for (int i = 0; i < N; i++)
		{
			copy(parents[i].begin(),   // итератор начала массива
				parents[i].end(),     // итератор конца массива
				ostream_iterator<int>(cout, " ")   //итератор потока вывода
				);
			cout << endl;

		}
		return W;
	}

	int** Floyd()
	{
		NecessaryConversions();
		int **W;
		W = new int*[N];
		for (int i = 0; i < N; i++)
			W[i] = new int[N];
		for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
			W[i][j] = A[i][j];
		int **H;
		H = new int*[N];
		for (int i = 0; i < N; i++)
			H[i] = new int[N];
		for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
		{
			H[i][j] = 0;
			if (A[i][j] != MAX)
				H[i][j] = j;
		}
		//
		for (int a = 0; a < N; a++)
		for (int b = 0; b < N; b++)
		{
			if (W[a][b] != MAX)
			for (int c = 0; c < N; c++)
			{
				if (W[a][c]>(W[a][b] + W[b][c]))
				{
					W[a][c] = W[a][b] + W[b][c];
					H[a][c] = H[a][b];
				}
			}
		}
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
				cout << W[i][j] << " ";
			cout << "\n";
		}
		cout << "\n\n";
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
				cout << H[i][j] << " ";
			cout << "\n";
		}
		cout << "\n\n";
		return W;
	}

	bool VisitedEdge(int v, int to, vector<NewEdge> newedges)
	{
		for (int i = 0; i < newedges.size(); i++)
		{
			if (newedges[i].initial == v && newedges[i].finale == to)
			if (newedges[i].used == true)
				return true;
			if (newedges[i].finale == v && newedges[i].initial == to)
			if (newedges[i].used == true)
				return true;
		}
		return false;
	}
};




int _tmain(int argc, _TCHAR* argv[])
{
	Graph graph;
	graph.ReadingOfMatrix("inputMatrix.txt");
	graph.PrintMatrix();
	graph.PrintEdges();
	/*graph.AddEdge(1, 3, 45);
	graph.PrintMatrix();
	graph.ChangeOfEdges(1, 3, 37);
	graph.PrintMatrix();
	graph.DeleteEdge(1, 3);
	graph.PrintMatrix();*/
	graph.AddVertex();
	cout << graph.GraphCohesion() << endl << endl;
	graph.FindComps();
	graph.DeleteVertex(5);
	cout << graph.GraphCohesion() << endl << endl;
	/*vector<Edge> PrimeEdges = graph.NewPrimeAlgorithm();
	for (int i = 0; i < PrimeEdges.size(); i++)
	{
	cout << PrimeEdges[i].initial << " " << PrimeEdges[i].finale << " " << PrimeEdges[i].weight;
	cout << endl;
	}
	cout << endl;
	vector<Edge> CruskalEdges = graph.CruskalAlgorithm();
	for (int i = 0; i < CruskalEdges.size(); i++)
	{
	cout << CruskalEdges[i].initial << " " << CruskalEdges[i].finale << " " <<CruskalEdges[i].weight;
	cout << endl;
	}
	cout << endl;
	bool* used = new bool[5];
	for (int i = 0; i < 5; i++)
	used[i] = false;
	int *parents = new int[5];
	bool flag = false;
	for (int i = 0; i < 5; i++)
	parents[i] = -1;
	graph.DFS(3, used, 2, parents,flag);

	for (int i = 2; i != -1; i = parents[i])
	cout << i<<" ";
	cout << endl;
	cout << endl;



	int *coloured = new int[5];
	for (int i = 0; i < 5; i++)
	coloured[i] = 0;
	for (int i = 0; i < 5; i++)
	used[i] = false;
	for (int i = 0; i < 5; i++)
	parents[i] = -1;
	int index = -1;
	vector<Edge> edges = graph.ReturnEdges();
	vector<NewEdge> newedges(edges.size());
	for (int i = 0; i < edges.size(); i++)
	{
	newedges[i].initial = edges[i].initial;
	newedges[i].finale = edges[i].finale;
	}
	graph.dfs(1, index, parents, coloured, newedges);
	for (int i = index,f=0;; f++, i = parents[i])
	{
	cout << i << " ";
	if (f > 0 && i == index)
	{
	break;
	}
	}

	cout << endl << endl;
	for (int i = 0; i < 5; i++)
	coloured[i] = 0;
	for (int i = 0; i < 5; i++)
	used[i] = false;
	for (int i = 0; i < 5; i++)
	parents[i] = -1;
	for (int i = 0; i < newedges.size(); i++)
	newedges[i].used = false;
	index = -1;
	graph.NewDfs(1, index, parents, coloured, newedges);
	for (int i = index, f = 0;; f++, i = parents[i])
	{
	cout << i << " ";
	if (f > 0 && i == index)
	{
	break;
	}
	}
	cout << endl << endl;

	int* a=graph.Deikstra(2);
	for (int i = 0; i < 5; i++)
	cout << a[i]<<" ";
	cout << endl << endl;*/
	int index = -1;
	bool* used = new bool[5];
	int *parents = new int[5];
	int *coloured = new int[5];
	for (int i = 0; i < 5; i++)
		coloured[i] = 0;
	for (int i = 0; i < 5; i++)
		used[i] = false;
	for (int i = 0; i < 5; i++)
		parents[i] = -1;
	graph.NewDfs(3, index, parents, coloured);
	for (int i = index, f = 0;; f++, i = parents[i])
	{
		cout << i << " ";
		if (f > 0 && i == index)
		{
			break;
		}
	}
	cout << endl << endl;
	graph.Floyd();
	cin.get();
	cin.get();
	return 0;
}


