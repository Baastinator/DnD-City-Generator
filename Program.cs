using System;
using System.IO;
using System.Linq;

namespace DnD_City_Generator
{
    class Program
    {
        static City city;
        static int popLvl;

        public static Random RNG = new Random();

        static int[] debug = new int[3];

        /*city = new City(City.GetName());
        city.MayorStats(City.GetPop(popLvl));
        Console.WriteLine(city.mayor.GetDisplayString());*/

        public static void Main(string[] args)
        {   
            bool programLoop = true;
            bool nameLoop = true;
            while (programLoop) {
                bool nameSet = false;
                string name = "";
                while (nameLoop) {
                    try {
                        Console.Clear();
                        if (nameSet) Console.Write("Name: " + name + "\nType a new name if this is not correct\n");
                        else Console.Write("Please type a name for the city\n");
                        Console.Write("Type (C) to Cancel, (R) to randomise, (F) to Finish\n");
                        string input = Console.ReadLine();
                        if (input == "C") { programLoop = false; nameLoop = false; }
                        else if (input == "R") { name = City.GetName(); nameSet = true; }
                        else if (input == "F") { if (nameSet) { nameLoop = false; } }
                        else { name = input; nameSet = true; }
                    } catch (Exception a) { }
                }
                if (!programLoop) break;
                city = new City(name);
                bool popLoop = true; bool popRand = false;
                while (popLoop) {
                    try { // 0 Hamlet; 1 Village; 2 Locality; 3 Township; 4 Town; 5 County Capital; 6 City; 7 Capital;
                        Console.Clear();
                        Console.Write(  "(0) | Hamlet         | 0       - 100    ");
                        Console.Write("\n(1) | Village        | 100     - 150    ");
                        Console.Write("\n(2) | Locality       | 150     - 1000   ");
                        Console.Write("\n(3) | Township       | 1000    - 10000  ");
                        Console.Write("\n(4) | Town           | 10000   - 100000 ");
                        Console.Write("\n(5) | County Capital | 100000  - 300000 ");
                        Console.Write("\n(5) | City           | 300000  - 1000000");
                        Console.Write("\n(6) | Capital        | 1000000 - 3000000");
                        Console.Write("\n\nPlease Select Number\nTo Randomise press (R), to cancel press (C)\n");

                        string input = Console.ReadLine();

                        if (input == "R") popRand = true;
                        else if (input == "C") { popLoop = false; programLoop = false; }
                        else { popLvl = Convert.ToInt32(input); popLoop = false; city.MayorStats(City.GetPop(popLvl)); }
                        if (popRand) {
                            Console.Write("Please input lower bound of randomisation (0-7) ");
                            int min = Convert.ToInt32(Console.ReadLine()); debug[0] = min;
                            Console.Write("Please input upper bound of randomisation (0-7) ");
                            int max = Convert.ToInt32(Console.ReadLine()); debug[1] = max;
                            popLvl = RNG.Next(min, max + 1); popLoop = false;
                            debug[2] = popLvl;

                            city.MayorStats(City.GetPop(popLvl));
                        }
                    } catch (Exception a) { }
                }
                if (!programLoop) break;
                bool DisplayLoop = true;
                while (DisplayLoop) {
                    try {
                        Console.Clear();
                        Console.Write(city.GetCityString() + "\n\nWould you like to save (S) the file?\n");
                        string input = Console.ReadLine();
                        bool saveLoop = true; string saveLoopString = "";
                        while (saveLoop)
                        {
                            Console.Clear();
                            Console.Write("Please specify a" + saveLoopString + " filename: ");
                            string path = Environment.CurrentDirectory + "\\";
                            if (!Directory.Exists(path + "Towns\\"))
                            {
                                Directory.CreateDirectory(path + "Towns\\");
                            }
                            path += "Towns\\";
                            string fileName = Console.ReadLine();
                            path += fileName + ".txt";
                            if (!File.Exists(path))
                            {
                                using (StreamWriter sw = File.CreateText(path))
                                {
                                    sw.Write(city.GetCityString());
                                    saveLoop = false;
                                }
                            }
                            else saveLoopString = "n unused";
                        }
                    } catch (Exception a) { } 
                }
                Console.ReadLine();
            }
        }
        public static int Largest(int[] input) {
            int max = input.Max();
            int index = 0;
            for (int i = 0; i < input.Length; i++) {
                if (max == input[i]) { index = i; }
            } return index;
        }
        public static int Smallest(int[] input) {
            int min = input.Min();
            int index = 0;
            for (int i = 0; i < input.Length; i++) {
                if (min == input[i]) { index = i; }
            } return index;
        }
    }
}
