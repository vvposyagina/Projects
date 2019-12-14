// Линейный список (к экзамену).cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
using namespace std;
struct E
{
	int info;
	E * next, * prev;
	E(int x, E * pnext = NULL, E * pprev = NULL)
	{
		info = x;
		next = pnext;
		prev = pprev;
	}
};

class List
{
public:
	E * first; 
	E * last;
public:
	List(){first = NULL;}
	
	~List()
	{
		for(;first != NULL; first = last)
		{
			last = first -> next;
			delete first;
		}
	}

	void Print()
	{
		for(E * link = first; link != NULL; link = link -> next)
		{
			cout<<link->info<<" ";
		}
		cout<<endl;
	}

	void Rec_Print()
	{
		Rec_Print(first);
	}

	void Rec_Print(E * link)
	{
		if(link != NULL)
		{
			Rec_Print(link -> next);
			cout<<link -> info<<" ";	
		}
	}


	void Add_First(int x)
	{
		if(last != NULL)
		{
			E * link = new E(x,first);
			first -> prev = link;
			first = link;
		}
		else
		{
			first = new E(x,first);
			last = first;
		}
	}

	void Add_Last(int x)
	{
		if(last != NULL)
		{
			E * link = new E(x);
			last -> next = link;
			link -> prev = last;
			last = link;
		}
		else
			Add_First(x);
	}

	E * Search(int x)
	{
		for(E * link = first; link != NULL; link = link -> next)
			if(link -> info == x)
				return link;
		return NULL;
	}

	void Sort()
	{
		E * p , * q = first;
		for( q = first; q != NULL; q = q -> next)
			for( p = first; p -> next != NULL; p = p -> next)
				if(p -> info > p -> next -> info)
					swap(p->info, p->next->info);
	}

};

int _tmain(int argc, _TCHAR* argv[])
{
	List Table;
	for(int i = 0; i < 17; i+=2)
		Table.Add_Last(i);
	for(int i = 1; i < 18; i+=2)
		Table.Add_Last(i);

	Table.Print();
	Table.Sort();
	Table.Print();
	cout<<Table.Search(5)<<endl;

	return 0;
}

