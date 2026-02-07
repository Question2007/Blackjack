namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Kartya> pakli = Kartya.PakliLetrehozas();
            /*foreach (Kartya k in pakli)
            {
                Console.WriteLine(k);
            }*/
			//Console.WriteLine("--------------------------------");
 
            bool playAgain = true;
 
            bool isWin = false;

            bool jatekosMegall = false;

            bool tulcsordulas = false;
            bool osztoTulcsordulas = false;
            bool isDraw = false;
            while (playAgain)
            {
				//Játékos lapjai
				List<Kartya> jatekosKartyai = new List<Kartya>();
				jatekosKartyai = Jatekos.Osztas(pakli);
                int jatekosLapErtek = Jatekos.LapOsszeg(jatekosKartyai);
				System.Console.WriteLine("--------Játékos kártyái----------");
				foreach (Kartya k in jatekosKartyai)
				{
					Console.WriteLine(k);
				}
				System.Console.WriteLine($"Játékos lapjainak értéke: {Jatekos.LapOsszeg(jatekosKartyai)}");
 
				 // Osztó lapjai
 
				List<Kartya> osztoKartyai = new List<Kartya>();
				osztoKartyai = Oszto.Osztas(pakli);
                int osztoLapErtek = Oszto.LapOsszeg(osztoKartyai);
				System.Console.WriteLine("--------Osztó kártyái----------");
				foreach (Kartya k in osztoKartyai)
				{
					Console.WriteLine(k);
				}
                System.Console.WriteLine($"Osztó lapjainak értéke: {Oszto.LapOsszeg(osztoKartyai)}");


                while(!jatekosMegall && Jatekos.LapOsszeg(jatekosKartyai) < 21)
                {
                    System.Console.WriteLine("Akarsz lapot húzni Igen(1) Nem(2)");
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input == 1)
                    {
                        // Lap húzás
                        System.Console.WriteLine("--------Lap húzás----------");
                        Kartya ul = Jatekos.LapKeres(pakli);
                        jatekosKartyai.Add(ul);
                        System.Console.WriteLine(ul);
                        System.Console.WriteLine($"Játékos lapjainak értéke: {Jatekos.LapOsszeg(jatekosKartyai)}");
    
                    }
                    else if (input == 2)
                    {
                        System.Console.WriteLine("--------Játékos kártyái----------");
                        foreach (Kartya k in jatekosKartyai)
                        {
                            Console.WriteLine(k);
                        }
                        System.Console.WriteLine($"Játékos lapjainak értéke: {Jatekos.LapOsszeg(jatekosKartyai)}");
                        jatekosMegall = true;                    
                    }
                }
				//Osztó lapjai
                while(Oszto.LapOsszeg(osztoKartyai) < 17) {
                    System.Console.WriteLine("-----------Osztó lapot húz-----------");
                    Kartya uj_lap = Oszto.LapKeres(pakli);
                    osztoKartyai.Add(uj_lap);
                    System.Console.WriteLine("Osztó húz: " + uj_lap);
				}
                System.Console.WriteLine($"Osztó lapjainak értéke: {Oszto.LapOsszeg(osztoKartyai)}");

                if (Jatekos.LapOsszeg(jatekosKartyai) > 21)
                {
                    tulcsordulas = true;
                    playAgain = false;
                }

                if (Oszto.LapOsszeg(osztoKartyai) > 21)
                {
                    osztoTulcsordulas = true;
                    playAgain = false;
                }

                if (Jatekos.LapOsszeg(jatekosKartyai) > Oszto.LapOsszeg(osztoKartyai))
                {
                    isWin = true;
                    playAgain =false;
                }
                else if (Jatekos.LapOsszeg(jatekosKartyai) < Oszto.LapOsszeg(osztoKartyai))
                {
                    playAgain = false;
                }
                else
                {
                    isDraw = true;
                }
			}
            if (tulcsordulas)
            {
                System.Console.WriteLine("Vesztettél (túlcsordulás)");
                Environment.Exit(0);
            }
            if (osztoTulcsordulas)
            {
                System.Console.WriteLine("Nyertél (osztó túlcsordult)");
                Environment.Exit(0);
            }
            if (isDraw)
            {
                System.Console.WriteLine("Döntetlen");
                Environment.Exit(0);
            }
            if (isWin)
            {
                System.Console.WriteLine("Nyertél!!!");
                Environment.Exit(0);
            }
            else
            {
                System.Console.WriteLine("Vesztettél!!!");
                Environment.Exit(0);
            }
		}
    }
}