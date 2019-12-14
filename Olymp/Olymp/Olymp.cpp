#include <iostream>
#include <cstdio>
#include <ctime>
#include <cmath>
#include <iomanip> 
#include <cstdlib>
#include <algorithm>
#include <utility>
using namespace std;
const int N = 100000;
int compare(const void * a, const void * b)
{
	return (*(unsigned int*)a - *(unsigned int*)b);
}
int main()
{
	int n, m, rtg[N], x, result = 0;
	cin >> n >> m;
	for (int i = 0; i < n; i++)
	{
		cin >> rtg[i];
	}
	qsort(rtg, n, sizeof(int), compare);

	for (int z = 0; z < m; z++)
	{

		cin >> x;
		for (int i = n - 1; i >= 0; i--)
		{
			if (rtg[i] * 100 < x) { result = n - 1 - i; break; }
		}
		if (rtg[0] * 100 >= x) result = n;
		cout << result << endl;
		cout.flush();
	}


	return 0;
}