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
            List<Kartya> jatekosKartyai = new List<Kartya>();
            jatekosKartyai = Oszto.Osztas(pakli);
			foreach (Kartya k in jatekosKartyai)
			{
				Console.WriteLine(k);  // Itt is a ToString() metódus hívódik
			}
		}
    }
}
