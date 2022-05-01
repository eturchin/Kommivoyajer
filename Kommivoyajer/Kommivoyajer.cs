using System;

namespace Kommivoyajer
{
    public class Graph
    {
        private readonly Node _graph;

        public Graph(int[,] arr)
        {
            _graph = new Node(arr);
        }


        public void SearchGm() //внешний класс Гамильтонов
        {
            var count = 0;
            var minimum = int.MaxValue;
            _graph.NovSet();
            var way = new int[_graph.Size + 1];
            var st = new int[_graph.Size + 1];
            st[0] = 0;
            _graph[0] = false; //обращение к индексатору
            _graph.SearchGm(1, ref st, ref count, ref minimum, ref way);
            Console.WriteLine($"Количество вариантов путей: {count}");
            Console.Write("Путь: ");
            foreach (var item in way) Console.Write($"{item} ");
            Console.WriteLine($"\nМинимальное расстояние: {minimum}");
        }

        private class Node //вложенный класс для скрытия данных и алгоритмов
        {
            private readonly int[,] _array; //матрица смежности

            private readonly bool[] _nov; //вспомогательный массив: если i-ый элемент массива равен

            public Node(int[,] a)
            {
                _array = a;
                _nov = new bool[a.GetLength(0)];
            }

            public bool this[int i] //индексатор для обращения к матрице меток
            {
                set => _nov[i] = value;
            }

            public int Size => _array.GetLength(0); //свойство для получения размерности матрицы смежности

            public void NovSet() //метод помечает все вершины графа как непросмотреные
            {
                for (var i = 0; i < Size; i++) _nov[i] = true;
            }

            public void SearchGm(int k, ref int[] st, ref int count, ref int minimum, ref int[] way)
            {
                var v = st[k - 1];
                for (var j = 0; j < _array.GetLength(0); j++)
                    if (_array[v, j] != 0)
                    {
                        if (k == _array.GetLength(0) && j == 0)
                        {
                            var sum = 0;
                            st[k] = j;
                            foreach (var item in st) Console.Write("{0} ", item + 1);
                            for (var i = 0; i < st.Length - 1; i++) sum += _array[st[i], st[i + 1]];
                            Console.WriteLine($"Сумма = {sum}");
                            if (sum < minimum)
                            {
                                minimum = sum;
                                for (var i = 0; i < st.Length; i++) way[i] = st[i] + 1;
                            }
                            Console.WriteLine("\n-----\n");
                            count++;
                        }
                        else
                        {
                            if (!_nov[j]) continue;
                            st[k] = j;
                            _nov[j] = false;
                            SearchGm(k + 1, ref st, ref count, ref minimum, ref way);
                            _nov[j] = true;
                        }
                    }
            }
        }
    }
}