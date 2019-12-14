// Graphs.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <fstream>
#include <vector>
#include <queue>
#include <list>
#include <Windows.h>

using namespace std;
//string nameOfFile;
ifstream read("input.txt");
int const MAX = 99999;
int const N = 100;
struct rib
{
	int fi, se, weight;

	rib(int f = 0, int s = 0, int w = 0)
	{
		fi = f;
		se = s;
		weight = w;
	}
};
class graph
{
	/*struct rib
	{
		int fi, se, weight;

		rib(int f = 0, int s = 0, int w = 0)
		{
			fi = f;
			se = s;
			weight = w;
		}
	};*/

protected:
	//const int N = 1000;
	vector<vector<int>> matrix;
	list<rib> listOfRib;
	bool refreshed;
	int countOfVertex, countOfRib;

public:
	graph(int size)
	{
		vector<int> n(size, 0);

		for (int i = 0; i < size; i++)
			matrix.push_back(n);
	}

	void ReadMatrix()
	{
		countOfRib = 0;

		read >> countOfVertex;
		int q = 0;

		for (int i = 0; i < countOfVertex; i++)
		{
			for (int j = 0; j < countOfVertex; j++)
			{
				read >> matrix[i][j];

				if (matrix[i][j] == 0 && i != j)
					matrix[i][j] = MAX;

				if (matrix[i][j] > 0)
				{
					listOfRib.push_back(rib(i, j, matrix[i][j]));
					countOfRib++;
				}
			}
		}
	}

	void ReadList()
	{
		int first, second, weight, max = -1;

		read >> countOfRib;

		for (int i = 0; i < countOfRib; i++)
		{
			read >> first >> second >> weight;
			listOfRib.push_back(rib(first, second, weight));
			matrix[first][second] = weight;

			if (first > max)
				max = first;

			if (second > max)
				max = second;

			countOfVertex = max;
		}
	}

	bool AddRib(int first, int second, int weight)
	{
		if (first > countOfVertex || second > countOfVertex || first < 0 || second < 0)
			return false;
		else
		{
			matrix[first][second] = weight;
			listOfRib.push_back(rib(first, second, weight));
			return true;
		}
	}

	bool DeleteRib(int first, int second)
	{
		if (first > countOfVertex || second > countOfVertex || first < 0 || second < 0)
			return false;
		else
		{
			bool flag;
			matrix[first][second] = 0;
			for (list<rib>::iterator i = listOfRib.begin(); i != listOfRib.end(); i++)
			{
				if (i->fi == first && i->se == second)
				{
					listOfRib.erase(i);
					i = listOfRib.begin();
					flag = true;
					break;
				}
			}
			if (flag)
				return true;
			else
				return false;
		}
	}

	void AddVertex()
	{
		int newWeight;
		vector<int> n(countOfVertex);
		matrix.push_back(n);
		for (int i = 0; i < countOfVertex; i++)
		{
			cin >> newWeight;
			if (countOfVertex < matrix.size())
			{
				matrix[i][countOfVertex] = newWeight;
				matrix[countOfVertex][i] = newWeight;
			}
			else
			{
				matrix[i].push_back(newWeight);
				matrix[countOfVertex].push_back(newWeight);
			}

			if (newWeight != 0)
			{
				listOfRib.push_back(rib(countOfVertex, i, newWeight));
				countOfRib++;
			}
		}

		cin >> newWeight;
		matrix[countOfVertex].push_back(newWeight);

		countOfVertex++;
	}

	bool DeleteVertex(int num)
	{
		if (num >= countOfVertex)
			return false;
		else
		{
			for (list<rib>::iterator i = listOfRib.begin(); i != listOfRib.end(); i++)
			{
				if (i->fi == num || i->se == num)
				{
					listOfRib.erase(i);
					i = listOfRib.begin();
					countOfRib--;
				}
			}

			for (list<rib>::iterator i = listOfRib.begin(); i != listOfRib.end(); i++)
			{
				if (i->fi >= num)
					i->fi--;

				if (i->se >= num)
					i->se--;
			}

			for (int i = 0; i < countOfVertex; i++)
			{
				matrix[i].erase(matrix[i].begin() + num);
			}
			matrix.erase(matrix.begin() + num);

			countOfVertex--;
			return true;
		}
	}

	bool ChangeRib(int first, int second, int newWeight)
	{

		if (first > countOfVertex || second > countOfVertex || first < 0 || second < 0)
			return false;
		else
		{
			bool flag = false;

			for (list<rib>::iterator i = listOfRib.begin(); i != listOfRib.end(); i++)
			{
				if (i->fi == first && i->se == second)
				{
					i->weight = newWeight;
					flag = true;
					break;
				}
			}

			if (flag)
			{
				matrix[first][second] = newWeight;
				return true;
			}
			return false;
		}
	}

	bool Connect()
	{
		bool *visited = new bool[countOfVertex];

		for (int i = 0; i < countOfVertex; i++)
			visited[i] = false;

		queue<int> q;

		visited[0] = true;

		q.push(0);

		for (; !q.empty();)
		{
			int p = q.front();
			q.pop();

			for (int i = 0; i < countOfVertex; i++)
			{
				if (matrix[p][i] > 0 && !visited[i])
				{
					visited[i] = true;
					q.push(i);
				}
			}
		}

		for (int i = 0; i < countOfVertex; i++)
		{
			if (visited[i] == false)
			{
				return false;
			}
		}
		return true;
	}

