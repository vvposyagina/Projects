#include <iostream>
#include <fstream>
#include <string>
#include <algorithm>

using namespace std;

struct word
{
	string value;
	int num;
};

bool compare(word x, word y)
{
	if (x.num > y.num)
		return true;
	else
		return false;
}

int main()
{
	ifstream cin("input.txt");
	word dict[100];
	string temp;
	int n = 0;
	while (cin >> temp)
	{
		bool flag = false;
		for (int i = 0; i < n; i++)
		{
			if (temp == dict[i].value)
			{
				dict[i].num++;
				flag = true;
				break;
			}
			else
			{
				flag = false;
			}
		}
		if (!flag)
		{
			
			dict[n].value = temp;
			dict[n].num = 1;
			n++;
		}
	 }

	sort(dict, dict + n, compare);

	for (int i = 0; i < n; i++)
	{
		cout << dict[i].value << " " << dict[i].num << endl;
	}
	return 0;
}