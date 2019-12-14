// Archiver.cpp: определяет точку входа для консольного приложения.
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
vector<int> Code(string text)
{
	bool find = 0;
	int FindId = 0;
	vector<int> code;

	string p,c, cPLUSp;
	c = text[0];
	cPLUSp = text[0];
	
	for (int i = 1; i < text.length();)
	{
		for (int j = 0; j < dictionary.size(); j++)
		{
			if (cPLUSp == dictionary[j].symbol)
			{
				find = 1; 				
			}			
			if (p == dictionary[j].symbol)
			{
				FindId = j;
			}
		}

		if (!find)
		{
			code.push_back(FindId);

			dictionary.push_back(element(dictionary.size() + 1, cPLUSp));
			p = c;
			c = text[i++];
			cPLUSp = p + c;
		}
		else
		{
			p = cPLUSp;
			c = text[i++];
			cPLUSp += c;
		}
		find = false;
	}
	string temp;
	temp = text[text.length() - 1];
	for (int q = 0; q < dictionary.size(); q++)
	{
		if (p == dictionary[q].symbol)
			code.push_back(q);		
	}	
	for (int q = 0; q < dictionary.size(); q++)
	{
		if (temp == dictionary[q].symbol)
			code.push_back(q);
	}

	return code;
}
vector<int> StringToInt(string code)
{
	vector<int> sourceCode;
	int i = 0;
	string temp;
	while (i < code.length())
	{
		for (; code[i] != ' '; i++)
		{
			temp += code[i];
		}
		temp.erase(temp.end());
		sourceCode.push_back(atoi(temp.c_str()));
		i++;
	}
	return sourceCode;
}
string Decode(vector<int> sourceCode)
{
	string readyText;
	int pw, cw;
	string strpw, strcw, p, c, cPLUSp;	

	strpw = dictionary[sourceCode[0]].symbol;

	pw = sourceCode[0], cw = sourceCode[1];

	p = dictionary[sourceCode[0]].symbol;
	c = dictionary[sourceCode[1]].symbol;

	cPLUSp = p + c;

	bool find = false;

	for (int i = 1; i < sourceCode.size() - 1; i++)
	{		
		for (int j = 0; j < dictionary.size(); j++)
		{
			if (strcw == dictionary[j].symbol)
			{
				find = true;
			}
		}
		if (find)
		{
			readyText += strcw;
			p = cw;
			c = strcw[0];
			dictionary.push_back(element(dictionary.size() + 1, cPLUSp));
		}
		else
		{
			p = strpw;
			c = strpw[0];
			readyText += cPLUSp;
			dictionary.push_back(element(dictionary.size() + 1, cPLUSp));
		}
	}
	return readyText;
}
int main()
{	
	vector<int> readyCode;
	string text;
	MakeDictionary();
	getline(read, text);
	
	readyCode = Code(text);
	
	for (int i = 0; i < readyCode.size(); i++)
	{
		write << readyCode[i] << " ";
	}
	
	return 0;
}

