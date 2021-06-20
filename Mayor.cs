using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_City_Generator
{
    class Mayor
    {
        public static Random RNG = new Random();

        public int age, ambition, hostility, science, artisan, justice, hedonism, wisdom;
        public string title, name;

        public Mayor(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string GetDisplayString()
        {
            string dis = "";

            dis += "\n"; for (int i = 0; i < Math.Max(name.Length + title.Length + 22, 30); i++) { dis += "-"; }
            dis += "\nName: " + name + " " + title + ", " + age + " years old";
            dis += "\n"; for (int i = 0; i < Math.Max(name.Length + title.Length + 22, 30); i++) { dis += "-"; }
            dis += "\nAmbition:  " + ambition;
            dis += "\nHostility: " + hostility;
            dis += "\nScience:   " + science;
            dis += "\nArtisan:   " + artisan;
            dis += "\nJustice:   " + justice;
            dis += "\nHedonism:  " + hedonism;
            dis += "\nWisdom:    " + wisdom ;
            dis += "\n---------------";
            dis += "\n";
            dis += "\n";

            return dis;
        }
        public void RandomiseStats()
        {
            ambition = D100();
            hostility = D100();
            science = D100();
            artisan = D100();
            justice = D100();
            hedonism = D100();
            wisdom = (int)((artisan + science) / 1.5);
        }
        public int[] GetStatArray()
        {
            return new int[] { ambition, hostility, science, artisan, justice, hedonism, wisdom};
        }
        public static string GetName()
        {
            string[] names = File.ReadAllLines("Names.txt");
            return names[Mayor.D100()];
        }
        public static string GetTitle(Mayor mayor)
        {
            int[] stats = mayor.GetStatArray();
            string Title = "The ";
            string title = "";

            int largest = Program.Largest(stats);
            int smallest = Program.Smallest(stats);

            if (mayor.age > 80) return "The Old";
            if (stats[smallest] < 5)
            {
                switch (smallest)
                {
                    case 0:
                        title = "Satisfied";
                        break;
                    case 1:
                        title = "Peaceful";
                        break;
                    case 2:
                        title = "Traditional";
                        break;
                    case 3:
                        return "";
                    case 4:
                        title = "Tyrant";
                        break;
                    case 5:
                        title = "Greedy";
                        break;
                }
                return Title + title;
            }
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
        public static int GetAge()
        {
            return RNG.Next(20, 61);
        }
        public static int D100()
        {
            return RNG.Next(1, 101);
        }
    }
}
