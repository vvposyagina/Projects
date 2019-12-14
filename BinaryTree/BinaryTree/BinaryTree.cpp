// BinaryTree.cpp: определяет точку входа для консольного приложения.
//

#include <iostream>
#include <fstream>
#include <Windows.h>

using namespace std;

ifstream read("input.txt");

template <typename T, class F> class BinaryTree
{
protected: BinaryTree<T, F> *root, *left, *right;
		   T info;
		   F comp;
public:
	BinaryTree<T, F>(T pinfo, F f, BinaryTree<T, F> *proot = NULL, BinaryTree<T, F> *pleft = NULL, BinaryTree<T, F> *pright = NULL)
	{
		info = pinfo;
		root = proot;
		left = pleft;
		right = pright;
		comp = f;
	}

	BinaryTree<T, F> *AddLeft(T info)
	{
		BinaryTree<T, F> *temp = new BinaryTree<T, F>(info, comp, this, NULL, NULL);
		left = temp;
		return left;
	}

	BinaryTree<T, F> *AddRight(T info)
	{
		BinaryTree<T, F> *temp = new BinaryTree<T, F>(info, comp, this, NULL, NULL);
		right = temp;
		return right;
	}

	BinaryTree<T, F> *UpOnePosition()
	{
		return root;
	}

	void DFS()
	{
		if (this != NULL)
		{
			left->DFS();
			cout << info << " ";
			right->DFS();
		}
	}

	void CreateTree()
	{
		T x;		
		BinaryTree<T, F> *temp1 = this;
		
		while (read >> x)
		{					
				if (comp(info, x) == 0)
				{
					continue;
				}
				else
				if (comp(info, x) == 1)
						if (temp1->left == NULL)
						{				
							temp1 = temp1->AddLeft(x);							
							continue;
						}
						else
							temp1->left->CreateTree();
					else
						if (temp1->right == NULL)
						{
							temp1 = temp1->AddRight(x);
							continue;
						}
						else
							temp1->right->CreateTree();
		}
	}
	
};

int  Compare(int a, int b)
{
	if (a > b)
		return 1;
	if (a == b)
		return 0;
	else
		return -1;
}

int main()
{
	BinaryTree<int, int(*)(int, int)> *newTree = new BinaryTree<int, int(*)(int, int)>(4, &Compare);
	BinaryTree<int, int(*)(int, int)> *left = new BinaryTree<int, int(*)(int, int)>(-1, &Compare);
	BinaryTree<int, int(*)(int, int)> *right = new BinaryTree<int, int(*)(int, int)>(-1, &Compare);

	//left = newTree->AddLeft(5);
	//right = left->AddRight(9);
	//left = left->AddLeft(7);
	//right = newTree->AddRight(8);
	//left = right->AddRight(11);
	//left = right->AddLeft(6);

	//newTree->DFS();
	
	newTree->CreateTree();
	newTree->DFS();


	return 0;
}

