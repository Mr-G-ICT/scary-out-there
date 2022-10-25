using System;
using System.IO;
using System.Linq;

namespace Spooky
{
    internal class Program
    {
        public static int ghosts;
        public static int ghouls;
        public static int witches;
        public static int vampires;
        public static int zombies;
        public static int trolls;

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


                for (int lineCount = 0; lineCount < allLines.Length; lineCount++)
                {
                    string[] words = allLines[lineCount].Split(' ');

                    for (int wordCount = 0; wordCount < words.Length; wordCount++)
                    {
                        string word = words[wordCount].ToLower();
                        //sort out the XML File
                        if (word.Contains("amount"))
                        {
                            //had to do it this way as it didn't like the diamonds around amount
                            word = word.Replace("amount", "").Replace("<>", "").Replace("</>", "");
                            amount = int.Parse(word);
                            addToMonster(amount - 1, monster);

                            monster = "";
                            lineCount = lineCount + 1;
                        }
                        else if (word.Any(char.IsDigit))
                        {
                            //sort out the txt files
                            word = word.Trim('"').TrimEnd('"', ',');
                            amount = int.Parse(word);
                            if (wordCount + 1 < words.Length)
                                monster = words[wordCount + 1].ToLower();
                            else 
                                monster = "";
                            addToMonster(amount - 1, monster);
                        }
                        else if(word.Contains("[")){
                            int count = 0;
                            //this is looking for the mention of json
                            while (!word.Contains("]"))
                            {
                               
                                lineCount++;
                                word = allLines[lineCount];
                                if (word.Contains('}'))
                                    count++;
                            }
                            addToMonster(count - 1, monster);
                        }
                       else if (validwords.Any(word.Contains))
                       {
                            //this sorts out single mentions of witch etc.
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
                ghouls = ghouls + amount;
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
