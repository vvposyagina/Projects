using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCSharp
{
    class BinaryTree<T>
    {
        public delegate int F(T x, T y);
        protected BinaryTree<T> root, left, right;
        protected T info;
        protected F comp;

        
        public BinaryTree(T pinfo, F f, BinaryTree<T> proot = null, BinaryTree<T> pleft = null, BinaryTree<T> pright = null)
        {
            info = pinfo;
            root = proot;
            left = pleft;
            right = pright;
            comp = f;
        }
        public BinaryTree(F f)
        {
            comp = f;
        }
        public BinaryTree<T> AddLeft(T info)
        {
            BinaryTree<T> temp = new BinaryTree<T>(info, comp, this, null, null);
            left = temp;
            return left;
        }

        public BinaryTree<T> AddRight(T info)
        {
            BinaryTree<T> temp = new BinaryTree<T>(info, comp, this, null, null);
            right = temp;
            return right;
        }

        public BinaryTree<T> UpOnePosition()
        {
            return root;
        }

        public void DFS()
        {
            if (this != null)
            {
                left.DFS();
                Console.Write(info + " ");
                right.DFS();
            }
        }

        public void CreateTree(T x)
        {
            if (comp(info, x) == 0)
            {
                return;
            }
            else
                if (comp(info, x) == 1)
                    if (this.left == null)
                    {
                        this.AddLeft(x);
                    }
                    else
                        this.left.CreateTree(x);
                else
                    if (this.right == null)
                    {
                        this.AddRight(x);
                    }
                    else
                        this.right.CreateTree(x);
        }
    }
}