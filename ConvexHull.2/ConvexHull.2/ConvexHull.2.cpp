// ConvexHull.2.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <fstream>
#include <cmath>

using namespace std;

struct point
{
	double x, y, alfa;
	bool be;	
};

point set[100], hull;
double const PI = 3.14159265358979323846;
int n;
double minx;

double distance(double x1, double y1, double x2, double y2)
{
	return sqrt((x2 - x1)*(x2 - x1) + (y2 - y1)*(y2 - y1));
}

double angle(double x1, double y1, double x0, double y0)
{
	if (distance(x1, y1, x0, y0) == 0)
		return 0;
	else
		return asin((y1 - y0) / distance(x1, y1, x0, y0));	
}
void extrPoint()
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
double VecMult(int i, int j, int k)
{
	point vec1, vec2;
	vec1.x = set[i].x - set[k].x;
	vec1.y = set[i].y - set[k].y;
	vec2.x = set[j].x - set[k].x;
	vec2.y = set[j].y - set[k].y;

	return vec1.x * vec2.y - vec1.y * vec2.x;
}
int MinPoint(int q)
{
	double max = -2;
	int MinAng = 0;

	for (int i = 1; i < n; i++)
	{
		if (set[i].be == false)
		{
			if (angle(set[q].x, set[q].y, set[i].x, set[i].y) > max)
			{
				max = angle(set[q].x, set[q].y, set[i].x, set[i].y);
				MinAng = i;
			}
		}
	}
	set[MinAng].be = true;
	return MinAng;
}

int main()
{
	ifstream cin("input.txt");
	cin >> n;
	for (int i = 0; i < n; i++)
	{
		cin >> set[i].x >> set[i].y;
		set[i].be = false;		
	}

	extrPoint();

	/*for (int i = 0; i < n; i++)
	{
		cout << set[i].x << " " << set[i].y << endl;
	}*/

	cout << set[0].x <<  " " << set[0].y << endl;

	for (int i = 0; i < n; i++)
	{
		int a = MinPoint(i);
		cout << set[a].x << " " << set[a].y << endl;
	}
	
	return 0;
}

