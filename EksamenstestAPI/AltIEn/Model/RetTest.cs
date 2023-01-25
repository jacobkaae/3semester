using System;
namespace AltIEn.Model
{
	public class Ret
	{
		public int RetId { get; set; }
		public string Navn { get; set; }
		public List<Ingrediens> Ingredienser { get; set; }

		public Ret(string navn)
		{
			this.Navn = navn;
		}

		public Ret()
		{

		}

		public int antalIngredienser()
		{
			return this.Ingredienser.Count();
		}
	}
}

