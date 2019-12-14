// BubbleAndPocketSortings.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <ctime>
#include <Windows.h>

using namespace std;

const int N = 10000;
int array[N];
int arrays[N];

void createArray(int count)
{
	for (int i = 0; i < count; i++)
	{
		array[i] = rand() % (count - 1);
	}
}

void bubbleSort(int *array, int count)
{
	for (int i = 0; i < count - 1; i++)
	{
		for (int j = 0; j < count - i - 1; j++)
		{
			if (array[j] > array[j + 1])
			{
				swap(array[j + 1], array[j]);
			}
		}
	}
}

void pocketSort(int *array, int count)
{	
	for (int i = 0; i < count; i++)
	{		
			arrays[array[i]]++;		
	}
	int k = 0;
	for (int i = 0; i < count; i++)
	{
		if (arrays[i] != 0)
		{
			for (int j = 0; j < arrays[i]; j++)
			{
				array[k] = i;
				k++;
			}
		}
	}
}


int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int arr1[N], arr2[N], count;
	cin >> count;
	createArray(count);
	for (int i = 0; i < count; i++)
	{
		arr1[i] = array[i];
		arr2[i] = array[i];		
	}
	
	clock_t time1;
	time1 = clock();
	bubbleSort(arr1, count);
	time1 = clock() - time1;
	cout << "Время работы сортировки пузырьком: ";
	printf("%f\n", (double)time1 / CLOCKS_PER_SEC);
	cout << endl;

	clock_t time2;
	time2 = clock();
	pocketSort(arr2, count);
	time2 = clock() - time2;
	cout << "Время работы карманной сортировки: ";
	printf("%f\n", (double)time2 / CLOCKS_PER_SEC);
	cout << endl;

	return 0;
}

