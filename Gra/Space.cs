using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    internal class Space
    {
        private Island island;
        
        public Space(Island x)
        {
            island = x;
        }

        public void DrawSpace(Dictionary<(int, int), Question> quest, Dictionary<(int, int), Animals> anim, Dictionary<(int, int), Items> item, Player gracz)
        {
            for(int i = island.Size; i >= 0; i--)
            {
                for(int j=0; j <= island.Size; j++)
                {
                    if(i == 0 && j==0)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }

                    if(item.ContainsKey((j,i)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    if (quest.ContainsKey((j,i)) && anim.ContainsKey((j,i)))
                    {
                        Console.Write("2");
                        Console.ResetColor();
                    }

                    else if (quest.ContainsKey((j,i)))
                    {
                        Console.Write("?");
                        Console.ResetColor();
                    }
                    else if (anim.ContainsKey((j,i)))
                    {
                        Console.Write("A");
                        Console.ResetColor();
                    }

                    else if (gracz.Localization == (j,i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("o");
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.Write("X");
                        Console.ResetColor();
                    }

                    
                }
                Console.WriteLine();
            }

        }


        public void Check(ref Dictionary<(int, int), Question> quest, ref Dictionary<(int, int), Animals> anim,ref  Dictionary<(int, int), Items> item, Player gracz, Bag bag)
        {
            if(CheckAnimals(anim, gracz) != null)
            {
                Animals animal = CheckAnimals(anim, gracz);
                
                gracz.Fight(animal.FightPoints());

                if(!(gracz.IsAlive()))
                {
                    return;
                }

                else
                {
                    gracz.Eat((animal.Meat) * 15);
                    Console.WriteLine("Wygrałeś z "+ animal.Name+ " zostało ci: " + gracz.Health.Heart + "hp");
                    Console.WriteLine("Zdobyte punkty jedzenia: " + (animal.Meat) * 15);
                }
                anim.Remove(gracz.Localization);
            }

            if(CheckQuestion(quest,gracz) != null)
            {
                Question question = CheckQuestion(quest,gracz);
                
                Console.WriteLine(question.AskQuestion());
                if(question.Check(question.Answer()))
                {
                    Console.WriteLine("Dobrze dostajesz 20 punktów życia");
                    gracz.Health.GetHealth(20);
                }
                else 
                {
                    Console.WriteLine("Źle!!");
                    gracz.Hurt(40);
                    if (!(gracz.IsAlive()))
                    {
                        return;
                    }

                    else
                    {
                        Console.WriteLine("Odjęto ci 40hp, zostało ci: " + gracz.Health.Heart + "hp");
                    }
                }
                quest.Remove(gracz.Localization);

            }

            if(CheckItems(item,gracz) != null)
            {
                Items foundItem = CheckItems(item,gracz);
                if(foundItem.Item == "Wood")
                {
                    Console.WriteLine("Znalazłeś 1 drewno");
                    bag.Wood += 1;
                }
                else if(foundItem.Item == "Nail")
                {
                    Console.WriteLine("Znalazłeś 1 gwóźdź!");
                    bag.Nails += 1;
                }

                item.Remove(gracz.Localization);
            }


            else if(CheckAnimals(anim, gracz) == null && CheckQuestion(quest, gracz) == null && CheckItems(item, gracz) == null)
            {
                if(gracz.Localization == (0,0))
                {
                    Console.WriteLine("Jesteś na statku");
                }

                else
                {
                    Console.WriteLine("Puste pole");
                }

            }
        }

        public Animals CheckAnimals(Dictionary<(int, int), Animals> anim, Player gracz)
        {
            if (anim.TryGetValue(gracz.Localization, out Animals value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public Question CheckQuestion(Dictionary<(int, int), Question> quest, Player gracz)
        {
            if (quest.TryGetValue(gracz.Localization, out Question value))
            {
                return value;
            }
            else
            {
                return null;
            }

        }

        public Items CheckItems(Dictionary<(int,int), Items> item, Player gracz)
        {
            if(item.TryGetValue(gracz.Localization,out Items value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }
    }
}
