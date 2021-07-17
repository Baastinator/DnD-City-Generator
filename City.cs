using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DnD_City_Generator
{
    class City
    {
        public string name;
        public int population, size, militarySize, defenceStrength;
        public Mayor mayor;

        public City(string name)
        {
            this.name = name;
            mayor = new Mayor(Mayor.GetName(), Mayor.GetAge());
            mayor.RandomiseStats();
            mayor.title = Mayor.GetTitle(mayor);            
        }
        public void MayorStats(int[] pop)
        {
            size = pop[1];
            population = (int)(pop[0] + pop[0] * (Math.Pow((1 + Math.Exp(-((mayor.ambition - 50) / 30))), -1)) - 0.5f);
            militarySize = (int)(population*(1+(Math.Pow(1+Math.Exp(-((mayor.hostility - 50)/13.5)),-1)-0.5)) / 2);
            defenceStrength = (int)(militarySize * (0.75f - (mayor.hostility / 200f)));
        }
        public static int[] GetPop(int lvl) 
        {
            // 0 Hamlet; 1 Village; 2 Locality; 3 Township; 4 Town; 5 County Capital; 6 City; 7 Capital;
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
                    min = 1000000; max = 3000000;
                    break;
            }
            return new int[] { Mayor.RNG.Next(min, max + 1) , lvl};
        }
        public string GetCityString()
        {
            int min = mayor.DisplayStringTitleLength();

            string a = "";

            for (int i = 0; i < Math.Max(min, name.Length); i++) { a += "-"; }
            a += "\nCity: " + name + "\n";
            for (int i = 0; i < Math.Max(min, name.Length); i++) { a += "-"; }
            a += "\nPopulation: " + population;
            a += "\nSize: " + GetLevelString();
            a += "\nReserve Military Size: " + militarySize;
            a += "\nDefence Force Size: " + defenceStrength;
            a += "\n";


            a += mayor.GetDisplayString(name.Length);

            return a;
        }
        public static string GetName()
        {
            string[] names = File.ReadAllLines("Cities.txt");
            
            return names[Mayor.D100()];
        }
        public string GetLevelString()
        {
            // 0 Hamlet; 1 Village; 2 Locality; 3 Township; 4 Town; 5 County Capital; 6 City; 7 Capital;
            switch (size)
            {
                case 0:
                    return "Hamlet";
                case 1:
                    return "Village";
                case 2:
                    return "Locality";
                case 3:
                    return "Township";
                case 4:
                    return "Town";
                case 5:
                    return "County Capital";
                case 6:
                    return "City";
                case 7:
                    return "Capital";
            }
            throw new Exception("GetLevelString");
        }
    }
}
