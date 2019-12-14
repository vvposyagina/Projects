#include <fstream>

using namespace std;
int main()
{
	ifstream cin("input.txt");
	ofstream cout("output.txt");

	int n, num;
	cin >> n;

	for (int i = 0; i < n; i++)
	{
		cin >> num;

		int tempnum = num, min = 10, max = -1, mindis = 1, maxdis = 1, first = 0;
		int dis = 0;
		while (tempnum > 0)
		{
			int temp = tempnum % 10;
			first = temp;
			tempnum /= 10;
			dis++;

			if (min > temp && temp != 0)
			{
				min = temp;
				mindis = dis;
			}
			if (max < temp && temp != 0)
			{
				max = temp;
				maxdis = dis;
			}
		}
		if (min == 10)
		{
			min = 0;
		}
		cout << "Case #" << i + 1 << ": ";
		int n1 = (num + (first - min) * pow(10, mindis - 1) + (min - first) * pow(10, dis - 1));
		int n2 = (num + (first - max) * pow(10, maxdis - 1) + (max - first) * pow(10, dis - 1));
		cout << n1 << " ";
		cout << n2 << endl;

	}

	return 0;
}

