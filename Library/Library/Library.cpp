
// Library.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <fstream>
#include <string>
#include <algorithm>
#include <vector>
#include <Windows.h>

#pragma warning(disable:4996)


using namespace std;

string NameOfFileInput, NameOfFileOutput;

ifstream read(NameOfFileInput);
ofstream write(NameOfFileOutput);

struct book
{
	int id;
	string name;
	string author;
	int year;
};

vector<book> books;
book MakeStruct(string str)
{
	book NewBook;
	string temp;
	int i = 0;
	while (str[i] != ';')
	{
		temp += str[i];
		i++;
	}
	NewBook.id = atoi(temp.c_str());
	temp = "";
	i += 2;
	while (str[i] != ';')
	{

		NewBook.name += str[i];
		i++;
	}
	i += 2;
	while (str[i] != ';')
	{
		NewBook.author += str[i];
		i++;
	}
	i += 2;
	while (str[i] != ';')
	{
		temp += str[i];
		i++;
	}
	NewBook.year = atoi(temp.c_str());
	return NewBook;
}
void AddFromFile(string str)
{
	book NewElement = MakeStruct(str);
	books.push_back(NewElement);
}
void AddFromConsole(int id, string name, string author, int year)
{
	book NewElement;
	NewElement.id = id;
	NewElement.name = name;
	NewElement.author = author;
	NewElement.year = year;
	books.push_back(NewElement);
}
void Save()
{
	int count = books.size();
	for (int i = 0; i < count; i++)
	{
		write << books[i].id << "; " << books[i].name << "; " << books[i].author << "; " << books[i].year << ";" << endl;
	}
}

void DownLoad()
{
	string str;
	//while (getline(read, str))
	while (!read.eof())
	{
		getline(read, str);
		AddFromFile(str);
	}
}
void Search(int id, string name, string author, int year)
{
	bool FindId = 0, FindName = 0, FindAuthor = 0, FindYear = 0;
	int temp = -1;
	for (int i = 0; i < books.size(); i++)
	{		
		if (books[i].id == id || id == 0)
		{
			FindId = 1;
		}
		if (books[i].year == year || year == 0)
		{
			FindYear = 1;
		}
		int resFind = books[i].name.find(name);

		if (resFind != -1 || name[0] == '0')
		{
			FindName = 1;
		}

		resFind = books[i].author.find(author);

		if (resFind != -1 || author[0] == '0')
		{
			FindAuthor = 1;
		}

		if (year == 0 && id == 0 && name[0] == '0' && author[0] == '0')
		{
			continue;
		}
		else if (FindId && FindYear && FindName && FindAuthor)
		{
			cout << books[i].id << "; " << books[i].name << "; " << books[i].author << "; " << books[i].year << ";" << endl;
			temp = 1;
		}
		else
		{
			continue;
		}
		FindId = 0, FindName = 0, FindAuthor = 0, FindYear = 0;		
	}
	if (temp < 0)
	{
		cout << "Ничего не найдено" << endl;
	}
}
void Remove(int id, string name, string author, int year)
{
	bool FindId = 0, FindName = 0, FindAuthor = 0, FindYear = 0;
	for (int i = 0; i < books.size(); i++)
	{
		if (books[i].id == id || id == 0)
		{
			FindId = 1;
		}
		if (books[i].year == year || year == 0)
		{
			FindYear = 1;
		}
		int resFind = books[i].name.find(name);

		if (resFind != -1 || name[0] == '0')
		{
			FindName = 1;
		}

		resFind = books[i].author.find(author);

		if (resFind != -1 || author[0] == '0')
		{
			FindAuthor = 1;
		}
		
		if (FindId && FindYear && FindName && FindAuthor)
		{
			books.erase(books.begin() + i);
		}
		
		FindId = 0, FindName = 0, FindAuthor = 0, FindYear = 0;
	}
	
}
void Process()
{
	int sign;
	string temp;
	while (cin >> sign)
	{
		while (sign > 0 && sign <= 5)
		{
			if (sign == 1)
			{
				cout << "Введите имя файла ввода: " << endl;
				cin >> NameOfFileInput;
				read.open(NameOfFileInput);
				DownLoad();
				cout << "Библиотека успешно загружена." << endl;
				break;
			}
			if (sign == 2)
			{
				int id, year;
				string name, author;
				cout << "Если вы хотите оставить поле пустым, введите 0" << endl;
				cout << "Введите id: " << endl;
				cin >> id;
				getline(cin, name);
				cout << "Введите название книги: " << endl;
				getline(cin, name);
				cout << "Введите имя автора: " << endl;
				getline(cin, author);
				cout << "Введите год создания: " << endl;
				cin >> year;
				Search(id, name, author, year);
				break;
			}
			if (sign == 3)
			{
				int id, year;
				string name, author;
				cout << "Введите id: " << endl;
				cin >> id;
				getline(cin, name);
				cout << "Введите название книги: " << endl;
				getline(cin, name);
				cout << "Введите имя автора: " << endl;
				getline(cin, author);
				cout << "Введите год создания: " << endl;
				cin >> year;
				AddFromConsole(id, name, author, year);
				break;
			}
			if (sign == 4)
			{
				int id, year;
				string name, author;
				cout << "Введите id: " << endl;
				cin >> id;
				getline(cin, name);
				cout << "Введите название книги: " << endl;
				getline(cin, name);
				cout << "Введите имя автора: " << endl;
				getline(cin, author);
				cout << "Введите год создания: " << endl;
				cin >> year;
				Remove(id, name, author, year);
				break;
			}
			if (sign == 5)
			{
				cout << "Введите имя файла вывода: " << endl;
				cin >> NameOfFileOutput;
				write.open(NameOfFileOutput);
				Save();
				break;
			}


		}
		if (sign == 0)
		{
			cout << "Программа завершила работу" << endl;
		}
	}

}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	cout << "Добро пожаловать в программу. Выберите команду:" << endl;
	cout << endl;
	cout << "1 - Загрузить библиотеку" << endl;
	cout << "2 - Поиск" << endl;
	cout << "3 - Добавить новый элемент библиотеки" << endl;
	cout << "4 - Удалить элемент" << endl;
	cout << "5 - Сохранить изменения" << endl;

	Process();


	return 0;
}