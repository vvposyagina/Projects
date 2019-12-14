using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public enum operation {NOT, AND, OR, XOR, EQ, IM, RBL, RBR, ERROR}
    class Bdd
    {
        string NameVariable;
        int RankVariable;
        Bdd Zero, One;
        NodeValueFunction ZeroValue, OneValue;
        List<Bdd> parents;
        List<NodeValueFunction> used = new List<NodeValueFunction>();
        Dictionary<int, Tuple<Bdd, Bdd, Bdd, operation>> BddInProcess;
        Dictionary<Bdd, string> allFunction;
        const int SIZE_OF_VERTEX = 30;
        static int countOfOperation = 1;
        string function = "";
        bool isConst = false;
        public Bdd()
        {
            parents = new List<Bdd>();
            BddInProcess = new Dictionary<int, Tuple<Bdd, Bdd, Bdd, operation>>();
            allFunction = new Dictionary<Bdd, string>();
        }
        public Bdd(Bdd prevBdd)
        {
            NameVariable = prevBdd.NameVariable;
            RankVariable = prevBdd.RankVariable;
            if (prevBdd.Zero != null)
            {
                Zero = new Bdd(prevBdd.Zero);
                ConnectToParent(Zero);
            }
            else
            {
                Zero = null;
            }
            if (prevBdd.One != null)
            {
                One = new Bdd(prevBdd.One);
                ConnectToParent(One);
            }
            else
            {
                One = null;
            }
            if (prevBdd.ZeroValue != null)
            {
                ZeroValue = new NodeValueFunction(prevBdd.ZeroValue);
            }
            else
            {
                ZeroValue = null;
            }
            if (prevBdd.OneValue != null)
            {
                OneValue = new NodeValueFunction(prevBdd.OneValue);
            }
            else
            {
                OneValue = null;
            }
            parents = new List<Bdd>();
            BddInProcess = prevBdd.BddInProcess;
            allFunction = new Dictionary<Bdd, string>();
        }
        public void ConnectToParent(Bdd bdd)
        {
            if (bdd.Zero != null)
            {
                bdd.Zero.parents.Add(bdd);
            }
            if (bdd.One != null)
            {
                bdd.One.parents.Add(bdd);
            }
        }
        public Bdd(string name, int rank, Bdd z = null, Bdd o = null, NodeValueFunction zv = null, NodeValueFunction ov = null)
        {
            NameVariable = name;
            RankVariable = rank;
            Zero = z;
            One = o;
            ZeroValue = zv;
            OneValue = ov;
            parents = new List<Bdd>();
            BddInProcess = new Dictionary<int, Tuple<Bdd, Bdd, Bdd, operation>>();
            allFunction = new Dictionary<Bdd, string>();
        }        
        public Dictionary<int, Tuple<Bdd, Bdd, Bdd, operation>> ListBddInProcess
        {
           get {return BddInProcess;}
        }
        private Dictionary<int, List<Tuple<Bdd, int>>> GetNodesOnLevel(Bdd root)
        {            
            Dictionary<int, List<Tuple<Bdd, int>>> list = new Dictionary<int, List<Tuple<Bdd, int>>>();
            Queue<Bdd> q1 = new Queue<Bdd>();
            Queue<Bdd> q2 = new Queue<Bdd>();
            q1.Enqueue(root);
            int level = root.RankVariable;
            int order = 1;
            list.Add(level, new List<Tuple<Bdd, int>>());            
            list[level].Add(Tuple.Create<Bdd, int>(root, order));            
            level++;
            while(q1.Count > 0)
            {
                order = 1;
                list.Add(level, new List<Tuple<Bdd, int>>());  
                for(int i = 0; i < q1.Count; i++)
                {
                    Bdd tempBdd = q1.Dequeue();
                    if(tempBdd.One != null)
                    {
                        q2.Enqueue(tempBdd.One);
                        list[level].Add(Tuple.Create<Bdd, int>(tempBdd.One, order));
                    }
                    order++;
                    if(tempBdd.Zero != null)
                    {
                        q2.Enqueue(tempBdd.Zero);
                        list[level].Add(Tuple.Create<Bdd, int>(tempBdd.Zero, order));
                    }
                    order++;
                }
                q1 = new Queue<Bdd>(q2);
                q2.Clear();
                level++;
            }
            return list;
        }
        public Bdd GlueBDD(Bdd first, Bdd second, operation op)
        {
            Bdd newBdd = null;
                switch (op)
                {
                    case operation.AND:
                        if (first.RankVariable < second.RankVariable)
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null)
                            {
                                if (first.ZeroValue.Value)
                                {
                                    newBdd.Zero = new Bdd(second);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.ZeroValue = newZero;
                                }
                            }
                            if (first.OneValue != null)
                            {
                                if (first.OneValue.Value)
                                {
                                    newBdd.One = new Bdd(second);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.OneValue = newZero;
                                }
                            }
                        }
                        else if (first.RankVariable > second.RankVariable)
                        {
                            newBdd = new Bdd(second.NameVariable, second.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(second.One, first, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(second.Zero, first, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (second.ZeroValue != null)
                            {
                                if (second.ZeroValue.Value)
                                {
                                    newBdd.Zero = new Bdd(first);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.ZeroValue = newZero;
                                }
                            }
                            if (second.OneValue != null)
                            {
                                if (second.OneValue.Value)
                                {
                                    newBdd.One = new Bdd(first);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.OneValue = newZero;
                                }
                            }
                        }
                        else
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null && second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second.One, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null && second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second.Zero, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null && second.Zero != null)
                            {
                                if (first.ZeroValue.Value)
                                {
                                    newBdd.Zero = new Bdd(second.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.ZeroValue = newZero;
                                }
                            }
                            if (first.ZeroValue != null && second.ZeroValue != null)
                            {
                                if (first.ZeroValue.Value && second.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                                else
                                {
                                    newBdd.ZeroValue = newZero;
                                }
                            }
                            if (first.Zero != null && second.ZeroValue != null)
                            {
                                if (second.ZeroValue.Value)
                                {
                                    newBdd.Zero = new Bdd(first.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.ZeroValue = newZero;
                                }
                            }
                            if (first.OneValue != null && second.One != null)
                            {
                                if (first.OneValue.Value)
                                {
                                    newBdd.One = new Bdd(second.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.OneValue = newZero;
                                }
                            }
                            if (first.OneValue != null && second.OneValue != null)
                            {
                                if (first.OneValue.Value && second.OneValue.Value)
                                {
                                    newBdd.OneValue = newOne;
                                }
                                else
                                {
                                    newBdd.OneValue = newZero;
                                }
                            }
                            if (first.One != null && second.OneValue != null)
                            {
                                if (second.OneValue.Value)
                                {
                                    newBdd.One = new Bdd(first.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.OneValue = newZero;
                                }
                            }
                        }
                        break;
                    case operation.OR:
                        if (first.RankVariable < second.RankVariable)
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null)
                            {
                                if (first.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(second);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (first.OneValue != null)
                            {
                                if (first.OneValue.Value)
                                {
                                    newBdd.OneValue = newOne;
                                }
                                else
                                {
                                    newBdd.One = new Bdd(second);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        else if (first.RankVariable > second.RankVariable)
                        {
                            newBdd = new Bdd(second.NameVariable, second.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(second.One, first, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(second.Zero, first, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (second.ZeroValue != null)
                            {
                                if (second.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(first);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (second.OneValue != null)
                            {
                                if (second.OneValue.Value)
                                {
                                    newBdd.OneValue = newOne;
                                }
                                else
                                {
                                    newBdd.One = new Bdd(first);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        else
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null && second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second.One, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null && second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second.Zero, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null && second.Zero != null)
                            {
                                if (first.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(second.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (first.ZeroValue != null && second.ZeroValue != null)
                            {
                                if (!first.ZeroValue.Value && !second.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newZero;
                                }
                                else
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                            }
                            if (first.Zero != null && second.ZeroValue != null)
                            {
                                if (second.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(first.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (first.OneValue != null && second.One != null)
                            {
                                if (first.OneValue.Value)
                                {
                                    newBdd.OneValue = newOne;
                                }
                                else
                                {
                                    newBdd.One = new Bdd(second.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                            if (first.OneValue != null && second.OneValue != null)
                            {
                                if (!first.OneValue.Value && !second.OneValue.Value)
                                {
                                    newBdd.OneValue = newZero;
                                }
                                else
                                {
                                    newBdd.OneValue = newOne;
                                }
                            }
                            if (first.One != null && second.OneValue != null)
                            {
                                if (second.OneValue.Value)
                                {
                                    newBdd.OneValue = newOne;
                                }
                                else
                                {
                                    newBdd.One = new Bdd(first.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        break;
                    case operation.XOR:
                        if (first.RankVariable < second.RankVariable)
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null)
                            {
                                if (first.ZeroValue.Value)
                                {
                                    newBdd.Zero = InverseBDD(second, new Bdd());
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(second);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (first.OneValue != null)
                            {
                                if (first.OneValue.Value)
                                {
                                    newBdd.One = InverseBDD(second, new Bdd());
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.One = new Bdd(second);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        else if (first.RankVariable > second.RankVariable)
                        {
                            newBdd = new Bdd(second.NameVariable, second.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(second.One, first, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(second.Zero, first, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (second.ZeroValue != null)
                            {
                                if (second.ZeroValue.Value)
                                {
                                    newBdd.Zero = InverseBDD(first, new Bdd());
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(first);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (second.OneValue != null)
                            {
                                if (second.OneValue.Value)
                                {
                                    newBdd.One = InverseBDD(first, new Bdd());
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.One = new Bdd(first);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        else
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null && second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second.One, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null && second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second.Zero, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null && second.Zero != null)
                            {
                                if (first.ZeroValue.Value)
                                {
                                    newBdd.Zero = InverseBDD(second.Zero, new Bdd());
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(second.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (first.ZeroValue != null && second.ZeroValue != null)
                            {
                                if (!first.ZeroValue.Value && second.ZeroValue.Value || first.ZeroValue.Value && !second.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                                else
                                {
                                    newBdd.ZeroValue = newZero;
                                }
                            }
                            if (first.Zero != null && second.ZeroValue != null)
                            {
                                if (second.ZeroValue.Value)
                                {
                                    newBdd.Zero = InverseBDD(first.Zero, new Bdd());
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(first.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (first.OneValue != null && second.One != null)
                            {
                                if (first.OneValue.Value)
                                {
                                    newBdd.One = InverseBDD(second.One, new Bdd());
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.One = new Bdd(second.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                            if (first.OneValue != null && second.OneValue != null)
                            {
                                if (!first.OneValue.Value && second.OneValue.Value || first.OneValue.Value && !second.OneValue.Value)
                                {
                                    newBdd.OneValue = newOne;
                                }
                                else
                                {
                                    newBdd.OneValue = newZero;
                                }
                            }
                            if (first.One != null && second.OneValue != null)
                            {
                                if (second.OneValue.Value)
                                {
                                    newBdd.One = InverseBDD(first.One, new Bdd());
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.One = new Bdd(first.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        break;
                    case operation.EQ:
                        if (first.RankVariable < second.RankVariable)
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null)
                            {
                                if (!first.ZeroValue.Value)
                                {
                                    newBdd.Zero = InverseBDD(second, new Bdd());
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(second);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (first.OneValue != null)
                            {
                                if (!first.OneValue.Value)
                                {
                                    newBdd.One = InverseBDD(second, new Bdd());
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.One = new Bdd(second);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        else if (first.RankVariable > second.RankVariable)
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(second.One, first, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(second.Zero, first, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (second.ZeroValue != null)
                            {
                                if (!second.ZeroValue.Value)
                                {
                                    newBdd.Zero = InverseBDD(first, new Bdd());
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(first);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (second.OneValue != null)
                            {
                                if (!second.OneValue.Value)
                                {
                                    newBdd.One = InverseBDD(first, new Bdd());
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.One = new Bdd(first);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        else
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null && second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second.One, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null && second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second.Zero, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null && second.Zero != null)
                            {
                                if (!first.ZeroValue.Value)
                                {
                                    newBdd.Zero = InverseBDD(second.Zero, new Bdd());
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(second.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (first.ZeroValue != null && second.ZeroValue != null)
                            {
                                if (!first.ZeroValue.Value && !second.ZeroValue.Value || first.ZeroValue.Value && second.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                                else
                                {
                                    newBdd.ZeroValue = newZero;
                                }
                            }
                            if (first.Zero != null && second.ZeroValue != null)
                            {
                                if (!second.ZeroValue.Value)
                                {
                                    newBdd.Zero = InverseBDD(first.Zero, new Bdd());
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.Zero = new Bdd(first.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (first.OneValue != null && second.One != null)
                            {
                                if (!first.OneValue.Value)
                                {
                                    newBdd.One = InverseBDD(second.One, new Bdd());
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.One = new Bdd(second.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                            if (first.OneValue != null && second.OneValue != null)
                            {
                                if (!first.OneValue.Value && !second.OneValue.Value || first.OneValue.Value && second.OneValue.Value)
                                {
                                    newBdd.OneValue = newOne;
                                }
                                else
                                {
                                    newBdd.OneValue = newZero;
                                }
                            }
                            if (first.One != null && second.OneValue != null)
                            {
                                if (!second.OneValue.Value)
                                {
                                    newBdd.One = InverseBDD(first.One, new Bdd());
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.One = new Bdd(first.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        break;
                    case operation.IM:
                        if (first.RankVariable < second.RankVariable)
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null)
                            {
                                if (first.ZeroValue.Value)
                                {
                                    newBdd.Zero = new Bdd(second);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                            }
                            if (first.OneValue != null)
                            {
                                if (first.OneValue.Value)
                                {
                                    newBdd.One = new Bdd(second);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.OneValue = newOne;
                                }
                            }
                        }
                        else if (first.RankVariable > second.RankVariable)
                        {
                            newBdd = new Bdd(second.NameVariable, second.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first, second.One, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first, second.Zero, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (second.ZeroValue != null)
                            {
                                if (second.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                                else
                                {
                                    newBdd.Zero = InverseBDD(first, new Bdd());
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                            }
                            if (second.OneValue != null)
                            {
                                if (second.OneValue.Value)
                                {
                                    newBdd.OneValue = newOne;
                                }
                                else
                                {
                                    newBdd.One = InverseBDD(first, new Bdd());
                                    newBdd.One.parents.Add(newBdd);
                                }
                            }
                        }
                        else
                        {
                            newBdd = new Bdd(first.NameVariable, first.RankVariable);
                            NodeValueFunction newZero = new NodeValueFunction(false);
                            NodeValueFunction newOne = new NodeValueFunction(true);
                            if (first.One != null && second.One != null)
                            {
                                newBdd.One = new Bdd(GlueBDD(first.One, second.One, op));
                                ConnectToParent(newBdd.One);
                                newBdd.One.parents.Add(newBdd);
                            }
                            if (first.Zero != null && second.Zero != null)
                            {
                                newBdd.Zero = new Bdd(GlueBDD(first.Zero, second.Zero, op));
                                ConnectToParent(newBdd.Zero);
                                newBdd.Zero.parents.Add(newBdd);
                            }
                            if (first.ZeroValue != null && second.Zero != null)
                            {
                                if (first.ZeroValue.Value)
                                {
                                    newBdd.Zero = new Bdd(second.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                            }
                            if (first.ZeroValue != null && second.ZeroValue != null)
                            {
                                if (first.ZeroValue.Value && !second.ZeroValue.Value)
                                {
                                    newBdd.ZeroValue = newZero;
                                }
                                else
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                            }
                            if (first.Zero != null && second.ZeroValue != null)
                            {
                                if (second.ZeroValue.Value)
                                {
                                    newBdd.Zero = new Bdd(first.Zero);
                                    ConnectToParent(newBdd.Zero);
                                    newBdd.Zero.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.ZeroValue = newOne;
                                }
                            }
                            if (first.OneValue != null && second.One != null)
                            {
                                if (first.OneValue.Value)
                                {
                                    newBdd.One = new Bdd(second.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.OneValue = newOne;
                                }
                            }
                            if (first.OneValue != null && second.OneValue != null)
                            {
                                if (first.OneValue.Value && !second.OneValue.Value)
                                {
                                    newBdd.OneValue = newZero;
                                }
                                else
                                {
                                    newBdd.OneValue = newOne;
                                }
                            }
                            if (first.One != null && second.OneValue != null)
                            {
                                if (second.OneValue.Value)
                                {
                                    newBdd.One = new Bdd(first.One);
                                    ConnectToParent(newBdd.One);
                                    newBdd.One.parents.Add(newBdd);
                                }
                                else
                                {
                                    newBdd.OneValue = newOne;
                                }
                            }
                        }
                        break;
                
            }
            return newBdd;
        }
        ////public Bdd InverseBDD(Bdd bdd)
        ////{
        ////    used.Clear();
        ////    return InverseBDDFunc(bdd);
        ////}
        private Bdd InverseBDD(Bdd bdd, Bdd newBdd)
        {
            if(bdd != null)
            {
                newBdd.RankVariable = bdd.RankVariable;
                newBdd.NameVariable = bdd.NameVariable;
                if (bdd.ZeroValue != null)
                {
                    NodeValueFunction newZeroValue = new NodeValueFunction(!bdd.ZeroValue.Value);
                    newBdd.ZeroValue = newZeroValue;
                }
                if (bdd.OneValue != null)
                {
                    NodeValueFunction newOneValue = new NodeValueFunction(!bdd.OneValue.Value);
                    newBdd.OneValue = newOneValue;
                }
                if(bdd.Zero != null)
                {
                    newBdd.Zero = InverseBDD(bdd.Zero, newBdd.Zero);
                    newBdd.Zero.parents.Add(newBdd);
                }
                if (bdd.One != null)
                {
                    newBdd.One = InverseBDD(bdd.One, newBdd.One);
                    newBdd.One.parents.Add(newBdd);
                }
            }
            return newBdd;
        }        
        //private Bdd InverseBDDFunc(Bdd bdd)
        //{
        //    if (bdd.One != null)
        //    {
        //        InverseBDDFunc(bdd.One);
        //    }
        //    if (bdd.Zero != null)
        //    {
        //        InverseBDDFunc(bdd.Zero);
        //    }
        //    if (bdd.OneValue != null && !used.Contains(bdd.OneValue))
        //    {
        //        bdd.OneValue.Value = !bdd.OneValue.Value;
        //        used.Add(bdd.OneValue);
        //    }
        //    if (bdd.ZeroValue != null && !used.Contains(bdd.ZeroValue))
        //    {
        //        bdd.ZeroValue.Value = !bdd.ZeroValue.Value;
        //        used.Add(bdd.ZeroValue);
        //    }
        //    return bdd;
        //}
        private void ProcessOperation(Stack<Bdd> bdd, operation op, Stack<string> operands, string operate)
        {
            Bdd right;
            Bdd left;
            operate = GetUserSymbol(operate);
            string leftStr, rightStr, formula = "";
            Bdd newBDD;
            if (op == operation.NOT)
            {
                left = bdd.Pop();
                leftStr = operands.Pop();
                if (leftStr.Length > 2)
                {
                    leftStr = "(" + leftStr + ")";
                }
                formula = operate + leftStr;
                newBDD = InverseBDD(left, new Bdd());                
                newBDD.function = formula;
                operands.Push(formula);
                BddInProcess.Add(countOfOperation, Tuple.Create<Bdd, Bdd, Bdd, operation>(left, null, newBDD, operation.NOT));
                bdd.Push(BddInProcess[countOfOperation].Item3);
                allFunction.Add(BddInProcess[countOfOperation].Item3, formula);
            }
            else
            {
                right = bdd.Pop();
                left = bdd.Pop();
                rightStr = operands.Pop();
                leftStr = operands.Pop();
                if (leftStr.Length > 2)
                {
                    leftStr = "(" + leftStr + ")";
                }
                if (rightStr.Length > 2)
                {
                    rightStr = "(" + rightStr + ")";
                }
                formula = leftStr + " " + operate + " " + rightStr;
                operands.Push(formula);
                switch (op)
                {
                    case operation.AND:
                        newBDD = GlueBDD(left, right, operation.AND);
                        DeleteAllNodesWithSameResults(newBDD);
                        DeleteAllSameSubtree(newBDD);
                        DeleteAllNodesWithSameOneAndZeroNodes(newBDD);
                        BddInProcess.Add(countOfOperation, Tuple.Create<Bdd, Bdd, Bdd, operation>(left, right, newBDD, operation.AND));
                        bdd.Push(newBDD);
                        break;
                    case operation.OR:
                        newBDD = GlueBDD(left, right, operation.OR);
                        DeleteAllNodesWithSameResults(newBDD);
                        DeleteAllSameSubtree(newBDD);
                        DeleteAllNodesWithSameOneAndZeroNodes(newBDD);
                        BddInProcess.Add(countOfOperation, Tuple.Create<Bdd, Bdd, Bdd, operation>(left, right, newBDD, operation.OR));
                        bdd.Push(newBDD);
                        break;
                    case operation.XOR:
                        newBDD = GlueBDD(left, right, operation.XOR);
                        DeleteAllNodesWithSameResults(newBDD);
                        DeleteAllSameSubtree(newBDD);
                        DeleteAllNodesWithSameOneAndZeroNodes(newBDD);
                        BddInProcess.Add(countOfOperation, Tuple.Create<Bdd, Bdd, Bdd, operation>(left, right, newBDD, operation.XOR));
                        bdd.Push(newBDD);
                        break;
                    case operation.IM:
                        newBDD = GlueBDD(left, right, operation.IM);
                        DeleteAllNodesWithSameResults(newBDD);
                        DeleteAllSameSubtree(newBDD);
                        DeleteAllNodesWithSameOneAndZeroNodes(newBDD);
                        BddInProcess.Add(countOfOperation, Tuple.Create<Bdd, Bdd, Bdd, operation>(left, right, newBDD, operation.IM));
                        bdd.Push(newBDD);
                        break;
                    case operation.EQ:
                        newBDD = GlueBDD(left, right, operation.EQ);
                        DeleteAllNodesWithSameResults(newBDD);
                        DeleteAllSameSubtree(newBDD);
                        DeleteAllNodesWithSameOneAndZeroNodes(newBDD);
                        BddInProcess.Add(countOfOperation, Tuple.Create<Bdd, Bdd, Bdd, operation>(left, right, newBDD, operation.EQ));
                        bdd.Push(newBDD);
                        break;
                }
                allFunction.Add(BddInProcess[countOfOperation].Item3, formula);
            }
            countOfOperation++;
        }
        public Bdd BuildBddOnFormula(string formula, string[] order)
        {
            Stack<Bdd> stBdd = new Stack<Bdd>();
            Stack<operation> operators = new Stack<operation>();
            Stack<string> operandsStr = new Stack<string>();
            Stack<string> operatorsStr = new Stack<string>();
            Dictionary<string, int> orderVar = GetOrder(order);
            for (int i = 0; i < formula.Length; i++)
            {
                if (!IsDelimeter(formula[i]))
                {
                    if (formula[i] == '(')
                    {
                        operators.Push(operation.RBL);
                        operatorsStr.Push("(");
                    }
                    else if (formula[i] == ')')
                    {
                        while (operators.Peek() != operation.RBL)
                        {
                            ProcessOperation(stBdd, operators.Pop(), operandsStr, operatorsStr.Pop());
                        }
                        operators.Pop();
                        operatorsStr.Pop();
                    }
                    else if (IsOperator(formula[i]))
                    {
                        operation newOp = GetOperation(formula[i]);
                        while (operators.Count > 0 && GetPriority(operators.Peek()) >= GetPriority(newOp))
                        {
                            ProcessOperation(stBdd, operators.Pop(), operandsStr, operatorsStr.Pop());
                        }
                        operators.Push(newOp);
                        string str = "" + formula[i];
                        operatorsStr.Push(str);
                    }
                    else
                    {
                        string operand = "";
                        while (i < formula.Length && !IsDelimeter(formula[i]) && !IsOperator(formula[i]))
                        {
                            operand += formula[i++];
                        }
                        i--;
                        bool flag = false;
                        foreach (var it in orderVar)
                        {
                            if (it.Key == operand)
                            {
                                Bdd newBdd = new Bdd(it.Key, it.Value, null, null, new NodeValueFunction(false), new NodeValueFunction(true));
                                newBdd.function = operand;
                                allFunction.Add(newBdd, operand);
                                stBdd.Push(newBdd);
                                operandsStr.Push(operand);
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            throw new ArgumentException();
                        }
                    }
                }
            }
            while (operators.Count > 0)
            {
                ProcessOperation(stBdd, operators.Pop(), operandsStr, operatorsStr.Pop());
            }
            stBdd.Peek().BddInProcess = BddInProcess;
            stBdd.Peek().allFunction = allFunction;
            countOfOperation = 1;
            return stBdd.Peek();
        }
        private static bool IsDelimeter(char c)
        {
            return c == ' ';
        }
        private static bool IsOperator(char a)
        {
            return a == '+' || a == '*' || a == '!' || a == '~' || a == '%' || a == '>' || a == ')' || a == '(';
        }
        private static int GetPriority(operation op)
        {
            switch (op)
            {
                case operation.RBL: return 0;
                case operation.RBR: return 0;
                case operation.EQ: return 1;
                case operation.IM: return 2;
                case operation.XOR: return 3;
                case operation.OR: return 4;
                case operation.AND: return 5;
                case operation.NOT: return 6;
                default: return -1;
            }
        }
        private operation GetOperation(char s)
        {
            switch (s)
            {
                case '(': return operation.RBL;
                case ')': return operation.RBR;
                case '~': return operation.EQ;
                case '>': return operation.IM;
                case '%': return operation.XOR;
                case '+': return operation.OR;
                case '*': return operation.AND;
                case '!': return operation.NOT;
                default: return operation.ERROR;
            }
        }
        private Dictionary<string, int> GetOrder(string[] str)
        {
            Dictionary<string, int> order = new Dictionary<string, int>();

            for (int i = 0; i < str.Length; i++)
            {
                order.Add(str[i], i);
            }

            return order;
        }
        public void DFS(Bdd root, List<Bdd> nodes, List<Bdd> used)
        {
            if (root != null && !used.Contains(root))
            {
                DFS(root.Zero, nodes, used);
                nodes.Add(root);
                used.Add(root);
                DFS(root.One, nodes, used);
            }
        }
        public List<Bdd> ListNodesDFS(Bdd node)
        {
            List<Bdd> list = new List<Bdd>();
            List<Bdd> used = new List<Bdd>();
            DFS(node, list, used);
            return list;
        }
        public bool CompareTree(Bdd firstNode, Bdd secondNode)
        {
            if (firstNode != null && secondNode != null)
            {
                if ((firstNode.RankVariable == secondNode.RankVariable) &&
                    (firstNode.NameVariable == secondNode.NameVariable) &&
                    ((firstNode.One == null && secondNode.One == null) || (firstNode.One != null && secondNode.One != null && firstNode.One.RankVariable == secondNode.One.RankVariable)) &&
                    ((firstNode.Zero == null && secondNode.Zero == null) || (firstNode.Zero != null && secondNode.Zero != null && firstNode.Zero.RankVariable == secondNode.Zero.RankVariable)) &&
                    ((firstNode.OneValue == null && secondNode.OneValue == null) || (firstNode.OneValue != null && secondNode.OneValue != null && firstNode.OneValue.Value == secondNode.OneValue.Value)) &&
                    ((firstNode.ZeroValue == null && secondNode.ZeroValue == null) || (firstNode.ZeroValue != null && secondNode.ZeroValue != null && firstNode.ZeroValue.Value == secondNode.ZeroValue.Value)))
                {
                    return (CompareTree(firstNode.One, secondNode.One) && CompareTree(firstNode.Zero, secondNode.Zero));
                }
                else
                {
                    return false;
                }
            }
            else if (firstNode == null && secondNode == null)
            {
                return true;
            }
            else return false;
        }
        public bool DeleteNodeWithSameResults(Bdd node)
        {
            if (node.ZeroValue != null && node.OneValue != null && node.ZeroValue.Value == node.OneValue.Value)
            {
                if (node.parents.Count != 0)
                {
                    for (int i = 0; i < node.parents.Count; i++)
                    {
                        if (node.parents[i].One == node)
                        {
                            node.parents[i].One = null;
                            node.parents[i].OneValue = node.OneValue;
                            node = null;
                            return true;
                        }
                        else
                        {
                            node.parents[i].Zero = null;
                            node.parents[i].ZeroValue = node.ZeroValue;                            
                            node = null;
                            return true;
                        }
                    }
                }                
            }
            return false;
        }        
        public void DeleteAllNodesWithSameResults(Bdd root)
        {
            if (root.Zero != null || root.One != null)
            {
                List<Bdd> nodes = ListNodesDFS(root);
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (DeleteNodeWithSameResults(nodes[i]))
                        {
                            flag = true;
                        }
                    }
                    nodes = ListNodesDFS(root);
                }
            }
        }        
        public static string[] GetOptimalOrderByDistance(string formula)
        {
            Dictionary<string, Tuple<int, int>> variable = new Dictionary<string, Tuple<int, int>>();
            int countOfParenthesis = 0;
            for (int i = 0; i < formula.Length; i++)
            {
                if (formula[i] == '(')
                {
                    countOfParenthesis++;
                }
                if (formula[i] == ')')
                {
                    countOfParenthesis--;
                }
                string operand = "";
                while (i < formula.Length && !IsDelimeter(formula[i]) && !IsOperator(formula[i]))
                {
                    operand += formula[i++];
                }
                if (variable.ContainsKey(operand))
                {
                    variable[operand] = Tuple.Create<int, int>(variable[operand].Item1 + 1, Math.Min(countOfParenthesis, variable[operand].Item2));
                    i--;
                }
                else
                {
                    if (operand != "")
                    {
                        variable.Add(operand, Tuple.Create<int, int>(1, countOfParenthesis));
                        i--;
                    }
                }
            }
            string[] answer = new string[variable.Count];
            int min = 1000000000;
            string minVar = "";
            for (int i = 0; i < answer.Length; i++)
            {
                foreach (var it in variable)
                {
                    if (it.Value.Item2 < min)
                    {
                        min = it.Value.Item2;
                        minVar = it.Key;
                    }
                    else if (it.Value.Item1 == min)
                    {
                        if (variable[minVar].Item1 < it.Value.Item2)
                        {
                            min = it.Value.Item2;
                            minVar = it.Key;
                        }
                    }
                }
                answer[i] = minVar;
                variable.Remove(minVar);
                min = 100000000;
                minVar = "";
            }
            return answer;
        }
        public static string[] GetOptimalOrderByCount(string formula)
        {
            Dictionary<string, Tuple<int, int>> variable = new Dictionary<string, Tuple<int, int>>();
            int countOfParenthesis = 0;
            for (int i = 0; i < formula.Length; i++)
            {
                if (formula[i] == '(')
                {
                    countOfParenthesis++;
                }
                if (formula[i] == ')')
                {
                    countOfParenthesis--;
                }
                string operand = "";
                while (i < formula.Length && !IsDelimeter(formula[i]) && !IsOperator(formula[i]))
                {
                    operand += formula[i++];
                }
                if (variable.ContainsKey(operand))
                {
                    variable[operand] = Tuple.Create<int, int>(variable[operand].Item1 + 1, Math.Min(countOfParenthesis, variable[operand].Item2));
                    i--;
                }
                else
                {
                    if (operand != "")
                    {
                        variable.Add(operand, Tuple.Create<int, int>(1, countOfParenthesis));
                        i--;
                    }
                }
            }
            string[] answer = new string[variable.Count];
            int max = 0;
            string maxVar = "";
            for (int i = 0; i < answer.Length; i++)
            {
                foreach (var it in variable)
                {
                    if (it.Value.Item1 > max)
                    {
                        max = it.Value.Item1;
                        maxVar = it.Key;
                    }
                    else if (it.Value.Item1 == max)
                    {
                        if (variable[maxVar].Item2 > it.Value.Item2)
                        {
                            max = it.Value.Item1;
                            maxVar = it.Key;
                        }
                    }
                }
                answer[i] = maxVar;
                variable.Remove(maxVar);
                max = 0;
                maxVar = "";
            }
            return answer;
        }
        public string GetUserSymbol(string op)
        {
            switch (op)
            {
                case "(": return "(";
                case ")": return ")";
                case "~": return "~";
                case ">": return "->";
                case "%": return "+";
                case "+": return "\\/";
                case "*": return "/\\";
                case "!": return "!";
            }
            return "";
        }
        private void DrawVertexVar(Graphics g, string text, Point pos)
        {
            g.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Black, 2), pos.X, pos.Y, SIZE_OF_VERTEX, SIZE_OF_VERTEX);
            g.DrawString(text, new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Regular), new System.Drawing.SolidBrush(System.Drawing.Color.Black), pos.X + 2, pos.Y + 5);
        }
        private void DrawVertexResult(Graphics g, string text, Point pos)
        {
            g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black, 2), pos.X, pos.Y, SIZE_OF_VERTEX, SIZE_OF_VERTEX);
            g.DrawString(text, new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Regular), new System.Drawing.SolidBrush(System.Drawing.Color.Black), pos.X + 2, pos.Y + 5);
        }
        public Bitmap DrawBDD(Bdd bdd)
        {           
            Dictionary<int, List<Tuple<Bdd, int>>> nodes = GetNodesOnLevel(bdd);
            int countOfLevel = nodes.Count;
            int maxVertexOnLevel = Convert.ToInt32(Math.Pow(2, countOfLevel - 1));
            int widthBitmap = 2 * SIZE_OF_VERTEX * maxVertexOnLevel;
            int heightBitmap = (countOfLevel + 2) * 2 * SIZE_OF_VERTEX + 3 * SIZE_OF_VERTEX;
            int countOfSteps = 1;
            int stepOneVertex;
            int minLevel = 0;
            Dictionary<Bdd, Point> vertices = new Dictionary<Bdd, Point>();
            Bitmap bmp = new Bitmap(widthBitmap, heightBitmap);
            Point coordOfNode;
            Point pointForFunc = new Point(30, heightBitmap - 100);
            Pen ZeroPen = new System.Drawing.Pen(System.Drawing.Color.Red, 2);
            ZeroPen.DashStyle = DashStyle.Dash;
            Pen OnePen = new System.Drawing.Pen(System.Drawing.Color.Blue, 2);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);                
                
                    foreach(var it in nodes)
                    {
                        foreach(var x in it.Value)
                        {
                            if(x.Item1.OneValue != null && x.Item1.ZeroValue != null && x.Item1.ZeroValue.Value == x.Item1.OneValue.Value)
                            {
                                int widthBitmap1 = 600;
                                int heightBitmap1 = 300;
                                string answer = "CONST = ";
                                if (x.Item1.ZeroValue.Value)
                                {
                                    answer += "1";
                                }
                                else
                                {
                                    answer += "0";
                                }
                                Bitmap bmp1 = new Bitmap(widthBitmap1, heightBitmap1);
                                using (Graphics g1 = Graphics.FromImage(bmp1))
                                {
                                    g1.Clear(Color.White);
                                    g1.TranslateTransform(15, 15);
                                    g1.DrawString(answer, new System.Drawing.Font("Times New Roman", 28, System.Drawing.FontStyle.Regular), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 150, 150);
                                    if (allFunction.ContainsKey(bdd))
                                    {
                                        g1.DrawString(allFunction[bdd], new System.Drawing.Font("Times New Roman", 28, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 20, 220);                                        
                                    }                                    
                                }
                                return bmp1;
                            }
                        }
                    }
                
                if (allFunction.ContainsKey(bdd))
                {
                    g.DrawString(allFunction[bdd], new System.Drawing.Font("Times New Roman", 16, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), pointForFunc);
                }
                DrawVertexResult(g, "0", new Point(widthBitmap / 3, 2 * SIZE_OF_VERTEX * (countOfLevel + 1)));
                DrawVertexResult(g, "1", new Point(2 * widthBitmap / 3, 2 * SIZE_OF_VERTEX * (countOfLevel + 1)));
                g.TranslateTransform(10, 10);
                foreach (KeyValuePair<int, List<Tuple<Bdd, int>>> it in nodes)
                {
                    minLevel = it.Key;
                    break;
                }
                foreach (KeyValuePair<int, List<Tuple<Bdd, int>>> it in nodes)
                {
                    stepOneVertex = widthBitmap / (countOfSteps + 1);
                    countOfSteps *= 2;
                    foreach (var node in it.Value)
                    {
                        if (!vertices.ContainsKey(node.Item1))
                        {
                            if (node.Item1 != null && node.Item1.RankVariable >= 0)
                            {
                                coordOfNode = new Point(stepOneVertex * node.Item2 - SIZE_OF_VERTEX / 2, 2 * SIZE_OF_VERTEX * (node.Item1.RankVariable - minLevel) + SIZE_OF_VERTEX / 2);
                                DrawVertexVar(g, node.Item1.NameVariable, coordOfNode);
                                if (!vertices.ContainsKey(node.Item1))
                                {
                                    vertices.Add(node.Item1, coordOfNode);
                                }
                                if (node.Item1.parents != null)
                                {
                                    foreach (var parent in node.Item1.parents)
                                    {
                                        if (vertices.ContainsKey(parent))
                                        {
                                            if (parent.Zero == node.Item1)
                                            {
                                                g.DrawLine(ZeroPen, coordOfNode.X + SIZE_OF_VERTEX / 2 - 10, coordOfNode.Y, vertices[parent].X + SIZE_OF_VERTEX / 2, vertices[parent].Y + SIZE_OF_VERTEX);
                                            }
                                            if (parent.One == node.Item1)
                                            {
                                                g.DrawLine(OnePen, coordOfNode.X + SIZE_OF_VERTEX / 2 + 10, coordOfNode.Y, vertices[parent].X + SIZE_OF_VERTEX / 2, vertices[parent].Y + SIZE_OF_VERTEX);
                                            }
                                        }
                                    }
                                }
                                if (node.Item1.ZeroValue != null)
                                {
                                    if (node.Item1.ZeroValue.Value)
                                    {
                                        g.DrawLine(ZeroPen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, 2 * widthBitmap / 3 + SIZE_OF_VERTEX / 2 + 5, 2 * SIZE_OF_VERTEX * (countOfLevel + 1) - 12);
                                    }
                                    else
                                    {
                                        g.DrawLine(ZeroPen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, widthBitmap / 3 + SIZE_OF_VERTEX / 2 + 5, 2 * SIZE_OF_VERTEX * (countOfLevel + 1) - 12);
                                    }
                                }
                                if (node.Item1.OneValue != null)
                                {
                                    if (node.Item1.OneValue.Value)
                                    {
                                        g.DrawLine(OnePen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, 2 * widthBitmap / 3 - SIZE_OF_VERTEX / 2 + 5, 2 * SIZE_OF_VERTEX * (countOfLevel + 1) - 12);
                                    }
                                    else
                                    {
                                        g.DrawLine(OnePen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, widthBitmap / 3 - SIZE_OF_VERTEX / 2 + 5, 2 * SIZE_OF_VERTEX * (countOfLevel + 1) - 12);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bmp;
        }
        public void DeleteSubtree(Bdd node)
        {
            if (node != null && node.parents.Count < 2)
            {
                node.parents.Clear();
                DeleteSubtree(node.Zero);
                DeleteSubtree(node.One);
                if (node.Zero != null)
                {
                    node.Zero.parents.RemoveAll(t => t == node);
                }
                if (node.One != null)
                {
                    node.One.parents.RemoveAll(t => t == node);
                }
                node = null;
            }
        }
        public bool DeleteSameSubtree(Bdd firstRoot, Bdd secondRoot)
        {
            bool flag = false;
            if (CompareTree(firstRoot, secondRoot))
            {
                for (int i = 0; i < secondRoot.parents.Count; i++)
                {
                    if (secondRoot.parents[i].One == secondRoot)
                    {
                        secondRoot.parents[i].One = firstRoot;
                        firstRoot.parents.Add(secondRoot.parents[i]);
                        flag = true;
                    }
                    else
                    {
                        secondRoot.parents[i].Zero = firstRoot;
                        firstRoot.parents.Add(secondRoot.parents[i]);
                        flag = true;
                    }
                }
                DeleteSubtree(secondRoot);
            }
            return flag;
        }
        public void DeleteAllSameSubtree(Bdd root)
        {
            List<Bdd> nodes = ListNodesDFS(root);
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < nodes.Count; i++)
                {
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (nodes[i] != nodes[j])
                        {
                            if (DeleteSameSubtree(nodes[i], nodes[j]))
                            {
                                flag = true;
                            }
                        }
                    }
                    nodes = ListNodesDFS(root);
                }
                nodes = ListNodesDFS(root);
            }
        }
        public bool DeleteNodeWithSameOneAndZeroNodes(Bdd node)
        {
            bool flag = false;
            if (node.One == node.Zero && node.Zero != null)
            {
                while (node.One.parents.Remove(node)) ;

                for (int i = 0; node.parents != null && i < node.parents.Count; i++)
                {
                    if (node.parents[i].One == node)
                    {
                        node.parents[i].One = node.One;
                        node.One.parents.Add(node.parents[i]);
                        flag = true;
                    }
                    else
                    {
                        node.parents[i].Zero = node.Zero;
                        node.Zero.parents.Add(node.parents[i]);
                        flag = true;
                    }
                }                
                node.RankVariable = -1;
            }
            return flag;
        }
        public void DeleteAllNodesWithSameOneAndZeroNodes(Bdd bdd)
        {
            List<Bdd> nodes = ListNodesDFS(bdd);
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (DeleteNodeWithSameOneAndZeroNodes(nodes[i]))
                    {
                        flag = true;                        
                    }
                }
                nodes = ListNodesDFS(bdd);
            }
        }

    }
}

