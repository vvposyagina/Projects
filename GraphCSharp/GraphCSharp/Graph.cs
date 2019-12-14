using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraphCSharp
{
    class Graph
    {
        public const int  MAX = 99999;
        public const int N = 100;      

        public int[][] matrix;
        public List<rib> listOfRibs;
        public bool refreshed;
        public int countOfVertex, countOfRib;

        public Graph()
        {
            countOfVertex = 0;
            countOfRib = 0;
        }        
     
        private void MemoryAllocation()
        {
            matrix = new int[countOfVertex][];
            for (int i = 0; i < countOfVertex; i++)
            {
                matrix[i] = new int[countOfVertex];
                for (int j = 0; j < countOfVertex; j++)
                {
                    if (i == j)
                        matrix[i][j] = 0;
                    else
                        matrix[i][j] = MAX;

                }
                    
            }
        }
        public void ReadMatrix(string nameOfFile)
        {
            System.IO.StreamReader read = new System.IO.StreamReader(@nameOfFile);
            countOfVertex = Convert.ToInt32(read.ReadLine());
            listOfRibs = new List<rib>();                    
            MemoryAllocation();
            string str = read.ReadLine();
            int q = countOfVertex;
            int i = 0;
            while(q > 0)
            {
                string[] temp;
                temp = str.Split(' ');
                
                for (int j = 0; j < countOfVertex; j++)
                {
                    if (Convert.ToInt32(temp[j]) != 0)
                    { 
                        matrix[i][j] = Convert.ToInt32(temp[j]);
                        countOfRib++;
                        rib newRib = new rib(i, j, matrix[i][j]);
                        listOfRibs.Add(newRib);
                    }
                    if (Convert.ToInt32(temp[j]) == 0 && i == j)
                    {
                        matrix[i][j] = Convert.ToInt32(temp[j]);
                    }
                    else if (Convert.ToInt32(temp[j]) == 0 && i != j)
                        matrix[i][j] = MAX;            
                    
                }
                i++;
                q--;
                str = read.ReadLine();
            }          
                                   
            refreshed = false;
            read.Close();
        }

        public void ReadListOfRibs(string nameOfFile)
        {
            System.IO.StreamReader read = new System.IO.StreamReader(@nameOfFile);
            countOfRib = Convert.ToInt32(read.ReadLine());
            listOfRibs = new List<rib>();                     
            MemoryAllocation();
            string str = read.ReadLine();
            int i = 0;

            while (str.Count() > 0)
            {
                string[] temp;
                temp = str.Split(' ');

                rib newRib = new rib(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[2]));
                listOfRibs.Add(newRib);

                matrix[Convert.ToInt32(temp[0])][Convert.ToInt32(temp[1])] = Convert.ToInt32(temp[2]);
            }
        }

        public bool AddRib(int first, int second, int weight)
        {
            if (first > countOfVertex || second > countOfVertex || first < 0 || second < 0)
                return false;
            else
            {
                rib newRib = new rib(first, second, weight);
                matrix[first][second] = weight;
                listOfRibs.Add(newRib);
                return true;
            }
        }

        public bool DeleteRib(int first, int second)
	    {
            bool flag = false;
            if (first > countOfVertex || second > countOfVertex || first < 0 || second < 0)
			    return false;
		    else
		    {
			    
			    matrix[first][second] = MAX;
                for (int i = 0; i < listOfRibs.Count(); i++ )
                {
                    if (listOfRibs[i].fi == first && listOfRibs[i].se == second)
                    {
                        listOfRibs.RemoveAt(i);                        
                        flag = true;
                        break;
                    }
                }
			    if (flag == true)
				    return true;
			    else
				    return false;
		    }
	    }

        private void RewriteMatrix()
        {
            MemoryAllocation();
            for (int i = 0; i < listOfRibs.Count(); i++)
            {                
                matrix[listOfRibs[i].fi][listOfRibs[i].se] = listOfRibs[i].weight;
            }            
        }

        public void AddVertex()
        {
            countOfVertex++;
            MemoryAllocation();
            RewriteMatrix();
            string newWeight = Console.ReadLine();
            string[] temp = newWeight.Split(' ');
            for (int i = 0; i < countOfVertex; i++)
            { 
                 matrix[i][countOfVertex - 1] = Convert.ToInt32(temp[i]);
                 matrix[countOfVertex - 1][i] = Convert.ToInt32(temp[i]);  
                
                if (Convert.ToInt32(temp[i]) != 0)
                {
                    rib newEl = new rib(countOfVertex, i, Convert.ToInt32(temp[i]));
                    listOfRibs.Add(newEl);
                    countOfRib++;
                }
            }          
        }

        public bool DeleteVertex(int num)
        {
            if (num >= countOfVertex)
                return false;
            else
            {
                for (int i = 0; i < listOfRibs.Count(); i++)
                {
                    if (listOfRibs[i].fi == num || listOfRibs[i].se == num)
                    {
                        listOfRibs.RemoveAt(i);
                        countOfRib--;
                    }
                }

                for (int i = 0; i < listOfRibs.Count(); i++)
                {
                    if (listOfRibs[i].fi >= num)
                    {
                        listOfRibs[i].fi--;
                    }

                    if (listOfRibs[i].se >= num)
                    {
                        listOfRibs[i].se--;
                    }
                }          

                countOfVertex--;

                RewriteMatrix();
                return true;
            }
        }

        public bool ChangeRib(int first, int second, int weight)
        {
            if (first > countOfVertex || second > countOfVertex || first < 0 || second < 0)
                return false;
            else
            {
                bool flag = false;

                for (int i = 0; i < listOfRibs.Count(); i++)
                {
                    if (listOfRibs[i].fi == first && listOfRibs[i].se == second)
                    {
                        listOfRibs[i].weight = weight;
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    matrix[first][second] = weight;
                    return true;
                }
                return false;
            }
        }

        public void PrintMatrix()
        {
            Console.WriteLine(countOfVertex);
            for (int i = 0; i < countOfVertex; i++)
            {
                for (int j = 0; j < countOfVertex; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void PrintList()
	    {
		    Console.WriteLine(countOfRib);
            for (int i = 0; i < listOfRibs.Count(); i++ )
            {
                Console.WriteLine(listOfRibs[i].fi + " " + listOfRibs[i].se + " " + listOfRibs[i].weight);
            }
	    }

        public bool Connectivity()
        {
            bool[] visited = new bool[countOfVertex];

            for (int i = 0; i < countOfVertex; i++)
                visited[i] = false;

            Queue<int> q = new Queue<int>();

            visited[0] = true;

            q.Enqueue(0);

            for (; q.Count() > 0; )
            {
                int p = q.Peek();
                q.Dequeue();

                for (int i = 0; i < countOfVertex; i++)
                {
                    if (matrix[p][i] > 0 && !visited[i])
                    {
                        visited[i] = true;
                        q.Enqueue(i);
                    }
                }
            }

            for (int i = 0; i < countOfVertex; i++)
            {
                if (visited[i] == false)
                {
                    return false;
                }
            }
            return true;
        }
        
        public List<rib> MST(ref int lenghtOfTrick)
	    {
		    bool[] visited = new bool[countOfVertex];
		    List<rib> listMST = new List<rib>();
		    int count = 1;

		    for (int i = 0; i < countOfVertex; i++)
		    {
			    visited[i] = false;
		    }

		    visited[0] = true;
		    while (count != countOfVertex)
		    {
			    int min = MAX, minVertexTwo = 0, minVertexOne = 0;
			    bool flag = false;
			    for (int j = 0; j < countOfVertex; j++)
			    if (visited[j])
			    {
				    for (int i = 0; i < countOfVertex; i++)
				    {
					    if (matrix[j][i] < min && matrix[j][i] != 0 && visited[i] != true)
					    {
						    min = matrix[j][i];
						    minVertexOne = j;
						    minVertexTwo = i;
						    flag = true;
					    }
				    }
			    }

			    if (flag)
			    {
				    visited[minVertexTwo] = true;
                    rib newEl = new rib(minVertexOne, minVertexTwo, min);
				    listMST.Add(newEl);
				    //cout << minVertexOne << " " << minVertexTwo << " " << endl;
				    count++;
				    lenghtOfTrick += min;
			    }
			    else
			    {
				    listMST.Clear();
				    lenghtOfTrick = 0;
				    return listMST;
			    }
		    }
		    return listMST;
	    }

        private int getMinIndex(int n, List<int> d, bool[] used)
        {
            int min = MAX, num = 0;
            for (int i = 0; i < n; i++)
            {
                if (min > d[i] && !used[i])
                {
                    num = i;
                    min = d[i];
                }
            }
            return num;
        }
        
        public List<int> Dijkstra(int a)
	    {		
		    bool[] used = new bool[countOfVertex];
		    List<int> d = new List<int>(countOfVertex);
		    List<List<Tuple<int, int>>> g = new List<List<Tuple<int, int>>>();

            for(int i = 0; i < countOfVertex; i++)
            {
                g.Insert(i, new List<Tuple<int, int>>());
            }

            
		    for (int i = 0; i < listOfRibs.Count(); i++)
		    {
                Tuple<int, int> newp = new Tuple<int, int>(listOfRibs[i].se, listOfRibs[i].weight);
		        g[listOfRibs[i].fi].Add(newp);                
		    }
            for (int i = 0; i < countOfVertex; i++)
            {
                d.Insert(i, MAX);
            }
		    

		    for (int i = 0; i < g[a].Count(); i++)
		    {
		         d[g[a][i].Item1] = g[a][i].Item2; 
		    }

		    d[a] = 0;


            for (int i = 0; i < countOfVertex; i++)
            {
                used[i] = false; 
            }

		    used[a] = true;

		    int j;

		    for (int i = 0; i < countOfVertex - 2; i++)
		    {
			    j = getMinIndex(countOfVertex, d, used);

			    used[j] = true;

			    for (int q = 0; q < g[j].Count(); q++)
			    {
				    int w = g[j][q].Item1;
				    if (d[w] == MAX || d[w] > d[j] + g[j][q].Item2)
				    {
					    d[w] = d[j] + g[j][q].Item2;
				    }
			    }
		    }
		    return d;
	    }

        public int[][] Floyd()
        {
            int[][] newMatrix;
            newMatrix = new int[countOfVertex][];
            for (int i = 0; i < countOfVertex; i++)
            {
                newMatrix[i] = new int[countOfVertex];
                for (int j = 0; j < countOfVertex; j++)
                {
                    if (i == j)
                        newMatrix[i][j] = 0;
                    else
                        newMatrix[i][j] = MAX;

                }

            }
            newMatrix = matrix;

            for (int k = 0; k < countOfVertex; k++)
            {
                for (int i = 0; i < countOfVertex; i++)
                {
                    for (int j = 0; j < countOfVertex; j++)
                    {
                        newMatrix[i][j] = Math.Min(newMatrix[i][j], newMatrix[i][k] + newMatrix[k][j]);
                    }
                }
            }

            return newMatrix;
        }

    }
}
