using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    internal class Items
    {

        public string Item {get; set;}
        public (int, int) Localization { get; set; } 

        public enum ItemType
        {
            Nail,
            Wood
        }

        public void SetItem(ItemType itemType)
        {
            if (itemType == ItemType.Nail)
            {
                Item = "Nail";
            }
            else if (itemType == ItemType.Wood)
            {
                Item = "Wood";
            }
            else
            {
                throw new ArgumentException("Wrong type of item.");
            }
        }

        public Items(ItemType x)
        {
            SetItem(x);
        }
    }
}
