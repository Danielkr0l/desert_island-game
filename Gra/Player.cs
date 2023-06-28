using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    internal class Player
    {
        public string Name { get; set; }
        
        public Health Health { get; set; }
        public (int, int) Localization { get; set; }

        Random random = new Random();

        public Player(string name)
        {
            Health = new Health();
            Name = name;
            Health.Heart = 100;
            Health.Hunger = 100;
            Localization = (0, 0);
        }



        public void Hurt(int value) 
        {
            Health.GetDamage(value);
        }

        public void Eat(int value)
        {
            Health.GetEat(value);
        }

        public void GetHunger(int value)
        {
            Health.GetHunger(value);
        }
        
        public string CheckFood()
        {

            if(Health.Hunger == 0)
            {
                Health.GetDamage(20);
                return "Zdobądź jedzenie (-20hp)";
            }

            return "";
            
        }

        public bool IsAlive()
        {
            if (Health.Heart <= 0) return false;
            else return true;
        }

        public bool Fight((int ,int) val)
        {
            int value = val.Item1;
            int hp = val.Item2;
            value = value / 2;

            while(hp > 0)
            {
                int myForce = random.Next(1, 30);
                hp -= myForce;
                this.Hurt(value);

                if (!this.IsAlive())
                    return false;
               
            }
            Console.WriteLine("Twoje życie:" + Health.Heart);
            return true;
        }

        public void MoveUp()
        {
            int a = Localization.Item1;
            int b = Localization.Item2;
            b += 1;
            Localization = (a, b);
        }
        public void MoveDown()
        {
            int a = Localization.Item1;
            int b = Localization.Item2;
            b -= 1;
            Localization = (a, b);
        }
        public void MoveLeft()
        {
            int a = Localization.Item1;
            int b = Localization.Item2;
            a -= 1;
            Localization = (a, b);
        }
        public void MoveRight()
        {
            int a = Localization.Item1;
            int b = Localization.Item2;
            a += 1;
            Localization = (a, b);
        }

    }
}
