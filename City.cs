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
            //mayor = new Mayor()
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
