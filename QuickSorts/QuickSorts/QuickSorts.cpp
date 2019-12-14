#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

long int N = 10;
int array[10];

void QuickSort(int *array, int first, int last, int ReferenceElement)
{
	int i = first, j = last, x = ReferenceElement;

	for (; i <= j;)
	{
		for (; array[i] < x; i++);
		for (; array[j] > x; j--);

		if (i <= j)
		{
			if (array[i] > array[j])
			{
				swap(array[i], array[j]);
				i++;
				j--;
			}
		}
	}

	if (i < last)
		QuickSort(array, i, last, ReferenceElement);
	if (first < j)
		QuickSort(array, first, j, ReferenceElement);
}

int SearchMiddleAndFirst(int *array, int element)
{
	int max = array[element];
	if (array[element + 1] > array[max])
	{
		max = array[element + 1];
	}
	return max;
}

int SearchLast(int *array, int last)
{
	int max = array[last];
	if (array[last - 1] > array[max])
	{
		max = array[last - 1];
	}
	return max;
}
int SearchMax(int *array, int middle, int first, int last)
{
	int max, max1, max2, max3; 

	max1 = SearchMiddleAndFirst(array, middle);
	max2 = SearchMiddleAndFirst(array, first);
	max3 = SearchLast(array, last);
	
	if (max1 > max2 && max1 > max3)
	{
		max = max1;
		return max;
	}
	if (max2 > max1 && max2 > max3)
	{
		max = max2;
		return max;
	}
	if (max3 > max1 && max3 > max1)
	{
		max = max3;
		return max;
	}
}

int main()
{
	srand(time(0));
	for (int i = 0; i < N; i++)
	{
		array[i] = rand() % 1000;
		//cout << array[i] << ' ';
	}
	clock_t TimeFirst;
	TimeFirst = clock();
	QuickSort(array, 0, N - 1, SearchMiddleAndFirst(array, 0));
	TimeFirst = clock() - TimeFirst;
	printf("%f\n", (double)TimeFirst / CLOCKS_PER_SEC);
	
	clock_t TimeMiddle;
	TimeMiddle = clock();
	QuickSort(array, 0, N - 1, SearchMiddleAndFirst(array, (N - 1) / 2));
	TimeMiddle = clock() - TimeMiddle;
	printf("%f\n", (double)TimeMiddle / CLOCKS_PER_SEC);

	clock_t TimeLast;
	TimeLast = clock();
	QuickSort(array, 0, N - 1, SearchLast(array, N - 1));
	TimeLast = clock() - TimeLast;
	printf("%f\n", (double)TimeLast / CLOCKS_PER_SEC);

	clock_t TimeMax;
	TimeMax = clock();
	QuickSort(array, 0, N - 1, SearchMax(array,( N - 1 )/ 2, 0, N - 1));
	TimeMax = clock() - TimeMax;
	printf("%f\n", (double)TimeMax / CLOCKS_PER_SEC);
	system("pause");
	return 0;
}




