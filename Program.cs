using System;

namespace DnD_City_Generator
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] test = { 2, 4, 6, 3, 8, 3, 5, 7, 111};
            Console.WriteLine(Smallest(test));
            Console.ReadLine();
        }

        public static int Largest(int[] input)
        {
            int index = 0;
            int value = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > value) { value = input[i]; index = i; }
            }
            return index;
        }
        public static int Smallest(int[] input)
        {
            int index = input.Length;
            int value = Largest(input);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < value) { value = input[i]; index = i; }
            }
            return index;
        }
    }
}
