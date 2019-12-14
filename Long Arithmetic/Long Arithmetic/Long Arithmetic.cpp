#include <iostream>

using namespace std;

const int N = 100, R = 10;

struct Ltype
{
	int mas[N + 1];
	int st;
};
Ltype CharToInt(char a[])
{
	int n = strlen(a), q = N;
	Ltype p;
	for (int i = n - 1; i >= 0; i--)
	{
		p.mas[q] = (((int)(a[i])) - 48);
		q--;		
	}
	p.st = N - n + 1;
	return p;
}
Ltype Add(Ltype a, Ltype b)
{
	Ltype max, min, c;
	int temp = 0, i, st;

	min = a.st > b.st ? a : b;
	max = a.st <= b.st ? a : b;

	st = max.st;

	for (i = 0; i < N + 1; i++)
	{
		c.mas[i] = 0;
	}

	for (i = N; i >= min.st; i--)
	{
		c.mas[i] = max.mas[i] + min.mas[i] + temp;
		temp = c.mas[i] / R;
		c.mas[i] %= R;
	}
	for (i = min.st - 1; i >= max.st; i--)
	{
		c.mas[i] = max.mas[i] + temp;
		temp = c.mas[i] / R;
		c.mas[i] %= R;
	}

	if (temp)
		c.mas[--st] = temp;
	c.st = st;

	return c;
}
Ltype MultShort(Ltype a, int x, int y)
{
	int i, temp = 0, st = a.st;
	Ltype c;

	for (i = 0; i < N + 1; i++)
	{
		c.mas[i] = 0;
	}
	for (i = N; i >= st; i--)
	{
		c.mas[i - y] = a.mas[i] * x + temp;
		temp = c.mas[i - y] / R;
		c.mas[i - y] %= R;
	}	
	if (temp)
		c.mas[--st - y] = temp;
	c.st = st - y;

	return c;
}
Ltype MultLong(Ltype a, Ltype b)
{
	int i;
	Ltype temp, c;
	c.st = N;
	c.mas[N] = 0;

	for (i = N; i >= a.st; i--)
	{
		temp = MultShort(b, a.mas[i], N - i);
		c = Add(c, temp);
	}
	return c;
}
Ltype Sub(Ltype a, Ltype b)
{
	Ltype max, min, c;
	int temp = 0, i, st, lastNot0 = N;

	min = a.st > b.st ? a : b;
	max = a.st <= b.st ? a : b;

	st = max.st;

	for (i = 0; i < N + 1; i++)
	{
		c.mas[i] = 0;
	}

	for (i = N; i >= min.st; i--)
	{
		if (max.mas[i] >= min.mas[i])
		{
			c.mas[i] = max.mas[i] - min.mas[i] - temp;
			temp = 0;
		}
		else
		{
			c.mas[i] = R + max.mas[i] - min.mas[i] - temp;
			temp = 1;
		}
		c.mas[i] %= R;
		if (c.mas[i] != 0)
		{
			lastNot0 = i;
		}
	}
	for (int i = min.st - 1; i >= max.st; i--)
	{
		if (max.mas[i] >= min.mas[i])
		{
			c.mas[i] = max.mas[i] - temp;
			temp = 0;
		}
		else
		{
			c.mas[i] = R + max.mas[i] - temp;
			temp = 1;
		}
		c.mas[i] %= R;
		if (c.mas[i] != 0)
		{
			lastNot0 = i;
		}
	}


	c.st = lastNot0;

	return c;
}
void Cmp(Ltype a, Ltype b)
{
	if (a.st > b.st)
		cout << "-1" << endl;
	else if (a.st < b.st)
		cout << "1" << endl;
	else
	{
		int k = 0;
		for (int i = N; i >= a.st; i--)
		{
			if (a.mas[i] > b.mas[i])
			{
				k = 1;
				break;
			}
			else if (a.mas[i] < b.mas[i])
			{
				k = -1;
				break;
			}
			
		}
		cout << k << endl;
	}
}

int main()
{	
	char s[N], t[N];
	Ltype a, b, c;

	cin >> s >> t;

	int slen = strlen(s);
	int tlen = strlen(t);

	a.st = N - slen;
	b.st = N - tlen;	

	a = CharToInt(s);
	b = CharToInt(t);

	//c = Add(a, b);
	//c = MultLong(a, b);
	//c = Sub(a, b);
	Cmp(a, b);
	
		
	/*for (int i = c.st; i <= N; i++)
	{
		cout << c.mas[i];
	}*/

	cout << endl;
	
	return 0;
}

