// convex hull 2.cpp: определяет точку входа для консольного приложения.
//
#include <iostream>
#include <fstream>
#include <cmath>
#include <algorithm>

using namespace std;



struct point
{
	int x, y;
	double alfa;
	bool be;
};

point set[100], hull;
double const PI = 3.14159265358979323846;
int n, minx;

double angle(int i, int j)
{
	double lenx = set[j].x - set[i].x;
	double leny = set[j].y - set[i].y;
	double alfa = atan(leny / lenx) + 2 * PI;

	return alfa;
}

void FarPoint()
{
	minx = set[0].x;
	hull.x = set[0].x;
	hull.y = set[0].y;
	hull.alfa = 0;
	int k;
	for (int i = 1; i < n; i++)
	{
		if (set[i].x < minx)
		{
			minx = set[i].x;
			hull.x = set[i].x;
			hull.y = set[i].y;
			k = i;
		}
		else if (minx == set[i].x)
		{
			if (set[i].y < hull.y)
			{
				minx = set[i].x;
				hull.x = set[i].x;
				hull.y = set[i].y;
				k = i;
			}
		}
	 }
	swap(set[k], set[0]);	
}
int VecMult(int i,int j, int k)
{
	point vec1, vec2;
	vec1.x = set[i].x - set[k].x;
	vec1.y = set[i].y - set[k].y;
	vec2.x = set[j].x - set[k].x;
	vec2.y = set[j].y - set[k].y;

	return vec1.x * vec2.y - vec1.y * vec2.x;
}

double Dist(int j)
{
	return sqrt((set[j].x - set[0].x)*(set[j].x - set[0].x) + (set[j].y - set[0].y)*(set[j].y - set[0].y));
}

int main()
{
	
	ifstream cin("input.txt");
	//ofstream cout("output.txt");
	
	cin >> n;
	for (int i = 0; i < n; i++)
	{
		cin >> set[i].x >> set[i].y;
		set[i].be = false;
	}
	
	FarPoint();

	int i = 0;

	cout << set[0].x << " " << set[0].y << endl;

	set[0].be = true;

	do
	{
		int q = 0;
		
		for (int j = 0; j < n; j++)
		{
			if (set[j].be == false)
			{
				int min = 1000;

				if (angle(i, j) < min)
				{					
					min = angle(i, j);
					q = j;
				}
				else if (angle(i, j) == min)
				{
					double dist1 = Dist(j);
					double dist2 = Dist(j);

					if (dist1 > dist2)
					{
						min = angle(i, j);
						q = j;
					}
				}
			}
		}
		set[q].be = true;
		cout << set[q].x << " " << set[q].y << endl;
		i++;
	} while (set[i].x != set[0].x && set[i].y != set[0].y && i < n);
			
	return 0;
}

