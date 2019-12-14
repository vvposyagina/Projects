// CreateGraph.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <fstream>

using namespace std;


int main()
{

	int n, m, a[10000][2], size = 1;;

	cin >> n >> m;

	ofstream write("input.txt");

	a[0][0] = 0;
	a[0][1] = 0;
	int x, y, i = 0;
	write << n << " " << m << endl;
	while (i != m)
	{
		bool flag = true;
		x = rand() % n + 1;
		y = rand() % n + 1;
		int j = 1;
		int temp = size;
		while (temp != 0)
		{
			if (x == a[j][0] && y == a[j][1])
			{
				flag = false;
			}

			temp--;
		}

		if (!flag)
		{
			a[size][0] = x;
			a[size][1] = y;
			size++;
		}

		if (x != y && flag)
		{
			int a = rand() % 300;
			write << x << " " << y << " " << a << endl;
			i++;
		}
	}



	return 0;
}

