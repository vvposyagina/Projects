// Граф (к экзамену).cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <queue>
using namespace std;

class Graph
{
	int n;
	int e[100][100];
public:
	Graph(){};
	void Input()
	{
		ifstream fin("input.txt");
		fin>>n;

		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
				fin>>e[i][j];
	}

	void Input_List()
	{
		int m;
		cin>>n>>m;

		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
				e[i][j] = 0;

		for(int i = 0; i < m; i++)
		{
			int a, b, value;
			cin>>a>>b>>value;
			e[a-1][b-1] = e[b-1][a-1] = value;
		}
	}

	void Floyd()
	{
		cout<<"Floyd"<<endl;
		int d[100][100];

		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
			{
				if(i != j && e[i][j] == 0)
					d[i][j] = 100000;
				else
					d[i][j] = e[i][j];
			}

		for(int k = 0; k < n; k++)
			for(int i = 0; i < n; i++)
				for(int j = 0; j < n; j++)
					d[i][j]=min(d[i][j], d[i][k]+d[k][j]);
		
		for(int i = 0; i < n; i++)
		{
			for(int j = 0; j < n; j++)
				cout<<d[i][j]<<" ";
			cout<<endl;
		}
		cout<<endl<<endl;	
	}

	void Kruskal()
	{
		cout<<"Kruskal"<<endl;
		int * v;
		v = new int [n];

		for(int i = 0; i < n; i++)
			v[i] = i + 1;

		for(int k = 0; k < n-1; k++)
		{
			int min = 100000, index1 = -1, index2 = -1;
			for(int i = 0; i < n; i++)
				for(int j = i; j < n; j++)
					if(e[i][j] != 0 && min > e[i][j] && v[i] != v[j])
					{
						min = e[i][j];
						cout<<i<<" "<<j<<" : "<<e[i][j]<<endl;
						v[j] = v[i];
					}	
		}
		cout<<endl<<endl;
	}

	void Prim()
	{
		cout<<"Prim"<<endl;
		bool v[100];
		for(int i = 0; i < n; i++)
			v[i] = false;

		int d[100][100];

		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
				d[i][j] = 0;

		
		int prev = 0, next = 1;
		for(int count = 0; count < n - 1; count++)
		{
			int min = 100000;
			v[prev] = true;
			for(int i = 0; i < n; i++)
				if(i != prev && e[prev][i] != 0 && e[prev][i] < min && v[i] == false)
				{
					next = i;
					min = e[prev][i];
				}
			d[prev][next] = d[next][prev] = min;
			prev = next;
		}

		for(int i = 0; i < n; i++)
		{
			for(int j = 0; j < n; j++)
				cout<<d[i][j]<<" ";
			cout<<endl;
		}
		cout<<endl<<endl;
	}

	void Components()
	{
		cout<<"Components"<<endl<<endl;
		int *visited=new int [n];

		for (int i = 0; i < n; i++)
			visited[i] = -1;

		int count = 0;

		for (int i = 0; i < n; i++) //проверка всех вершин
		{
			if (visited[i] == -1)
			{
				queue <int> q;
				q.push(i);
				visited[i] = count;
				for (;!q.empty();) 
				{
					int p = q.front();
					q.pop();
					for (int j=0; j<n; j++)
						if (e[p][j] && visited[j]==-1)
						{
							visited[j]=count;
							q.push(j);
						}
				}
				count++;

			} 

		}
	
		for (int i = 0; i < count; i++)
		{
			cout<<"component #"<<i+1<<" : ";
			for (int j = 0; j < n; j++)
				if (visited[j] == i)
			cout<<j<<' ';
			cout<<endl;
		}
		cout<<endl<<endl;
	}
};

int _tmain(int argc, _TCHAR* argv[])
{
	Graph way;
	way.Input();
	way.Floyd();
	way.Kruskal();
	way.Prim();
	way.Components();
	return 0;
}

