// MST.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <fstream>
#include <vector>
#include <queue>
#include <list>
#include <Windows.h>

using namespace std;
const int INF = 1000000000;
ifstream read("input.txt");

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
	int CountOfVertex()
	{
		return countOfVertex;
	}

	int CountOfRib()
	{
		return countOfRib;
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
	bool MST()
	{
		vector<bool> used(countOfVertex);		
		vector<int> min_e(countOfVertex, INF), sel_e(countOfVertex, -1);
		
		for (int i = 0; i < countOfVertex; ++i)
		{
			int v = -1;
			for (int j = 0; j<  countOfVertex; ++j)
				if (!used[j] && (v == -1 || min_e[j] < min_e[v]))
					v = j;
			
			/*if (min_e[v] == INF)
			{
				cout << "No MST!";
				return false;
			}*/

			used[v] = true;	
			if (sel_e[v] != -1)
				cout << v << " " << sel_e[v] << endl;

			for (int q = 0; q < countOfVertex; ++q)
				if (matrix[v][q] < min_e[q])
				{
					min_e[q] = matrix[v][q];
					sel_e[q] = v;
				}

				for (int p = 0; p < countOfVertex; p++)
					cout << sel_e[p] << " ";
				cout << endl;

				return true;
		}
	}
};


int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	graph g;

	bool a = false;
	g.ReadMatrix();
	a = g.Connect();

	if (a)
	{
		vector<int> temp(g.CountOfVertex(), -1);
		bool flag = g.MST();
		cout << flag << endl;
		/*if (flag)
		for (int i = 0; i < g.CountOfVertex(); i++)
		{
			cout << temp[i] << " ";
		}
		cout << endl;*/
	}
	else
		cout << "Граф не является связным" << endl;
	return 0;
}

