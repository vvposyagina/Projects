// Двоичное дерево.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <queue>
using namespace std;

struct Node
{
	int info;
	Node * left, * right, * parent;
	Node(int pinfo, Node * l = NULL, Node * r = NULL, Node * p = NULL)
	{
		info = pinfo;
		right = r;
		left = l;
		parent = p;
	}

	void Print() {
		cout<<info<<" ";
	}
};

class Tree
{
	Node * root;
public:
	Tree() {
		root = NULL;
	}

	void PrintTree()
	{
		PrintTree(root);
		cout<<endl;
	}

	void PrintTree(Node * link) // Печать дерева обходом в глубину
	{
		if(link!=NULL)
		{
			PrintTree(link->left);
			link->Print();
			PrintTree(link->right);
		}
	}

	void PrintByLevel() // Печать дерева обходом в ширину
	{
		PrintByLevel(root);
		cout<<endl;
	}

	void PrintByLevel(Node * link)
	{
		queue <Node *> q;
		if(link == NULL)
			return;
		q.push(link);
		for(;!q.empty();)
		{
			Node * temp = q.front();
			q.pop();
			temp->Print();
			if(temp->left != NULL)
				q.push(temp->left);
			if(temp->right != NULL)
				q.push(temp->right);
		}
	}

	int Level()
	{
		return Level(root);
	}

	int Level(Node * link)
	{
		if(link == NULL)
			return 0;
		else
			return max(Level(link->left),Level(link->right))+1;
	}

	bool Add_Node(int x)
	{
		return Add_Node(x, root);
	}

	bool Add_Node(int x, Node *& link) // Добавление узла по принципу глубины
	{
		if(link == NULL)
		{
			link = new Node(x);
			return true;
		}
		else
		{
			if(x > link -> info)
				Add_Node(x, link -> right);
			else
				if(x < link -> info)
					Add_Node(x, link -> left);
				else
					if( x == link -> info)
						return false;
		}
	}

	Node * Find(int x)
	{
		return Find(x,root);
	}

	Node * Find(int x, Node * link)
	{
		if(link==NULL)
			return NULL;
		if(link -> info == x)
			return link;
		Node * p = Find(x, link -> left);
		if(p != NULL)
			return p;
		return Find(x, link -> right);
	}
};

int _tmain(int argc, _TCHAR* argv[])
{
	Tree Derevo;
	Derevo.Add_Node(5);
	Derevo.Add_Node(4);
	Derevo.Add_Node(6);
	Derevo.Add_Node(2);
	Derevo.Add_Node(3);
	Derevo.Add_Node(1);
	Derevo.PrintByLevel();
	Derevo.PrintTree();
	cout<<Derevo.Level()<<endl;
	cout<<Derevo.Find(2)<<endl;
	return 0;
}

