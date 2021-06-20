using System;
using System.Linq;

namespace DnD_City_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            City city = new City(City.GetName());

            Console.WriteLine(city.mayor.GetDisplayString());

            Console.ReadLine();
        }

        public static int Largest(int[] input)
        {
            int max = input.Max();
            int index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (max == input[i])
                {
                    index = i;
                }
            }
            return index;
        }
        public static int Smallest(int[] input)
        {
            int min = input.Min();
            int index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (min == input[i])
                {
                    index = i;
                }
            }
            return index;
        }
    }
}
