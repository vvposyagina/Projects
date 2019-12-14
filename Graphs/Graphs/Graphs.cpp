// Graphs.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <fstream>
#include <vector>
#include <tuple>
#include <list>

using namespace std;
//string nameOfFile;
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
	const int N = 1000;
	vector<vector<int>> matrix;
	list<rib> listOfRib;
	bool refreshed;
	int countOfVertex, countOfRib;

public:
	graph()
	{
		vector<int> n(N);

		for (int i = 0, size = matrix.size(); i < N; i++)
			matrix.push_back(n);

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
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

	void AddRib(int first, int second, int weight)
	{
		matrix[first][second] = weight;
		listOfRib.push_back(rib(first, second, weight));
	}

	void DeleteRib(int first, int second)
	{
		matrix[first][second] = 0;
		for (list<rib>::iterator i = listOfRib.begin(); i != listOfRib.end(); i++)
		{
			if (i->fi == first && i->se == second)
			{
				listOfRib.erase(i);
				i = listOfRib.begin();
				break;
			}
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
			matrix[i][countOfVertex] = newWeight;
			matrix[countOfVertex][i] = newWeight;

			//matrix[i].push_back(newWeight);
			//matrix[countOfVertex].push_back(newWeight);

			if (newWeight != 0)
			{
				listOfRib.push_back(rib(countOfVertex, i, newWeight));
			}
		}

		cin >> newWeight;
		matrix[countOfVertex].push_back(newWeight);

		countOfVertex++;
	}

};

int main()
{
	graph g;
	g.ReadMatrix();
	//g.ReadList();

	//g.AddRib(1, 6, 10);
	//g.DeleteRib(1, 6);

	g.AddVertex();
	return 0;
}