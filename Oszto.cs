using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
	internal class Oszto
	{

		private List<Kartya> pakli;

		private static Random rnd = new Random();

		public Oszto(List<Kartya> pakli)
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
	}
}
