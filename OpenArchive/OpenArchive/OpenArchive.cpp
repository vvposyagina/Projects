// OpenArchive.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <algorithm>
#include <fstream>
#include <Windows.h>
#include <string>
#include <vector>

using namespace std;
struct element
{
	int num;
	string symbol;
	element()
	{
		num = 0;
		symbol = "";
	}

	element(int n, string s)
	{
		num = n;
		symbol = s;
	}
};

ifstream read("input.txt");
ofstream write("output.txt");

vector<element> dictionary(256);

void MakeDictionary()
{
	for (int i = 0; i < 256; i++)
	{
		dictionary[i].num = i;
		dictionary[i].symbol = (char)i;
	}
}
string Decode(vector<int> code)
{
	int i = 0, pw = 0, cw;
	string p, c;	

	while (code[i])
	{
		cw = code[i] - 48;

		if (dictionary[cw].empty() == false)
		{

			c = D[cW];

			std::cout << c;

			if (pW != 0) {
				p = D[pW];
				D[j++] = p + c;
			}
			pW = cW;
		}

		if (D[cW].empty() == true)
		{

			p = D[pW];
			c = (D[pW])[0];
			std::cout << p + c;
			D[j++] = p + c;
		}

		i++;
	}
}

int main()
{
	return 0;
}

