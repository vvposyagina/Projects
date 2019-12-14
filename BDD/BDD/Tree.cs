using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    delegate void BuildTree();
    public class MyComparer : IEqualityComparer<bool[]>
    {
        public bool Equals(bool[] x, bool[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }
        public int GetHashCode(bool[] obj)
        {
            bool result = true;
            for (int i = 0; i < obj.Length; i++)
            {
                unchecked
                {
                    result ^= obj[i];
                }
            }
            return Convert.ToInt32(result);
        }
    }
    class Tree
    {
        public event BuildTree refresh = null;
        public event BuildTree buildNewTree = null;
        public event BuildTree IsConst = null;
        string action;
        Node root;
        int countOfLevel;
        string[] sequenceVariable;
        Dictionary<int, List<Tuple<Node, int>>> nodesOnLevel;
        bool[] functionValue;
        int maxVertexOnLevel = 0;
        const int SIZE_OF_VERTEX = 40;
        bool isConst = false;
        string function;    
        public string Function
        {
            get { return function; }
            set { function = value; }
        }
        public int CountOfLevel
        {
            get { return countOfLevel; }
        }
        public Node Root
        {
            get { return root; }
        }
        public Tree(Tree copyTree)
        {
            root = new Node(copyTree.Root);
            root.ConnectToParent(root);
            maxVertexOnLevel = copyTree.maxVertexOnLevel;
            countOfLevel = copyTree.CountOfLevel;
            sequenceVariable = copyTree.sequenceVariable;
            functionValue = copyTree.functionValue;
            nodesOnLevel = new Dictionary<int, List<Tuple<Node, int>>>();
            for (int i = 0; i < countOfLevel; i++)
            {
                if (copyTree.nodesOnLevel.ContainsKey(i))
                {
                    nodesOnLevel.Add(i, copyTree.nodesOnLevel[i]);
                }
            }
            action = copyTree.action;
            function = copyTree.function;
            flag0 = true;
            flag1 = true;
            flag2 = true;
            flag3 = true;
        }
        public Tree(int n, string[] seqVar = null, bool[] valFunc = null)
        {
            root = new Node(1);
            maxVertexOnLevel = Convert.ToInt32(Math.Pow(2, n - 1));
            countOfLevel = n;
            sequenceVariable = seqVar;
            functionValue = valFunc;
            nodesOnLevel = new Dictionary<int, List<Tuple<Node, int>>>();
            for (int i = 0; i < countOfLevel; i++ )
            {
                nodesOnLevel.Add(i, new List<Tuple<Node, int>>());
            }
            flag0 = true;
            flag1 = true;
            flag2 = true;
            flag3 = true;
        }
        public Tree(int n, string[] seqVar = null, string valFunc = null)
        {
            root = new Node(1);
            maxVertexOnLevel = Convert.ToInt32(Math.Pow(2, n - 1));
            countOfLevel = n;
            sequenceVariable = seqVar;
            functionValue = StringConvertToBool(valFunc);
            nodesOnLevel = new Dictionary<int, List<Tuple<Node, int>>>();
            for (int i = 0; i < countOfLevel; i++)
            {
                nodesOnLevel.Add(i, new List<Tuple<Node, int>>());
            }
            flag0 = true;
            flag1 = true;
            flag2 = true;
            flag3 = true;
        }
        public Node AddOneNode(Node parent)
        {
            Node newNode = new Node(parent.Value + 1, null, null, parent);
            parent.One = newNode;
            return newNode;
        }
        public Node AddZeroNode(Node parent)
        {
            Node newNode = new Node(parent.Value + 1, null, null, parent);
            parent.Zero = newNode;
            return newNode;
        }
        public void AddNodeOnLevel(int level, Node node, int range)
        {
            nodesOnLevel[level].Add(Tuple.Create<Node, int>(node, range));
        }
        public bool CreateTree()
        {
            if (countOfLevel <= 0)
                return false;

            Queue<Node> q1 = new Queue<Node>();
            Queue<Node> q2 = new Queue<Node>();
            root.Value = 0;
            AddNodeOnLevel(0, root, 1);
            root.Key = sequenceVariable[root.Value];
            q1.Enqueue(root);
            for (int i = 1; i < countOfLevel; i++)
            {
                int countQ1 = q1.Count;
                int beginFuncVal = 0;
                int j = 1;
                while (q1.Count > 0)
                {
                    Node oldNode = q1.Dequeue();
                    Node newNodeZero = AddZeroNode(oldNode);
                    newNodeZero.Key = sequenceVariable[i];
                    q2.Enqueue(newNodeZero);
                    Node newNodeOne = AddOneNode(oldNode);
                    newNodeOne.Key = sequenceVariable[i];
                    q2.Enqueue(newNodeOne);
                    AddNodeOnLevel(i, newNodeZero, j);
                    j++;
                    AddNodeOnLevel(i, newNodeOne, j);
                    j++;
                    if (i == countOfLevel - 1)
                    {
                        newNodeZero.ResultZero = new NodeValueFunction(functionValue[beginFuncVal], newNodeZero);
                        beginFuncVal++;
                        newNodeZero.ResultOne = new NodeValueFunction(functionValue[beginFuncVal], newNodeZero);
                        beginFuncVal++;
                        newNodeOne.ResultZero = new NodeValueFunction(functionValue[beginFuncVal], newNodeZero);
                        beginFuncVal++;
                        newNodeOne.ResultOne = new NodeValueFunction(functionValue[beginFuncVal], newNodeZero);
                        beginFuncVal++;
                    }
                }
                q1 = new Queue<Node>(q2);
                q2.Clear();                
            }
            action = "Семантическое дерево:";            
            return true;
        }
        public static bool[] StringConvertToBool(string s)
        {
            bool[] sequence = new bool[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                    sequence[i] = false;
                else if (s[i] == '1')
                    sequence[i] = true;
                else
                    throw new ArgumentException();
            }
            return sequence;
        }
        public void DFS(Node node, List<Node> nodes, List<Node> used)
        {
            if (node != null && !used.Contains(node))
            {
                DFS(node.Zero, nodes, used);
                nodes.Add(node);
                used.Add(node);
                DFS(node.One, nodes, used);
            }
        }
        public bool CompareTree(Node firstNode, Node secondNode)
        {
            if (firstNode != null && secondNode != null)
            {
                if ((firstNode.Value == secondNode.Value) &&
                    ((firstNode.One == null && secondNode.One == null) || (firstNode.One != null && secondNode.One != null && firstNode.One.Value == secondNode.One.Value)) &&
                    ((firstNode.Zero == null && secondNode.Zero == null) || (firstNode.Zero != null && secondNode.Zero != null && firstNode.Zero.Value == secondNode.Zero.Value)) &&
                    ((firstNode.ResultOne == null && secondNode.ResultOne == null) || (firstNode.ResultOne != null && secondNode.ResultOne != null && firstNode.ResultOne.Value == secondNode.ResultOne.Value)) &&
                    ((firstNode.ResultZero == null && secondNode.ResultZero == null) || (firstNode.ResultZero != null && secondNode.ResultZero != null && firstNode.ResultZero.Value == secondNode.ResultZero.Value)))
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
        public List<Node> ListNodesDFS(Node node)
        {
            List<Node> list = new List<Node>();
            List<Node> used = new List<Node>();
            DFS(node, list, used);
            return list;
        }
        private int NumberNode(Node node)
        {
            List<Node> list = ListNodesDFS(root);
            for (int i = 0; i < list.Count; i++)
                if (list[i] == node)
                    return i;
            return -1;
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
        public Bitmap DrawFirstTree()
        {
            int widthBitmap = 3 * SIZE_OF_VERTEX * maxVertexOnLevel * 2;
            int heightBitmap = (countOfLevel + 1) * 2 * SIZE_OF_VERTEX + SIZE_OF_VERTEX;
            int countOfSteps = 1;
            int stepOneVertex;
            Dictionary<Node, Point> vertices = new Dictionary<Node, Point>();
            Bitmap bmp = new Bitmap(widthBitmap, heightBitmap);            
            Point coordOfNode;
            Pen ZeroPen = new System.Drawing.Pen(System.Drawing.Color.Red, 2);
            ZeroPen.DashStyle = DashStyle.Dash;
            Pen OnePen = new System.Drawing.Pen(System.Drawing.Color.Blue, 2);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(15, 15);
                g.DrawString(action, new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Regular), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0);
                foreach(KeyValuePair<int, List<Tuple<Node, int>>> it in nodesOnLevel)
                {
                    stepOneVertex = widthBitmap / (countOfSteps + 1);
                    countOfSteps *= 2;      
                    foreach(var node in it.Value)
                    {
                        coordOfNode = new Point(stepOneVertex * node.Item2 - SIZE_OF_VERTEX / 2, 2 * SIZE_OF_VERTEX * node.Item1.Value + SIZE_OF_VERTEX / 2);
                        DrawVertexVar(g, node.Item1.Key, coordOfNode);
                        vertices.Add(node.Item1, coordOfNode);
                        if (node.Item1.Parents != null)
                        {
                             foreach(var parent in node.Item1.Parents)
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
                        if (node.Item1.ResultZero != null)
                        {
                            string text;
                            if(node.Item1.ResultZero.Value)
                            {
                                text = "1";
                            }
                            else
                            {
                                text = "0";
                            }
                            DrawVertexResult(g, text, new Point(coordOfNode.X - SIZE_OF_VERTEX / 2, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2));
                            g.DrawLine(ZeroPen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, coordOfNode.X, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2);
                        }
                        if (node.Item1.ResultOne != null)
                        {
                            string text;
                            if(node.Item1.ResultOne.Value)
                            {
                                text = "1";
                            }
                            else
                            {
                                text = "0";
                            }
                            DrawVertexResult(g, text, new Point(coordOfNode.X + SIZE_OF_VERTEX, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2));
                            g.DrawLine(OnePen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, coordOfNode.X + SIZE_OF_VERTEX + SIZE_OF_VERTEX / 2, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2);
                        } 
                    }
                }
            }            
            return bmp;
        }
        public Bitmap DrawNextTree()
        {
            int widthBitmap = 3 * SIZE_OF_VERTEX * maxVertexOnLevel * 2;
            int heightBitmap = (countOfLevel + 1) * 2 * SIZE_OF_VERTEX + 3 * SIZE_OF_VERTEX;
            int countOfSteps = 1;
            int stepOneVertex;
            Dictionary<Node, Point> vertices = new Dictionary<Node, Point>();
            Bitmap bmp = new Bitmap(widthBitmap, heightBitmap);
            Point pointForFunc = new Point(20, heightBitmap - 100);
            Point coordOfNode;
            Pen ZeroPen = new System.Drawing.Pen(System.Drawing.Color.Red, 2);
            ZeroPen.DashStyle = DashStyle.Dash;
            Pen OnePen = new System.Drawing.Pen(System.Drawing.Color.Blue, 2);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                DrawVertexResult(g, "0", new Point(widthBitmap / 3, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2));
                DrawVertexResult(g, "1", new Point(2 * widthBitmap / 3, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2));
                g.TranslateTransform(15, 15);
                g.DrawString(action, new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Regular), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0);
                g.DrawString(function, new System.Drawing.Font("Times New Roman", 28, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), pointForFunc);
                foreach (KeyValuePair<int, List<Tuple<Node, int>>> it in nodesOnLevel)
                {
                    stepOneVertex = widthBitmap / (countOfSteps + 1);
                    countOfSteps *= 2;
                    foreach (var node in it.Value)
                    {
                        coordOfNode = new Point(stepOneVertex * node.Item2 - SIZE_OF_VERTEX / 2, 2 * SIZE_OF_VERTEX * node.Item1.Value + SIZE_OF_VERTEX / 2);
                        DrawVertexVar(g, node.Item1.Key, coordOfNode);
                        vertices.Add(node.Item1, coordOfNode);
                        if (node.Item1.Parents != null)
                        {
                            foreach (var parent in node.Item1.Parents)
                            {
                                if (vertices.ContainsKey(parent))
                                {
                                    if (parent.Zero == node.Item1)
                                    {
                                        g.DrawLine(ZeroPen, coordOfNode.X + SIZE_OF_VERTEX / 2 - 10, coordOfNode.Y, vertices[parent].X + SIZE_OF_VERTEX / 2 - 10, vertices[parent].Y + SIZE_OF_VERTEX);
                                    }
                                    if (parent.One == node.Item1)
                                    {
                                        g.DrawLine(OnePen, coordOfNode.X + SIZE_OF_VERTEX / 2 + 10, coordOfNode.Y, vertices[parent].X + SIZE_OF_VERTEX / 2 + 10, vertices[parent].Y + SIZE_OF_VERTEX);
                                    }
                                }
                            }
                        }
                        if (node.Item1.ResultZero != null)
                        {
                            if (node.Item1.ResultZero.Value)
                            {
                                g.DrawLine(ZeroPen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, 2 * widthBitmap / 3 + SIZE_OF_VERTEX / 2 + 5, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2 - 15);
                            }
                            else
                            {
                                g.DrawLine(ZeroPen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, widthBitmap / 3 + SIZE_OF_VERTEX / 2 + 5, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2 - 15);
                            }                            
                        }
                        if (node.Item1.ResultOne != null)
                        {
                            if (node.Item1.ResultOne.Value)
                            {
                                g.DrawLine(OnePen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, 2 * widthBitmap / 3 - SIZE_OF_VERTEX / 2 + 5, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2 - 15);
                            }
                            else
                            {
                                g.DrawLine(OnePen, coordOfNode.X + SIZE_OF_VERTEX / 2, coordOfNode.Y + SIZE_OF_VERTEX, widthBitmap / 3 - SIZE_OF_VERTEX / 2 + 5, 2 * SIZE_OF_VERTEX * countOfLevel + SIZE_OF_VERTEX / 2 - 15);
                            }
                        }   
                    }
                }
            }
            return bmp;
        }  
        public Bitmap DrawConst()
        {
            int widthBitmap = 600;
            int heightBitmap = 300;
            string answer = "f = CONST = ";
            if(isConst)
            {
                answer += "1";
            }
            else
            {
                answer += "0";
            }
            Bitmap bmp = new Bitmap(widthBitmap, heightBitmap);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(15, 15);
                g.DrawString(action, new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Regular), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0);
                g.DrawString(answer, new System.Drawing.Font("Times New Roman", 28, System.Drawing.FontStyle.Regular), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 150, 150);
                g.DrawString(function, new System.Drawing.Font("Times New Roman", 28, System.Drawing.FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.Black), 20, 220);
            }
            return bmp;
        }
        public void ReductionToZeroAndUnit()
        {
            NodeValueFunction trueNode = new NodeValueFunction(true);
            NodeValueFunction falseNode = new NodeValueFunction(false);
            List<Node> nodes = ListNodesDFS(root);
            if (nodes.Count == 1 && nodes[0].ResultZero != null && nodes[0].ResultOne != null && nodes[0].ResultZero.Value == nodes[0].ResultOne.Value)
            {
                isConst = nodes[0].ResultZero.Value;
                action = "Функция представлена константой";
                if (IsConst != null)
                    IsConst();
                return;
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].ResultZero != null)
                {
                    if (nodes[i].ResultZero.Value)
                    {
                        nodes[i].ResultZero = null;
                        nodes[i].ResultZero = trueNode;
                        trueNode.AddNewVariable(nodes[i]);
                    }
                    else
                    {
                        nodes[i].ResultZero = null;
                        nodes[i].ResultZero = falseNode;
                        falseNode.AddNewVariable(nodes[i]);
                    }
                }
                if (nodes[i].ResultOne != null)
                {
                    if (nodes[i].ResultOne.Value)
                    {
                        nodes[i].ResultOne = null;
                        nodes[i].ResultOne = trueNode;
                        trueNode.AddNewVariable(nodes[i]);
                    }
                    else
                    {
                        nodes[i].ResultOne = null;
                        nodes[i].ResultOne = falseNode;
                        falseNode.AddNewVariable(nodes[i]);
                    }
                }
            }
            action = "Сведение всех ветвей дерева к единым \"0\" и \"1\". Конечная конфигурация";            
            if (refresh != null)
                refresh();
        }
        public bool DeleteNodeWithSameResults(Node node)
        {
            if (node.ResultZero != null && node.ResultOne != null && node.ResultZero.Value == node.ResultOne.Value)
            {
                if (node != root)
                {
                    for (int i = 0; i < node.Parents.Count; i++)
                    {
                        string text;
                            if(node.ResultZero.Value)
                            {
                                text = "1";
                            }
                            else
                            {
                                text = "0";
                            }
                            action = "Удаление вершины \"" + node.Key + "\" , из которой обе ветви ведут  к значению \"" + text + "\""; 
                        if (node.Parents[i].One == node)
                        {
                            node.Parents[i].One = null;
                            node.Parents[i].ResultOne = node.ResultOne;
                            nodesOnLevel[node.Value].RemoveAll(t => t.Item1 == node);
                            if(nodesOnLevel[node.Value].Count < 1)
                            {
                                nodesOnLevel.Remove(node.Value);
                            }
                            node = null;                            
                            return true;
                        }
                        else
                        {
                            node.Parents[i].Zero = null;
                            node.Parents[i].ResultZero = node.ResultZero;
                            nodesOnLevel[node.Value].RemoveAll(t => t.Item1 == node);
                            if (nodesOnLevel[node.Value].Count < 1)
                            {
                                nodesOnLevel.Remove(node.Value);
                            }
                            node = null;                            
                            return true;
                        }                        
                    }
                }                
            }         

            return false;
        }
        public bool DeleteNodeWithSameOneAndZeroNodes(Node node)
        {
            bool flag = false;
            if (node.One == node.Zero && node.Zero != null)
            {
                action = "Удаление вершины \"" + node.Key + "\" , из которой обе ветви ведут  к вершине \"" + node.One.Key + "\""; 
                while (node.One.Parents.Remove(node)) ;
               
                for (int i = 0; node.Parents != null && i < node.Parents.Count; i++)
                {
                    if (node.Parents[i].One == node)
                    {
                        node.Parents[i].One = node.One;
                        node.One.Parents.Add(node.Parents[i]);                                           
                        flag = true;
                    }
                    else
                    {
                        node.Parents[i].Zero = node.Zero;
                        node.Zero.Parents.Add(node.Parents[i]);                                       
                        flag = true;
                    }
                }                
                if (nodesOnLevel.ContainsKey(node.Value))
                {
                    nodesOnLevel[node.Value].RemoveAll(t => t.Item1 == node);
                    if (nodesOnLevel[node.Value].Count < 1)
                    {
                        nodesOnLevel.Remove(node.Value);
                    }                    
                    flag = true;
                }
                node = null;
            }
            return flag;
        }
        public void DeleteSubtree(Node node)
        {
            if (node != null && node.Parents.Count < 2)
            {
                action = "Удаление подструктуры(уже существующей в диаграмме) с вершиной \"" + node.Key + "\" в корне"; 
                node.Parents.Clear();
                DeleteSubtree(node.Zero);
                DeleteSubtree(node.One);  
                if(node.Zero != null)
                {
                    node.Zero.Parents.RemoveAll(t => t == node);
                }
                if(node.One != null)
                {
                    node.One.Parents.RemoveAll(t => t == node);
                }
                nodesOnLevel[node.Value].RemoveAll(t => t.Item1 == node);
                if (nodesOnLevel[node.Value].Count < 1)
                {
                    nodesOnLevel.Remove(node.Value);
                }
                node = null;               
            }
        }
        public bool DeleteSameSubtree(Node firstRoot, Node secondRoot)
        {
            bool flag = false;
            if(CompareTree(firstRoot, secondRoot))
            {                
                for(int i = 0; i < secondRoot.Parents.Count; i++)
                {
                    if (secondRoot.Parents[i].One == secondRoot)
                    {
                        secondRoot.Parents[i].One = firstRoot;
                        firstRoot.Parents.Add(secondRoot.Parents[i]);                        
                        flag = true;
                    }
                    else
                    {
                        secondRoot.Parents[i].Zero = firstRoot;
                        firstRoot.Parents.Add(secondRoot.Parents[i]);
                        flag = true;
                    }
                }
                DeleteSubtree(secondRoot);
            }
            return flag;
        }
        public void DeleteAllNodesWithSameResults()
        {
            List<Node> nodes = ListNodesDFS(root);
            nodes = ListNodesDFS(root);
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (DeleteNodeWithSameResults(nodes[i]))
                    {
                        flag = true;
                        if (buildNewTree != null)
                            buildNewTree();
                        //if (refresh != null)
                        //    refresh();
                    }
                }
                nodes = ListNodesDFS(root);                
            }
        }
        public void DeleteAllNodesWithSameOneAndZeroNodes()
        {
            List<Node> nodes = ListNodesDFS(root);
            nodes = ListNodesDFS(root);
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (DeleteNodeWithSameOneAndZeroNodes(nodes[i]))
                    {
                        flag = true;
                        if (buildNewTree != null)
                            buildNewTree();
                        //if (refresh != null)
                        //    refresh();
                    }
                }
                nodes = ListNodesDFS(root);                
            }
        }
        public void DeleteAllSameSubtree()
        {
            List<Node> nodes = ListNodesDFS(root);
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
                                if (buildNewTree != null)
                                    buildNewTree();
                                //if (refresh != null)
                                //    refresh();
                            }
                        }
                    }
                    nodes = ListNodesDFS(root);                    
                }
                nodes = ListNodesDFS(root);
            }
        }        
        public void BuildBDD()
        {
            if (buildNewTree != null)
                buildNewTree();
            DeleteAllNodesWithSameResults();
            DeleteAllSameSubtree();
            DeleteAllNodesWithSameOneAndZeroNodes();
            ReductionToZeroAndUnit();
        }

        bool flag0 = true;
        bool flag1 = true;
        bool flag2 = true;
        bool flag3 = true;        
        public bool BuildBDDOneStep()
        {
            if (flag0)
            {
                if (buildNewTree != null)
                    buildNewTree();
                flag0 = false;
                return true;
            }
            List<Node> nodes = ListNodesDFS(root);
            if (flag1)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (DeleteNodeWithSameResults(nodes[i]))
                    {
                        if (buildNewTree != null)
                            buildNewTree();
                        return true;
                    }
                }
            }
            flag1 = false;
            if (flag2)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (nodes[i] != nodes[j])
                        {
                            if (DeleteSameSubtree(nodes[i], nodes[j]))
                            {
                                if (buildNewTree != null)
                                    buildNewTree();
                                return true;
                            }
                        }
                    }
                }
            }
            flag2 = false;
            if (flag3)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (DeleteNodeWithSameOneAndZeroNodes(nodes[i]))
                    {
                        if (buildNewTree != null)
                            buildNewTree();
                        return true;
                    }
                }
            }
            flag3 = false;
            ReductionToZeroAndUnit();
            return false; 
        }
        public static bool[] ChangeOrderVar(string[] seqVarOld, string[] seqVarNew, bool[] seqVal)
        {
            Dictionary<bool[], bool> tableVal = new Dictionary<bool[], bool>(new MyComparer());
            bool[] answer = new bool[seqVal.Length];
            for (int i = 0; i < seqVal.Length; i++)
            {
                bool[] listVarOld = new bool[seqVarOld.Length];
                bool[] listVarNew = new bool[seqVarNew.Length];
                int mask = i;
                for (int j = 0; j < seqVarOld.Length; j++)
                {
                    listVarOld[seqVarOld.Length - 1 - j] = Convert.ToBoolean(mask % 2);
                    mask /= 2;
                }
                for (int k = 0; k < seqVarOld.Length; k++)
                {
                    bool flag = listVarOld[k];
                    for (int h = 0; h < seqVarNew.Length; h++)
                    {
                        if (seqVarOld[k] == seqVarNew[h])
                        {
                            listVarNew[h] = flag;
                        }
                    }
                }
                tableVal.Add(listVarNew, seqVal[i]);
            }
            for (int i = 0; i < seqVal.Length; i++)
            {
                bool[] maskVar = new bool[seqVarOld.Length];
                int mask = i;
                for (int j = 0; j < seqVarOld.Length; j++)
                {
                    maskVar[seqVarOld.Length - 1 - j] = Convert.ToBoolean(mask % 2);
                    mask /= 2;
                }
                answer[i] = tableVal[maskVar];
            }
            return answer;
        }
    }
}
