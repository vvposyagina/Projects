// Breadth-firstSearch.cpp: определяет точку входа для консольного приложения.
//
#include <iostream>
#include <fstream>

using namespace std;

const int n = 1000;
int i, j;

int graph[n][n];

void createArray()
{
	for (int q = 0; q < n; q++)
	{
		for (int z = 0; z < n; z++)
		{
			if (q == z)
				graph[q][z] = 0;
			else
				graph[q][z] = rand() % 2;
		}
	}

}

void BFS(bool *visited, int unit)
{
	int *queue = new int[n];
	int count, head;

	for (i = 0; i < n; i++)
	{
		queue[i] = 0;
	}

	count = 0; head = 0;
	queue[count++] = unit;
	visited[unit] = true;

	while (head < count)
	{
		unit = queue[head++];
		cout << unit + 1 << " ";

		for (i = 0; i < n; i++)
		{
			if (graph[unit][i] && !visited[i])
			{
				queue[count++] = i;
				visited[i] = true;
			}
		}
	}
	delete[]queue;
}

void main()
{
	setlocale(LC_ALL, "Rus");

	ofstream writeGraph("graph.txt");
	ifstream fout("input.txt");

	int start;
	cout << "Стартовая вершина: ";
	cin >> start;
	bool *visited = new bool[n];

	//createArray();

	int n;
	fout >> n;

	for (int q = 0; q < n; q++)
	{
		for (int z = 0; z < n; z++)
		{
			fout >> graph[q][z];
		}
	}

	writeGraph << "Матрица смежности графа: " << endl;
	for (i = 0; i < n; i++)
	{
		visited[i] = false;
		for (j = 0; j < n; j++)
			writeGraph << " " << graph[i][j];
		writeGraph << endl;
	}

	cout << "Порядок обхода: ";
	BFS(visited, start - 1);
	delete[]visited;
	system("pause>>void");
}


