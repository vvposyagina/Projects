// SequenceStatistics.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <algorithm>
#include <fstream>
#include <Windows.h>
#include <string>

using namespace std;

ifstream read("list.txt");
struct post
{
	int id;
	int like;
	string text;
};
bool compare(post a, post b)
{
	return (a.like < b.like);
}

const int N = 10000;

void sequenceStatitics(post *arr, int count, int begin, int end, int needed, int &idElement, string &postElement, int &likeElement)
{
	sort(arr, arr + count, compare);
}
void createArray(post *arr, int count)
{
	for (int i = 0; i < count; i++)
	{
		arr[i].id = i + 1;
		arr[i].like = rand() % 1000;
		getline(read, arr[i].text);

	}
}

post sequenceStatistics(post *arr, int begin, int end, int needed, int &idElement, string &postElement, int &likeElement)
{
	int state = (begin + end) / 2;
	int likeState = arr[state].like;
	int i = begin, j = end;
	while (i <= j)
	{
		while (arr[i].like < likeState) i++;
		while (arr[j].like > likeState) j--;

		if (i <= j)
		{
			swap(arr[i].like, arr[j].like);
			swap(arr[i].id, arr[j].id);
			i++;
			j--;
		}
	}
	if (begin <= needed && needed <= j)
		return sequenceStatistics(arr, begin, j, needed, idElement, postElement, likeElement);
		
	if (i <= needed && needed <= end)
		return sequenceStatistics(arr, i, end, needed, idElement, postElement, likeElement);
		
	idElement = arr[needed].id;	
	postElement = arr[needed].text;
	likeElement = arr[needed].like;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int idElement = 0, likeElement = 0;
	string postElement;
	post library[N], result;
	int count, needed;
	cout << "Введите размерность массива: " << endl;
	cin >> count;
	cout << "Введите номер искомого элемента: " << endl;
	cin >> needed;
	createArray(library, count);

	sequenceStatitics(library, count, 0, count - 1, needed, idElement, postElement, likeElement);

	cout << "ID искомого поста: " << library[needed].id << endl << library[needed].text << endl << "Количество лайков: " << library[needed].like << endl << endl;
	cout << "ID поста с максимальным количеством лайков: " << library[count - 1].id << endl << library[count - 1].text << endl << "Количество лайков: " << library[count - 1].like << endl << endl;
	cout << "ID поста с минимальным количеством лайков: " << library[0].id << endl << library[0].text << endl << "Количество лайков: " << library[0].like << endl << endl;
	return 0;
}

