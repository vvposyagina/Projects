#include <iostream>
#include <algorithm>
#include <iomanip>
#include <cmath>

using namespace std;
bool myFunction1(pair<short, short> i, pair<short, short> j)
{
	if (i.first < j.first)
	{

		return true;
	}
	else if (i.first == j.first)
	{
		if (i.second < j.second)
		{
			return true;
		}
		else
		{
			return false;
		}

	}
	else
	{
		return false;
	}
	//return  (i.second < j.second && i.first > j.first);
}
bool myFunction2(pair<short, short> i, pair<short, short> j)
{
	if (i.second < j.second)
	{
		
		return true;
	}
	else if (i.second == j.second)
	{
		if (i.first > j.first)
		{
			return true;
		}
		else
		{
			return false;
		}
		
	}
	else
	{
		return false;
	}
	//return  (i.second < j.second && i.first > j.first);
}
int main()
{
	short const N = 100;
	double b[6], k[6];
	short n;


	pair<short, short> f[N], f1[N], f2[N], vyb;

	cin >> n;
	if (n == 3)
	{
		cin >> f[0].first >> f[0].second;
		cin >> f[1].first >> f[1].second;
		cin >> f[2].first >> f[2].second;

		double s;
		double l1, l2, l3;

		l1 = sqrt((f[0].first - f[1].first)*(f[0].first - f[1].first) + (f[0].second - f[1].second)*(f[0].second - f[1].second));
		l2 = sqrt((f[1].first - f[2].first)*(f[1].first - f[2].first) + (f[1].second - f[2].second)*(f[1].second - f[2].second));
		l3 = sqrt((f[0].first - f[2].first)*(f[0].first - f[2].first) + (f[0].second - f[2].second)*(f[0].second - f[2].second));

		//cout << l1 << " " << l2 << " " << l3 << " " << endl;
		if ((l1 >= l2) && (l1 >= l3))
			s = l2 + l3;

		if ((l2 >= l1) && (l2 >= l3))
			s = l1 + l3;

		if ((l3 >= l2) && (l3 >= l1))
			s = l2 + l1;
		

		cout << fixed << setprecision(6) << s << endl;

		return 0;
	}
	for (int i = 0; i < n; i++)
	{
		short a, b;
		cin >> a >> b;
		f[i].first = a;
		f[i].second = b;
		f1[i].first = a;
		f1[i].second = b;
		f2[i].first = a;
		f2[i].second = b;
		
	}
	////cout << endl;
	for (int i = 0, q = 0; i < 4; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if ((f[i].first - f[j].first) == 0)
			{
				k[q] = 0;
				b[q] = 0;
			}
			else
			{
				k[q] = (f[i].second - f[j].second) / (f[i].first - f[j].first);
				b[q] = (f[i].first*f[j].second - f[j].first*f[i].second) / (f[i].first - f[j].first);
				
			}
			//cout << k[q] << " " << b[q] << endl;
			q++;
			
		}
	}
	//cout << endl;
	short nVyb = -1;



	for (int i = 1; i < 6; i++)
	{
		if (((k[0] != k[i]) || (b[0] != b[i])) && (nVyb == -1))
		{
			//s++;
			switch (i) {
			case 1:
				if ((k[3] == k[1]) && (b[3] == b[1]))
				{
					nVyb = 1;
				}
				else if ((k[3] == k[0]) && (b[3] == b[0]))
					nVyb = 2;
				else
					nVyb = 0;
				break;
			case 2:
				if ((k[4] == k[2]) && (b[4] == b[2]))
				{
					nVyb = 0;
				}
				else if ((k[4] == k[1]) && (b[4] == b[1]))
					nVyb = 2;
				else
					nVyb = 1;
				break;
			case 3:
				nVyb = 3;
				break;
			case 4:
				nVyb = 3;
				break;
			case 5:
				nVyb = 3;
				break;
			}
		}
	}

	if ( nVyb != -1)
	{		
		vyb.first = f[nVyb].first;
		vyb.second = f[nVyb].second;
	}
	else
	{
		for (int i = 4; i < n; i++)
		{
			if (f[i].second != f[i].first*k[0] + b[0])
			{
				nVyb = i;
				vyb.first = f[nVyb].first;
				vyb.second = f[nVyb].second;
			}
			break;
		}
	}
	//cout << nVyb << endl;
	sort(f1, f1 + n, myFunction1);
	/*
	for (int i = 0; i < n; i++)
	{
		cout << f1[i].first << " " << f1[i].second << endl;
	}
	*/
	//cout << endl << endl;
	sort(f2, f2 + n, myFunction2);
	/*
	for (int i = 0; i < n; i++)
	{
		cout << f2[i].first << " " << f2[i].second << endl;
	}
	*/
	//cout << endl << endl;
	/*
	double minx = abs(f[0].first - vyb.first), miny = abs(f[0].second - vyb.second);
	pair <short, short> nearX, nearY;
	nearX.first = f[0].first;
	nearX.second = f[0].second;
	nearY.first = f[0].first;
	nearY.second = f[0].second;
	short nX = 0, nY = 0;


	
	
	for (int i = 1; i < n; i++)
	{
		if (nVyb != i)
		{
			if (abs(f[i].first - vyb.first) < minx)
			{
				minx = abs(f[i].first - vyb.first);
				nearX.first = f[i].first;
				nearX.second = f[i].second;
				nX = i;
			}
			if (abs(f[i].second - vyb.second) < miny)
			{
				miny = abs(f[i].second - vyb.second);
				nearY.first = f[i].first;
				nearY.second = f[i].second;
				nY = i;
			}
		}
	}

	if (f[0].first != vyb.first && f[0].second != vyb.second && f[n - 1].first != vyb.first && f[n - 1].second != vyb.second)
	{
		s = sqrt((f[0].first - f[n - 1].first) * (f[0].first - f[n - 1].first) + (f[0].second - f[n - 1].second) * (f[0].second - f[n - 1].second));
	}
	else if (f[0].first != vyb.first && f[0].second != vyb.second)
	{
		s = sqrt((f[0].first - f[n - 2].first) * (f[0].first - f[n - 2].first) + (f[0].second - f[n - 2].second) * (f[0].second - f[n - 2].second));
	}
	else
	{
		s = sqrt((f[1].first - f[n - 1].first) * (f[1].first - f[n - 1].first) + (f[1].second - f[n - 1].second) * (f[1].second - f[n - 1].second));
	}
	*/
	double s = 0;
	if ((vyb.first == f1[n - 1].first && vyb.second == f1[n - 1].second) || (vyb.first == f1[0].first && vyb.second == f1[0].second) || (vyb.second == f2[n - 1].second && vyb.first == f2[n - 1].first) || (vyb.second == f2[0].second && vyb.first == f2[0].first))
	{
		if (vyb.first == f1[n - 1].first && vyb.second == f1[n - 1].second)
		{
			s = sqrt((f1[0].first - f1[n - 2].first) * (f1[0].first - f1[n - 2].first) + (f1[0].second - f1[n - 2].second) * (f1[0].second - f1[n - 2].second));
			s += sqrt((f1[n - 1].first - f1[n - 2].first) * (f1[n - 1].first - f1[n - 2].first) + (f1[n - 1].second - f1[n - 2].second) * (f1[n - 1].second - f1[n - 2].second));
		}
		else if (vyb.first == f1[0].first && vyb.second == f1[0].second)
		{
			s = sqrt((f1[1].first - f1[n - 1].first) * (f1[1].first - f1[n - 1].first) + (f1[1].second - f1[n - 1].second) * (f1[1].second - f1[n - 1].second));
			s += sqrt((f1[0].first - f1[1].first) * (f1[0].first - f1[1].first) + (f1[0].second - f1[1].second) * (f1[0].second - f1[1].second));
		}
		if (vyb.second == f2[n - 1].second && vyb.first == f2[n - 1].first)
		{
			s = sqrt((f2[0].first - f2[n - 2].first) * (f2[0].first - f2[n - 2].first) + (f2[0].second - f2[n - 2].second) * (f2[0].second - f2[n - 2].second));
			//cout << s << endl;
			s += sqrt((f2[n - 1].first - f2[n - 2].first) * (f2[n - 1].first - f2[n - 2].first) + (f2[n - 1].second - f2[n - 2].second) * (f2[n - 1].second - f2[n - 2].second));
			//cout << s << endl;
		}
		else if (vyb.second == f2[0].second && vyb.first == f2[0].first)
		{
			s = sqrt((f2[1].first - f2[n - 1].first) * (f2[1].first - f2[n - 1].first) + (f2[1].second - f2[n - 1].second) * (f2[1].second - f2[n - 1].second));
			s += sqrt((f2[0].first - f2[1].first) * (f2[0].first - f2[1].first) + (f2[0].second - f2[1].second) * (f2[0].second - f2[1].second));
		}
		cout << fixed << setprecision(6) << s << endl;
		//system("pause");
		return 0;
		
	}
	else
	{
		short n1, n2;
		//cout << "min" << endl;
		double min1, min2;

		if (nVyb != 0 && nVyb != 1)
		{
			min1 = sqrt((f[0].first - vyb.first) * (f[0].first - vyb.first) + (f[0].second - vyb.second) * (f[0].second - vyb.second));
			min2 = sqrt((f[1].first - vyb.first) * (f[1].first - vyb.first) + (f[1].second - vyb.second) * (f[1].second - vyb.second));
			n1 = 0;
			n2 = 1;
		}
		else if (nVyb == 0)
		{
			min1 = sqrt((f[1].first - vyb.first) * (f[1].first - vyb.first) + (f[1].second - vyb.second) * (f[1].second - vyb.second));
			min2 = sqrt((f[2].first - vyb.first) * (f[2].first - vyb.first) + (f[2].second - vyb.second) * (f[2].second - vyb.second));
			n1 = 1;
			n2 = 2;
		}
		else if (nVyb == 1)
		{
			min1 = sqrt((f[0].first - vyb.first) * (f[0].first - vyb.first) + (f[0].second - vyb.second) * (f[0].second - vyb.second));
			min2 = sqrt((f[2].first - vyb.first) * (f[2].first - vyb.first) + (f[2].second - vyb.second) * (f[2].second - vyb.second));
			n1 = 0;
			n2 = 2;
		}


		//cout << min1 << endl;
		//s[0] += sqrt((f[i].first - f[i + 1].first) * (f[i].first - f[i + 1].first) + (f[i].second - f[i + 1].second) * (f[i].second - f[i + 1].second));


		//cout << min2 << endl;
		for (int i = 3; i < n; i++)
		{
			if (i == nVyb)
			{
				continue;
			}
			double s = sqrt((f[i].first - vyb.first) * (f[i].first - vyb.first) + (f[i].second - vyb.second) * (f[i].second - vyb.second));
			//cout << s << endl;
			if (s <= min1 || s <= min2)
			{
				if (min1 >= min2)
				{
					min1 = s;
					n1 = i;
				}

				else
				{
					min2 = s;
					n2 = i;
				}

			}
		}
		//cout << "min " << min1 << " " << min2 << endl;
		//cout << "vyb " << vyb.first << " " << vyb.second << endl;

		double s1 = sqrt((f[n1].first - f[n2].first) * (f[n1].first - f[n2].first) + (f[n1].second - f[n2].second) * (f[n1].second - f[n2].second)), s = 0;
		//cout << " n1 n2 " << n1 << " " << n2 << endl;
		//cout << "s1 " << s1 << endl;

		

		if (f1[0].first != vyb.first && f1[0].second != vyb.second && f1[n - 1].first != vyb.first && f1[n - 1].second != vyb.second)
		{
			s = sqrt((f1[0].first - f1[n - 1].first) * (f1[0].first - f1[n - 1].first) + (f1[0].second - f1[n - 1].second) * (f1[0].second - f1[n - 1].second));
		}
		else if (f1[0].first != vyb.first && f1[0].second != vyb.second)
		{
			s = sqrt((f1[0].first - f1[n - 2].first) * (f1[0].first - f1[n - 2].first) + (f1[0].second - f1[n - 2].second) * (f1[0].second - f1[n - 2].second));
		}
		else
		{
			s = sqrt((f1[1].first - f1[n - 1].first) * (f1[1].first - f1[n - 1].first) + (f1[1].second - f1[n - 1].second) * (f1[1].second - f1[n - 1].second));
		}
		double s2 = 0;

		if (f2[0].first != vyb.first && f2[0].second != vyb.second && f2[n - 1].first != vyb.first && f2[n - 1].second != vyb.second)
		{
			s2 = sqrt((f2[0].first - f2[n - 1].first) * (f2[0].first - f2[n - 1].first) + (f2[0].second - f2[n - 1].second) * (f2[0].second - f2[n - 1].second));
		}
		else if (f2[0].first != vyb.first && f2[0].second != vyb.second)
		{
			s2 = sqrt((f2[0].first - f2[n - 2].first) * (f2[0].first - f2[n - 2].first) + (f2[0].second - f2[n - 2].second) * (f2[0].second - f2[n - 2].second));
		}
		else
		{
			s2 = sqrt((f2[1].first - f2[n - 1].first) * (f2[1].first - f2[n - 1].first) + (f2[1].second - f2[n - 1].second) * (f2[1].second - f2[n - 1].second));
		}
		//cout << " " << s << endl;
		//s = 0;
		if (s2 < s)
		{
			swap(s2, s);
		}
		s = s - s1 + min1 + min2;
		cout << fixed << setprecision(6) << s << endl;
		//system("pause");
		return 0;
	}
	
	
	
	return 0;
}

