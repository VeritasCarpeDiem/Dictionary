using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

    class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public KeyValuePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    class MyDictionary<TKey, TValue> where TKey : IComparable<TKey>
    {

        LinkedList<KeyValuePair<TKey, TValue>>[] buckets;

        int bucketSize;
        public int Count { get; private set; }
        public MyDictionary()
        {
            bucketSize = 100;
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[bucketSize];
        }

        public int Hash(string key)
        {
            int hash = 0;

            //  s[0]*31^(n-1) + s[1]*31^(n-2) + ... + s[n-1]
            int count = key.Length - 1;
            for (int i = 0; i < key.Length; i++)
            {
                int asciiValue = key[i];

                hash = asciiValue * (int)(Math.Pow(31, count));
                count--;
            }

            return hash % bucketSize;

        }

        public void Add(TKey key, TValue value)
        {
            int bucketNumber = Hash(key.ToString());

            if (buckets[bucketNumber] == null)
            {
                buckets[bucketNumber] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            buckets[bucketNumber].AddLast(new KeyValuePair<TKey, TValue>(key, value));

        }

        public TValue GetValue(TKey key)
        {
            //TValue value;

            //for (int i=0;i<buckets.Length();i++)
            //{
            //    if (key == buckets[i])
            //    {
            //         value= Hash(key.ToString().Length()) % bucketSize;
            //    }
            //}
            //return value;
            int bucket = Hash(key.ToString());

            if (buckets[bucket] == null)
            {
                throw new Exception("Key does not exist");
            }

                foreach (var item in buckets[bucket])
                {
                    if (item.Key.CompareTo(key) == 0)
                    {
                        return item.Value;
                    }
                }

                throw new Exception("Key does not exist!");
            }
        }
    //resize, remove, search
    }

