// CompareSorts.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <ctime>
#include <Windows.h>

using namespace std;

const int N = 10000;
int array[N];

void createArray(int count)
{
	for (int i = 0; i < count; i++)
	{
		array[i] = rand() % 9999;
	}	
}

void quickSortLeft(int *array, int first, int last)
{
	int i = first, j = last, referenceElement = array[first];
	do
	{
		while (array[i] < referenceElement)
			i++;
		while (array[j] > referenceElement)
			j--;		
		if (i <= j)
		{
			swap(array[i], array[j]);
			i++;
			j--;
		}
	} while (i <= j);

	if (first < j)
		quickSortLeft(array, first, j);
	if (last > i)
		quickSortLeft(array, i, last);
}
void quickSortRight(int *array, int first, int last)
{
	int i = first, j = last, referenceElement = array[last];
	do
	{
		while (array[i] < referenceElement)
			i++;
		while (array[j] > referenceElement)
			j--;
		if (i <= j)
		{
			swap(array[i], array[j]);
			i++;
			j--;
		}
	} while (i <= j);

	if (first < j)
		quickSortLeft(array, first, j);
	if (last > i)
		quickSortLeft(array, i, last);
}
void quickSortMiddle(int *array, int first, int last)
{
	int i = first, j = last, referenceElement = array[(first + last) / 2];
	do
	{
		while (array[i] < referenceElement)
			i++;
		while (array[j] > referenceElement)
			j--;
		if (i <= j)
		{
			swap(array[i], array[j]);
			i++;
			j--;
		}
	} while (i <= j);

	if (first < j)
		quickSortLeft(array, first, j);
	if (last > i)
		quickSortLeft(array, i, last);
}
void quickSortMax(int *array, int first, int last)
{
	int i = first, j = last, middle = (first + last) / 2, max;

	max = max(array[middle], max(array[first], array[last]));

	int referenceElement = array[max];
	do
	{
		while (array[i] < referenceElement)
			i++;
		while (array[j] > referenceElement)
			j--;
		if (i <= j)
		{
			swap(array[i], array[j]);
			i++;
			j--;
		}
	} while (i <= j);

	if (first < j)
		quickSortLeft(array, first, j);
	if (last > i)
		quickSortLeft(array, i, last);
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int arr1[N], arr2[N], arr3[N], arr4[N], count;
	cin >> count;
	createArray(count);
	for (int i = 0; i < count; i++)
	{
		arr1[i] = array[i];
		arr2[i] = array[i];
		arr3[i] = array[i];
		arr4[i] = array[i];
	}
	clock_t time1;
	time1 = clock();
	quickSortLeft(arr1, 0, count - 1);
	time1 = clock() - time1;
	cout << "Время работы быстрой сортировки с крайним левым опорным элементом: ";
	printf("%f\n", (double)time1/ CLOCKS_PER_SEC);
	cout << endl;

	clock_t time2;
	time2 = clock();
	quickSortRight(arr2, 0, count - 1);
	time2 = clock() - time2;
	cout << "Время работы быстрой сортировки с крайним правым опорным элементом: ";
	printf("%f\n", (double)time2 / CLOCKS_PER_SEC);
	cout << endl;

	clock_t time3;
	time3 = clock();
	quickSortMiddle(arr3, 0, count - 1);
	time3 = clock() - time3;
	cout << "Время работы быстрой сортировки с центральным опорным элементом: ";
	printf("%f\n", (double)time3 / CLOCKS_PER_SEC);
	cout << endl;

	clock_t time4;
	time4 = clock();
	quickSortMax(arr4, 0, count - 1);
	time4 = clock() - time4;
	cout << "Время работы быстрой сортировки с максимальным опорным элементом: ";
	printf("%f\n", (double)time4 / CLOCKS_PER_SEC);
	cout << endl;
	return 0;
}

