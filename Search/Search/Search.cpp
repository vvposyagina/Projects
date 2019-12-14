// Search.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <algorithm>
#include <Windows.h>
#include <ctime>

using namespace std;
const int N = 100000000;
int array[N];

void CreateArray(int count)
{
	for (int i = 0; i < count; i++)
	{
		array[i] = rand() % 99999;
	}
	sort(array, array + count);
}
int LinearSearch(int count, int NeededElement)
{
	if (count == 0)
	{
		return -1;
	}
	else if (array[0] > NeededElement)
	{
		return -1;
	}
	else if (array[count - 1] < NeededElement)
	{
		return -1;
	}

	for (int i = 0; i < count; i++)
	{
		if (array[i] == NeededElement)
		{
			return i;
		}
	}
	return -1;
}
int BinarySearch(int count, int first, int last, int NeededElement)
{
	int begin = first, end = last, middle;

	if (count == 0)
	{
		return -1;
	}
	else if (array[0] > NeededElement)
	{
		return -1;
	}
	else if (array[count - 1] < NeededElement)
	{
		return -1;
	}

	while (begin < end)
	{
		middle = begin + (end - begin) / 2;

		if (NeededElement <= array[middle])
			end = middle;
		else
			begin = middle + 1;
	}
	if (array[end] == NeededElement)
	{
		return end;
	}
	else
	{
		return -1;
	}
}
int SearchParts(int count, int NeededElement, int Step)
{
	if (count == 0)
	{
		return -1;
	}
	else if (array[0] > NeededElement)
	{
		return -1;
	}
	else if (array[count - 1] < NeededElement)
	{
		return -1;
	}

	for (int i = Step; i + Step < count; i += Step)
	{
		if (array[i] > NeededElement)
		{
			for (int j = i - Step; j < i; j++)
			{
				if (array[j] == NeededElement)
				{
					return j;
				}
			}
			return -1;
		}
	}
	for (int i = count - 1 - Step; i < count; i++)
	{
		if (array[i] == NeededElement)
		{
			return i;
		}
	}
	return -1;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int CountOfTests;
	cout << "Введите количество запросов: " << endl;
	cin >> CountOfTests;
	while (CountOfTests != 0)
	{
		int count, NeededElement = rand() % 99999, ResultLinearSearch, ResultBinarySearch, ResultSearchParts;
		cout << "Введите размерность массива:" << endl;
		cin >> count;
		clock_t TimeFill;
		TimeFill = clock();
		CreateArray(count);
		TimeFill = clock() - TimeFill;
		cout << "Время заполнения: ";
		printf("%f\n", (double)TimeFill / CLOCKS_PER_SEC);
		cout << endl;

		srand(time(0));

		clock_t TimeLinearSearch;
		TimeLinearSearch = clock();
		ResultLinearSearch = LinearSearch(count, NeededElement);
		TimeLinearSearch = clock() - TimeLinearSearch;
		cout << "Время работы линейного поиска: ";
		printf("%f\n", (double)TimeLinearSearch / CLOCKS_PER_SEC);
		cout << endl;
		if (ResultLinearSearch > 0)
		{
			cout << "Номер найденного элемента: " << ResultLinearSearch << endl;
		}
		else
		{
			cout << "Элемент не найден" << endl;
		}

		cout << endl;

		clock_t TimeBinarySearch;
		TimeBinarySearch = clock();
		ResultBinarySearch = BinarySearch(count, 0, count - 1, NeededElement);
		TimeBinarySearch = clock() - TimeBinarySearch;
		cout << "Время работы бинарного поиска: ";
		printf("%f\n", (double)TimeBinarySearch / CLOCKS_PER_SEC);
		cout << endl;
		if (ResultBinarySearch > 0)
		{
			cout << "Номер найденного элемента: " << ResultBinarySearch << endl;
		}
		else
		{
			cout << "Элемент не найден" << endl;
		}

		cout << endl;

		clock_t TimeSearchParts;
		TimeSearchParts = clock();
		ResultSearchParts = SearchParts(count, NeededElement, 100);
		TimeSearchParts = clock() - TimeSearchParts;
		cout << "Время работы поиска по частям: ";
		printf("%f\n", (double)TimeSearchParts / CLOCKS_PER_SEC);
		cout << endl;
		if (ResultSearchParts > 0)
		{
			cout << "Номер найденного элемента: " << ResultSearchParts << endl;
		}
		else
		{
			cout << "Элемент не найден" << endl;
		}
		cout << endl;
		CountOfTests--;

	}




	return 0;
}