	void PrintMatrix()
	{
		cout << countOfVertex << endl;
		for (int i = 0; i < countOfVertex; i++)
		{
			for (int j = 0; j < countOfVertex; j++)
			{
				cout << matrix[i][j] << " ";
			}
			cout << endl;
		}
	}

	void PrintList()
	{
		cout << countOfRib << endl;
		for (list<rib>::iterator i = listOfRib.begin(); i != listOfRib.end(); i++)
		{
			cout << i->fi << " " << i->se << " " << i->weight << endl;

		}
	}

	vector<rib> MST(int &lenghtOfTrick)
	{
		bool *visited = new bool[countOfVertex];
		vector<rib> listMST;
		int count = 1;

		for (int i = 0; i < countOfVertex; i++)
		{
			visited[i] = false;
		}

		visited[0] = true;
		while (count != countOfVertex)
		{
			int min = MAX, minVertexTwo, minVertexOne;
			bool flag = false;
			for (int j = 0; j < countOfVertex; j++)
			if (visited[j])
			{
				for (int i = 0; i < countOfVertex; i++)
				{
					if (matrix[j][i] < min && matrix[j][i] != 0 && visited[i] != true)
					{
						min = matrix[j][i];
						minVertexOne = j;
						minVertexTwo = i;
						flag = true;
					}
				}
			}

			if (flag)
			{
				visited[minVertexTwo] = true;
				listMST.push_back(rib(minVertexOne, minVertexTwo, min));
				//cout << minVertexOne << " " << minVertexTwo << " " << endl;
				count++;
				lenghtOfTrick += min;
			}
			else
			{
				listMST.clear();
				lenghtOfTrick = 0;
				return listMST;
			}
		}
		return listMST;
	}

	int getMinIndex(int n, vector<int> d, bool *used)
	{
		int min = MAX, num = 0;
		for (int i = 0; i < n; i++)
		{
			if (min > d[i] && !used[i])
			{
				num = i;
				min = d[i];
			}
		}
		return num;
	}

	vector<int> Dijkstra(int a)
	{		
		bool *used = new bool[countOfVertex];
		vector<int> d(countOfVertex);
		vector<pair<int, int>> g[N];

		for (list<rib>::iterator i = listOfRib.begin(); i != listOfRib.end(); i++)
		{
		g[i->fi].push_back(make_pair(i->se, i->weight));
		}

		fill(d.begin(), d.end(), MAX);

		for (int i = 0; i < g[a].size(); i++)
		{
		d[g[a][i].first] = g[a][i].second;
		}

		d[a] = 0;


		fill(used, used + countOfVertex, false);

		used[a] = true;

		int j;

		for (int i = 0; i < countOfVertex - 2; i++)
		{
			j = getMinIndex(countOfVertex, d, used);

			used[j] = true;

			for (int q = 0; q < g[j].size(); q++)
			{
				int w = g[j][q].first;
				if (d[w] == MAX || d[w] > d[j] + g[j][q].second)
				{
					d[w] = d[j] + g[j][q].second;
				}
			}
		}
		return d;
	}
	
	vector<vector<int>> Floyd()
	{
		vector<vector<int>> newMatrix;
		newMatrix = matrix;

		for (int k = 0; k < countOfVertex; k++)
		{
			for (int i = 0; i < countOfVertex; i++)
			{
				for (int j = 0; j < countOfVertex; j++)
				{
					newMatrix[i][j] = min(newMatrix[i][j], newMatrix[i][k] + newMatrix[k][j]);
				}
			}
		}

		return newMatrix;
	}

	~graph()
	{
		matrix.clear();
		listOfRib.clear();
	}

	int Count()
	{
		return countOfVertex;
	}


};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int n;
	cin>> n;
	graph g(n);

	bool a = false;
	g.ReadMatrix();
	//g.ReadList();

	g.PrintList();

	g.PrintMatrix();

	//a = g.AddRib(1, 3, 10);
	////g.DeleteRib(1, 6);

	////g.AddVertex();
	//a = g.DeleteVertex(1);

	//g.PrintList();

	//g.PrintMatrix();


	////g.ChangeRib(1, 2, 100);

	//bool flag = g.Connect();

	//if (flag)
	//	cout << "Граф является связным" << endl;
	//else
	//	cout << "Граф не является связным" << endl;

	//int x = 0;
	//vector<rib> mst;
	//mst = g.MST(x);

	//if (mst.size() != 0)
	//{
	//	for (vector<rib>::iterator it = mst.begin(); it != mst.end(); it++)
	//	{
	//		cout << (*it).fi << " " << (*it).se << endl;
	//	}
	//}
	//else
	//	cout << "Остовное дерево не может быть построено" << endl;

	vector<int> d;
	d = g.Dijkstra(5);	

	for(int i = 0; i < g.Count(); i++)
	{
		cout << d[i] << " ";
	}
	cout << endl;
	cout << endl;

	vector<vector<int>> newMatrix;
	newMatrix = g.Floyd();

	for (int i = 0; i < newMatrix.size(); i++)
	{
		for (int j = 0; j < newMatrix.size(); j++)
		{
			cout << newMatrix[i][j] << " ";
		}
		cout << endl;
	}
	return 0;
}