using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    internal class Boat
    {
        private int missingWood;
        private int missingNails;
        public (int, int) Localization { get; }

        public Boat(int wood, int nails)
        {
            missingWood = wood;
            missingNails = nails;
            Localization = (0, 0);
        }

        public void FixBoat(int wood, int nails)
        {
            missingWood -= wood;
            missingNails -= nails;

            if (missingWood <= 0 && missingNails <= 0)
                return;
            else
            {
                ShowHowMuch();
                Thread.Sleep(1000);
            }
        }

        public void ShowHowMuch()
        {
            Console.WriteLine("Brakuje ci:");
            Console.WriteLine(missingWood.ToString() + " sztuk drewna" );
            Console.WriteLine(missingNails.ToString() + " sztuk gwoździ" );
        }

        public bool IsFixed()
        {
            if ( missingWood <= 0  && missingNails <=0)
                return true;
            else { return false; }
        }

    }
}
