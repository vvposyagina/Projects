// convex hull.cpp: определяет точку входа для консольного приложения.
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
};

bool compare(point a, point b)
{
	return (a.alfa > b.alfa);
}

int main()
{
	double const PI = 3.14159265358979323846;
	ifstream cin("input.txt");
	//ofstream cout("output.txt");
	point set[100], hull;

	int n, minx;
	cin >> n;
	for (int i = 0; i < n; i++)
	{
		cin >> set[i].x >> set[i].y;
	}
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
	for (int i = 0; i < n; i++)
	{
		if (set[i].x != hull.x && set[i].y != hull.y)
		{
			double lenx = set[i].x - hull.x;
			double leny = set[i].y - hull.y;

			set[i].alfa = atan(leny / lenx) + 2 * PI;
			
			
		}
		else if ((set[i].x == hull.x && set[i].y == hull.y) || (set[i].x != hull.x && set[i].y == hull.y))
			set[i].alfa = 0;
	}	

	sort(set + 1, set + n, compare);
	
	point vec1, vec2;
	for (int i = 1; i < n - 1; i++)
	{		
		vec1.x = set[i].x - set[i - 1].x;
		vec1.y = set[i].y - set[i - 1].y;
		vec2.x = set[i + 1].x - set[i -1].x;
		vec2.y = set[i + 1].y - set[i - 1].y;
		
		if (vec1.x * vec2.y - vec1.y * vec2.x > 0)
		{
			for (int j = i; j < n; j++)
			{
				set[j].x = set[j + 1].x;
				set[j].y = set[j + 1].y;
				set[j].alfa = set[j + 1].alfa;
			}
			n--;
		}
	}		

	for (int i = 0; i < n; i++)
	{
		cout << set[i].x << " " << set[i].y << endl;
	}
	
	return 0;
}

