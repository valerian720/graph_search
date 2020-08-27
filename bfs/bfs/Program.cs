using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bfs
{
    /* алгоритм поиска в ширину
     * 
     * на вход идёт граф в виде квадратной csv таблицы (где столбцы и строки - узлы ) 
     *
     * граф хранится в виде массива (высотой в количество злов) списков (<номер узла>)
     *
     * //
     * временно хранится очередь из опрашиваемых вершин
     * //
     * в результате получается массив расстояний от исходной точки
     */

        /* пример входных данных
         *
         * 1;1;1
         * 1;1;1
         * 1;1;1
         */

    class Program
    {
        static void Main(string[] args)
        {
            // получение исходного графа
            string[] input = File.ReadAllLines("graph.txt"); 
            
            List<int>[] graph = new List<int>[input.Length]; 

            string[] temp; bool check; int intTemp;
            for (int i = 0; i < input.Length; i++) {
                graph[i] = new List<int>();

                temp = input[i].Split(';');
                for (int j = 0; j < temp.Length; j++) {

                    check = int.TryParse(temp[j], out intTemp);
                    if (check) {
                        if (intTemp>0)
                            graph[i].Add(j);
                    }
                }
            }

            // проход по узлам
            int[] widthPath = new int[input.Length]; // индекс - номер узла
            Queue<int> queue = new Queue<int>(); // хранение опрашиваемых узлов
            bool flag = true;
            int ret = -1;
            //======================
            int firstNode = 0;
            int lastNode = 2;
            //======================

             // 0вое ветвление
             queue.Enqueue(firstNode);

            int selected; int value = 0; int curQueueLen;
            do // внешний цикл
            {
                curQueueLen = queue.Count;
                for (int i = 0; i < curQueueLen; i++) // цикл по текущей очереди
                {

                    selected = queue.Dequeue();

                    if (lastNode == selected) { // конечная точка найдена
                        ret = value;
                        flag = false;
                        break;
                    }

                    if (widthPath[selected] == 0)
                    {
                        widthPath[selected] = value;
                        foreach(int node in graph[selected]) // добавление связанных узлов в очередь
                        queue.Enqueue(node);
                    }

                }
                value++;
            }
            while (queue.Count > 0 && flag);

            // вывод расстояния от входа до выхода

            if (flag)
                Console.WriteLine("out of reach");
            else
                Console.WriteLine("путь от "+firstNode+" до "+lastNode+" = "+ret);

            Console.ReadLine();
        }
    }
}
