using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    public class Hashing
    {
        private const int PrimeNumber = 7;
        private readonly double KnuthConst = (Math.Sqrt(5) + 1) / 2;
        private readonly double MyKnuthConst = (
            2 +
            Math.Pow(116 + 12 * Math.Sqrt(93), 1.0 / 3) +
            Math.Pow(116 - 12 * Math.Sqrt(93), 1.0 / 3)
        ) / 6; // 1,47
        
        private LinkedList<int>[] _hashTable;
        private int _currentSize;
        private int _tableSize;

        public Hashing(int size)
        {
            _tableSize = size;
            _hashTable = new LinkedList<int>[_tableSize];
            _currentSize = 0;
            
            for (var i = 0; i < _tableSize; i += 1)
            {
                _hashTable[i] = new LinkedList<int>();
            }
        }

        private bool IsFull()
        {
            return _currentSize >= _tableSize;
        }

        private int MultiplicationHash(int key, bool useOwnConst = false)
        {
            var multiplyConstant = useOwnConst ? MyKnuthConst : KnuthConst;
            return (int) Math.Floor(_tableSize * (key * multiplyConstant - Math.Floor(key * multiplyConstant)));
        }

        private static int SecondHash(int key)
        {
            return PrimeNumber - key % PrimeNumber;
        }

        private void DoubleHashing(int index, int key)
        {
            if (IsFull())
            {
                _hashTable[index].AddLast(key);
                _currentSize += 1;
                return;
            }

            var secondIndex = SecondHash(key);

            if (_hashTable[index].Count != 0)
            {
                var i = 1;
                while (true)
                {
                    var newIndex = (index + i * secondIndex) % _tableSize;

                    if (_hashTable[newIndex].Count == 0)
                    {
                        _hashTable[newIndex].AddLast(key);
                        break;
                    }

                    i += 1;
                }
            }
            else
            {
                _hashTable[index].AddLast(key);
            }

            _currentSize += 1;
        }

        private void LinearProbing(int index, int key)
        {
            if (IsFull())
            {
                _hashTable[index].AddLast(key);
                _currentSize += 1;
                return;
            }

            if (_hashTable[index].Count != 0)
            {
                for (int i = index + 1; i < index + _tableSize; i += 1)
                {
                    if (_hashTable[i % _tableSize].Count == 0)
                    {
                        _hashTable[i % _tableSize].AddLast(key);
                        break;
                    }
                }
            }
            else
            {
                _hashTable[index].AddLast(key);
            }

            _currentSize += 1;
        }

        private void Chaining(int index, int key)
        {
            _hashTable[index].AddLast(key);
        }

        public void Insert(int key, bool useOwnConst = false)
        {
            var index = MultiplicationHash(key, useOwnConst);
            DoubleHashing(index, key);
            // LinearProbing(index, key);
            // Chaining(index, key);
        }

        public void DisplayHash()
        {
            for (var i = 0; i < _tableSize; i++)
            {
                if (_hashTable[i].Count != 0)
                {
                    Console.Write(i);
                    for (int j = 0; j < _hashTable[i].Count; j += 1)
                    {
                        Console.Write(" ---> " + _hashTable[i].ElementAt(j));
                    }

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}