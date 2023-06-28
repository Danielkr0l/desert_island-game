using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    internal class Animals
    {
        public string Name { get; set; }
        public int Meat { get; set; }
        private (int, int) damage;
        private int hp;
        public (int, int) Localization { get; set; }
        Random random = new Random();

        public Animals()
        {
            
            
            string filePath = "Zwierzęta.txt";
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int randomNumber = random.Next(0, lines.Length -1);
                string line = lines[randomNumber];
                string[] oneAnimal = line.Split(';');

                Name = oneAnimal[0];
                damage = (int.Parse(oneAnimal[1]), int.Parse(oneAnimal[2]));
                Meat = int.Parse(oneAnimal[3]);
                hp = int.Parse(oneAnimal[4]);


            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik ze zwierzętami nie został znaleziony.");
            }
            catch (IOException e)
            {
                Console.WriteLine("Wystąpił błąd odczytu pliku ze zwierzętami: " + e.Message);
            }
        }

        public string AnimalInfo()
        {
            return Name + " " + damage;
        }

        public (int,int) FightPoints()
        {
            return (random.Next(damage.Item1, damage.Item2),hp);
        }
    }
    
}
