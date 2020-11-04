using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static int EvenNumbers(int[] Numbers)
        {
            int count = 0;
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i]%2 == 0)                      // if the number is divisible by 2 its even.
                {
                    count += 1;
                }
            }
            return count;
        }

        static void Frequency (Dictionary<int, int> FrequencyDictionary, int[] Numbers)
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (FrequencyDictionary.ContainsKey(Numbers[i]))            // if the directory already has this key
                {                                                           // add the value of that key to a temp variable
                    var count = FrequencyDictionary[Numbers[i]];            // then remove the key and add it again with value
                    FrequencyDictionary.Remove(Numbers[i]);                 // incremented by
                    FrequencyDictionary.Add(Numbers[i], count + 1);
                }
                else                                                        //if not just add the key with a count of 1
                {
                    FrequencyDictionary.Add(Numbers[i], 1);
                }
            }
        }
        static void Main(string[] args)
        {
            int[] Numbers = { 1, 9, 4, 6, 8, 10, 7, 44, 22, 6, 2, 1, 3, 7, 2, 3, 4, 5, 7, 6, 4, 3, 2, 1, 8, 9, 11, 22, 33, 45, 5, 10, 3, 2 };

            var Sum = Numbers.Sum();
            Console.WriteLine("Sum: " + Sum);

            var Avg = Numbers.Average();
            Console.WriteLine("Average: " + Avg);

            var EvenAmount = EvenNumbers(Numbers);
            Console.WriteLine("Amount of Even Numbers: " + EvenAmount);

            var OddAmount = Numbers.Length - EvenAmount;
            Console.WriteLine("Amount of Odd Numbers: " + OddAmount);

            Dictionary<int, int> FrequencyDictionary = new Dictionary<int, int>();          // Creates the new Dictionary
            Frequency(FrequencyDictionary, Numbers);   
            for (int i = 0; i < FrequencyDictionary.Count; i++)                             // goes through the dictionary and prints out the key and value pair
            {                                                                               // with some descriptive text
                Console.WriteLine("Number: {0}, Frequency: {1}", FrequencyDictionary.ElementAt(i).Key, FrequencyDictionary.ElementAt(i).Value);
            }

        }
    }
}
