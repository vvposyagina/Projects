#include <iostream>
#include <algorithm>

using namespace std;

int main()
{
	int x1, y1, x2, y2;
	cin >> x1 >> y1 >> x2 >> y2;

	if (abs(x1 - x2) == 0 && y1 > 1 && (y2 - y1 == 1 || y1 == 2 && y2 - y1 <= 2))
		cout << "YES";
	else
		cout << "NO";
	cout << endl;
	return 0;
}