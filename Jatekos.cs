using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
	internal class Jatekos
	{

		private List<Kartya> pakli;

		private static Random rnd = new Random();

		public Jatekos(List<Kartya> pakli)
		{
			this.pakli = pakli;
		}

		public List<Kartya> Pakli { get => pakli; set => pakli = value; }

		public static List<Kartya> Osztas(List<Kartya> pakli)
		{
			List<Kartya> jatekosKartyai = new List<Kartya>();
			for (int i = 0; i < 2; i++) { 
				Kartya k = pakli[rnd.Next(pakli.Count)];	
				jatekosKartyai.Add(k);

			}
			return jatekosKartyai;
		}

        public static Kartya LapKeres(List<Kartya> pakli) 
        {
            Kartya lap = pakli[rnd.Next(pakli.Count)];
            return lap;
        } 

        public static int LapOsszeg(List<Kartya> jatekosKartyai) 
        {
            int osszeg = 0;
            int aszDb =  0;
            foreach (var item in jatekosKartyai)
            {
                osszeg += (int)item.szam;

                if (item.szam == Kartya.Szam.Asz) {
                    aszDb++; 
                }
            }

            while (osszeg > 21 && aszDb > 0)
            {
                osszeg -= 10;
                aszDb--;
            }

            return osszeg;
        }
	}
}
