using System;
namespace AltIEn.Model
{
	public class Ingrediens
	{
		public int IngrediensId { get; set; }
		public string Navn { get; set; }

		public Ingrediens(string navn)
		{
			this.Navn = navn;
		}

		public Ingrediens()
		{

		}
	}
}

