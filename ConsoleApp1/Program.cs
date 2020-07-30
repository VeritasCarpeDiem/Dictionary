using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node = new Node<int>(5);

            Node<string> stringnode = new Node<string>("blah");

            MyDictionary<string, string> dict = new MyDictionary<string, string>();

            dict.Add("karan", "instructor at gmr");

            char start = 'a';
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"{start} = {dict.Hash(start.ToString())}");

                dict.Add(start.ToString(), start.ToString());

                start++;
            }

            //var dict = new MyDictionary<string, string>();
            dict.Add("apple", "fruit");
            dict.Add("orange", "fruit");

            Console.WriteLine(new string('-', 100));
            Console.WriteLine(dict.GetValue("orange"));
        }
        
    }
}
