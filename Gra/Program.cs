using Gra;
using System.Net.Http.Headers;
using System.Threading;


Island myIsland = new Island(5);
Boat myBoat = new Boat(3, 2);
Bag myBag = new Bag();

List<Items> items = new List<Items>();

Items wood1 = new Items(Items.ItemType.Wood);
Items wood2 = new Items(Items.ItemType.Wood);
Items wood3 = new Items(Items.ItemType.Wood);
Items wood4 = new Items(Items.ItemType.Wood);
Items nail1 = new Items(Items.ItemType.Nail);
Items nail2 = new Items(Items.ItemType.Nail);
Items nail3 = new Items(Items.ItemType.Nail);
Items nail4 = new Items(Items.ItemType.Nail);

items.Add(wood1);
items.Add(wood2);
items.Add(wood3);
items.Add(wood4);
items.Add(nail1);
items.Add(nail2);
items.Add(nail3);
items.Add(nail4);

Dictionary<(int, int), Items> arrangementItems = myIsland.LocalizeItems(items);


List<Animals> animals = new List<Animals>();

Animals animal1 = new Animals();
Animals animal2 = new Animals();
Animals animal3 = new Animals();
Animals animal4 = new Animals();
Animals animal5 = new Animals();
Animals animal6 = new Animals();
Animals animal7 = new Animals();
Animals animal8 = new Animals();
Animals animal9 = new Animals();


animals.Add(animal1);
animals.Add(animal2);
animals.Add(animal3);
animals.Add(animal4);
animals.Add(animal5);
animals.Add(animal6);
animals.Add(animal7);
animals.Add(animal8);
animals.Add(animal9);


Dictionary<(int, int), Animals> arrangementAnimals = myIsland.LocalizeAnimals(animals);

List<Question> questions = new List<Question>();

Question question1 = new Question();
Question question2 = new Question();
Question question3 = new Question();
Question question4 = new Question();
Question question5 = new Question();
Question question6 = new Question();
Question question7 = new Question();
Question question8 = new Question();
Question question9 = new Question();

questions.Add(question1);
questions.Add(question2);
questions.Add(question3);
questions.Add(question4);
questions.Add(question5);
questions.Add(question6);
questions.Add(question7);
questions.Add(question8);
questions.Add(question9);

Dictionary<(int, int), Question> arrangementQuestions = myIsland.LocalizeQuestion(questions);

Space mapa = new Space(myIsland);


Console.WriteLine("Podaj Imię: ");
string imie = Console.ReadLine();
Player gracz = new Player(imie);
Console.WriteLine("Witaj: " + gracz.Name);
Console.WriteLine();

Console.WriteLine("INSTRUKCJA");
Console.WriteLine("Rozbiłeś się na bezludnej wyspie, aby naprawić statek i z niej uciec musisz zebrać 3 drewna i 2 gwoździe.");
Console.WriteLine("Wyspa jest wielkości 6x6, ciągle będziesz widzieć współrzędne. Możesz również włączyć mapę, ale może być ona pokazana na 3 sekundy raz na 3 ruchy, są na niej zaznaczone: ");
Console.WriteLine("-X w kolorze magenta oznacza statek, znajdoje się on na współrzędnych (0,0), tam jest start gry");
Console.WriteLine("-czerwone o - oznacza gdzie znajduje się gracz jeśli nie jest na statku");
Console.WriteLine("-surowce(kolor zielony),");
Console.WriteLine("-zwierzęta (litera A) - walcząc z nimi zdobywasz jedenie, tracisz jednak punkty zdrowia,");
Console.WriteLine("Pytania (znak ?) - proste pytania abcd, jeśli dobrze odpowiesz- dostajesz 20 punktów zdrowia, w przeciwnym wypadku tracisz 40");
Console.WriteLine("-Pytanie i zwierze najednym polu oznaczone jest: 2");
Console.WriteLine("-X oznacza puste pole");
Console.WriteLine();
Console.WriteLine("Poruszaj się po mapie za pomącą klawiszy WASD");
Console.WriteLine("Klawiszem C Sprawdzisz stan głodu i punkty zdrowia");
Console.WriteLine("Klawisz M pokazuje mapę (jeśli jest dostępna w danym ruchu)");
Console.WriteLine("Wciskając E zobaczysz jakie przedmioty już zebrałeś");
Console.WriteLine("Klawisz B działa tylko jeśli jesteś na statku, jeśli go naciśniesz statek zostanie naprawiony, jeśli jeszcze brakuje surowców gra będzie kontynuowana, jesli zaś zostanie on naprawiony w całości - wygrywasz");

Console.WriteLine();
Console.WriteLine("Na pytania odpowiadasz wpisując a,b,c lub d i zatwierdzając to klawiszem enter");
Console.WriteLine();
Console.WriteLine("Musisz wybrać się w podróż po wyspie i zebrać potrzebne materały");
Console.WriteLine("Kontroluj stan zdrowia i głodu, odpowiadaj na pyatania i walcz ze zwierzętami. Po prostu przetrwaj.");
Console.WriteLine("Powodzenia!!");
Console.WriteLine("Naciśnij dowolny przycisk aby zacząć grę");

Console.ReadKey();

