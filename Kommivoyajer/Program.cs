using System;

namespace Kommivoyajer
{
    internal class Program
    {
        private static void Main()
        {
            var g = new Graph();
            g.SearchGm();
        }

        public class Stack
        {
            private Node _head; //ссылка на вершину стека

            public Stack() //конструктор класса, создает пустой стек
            {
                _head = null;
            }

            public bool IsEmpty => _head == null; //определяет пуст или нет стек

            public void Push(object nodeInfo) // добавляет элемент в вершину стека
            {
                var r = new Node(nodeInfo)
                {
                    Next = _head
                };
                _head = r;
            }

            public object Pop() //извлекает элемент из вершины стека, если он не пуст
            {
                if (_head == null) throw new Exception("Стек пуст");

                var r = _head;
                _head = r.Next;
                return r.Inf;
            }

            private class Node //вложенный класс, реализующий элемент стека
            {
                public Node(object nodeInfo)
                {
                    Inf = nodeInfo;
                    Next = null;
                }

                public Node Next { get; set; }

                public object Inf { get; }
            } //конец класса Node
        }

        public class Queue
        {
            private readonly Node _head;
            public Node Tail;

            public Queue()
            {
                _head = null;
                Tail = null;
            }

            public bool IsEmpty => _head == null;

            internal class Node //вложенный класс, реализующий базовый элемент очереди
            {
            } //конец класса Node
        }

        public class Graph
        {
            private readonly Node _graph; //закрытое поле, реализующее АТД «граф»

            public Graph() //конструктор внешнего класса
            {
                int[,] a =
                {
                    { int.MaxValue, 4, 39, 22, 10, 47 },
                    { 58, int.MaxValue, 56, 18, 4, 35 },
                    { 57, 85, int.MaxValue, 24, 38, 52 },
                    { 30, 50, 44, int.MaxValue, 9, 31 },
                    { 18, 42, 24, 31, int.MaxValue, 30 },
                    { 1, 38, 31, 19, 32, int.MaxValue }
                };
                _graph = new Node(a);
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

                //конструктор вложенного класса, инициализирует матрицу смежности и
                // вспомогательный массив
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

                //true, то i-ая вершина еще не просмотрена; если i-ый
                //элемент равен false, то i-ая вершина просмотрена
                public void NovSet() //метод помечает все вершины графа как непросмотреные
                {
                    for (var i = 0; i < Size; i++) _nov[i] = true;
                }

                public void SearchGm(int k, ref int[] st, ref int count, ref int minimum,
                    ref int[] way) //вложенный класс
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
            } //конец вложенного клаcса
        }
    }
}