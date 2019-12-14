#include < iostream >
#include <fstream>
#include <string.h> 

using namespace std;

void back(int n, int *a)
{
	for (int i = 0, j = n - 1; i < j; i++, j--)
	{
		swap(a[i], a[j]);
	}
}
void CharToInt(char *x, int *a, int n)
{
	for (int i = 0; i < n; i++)
	{
		a[i] = (int)x[i] - 48;
	}
}
void Add(int *a, int *b, int *c, int n, int m, int max, int min)
{
	back(n, a);
	back(m, b);

	for (int i = 0; i < max + 1; i++)
	{
		c[i] = 0;
	}

	for (int i = 0; i < min; i++)
	{
		if ((a[i] + b[i]) >= 10)
		{
			c[i] += (a[i] + b[i]) % 10;
			c[i + 1] += (a[i] + b[i]) / 10;
		}
		else
		{
			c[i] += a[i] + b[i];
		}
	}
	for (int j = min; j < max; j++)
	{
		if (n > m)
		{
			if ((c[j] + a[j]) >= 10)
			{
				c[j] += (c[j] + a[j]) % 10 - 1;
				c[j + 1] += (c[j] + a[j]) / 10 + 1;
			}
			else
			{
				c[j] += a[j];
			}

		}
		else
		{
			if ((c[j] + b[j]) >= 10)
			{
				c[j] += (c[j] + b[j]) % 10 - 1;
				c[j + 1] += (c[j] + b[j]) / 10 + 1;
			}
			else
			{
				c[j] += b[j];
			}
		}
	}
	int p = max + 1;
	back(p, c);
}
void Mult(int *a, int *b, int *p, int n, int m, int max, int min)
{
	back(n, a);
	back(m, b);

	for (int i = 0; i < n + m; i++)
	{
		p[i] = 0;
	}
	if (n > m)
	{
		for (int i = 0; i < m; i++)
		{
			for (int j = 0, q = i; j < n; j++)
			{
				p[q] += a[j] * b[i];
			}
		}
	}
	else
	{

		for (int i = 0; i < n; i++)
		{
			for (int j = 0, q = i; j < m; j++, q++)
			{
				p[q] += b[j] * a[i];
			}
		}
	}

	for (int i = 0; i < n + m - 1; i++)
	{
		if (p[i] >= 10)
		{
			p[i + 1] += (p[i] / 10);
			p[i] = (p[i] % 10);
 		}		
	}

	int x = n + m - 2;
	back(x, p);
}
void Substr(int *a, int *b, int *c, int n, int m, int max, int min)
{
	back(n, a);
	back(m, b);

	for (int i = 0; i < max; i++)
	{
		c[i] = 0;
	}

	if (n >= m)
	{
		for (int i = 0; i < min; i++)
		{
			if (a[i] < b[i])
			{
				c[i] += a[i] + 10 - b[i];
				c[i + 1]--;
			}
			else
			{
				c[i] += a[i] - b[i];
			}
		}
		for (int i = min; i < max; i++)
		{
			c[i] += a[i] + 10;
		}
	}
	else
	{
		for (int i = 0; i < min; i++)
		{
			if (b[i] < a[i])
			{
				c[i] += b[i] + 10 - a[i];
				c[i + 1]--;
			}
			else
			{
				c[i] += b[i] - a[i];
			}
		}
		for (int i = min; i < max; i++)
		{
			c[i] += b[i] + 10;
		}
	}
	int p = max;
	back(p, c);
}
void Compare(int *a, int *b, int n, int m)
{
	if (n != m)
		cout << "No";	
	else
	{
		bool ok = true;
		for (int i = 0; i < n; i++)
		{
			if (a[i] != b[i])
			{
				ok = false;
				break;
			}
		}
		if (ok)
			cout << "Yes";
		else
			cout << "No";
	}
}
void Output(int *c, int max)
{
	if (c[0] == 0)
	{
		for (int i = 1; i <= max; i++)
		{
			cout << c[i];
		}
	}
	else
	{
		for (int i = 0; i <= max; i++)
		{
			cout << c[i];
		}
	}

}
int main()
{
	char s[100], t[100];
	int a[100], b[100], c[101], p[100000], alen, blen, max, min;

	cin >> s >> t;

	alen = strlen(s);
	blen = strlen(t);

	if (alen > blen)
	{
		max = alen;
		min = blen;
	}
	else
	{
		max = alen;
		min = blen;
	}

	CharToInt(s, a, alen);
	CharToInt(t, b, blen);

	Add(a, b, c, alen, blen, max, min);
	//Mult(a, b, c, alen, blen, max, min);
	//Substr(a, b, c, alen, blen, max, min);

	Output(c, max);

	//Compare(a, b, alen, blen);





}


