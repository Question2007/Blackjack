namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Kartya> pakli = Kartya.PakliLetrehozas();

            foreach (Kartya k in pakli)
            {
                Console.WriteLine(k);
            }
			Console.WriteLine("--------------------------------");

            //Játékos lapjai
            List<Kartya> jatekosKartyai = new List<Kartya>();
            jatekosKartyai = Oszto.Osztas(pakli);
            System.Console.WriteLine("--------Játékos kártyái----------");
            int jatekosErtek = 0;
			foreach (Kartya k in jatekosKartyai)
			{
				Console.WriteLine(k);
                jatekosErtek += k.kartyaErtek();
			}
            System.Console.WriteLine($"Játékos lapjainak értéke: {jatekosErtek}");

            //Osztó lapjai
            List<Kartya> osztoKartyai = new List<Kartya>();
            osztoKartyai = Oszto.Osztas(pakli);
            System.Console.WriteLine("--------Osztó kártyái----------");
			foreach (Kartya k in osztoKartyai)
			{
				Console.WriteLine(k);
                System.Console.WriteLine(k.kartyaErtek());
			}
            System.Console.WriteLine("_________-Lap kérés-----------");
            Kartya lap = Oszto.LapKeres(pakli);
            System.Console.WriteLine(lap);
            System.Console.WriteLine(lap.kartyaErtek());
		}
    }
}
