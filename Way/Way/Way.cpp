// Way.cpp: определ€ет точку входа дл€ консольного приложени€.
//

#include <iostream>
#include <algorithm>

using namespace std;

const int W = 4;         // ширина рабочего пол€
const int H = 4;         // высота рабочего пол€
const int WALL = -1;         // непроходима€ €чейка
const int BLANK = -2;         // свободна€ непомеченна€ €чейка

int px[W * H], py[W * H];      // координаты €чеек, вход€щих в путь
int len;                       // длина пути
int grid[H][W];

bool lee(int ax, int ay, int bx, int by)   // поиск пути из €чейки (ax, ay) в €чейку (bx, by)
{
	int dx[4] = { 1, 0, -1, 0 };   // смещени€, соответствующие сосед€м €чейки
	int dy[4] = { 0, 1, 0, -1 };   // справа, снизу, слева и сверху
	int d, x, y, k;
	bool stop;

	// распространение волны
	d = 0;
	grid[ay][ax] = 0;            // стартова€ €чейка помечена 0
	do {
		stop = true;               // предполагаем, что все свободные клетки уже помечены
		for (y = 0; y < H; ++y)
		for (x = 0; x < W; ++x)
		if (grid[y][x] == d)                         // €чейка (x, y) помечена числом d
		{
			for (k = 0; k < 4; ++k)                    // проходим по всем непомеченным сосед€м
			if (grid[y + dy[k]][x + dx[k]] == BLANK)
			{
				stop = false;                            // найдены непомеченные клетки
				grid[y + dy[k]][x + dx[k]] = d + 1;      // распростран€ем волну
			}
		}
		d++;
	} while (!stop && grid[by][bx] == BLANK);

	if (grid[by][bx] == BLANK) return false;  // путь не найден

	// восстановление пути
	len = grid[by][bx];            // длина кратчайшего пути из (ax, ay) в (bx, by)
	x = bx;
	y = by;
	d = len;
	while (d > 0)
	{
		px[d] = x;
		py[d] = y;                   // записываем €чейку (x, y) в путь
		d--;
		for (k = 0; k < 4; ++k)
		if (grid[y + dy[k]][x + dx[k]] == d)
		{
			x = x + dx[k];
			y = y + dy[k];           // переходим в €чейку, котора€ на 1 ближе к старту
			break;
		}
	}
	px[0] = ax;
	py[0] = ay;                    // теперь px[0..len] и py[0..len] - координаты €чеек пути
	return true;
}

int main()
{
	bool answer = lee(0, 0, 3, 3);

	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			cin >> grid[i][j];
		}
	}
	if (!answer)
		cout << -1;
	else
	{
		for (int i = 0; i < 4; i++)
		{
		
				cout << px[i] << " " << py[i] << endl;
			
		}
	}
	return 0;
}

