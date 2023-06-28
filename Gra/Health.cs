using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    internal class Health
    {
        public int Heart { get; set; }
        public int Hunger { get; set; }


        public void GetDamage(int damage)
        {
            Heart -= damage;
        }

        public void GetHealth(int healthPoints)
        {
            if (Heart + healthPoints >= 100)
            {
                Heart = 100;
            }
            else
            {
                Heart += healthPoints;
            }
        }


        public void GetEat(int foodPoints)
        {
            if (Hunger + foodPoints >= 100)
            {
                Hunger = 100;
            }
            else
            {
                Hunger += foodPoints;
            }
        }

        public void GetHunger(int hungerPoints)
        {
            if(Hunger - hungerPoints <=0)
            {
                Hunger = 0;
            }
            else
            {
                Hunger -= hungerPoints;
            }
        }

    }

}
