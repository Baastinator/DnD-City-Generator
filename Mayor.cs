using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_City_Generator
{
    class Mayor
    {
        public static Random RNG = new Random();

        public int age, ambition, hostility, science, artisan, justice, hedonism;
        public string name, title;


        Mayor(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void RandomiseStats()
        {
            ambition = D100();
            hostility = D100();
            science = D100();
            artisan = D100();
            justice = D100();
            hedonism = D100();
        }
        public int[] GetStatArray()
        {
            return new int[] { ambition, hostility, science, artisan, justice, hedonism, science+artisan};
        }

        public static string GetTitle(Mayor mayor)
        {
            int[] stats = mayor.GetStatArray();
            string Title = "The ";
            string title = "";

            int largest = Program.Largest(stats);
            int smallest = Program.Smallest(stats);

            if (stats[largest] < 70) return "";
            switch (largest)
            {
                case 0:
                    title = "Ambitious";
                    break;
                case 1:
                    title = "General";
                    break;
                case 2:
                    title = "Scientist";
                    break;
                case 3:
                    title = "Craftsman";
                    break;
                case 4:
                    title = "Just";
                    break;
                case 5:
                    title = "Glutton";
                    break;
                case 6:
                    title = "Wise";
                    break;
            }

            Title += title;

            return Title;
        }

        public static int D100()
        {
            return RNG.Next(1, 101);
        }
    }
}
