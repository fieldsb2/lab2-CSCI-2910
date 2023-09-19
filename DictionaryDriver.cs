using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1___CSCI_2910
{
   internal class DictionaryDriver
    {

        static public void Main(string[] args)
        {
            List<VideoGame> ChooseGame = new List<VideoGame>();
            string FilePath = "../../../../../videogames.csv";
            StreamReader str = new StreamReader(FilePath);
            str.ReadLine();
            string LineInfo = "";
            string name = "";
            string plat = "";
            int year = 0;
            string pub = "";
            string genre = "";
            string nsale = "";
            string esale = "";
            string jsale = "";
            string osale = "";
            string gsale = "";

            int position = 0;
            int count = File.ReadAllLines(FilePath).Length;
            count--;

            while (count != 0)
            {
                LineInfo = str.ReadLine();
                string[] games = LineInfo.Split(new string[] { "," }, StringSplitOptions.None);
                name = games[position];
                position++;
                plat = games[position];
                position++;
                year = int.Parse(games[position]);
                position++;
                pub = games[position];
                position++;
                genre = games[position];
                position++;
                nsale = games[position];
                position++;
                esale = games[position];
                position++;
                jsale = games[position];
                position++;
                osale = games[position];
                position++;
                gsale = games[position];
                position++;

                count--;
                VideoGame game1 = new VideoGame(name, plat, year, pub, genre, nsale, esale, jsale, osale, gsale);
                                                                                                                 
                ChooseGame.Add(game1);
                position = 0;
            }

            Dictionary<string, List<VideoGame>> myDictionary = ChooseGame.GroupBy(o => o.Platform).ToDictionary(g => g.Key, g => g.OrderByDescending(g => g.G_Sales).Take(5).ToList());


            foreach (var game in myDictionary)
            {
                Console.WriteLine("\n");
                Console.WriteLine(game.Key);
                Console.WriteLine("----------------------------------------: \n");
                for (int i = 0; i < game.Value.Count; i++)
                {
                    Console.WriteLine(game.Value[i].ToString());
                }
            }
        }
    }
}
