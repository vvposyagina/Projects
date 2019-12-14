// Way2.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <fstream>

using namespace std;
const int N = 100;
int b[4][4];

struct way
{
	int x[16];
	int y[16];
	char str[16];
	int len;
};

void translate(char a[], int n)
{
	for (int i = 0; i < 4; i++)
	{
		if ((int)(a[i]) == 46)
			b[n][i] = 0;
		if ((int)a[i] == 35)
			b[n][i] = -1;
		if ((int)a[i] == 45)
			b[n][i] = -10;
	}
}

int main()
{
	char s1[4], s2[4], s3[4], s4[4];
	cin >> s1 >> s2 >> s3 >> s4;


	translate(s1, 0);
	translate(s2, 1); 
	translate(s3, 2);
	translate(s4, 3);

	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			cout << b[i][j] << " ";
		}
		cout << endl;
	}

	way mas[N];

	return 0;
}

