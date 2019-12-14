// Swim.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <cmath>

using namespace std;


int _tmain(int argc, _TCHAR* argv[])
{
	ifstream ifile("input.txt");
	ofstream ofile("output.txt");

	const double PI = 3.14159265;

	int x1, x2, x3, y1, y2, y3;
	double cosalfa, alfa, l, r, xO, yO, s;

	ifile >> x1 >> y1;
	ifile >> x2 >> y2;
	ifile >> x3 >> y3;

	xO = ((x2*x2 - x1*x1) + (y2*y2 - y1*y1) - 2 * (y1*(x1 - x3) - x1*(y1 - y3))*(y2 - y1) / (x1 - x3)) / (2*(x2 - x1) + 2*(y1 - y3)*(y2 - y1)/(x1 - x3));
	yO = (xO*(y1 - y3) + (y1*(x1 - x3) - x1*(y1 - y3))) / (x1 - x3);

	r = sqrt((xO - x1)*(xO - x1) + (yO - y1)*(yO - y1));
	l = sqrt((x2 - x1)*(x2 - x1) + (y2 - y1)*(y2 - y1));

	cosalfa = -l*l / 2 * r*r + 1;

	alfa = acos(cosalfa);

	s = 2 * PI*r*alfa / 360;

	ofile << s;

	return 0;
}

