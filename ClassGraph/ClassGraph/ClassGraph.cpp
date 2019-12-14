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
int const MAX = 100000000;
class graph
{
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

protected:
	//const int N = 1000;
	vector<vector<int>> matrix;
	list<rib> listOfRib;
	bool refreshed;
	int countOfVertex, countOfRib;

public:
	graph()
	{
		vector<int> n(100);

		for (int i = 0, size = matrix.size(); i < 100; i++)
			matrix.push_back(n);

		for (int i = 0; i < 100; i++)
		{
			for (int j = 0; j < 100; j++)
			{
				matrix[i][j] = 0;
			}
		}
	}

	void ReadMatrix()
	{
		countOfRib = 0;

		read >> countOfVertex;

		for (int i = 0; i < countOfVertex; i++)
		{
			for (int j = 0; j < countOfVertex; j++)
			{
				read >> matrix[i][j];

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
			if (countOfVertex < 100)
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

	vector<pair<int, int>> MST(int &lenghtOfTrick)
	{
		bool *visited = new bool[countOfVertex];
		vector<pair<int, int>> listMST;
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
				listMST.push_back(make_pair(minVertexOne, minVertexTwo));
				//cout << minVertexOne << " " << minVertexTwo << " " << endl;
				count++;
				lenghtOfTrick += min;								
			}
			else
			{
				listMST.clear();
				return listMST;
			}
		}
		return listMST;
	}

	int Dijkstra()
	{

	}


};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	graph g;

	bool a = false;
	g.ReadMatrix();
	//g.ReadList();

	g.PrintList();

	g.PrintMatrix();

	a = g.AddRib(1, 3, 10);
	//g.DeleteRib(1, 6);

	//g.AddVertex();
	a = g.DeleteVertex(1);

	g.PrintList();

	g.PrintMatrix();


	//g.ChangeRib(1, 2, 100);

	bool flag = g.Connect();

	if (flag)
		cout << "Граф является связным" << endl;
	else
		cout << "Граф не является связным" << endl;

	int x = 0;
	vector<pair<int, int>> mst;
	mst = g.MST(x);

	if (mst.size() != 0)
	{
		for (vector<pair<int, int>>::iterator it = mst.begin(); it != mst.end(); it++)
		{
			cout << (*it).first << " " << (*it).second << endl;
		}
	}
	else
		cout << "Остовное дерево не может быть построено" << endl;
	
	return 0;
}