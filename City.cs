using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DnD_City_Generator
{
    class City
    {
        public string name, size, type;
        public int population, militarySize, defenceStrength;
        public Mayor mayor;

        public City(string name)
        {
            this.name = name;
            mayor = new Mayor(Mayor.GetName(), Mayor.GetAge());
            mayor.RandomiseStats();
            mayor.title = Mayor.GetTitle(mayor);
        }

        // 0 Hamlet; 1 Village; 2 Locality; 3 Township; 4 Town; 5 County Capital; 6 City; 7 Capital;
        public static int GetPop(int lvl) 
        {
            int min = 0, max = 0;
            switch (lvl)
            {
                case 0:
                    min = 0; max = 100;
                    break;
                case 1:
                    min = 100; max = 150;
                    break;
                case 2:
                    min = 150; max = 1000;
                    break;
                case 3:
                    min = 1000; max = 10000;
                    break;
                case 4:
                    min = 10000; max = 100000;
                    break;
                case 5:
                    min = 100000; max = 300000;
                    break;
                case 6:
                    min = 300000; max = 1000000;
                    break;
                case 7:
                    min = 1000000; max = 10000000;
                    break;
            }
            return Mayor.RNG.Next(min,max+1);
        }

        public static string GetName()
        {
            string[] names = File.ReadAllLines("Cities.txt");
            
            return names[Mayor.D100()];
        }

        public static int MakePop(int rangeMin, int rangeMax)
        {
            return Mayor.RNG.Next(rangeMin, rangeMax + 1); 
        }        

    }
}
