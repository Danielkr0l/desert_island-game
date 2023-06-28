using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    internal class Island
    {
        public int Size { get; }

        public Island(int x)
        {
            Size = x;

        }



        public Dictionary<(int, int), Animals> LocalizeAnimals(List<Animals> animals)
        {
            Dictionary<(int,int), Animals> dict = new Dictionary<(int,int), Animals>();
            foreach (Animals animal in animals)
            {
                Random random = new Random();
                int x, y;
                do
                {
                    x = random.Next(0, Size+1);
                    y = random.Next(0, Size+1);
                    dict.ContainsKey((x, y));

                } while (dict.ContainsKey((x, y)) || (x, y) == (0, 0));
                animal.Localization = (x, y);
                dict.Add((x, y), animal);
            }
            return dict;
        }

        public Dictionary<(int, int), Question> LocalizeQuestion(List<Question> questions)
        {
            Dictionary<(int,int), Question> dict = new Dictionary<(int,int), Question>();
            foreach (Question question in questions)
            {
                Random random = new Random();
                int x, y;
                do
                {
                    x = random.Next(0, Size + 1);
                    y = random.Next(0, Size + 1);
                    dict.ContainsKey((x, y));

                } while (dict.ContainsKey((x, y)) || (x,y) == (0,0));
                
               
                question.Localization = (x, y);
                dict.Add((x, y), question);
            }

            return dict;
        }

        public Dictionary<(int, int), Items> LocalizeItems(List<Items> items)
        {
            Dictionary<(int, int), Items> dict = new Dictionary<(int, int), Items>();
            foreach (Items item in items)
            {
                Random random = new Random();
                int x, y;
                do
                {
                    x = random.Next(0, Size + 1);
                    y = random.Next(0, Size + 1);
                    dict.ContainsKey((x, y));

                } while (dict.ContainsKey((x, y)) || (x, y) == (0, 0));


                item.Localization = (x, y);
                dict.Add((x, y), item);
            }

            return dict;

        }
    }
}
