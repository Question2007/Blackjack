using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
	internal class Kartya
	{

		public enum Szin
		{
			Pikk,
			Kor,
			Treff,
			Karo
		}

		public enum Szam
		{
			Ketto = 2,
			Harom = 3,
			Negy = 4,
			Ot = 5,
			Hat = 6,
			Het = 7,
			Nyolc = 8,
			Kilenc = 9,
			Tiz = 10,
			Kiraly = 10,
			Bubi = 10,
			Dama = 10,
			Asz = 11
		}

		private Szin szin;  // Szín tárolása
		private string szam;  // Szám tárolása szöveges formában
		private int ertek;  // A kártya numerikus értéke (szám)

		// Konstruktor, amely a számot szöveges formában és a színt enumként tárolja
		public Kartya(Szin szin, string szam)
		{
			this.szin = szin;
			this.szam = szam;
			this.ertek = ConvertSzamToErtek(szam);  // A szöveges számot átalakítjuk numerikus értékké
		}

		// A szöveges számot numerikus értékké konvertáló metódus
		private int ConvertSzamToErtek(string szam)
		{
			// Az enum értékeinek lekérdezése
			foreach (Szam s in Enum.GetValues(typeof(Szam)))
			{
				if (szam == s.ToString())  // Ha a szöveges szám megegyezik az enum névével
				{
					return (int)s;  // Visszaadjuk az enum értékét
				}
			}

			return 0;  // Ha nem található, alapértelmezett értékként 0-t adunk vissza
		}

		// Kártya értékének visszaadása
		public int kartyaErtek()
		{
			return ertek;  // A numerikus értéket adjuk vissza
		}

		public override string ToString()
		{
			return $"{szin}-{szam}";
		}

		public static List<Kartya> PakliLetrehozas()
		{
			List<Kartya> pakli = new List<Kartya>();
			foreach (Szin color in Enum.GetValues(typeof(Szin))) {
				foreach (string num in Enum.GetNames(typeof(Szam)))
				{
					pakli.Add(new Kartya(color, num));
				}
			}
			return pakli;
		}
	}
}
