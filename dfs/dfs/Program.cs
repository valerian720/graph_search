using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfs
{
    

    class Program
    {
        /* поиск в лубину (получение списка вершин до которой можно добраться от заданой вершины)
         *
         * на вход граф
         *
         * на выходе список вершин, до которых можно добраться
         * 
         * алгоритм строится на основе рекурсии и передаваемого списка 
         */
        static List<int>[] graph;

        static void Main(string[] args)
        {
            // получение исходного графа
            string[] input = File.ReadAllLines("graph.txt");

             graph = new List<int>[input.Length];

            string[] temp; bool check; int intTemp;
            for (int i = 0; i < input.Length; i++)
            {
                graph[i] = new List<int>();

                temp = input[i].Split(';');
                for (int j = 0; j < temp.Length; j++)
                {

                    check = int.TryParse(temp[j], out intTemp);
                    if (check)
                    {
                        if (intTemp > 0)
                            graph[i].Add(j);
                    }
                }
            }
            //
            bool[] passed = new bool[graph.Length];
            for (int i = 0; i < passed.Length; i++) passed[i] = false;

            int firstNode = 1;

            f(firstNode, ref passed);
            Console.ReadLine();
        }
        // рекурсия
        static void f(int nodeIndex, ref bool[] passedNodes){

            if (!passedNodes[nodeIndex])
            {
                Console.WriteLine("=> " + nodeIndex);
                passedNodes[nodeIndex] = true;
                foreach (int item in graph[nodeIndex]) {
                    f(item,ref passedNodes);
                }
            }

         }
        
    }
}