ConsoleKeyInfo keyInfo;
int i = 3;
bool openMap = true;
do
{
    Console.Clear();
    Console.WriteLine("WASD - poruszanie");
    Console.WriteLine("M - mapa");
    Console.WriteLine("E - ekwipunek");
    Console.WriteLine("B - naprawa(tylko na statku)");
    Console.WriteLine("C - Stan zdrowia");

    Console.WriteLine("Wykonaj ruch. Bieżąca lokalizacja: "+gracz.Localization);

    keyInfo = Console.ReadKey(true);

    switch(keyInfo.Key)
    {
        case ConsoleKey.W:
            if(gracz.Localization.Item2 < myIsland.Size)
            {
                gracz.MoveUp();
                if (!(i % 3 == 0) || openMap == false)
                    i++;
                openMap = true;
                gracz.GetHunger(10);
                Console.WriteLine(gracz.CheckFood());
                mapa.Check(ref arrangementQuestions,  ref arrangementAnimals,ref arrangementItems ,gracz, myBag);
                Console.WriteLine("Wciśnij dowolny przycisk");
                Console.ReadKey();
                

            }
            else
            {
                Console.WriteLine("Koniec mapy!");
                Thread.Sleep(1000);
            }
            break;

        case ConsoleKey.A:
            if (gracz.Localization.Item1 > 0)
            {
                gracz.MoveLeft();
                if (!(i % 3 == 0) || openMap == false)
                    i++;
                openMap = true;
                gracz.GetHunger(10);
                Console.WriteLine(gracz.CheckFood());
                mapa.Check(ref arrangementQuestions, ref arrangementAnimals, ref arrangementItems, gracz, myBag);
                Console.WriteLine("Wciśnij dowolny przycisk");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Koniec mapy!");
                Thread.Sleep(1000);
            }

            break;

        case ConsoleKey.S:
            if (gracz.Localization.Item2 > 0)
            {
                gracz.MoveDown();
                if (!(i % 3 == 0) || openMap == false)
                    i++;
                openMap = true;
                gracz.GetHunger(10);
                Console.WriteLine(gracz.CheckFood());
                mapa.Check(ref arrangementQuestions, ref arrangementAnimals, ref arrangementItems, gracz, myBag);
                Console.WriteLine("Wciśnij dowolny przycisk");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Koniec mapy!");
                Thread.Sleep(1000);
            }
            break;

        case ConsoleKey.D:
            if (gracz.Localization.Item1 < myIsland.Size)
            {
                gracz.MoveRight();
                if (!(i % 3 == 0) || openMap == false)
                    i++;
                openMap = true;
                gracz.GetHunger(10);
                Console.WriteLine(gracz.CheckFood());
                mapa.Check(ref arrangementQuestions, ref arrangementAnimals, ref arrangementItems, gracz, myBag);
                Console.WriteLine("Wciśnij dowolny przycisk");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Koniec mapy!");
                Thread.Sleep(1000);
            }
            break;
        case ConsoleKey.M:
            if(i%3==0 && openMap == true)
            {
                Console.Clear();
                mapa.DrawSpace(arrangementQuestions, arrangementAnimals, arrangementItems, gracz);

                Console.WriteLine();
                Console.WriteLine("X - puste pole");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("X");
                Console.ResetColor();
                Console.WriteLine("- statek");
                Console.WriteLine("A - zwierze");
                Console.WriteLine("? - pytanie");
                Console.WriteLine("2 - pytanie i zwierze");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("o");
                Console.ResetColor();
                Console.WriteLine("- gracz");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Zielony kolor");
                Console.ResetColor();
                Console.WriteLine("- surowce");

                Console.WriteLine("Mapa znika za: ");
                Console.Write("3 sekundy");
                Thread.Sleep(1000); 

                Console.Write("\r"); 
                Console.Write(new string(' ', Console.WindowWidth - 1)); 
                Console.Write("\r"); 

                Console.Write("2 sekundy");
                Thread.Sleep(1000);
                Console.Write("\r");
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.Write("\r");

                Console.Write("1 sekundy");
                Thread.Sleep(1000);

                openMap = false;
            }
            else
            {
                Console.WriteLine("Nie można włączyć mapy. Ilość ruchów do odblokowania:  " + (3-(i%3)).ToString());
                Console.Write("czekaj.");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
            }
            
            break;

        case ConsoleKey.E:
            Console.WriteLine("Ilość drewna: " + myBag.Wood);
            Console.WriteLine("Ilość gwoździ: " + myBag.Nails);
            Thread.Sleep(2000);
            break;

        case ConsoleKey.B:
            if(gracz.Localization == (0,0))
            {
                myBoat.FixBoat(myBag.Wood, myBag.Nails);
                myBag.Wood = 0;
                myBag.Nails = 0;
            }
            else
            {
                Console.WriteLine("Aby naprawić łódź idź do punktu (0,0)");
                Thread.Sleep(1000);

            }
            break;

        case ConsoleKey.C:
            Console.WriteLine("Głód: " + gracz.Health.Hunger.ToString());
            Console.WriteLine("Punkty życia: " + gracz.Health.Heart.ToString());
            Thread.Sleep(1000);
            break;

        default:
            Console.WriteLine("Zły klawisz!");
            break;
    }
    

} while(gracz.IsAlive() && !(myBoat.IsFixed()));

if(gracz.IsAlive() && myBoat.IsFixed())
{
    Console.WriteLine("Wygrałeś!!");
    Console.WriteLine("Naciśnij dowolny przyckisk aby wyjść");
}

else
{
    Console.WriteLine("Niestety przegrałeś :(");
    Console.WriteLine("Naciśnij dowolny przyckisk aby wyjść");
}


