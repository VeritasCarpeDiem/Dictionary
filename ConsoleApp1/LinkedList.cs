using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp1
{
    class SimpleNode
    {
        public int value;

        public SimpleNode next;


        public SimpleNode(int val)
        {
            value = val;
        }
    }
    class Node<T>
    {
        public T Value { get; private set; }

        public Node<T> Next { get; set; }

        public Node(T val)
        {
            Value = val;
        }
    }
    class LinkedList<T>: IEnumerable<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }


        public int Count { get; private set; }

        public LinkedList()
        {
            Clear();
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddLast(T val)
        {
            if (Count == 0)
            {
                Head = new Node<T>(val);
                Tail = Head;
            }
            else
            {
                Tail.Next = new Node<T>(val);
                Tail = Tail.Next;
            }

            Count++;
        }
        

        public void ReverseList()
        {
            //1->2->3
            //3->2->1
            Node<T> prev = null;
            Node<T> current = Head;
            Node<T> next = null;

            while(current != null)
            {
                current.Next = next;
                next = prev;
                prev = current;
                current = next;
                
            }
            Head = prev;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
