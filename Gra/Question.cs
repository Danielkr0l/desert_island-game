using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    internal class Question
    {
        private string ask;
        private string answerOne;
        private string answerTwo;
        private string answerThree;
        private string answerFour;
        private char correctAnswer;
        public (int, int) Localization { get; set; }

        public Question()
        {
            GenerateQuestion();
              
        }

        public void GenerateQuestion()
        {
            Random random = new Random();
            string filePath = "Pytania.txt";

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int randomNumber = random.Next(0, lines.Length-1);
                string line = lines[randomNumber];
                string[] oneQuestion = line.Split(';');

                ask = oneQuestion[0];
                answerOne = oneQuestion[1];
                answerTwo = oneQuestion[2];
                answerThree = oneQuestion[3];
                answerFour = oneQuestion[4];
                correctAnswer = oneQuestion[5][0];


            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik z pytaniami nie został znaleziony.");
            }
            catch (IOException e)
            {
                Console.WriteLine("Wystąpił błąd odczytu pliku z pytaniami: " + e.Message);
            }

        }

        public string AskQuestion()
        { 
            return ask + "\n" + "a) " + answerOne + "\n" + "b) " + answerTwo + "\n" + "c) "+ answerThree + "\n"  + "d) "+ answerFour;
        }

        public char Answer()
        {
            bool isGoodAnswer = false;
            string answer;
            char ans = ' ';

            while(!isGoodAnswer)
            {
                answer = Console.ReadLine();

                if (answer == "a" || answer == "A" || answer == "b" || answer == "B" || answer == "c" || answer == "C" || answer == "d" || answer == "D")
                {
                    isGoodAnswer = true;
                    ans = answer[0];
                }
                else
                {
                    Console.WriteLine("Wpisz 'a', 'b', 'c' lub 'd'!!!");
                }
            }
            return ans;
        }

        public bool Check(char ans)
        {
            ans = char.ToUpper(ans);
            if (ans == correctAnswer)
                return true;
            else
                return false;
        }

    }
}
