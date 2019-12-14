// Stack.cpp: определ€ет точку входа дл€ консольного приложени€.
//

#include <iostream>
#include <windows.h>

using namespace std;

struct Element
{
	int info;
	Element *next;
	Element (int pinfo, Element *pnext = NULL)
	{
		info = pinfo;
		next = pnext;
	}
};

class  LinkedList
{	
	public:
		Element *first, *last;
		LinkedList()
		{
			first = NULL;		
			last = NULL;
		}
		int Peek()
		{
			if (first != NULL)
				return first->info;
			else
				return-1;
		}
		int Size()
		{
			int lenght = 0;
			Element *temp = first;
			while (temp != NULL)
			{
				lenght++;
				temp = temp->next;
			}
			return lenght;
		}

};

class Stack : public LinkedList
{
	public :
		Stack()
		{
			last = NULL;
		}
		void Push(int x)
		{
			first = new Element(x, first);
		}
		int Pop()
		{
			if (first != NULL)
			{
				int temp = first->info;
				first = first->next;
				return temp;
			}
			else
				return -1;
		}

		void Print()
		{
			Element * temp = first;
			while (temp != NULL)
			{
				cout << temp->info << " ";
				temp = temp->next;
			}
			cout << endl;
		}
};
class Queue : public LinkedList
{
	public :
		Queue()
		{
			first = NULL;
		}
		void Add(int x)
		{
			first = new Element(x, first);
		}
		void Remove()
		{
			if (first != NULL)
			{
				Element* temp = first;
				while (temp->next->next != NULL)
					temp = temp->next;
				temp->next = NULL;
			}
			else
				cout << "Queque is empty" << endl;
		}
		void Print()
		{
			Element * temp = first;
			while (temp != NULL)
			{
				cout << temp->info << " ";
				temp = temp->next;
			}
			cout << endl;
		}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Stack stack = Stack();
	int countOfStack;
	cout << "¬ведите первоначальное количество элементов в стеке: " << endl;
	cin >> countOfStack;

	int newElement;
	for (int i = 0; i < countOfStack; i++)
	{
		cin >> newElement;
		stack.Push(newElement);
	}

	int lastElement = stack.Pop();
	stack.Print();

	int sizeOfStack = stack.Size();
	cout << sizeOfStack << endl;

	int firstElement = stack.Peek();
	cout << firstElement << endl;

	Queue queue = Queue();
	int countOfQueue;
	cin >> countOfQueue;

	for (int i = 0; i < countOfQueue; i++)
	{
		cin >> newElement;
		queue.Add(newElement);
	}

	queue.Remove();
	queue.Print();

	int sizeOfQueue = queue.Size();
	cout << sizeOfQueue << endl;

	firstElement = queue.Peek();
	cout << firstElement << endl;

	return 0;
}

