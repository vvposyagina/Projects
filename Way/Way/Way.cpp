// Way.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include <iostream>
#include <algorithm>

using namespace std;

const int W = 4;         // ������ �������� ����
const int H = 4;         // ������ �������� ����
const int WALL = -1;         // ������������ ������
const int BLANK = -2;         // ��������� ������������ ������

int px[W * H], py[W * H];      // ���������� �����, �������� � ����
int len;                       // ����� ����
int grid[H][W];

bool lee(int ax, int ay, int bx, int by)   // ����� ���� �� ������ (ax, ay) � ������ (bx, by)
{
	int dx[4] = { 1, 0, -1, 0 };   // ��������, ��������������� ������� ������
	int dy[4] = { 0, 1, 0, -1 };   // ������, �����, ����� � ������
	int d, x, y, k;
	bool stop;

	// ��������������� �����
	d = 0;
	grid[ay][ax] = 0;            // ��������� ������ �������� 0
	do {
		stop = true;               // ������������, ��� ��� ��������� ������ ��� ��������
		for (y = 0; y < H; ++y)
		for (x = 0; x < W; ++x)
		if (grid[y][x] == d)                         // ������ (x, y) �������� ������ d
		{
			for (k = 0; k < 4; ++k)                    // �������� �� ���� ������������ �������
			if (grid[y + dy[k]][x + dx[k]] == BLANK)
			{
				stop = false;                            // ������� ������������ ������
				grid[y + dy[k]][x + dx[k]] = d + 1;      // �������������� �����
			}
		}
		d++;
	} while (!stop && grid[by][bx] == BLANK);

	if (grid[by][bx] == BLANK) return false;  // ���� �� ������

	// �������������� ����
	len = grid[by][bx];            // ����� ����������� ���� �� (ax, ay) � (bx, by)
	x = bx;
	y = by;
	d = len;
	while (d > 0)
	{
		px[d] = x;
		py[d] = y;                   // ���������� ������ (x, y) � ����
		d--;
		for (k = 0; k < 4; ++k)
		if (grid[y + dy[k]][x + dx[k]] == d)
		{
			x = x + dx[k];
			y = y + dy[k];           // ��������� � ������, ������� �� 1 ����� � ������
			break;
		}
	}
	px[0] = ax;
	py[0] = ay;                    // ������ px[0..len] � py[0..len] - ���������� ����� ����
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

