using System;
using System.IO;
using System.Linq;

namespace Spooky
{

    internal class Program
    {
        public static int ghosts;
        public static int ghouls;
        public static int witches = 0;
        public static int vampires = 0;
        public static int zombies = 0;
        public static int trolls = 0;

        static void Main(string[] args)
        {
            String Path = "data";
            int amount = 0;

            string[] files = Directory.GetFiles(Path);
            string[] validwords = new string[] { "ghoul", "ghost", "vampire", "zombie", "witch", "troll" };
            string monster = "";

            foreach (string file in files)
            {
                Console.WriteLine(file);

                string[] allLines = File.ReadAllLines(file);
                monster = "";


                for (int i = 0; i < allLines.Length; i++)
                {
                    string[] words = allLines[i].Split(' ');

                    for (int x = 0; x < words.Length; x++)
                    {
                        string word = words[x].ToLower();
                        if (word.Contains("amount"))
                        {
                            word = word.Replace("amount", "");
                            word = word.Replace("<>", "");
                            word = word.Replace("</>", ""); ;
                            amount = int.Parse(word);
                            Console.WriteLine("FOUND" + amount);
                            Console.WriteLine("monster" + monster);
                            addToMonster(amount - 1, monster);

                            Console.WriteLine("reset Monster");
                            monster = "";
                            i = i + 1;
                        }
                        else if (word.Any(char.IsDigit))
                        {

                            word = word.Trim('"').TrimEnd('"', ',');
                            amount = int.Parse(word);
                            if (x + 1 < words.Length)
                            {
                                monster = words[x + 1].ToLower();
                            }
                            else
                            {
                                monster = "";
                            }
                            addToMonster(amount - 1, monster);
                            Console.WriteLine(word + "Added" + monster + "to monster");

                        }
                       else if (validwords.Any(word.Contains))
                       {
                           Console.WriteLine(word);
                           monster = word;
                           amount = 1;
                           addToMonster(1, monster);
                        }

                    }

                }
            }
                Console.WriteLine("Ghouls:" + ghouls);
                Console.WriteLine("Ghosts:" + ghosts);
                Console.WriteLine("vampires:" + vampires);
                Console.WriteLine("zombies:" + zombies);
                Console.WriteLine("Whitches:" + witches);
                Console.WriteLine("trolls:" + trolls);

            }

            static void addToMonster(int amount, string monster)
            {
            if (monster.Contains("ghosts") || monster.Contains("ghost"))
            {
                ghosts = ghosts + amount;

            }
            else if (monster.Contains("ghouls") || monster.Contains("ghoul"))
            {
                ghouls = ghouls + amount; ;
            }
            else if (monster.Contains("vampires") || monster.Contains("vampire"))
            {
                vampires = vampires + amount;
            }
            else if (monster.Contains("zombies") || monster.Contains("zombie"))
            {
                zombies = zombies + amount;
            }
            else if (monster.Contains("witches") || monster.Contains("witch"))
            {
                witches = witches + amount;

            }
            else if (monster.Contains("trolls") || monster.Contains("troll"))
            {
                trolls = trolls + amount;
            }
        }
    }
}
