using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	/// <summary>
	/// class armur 
	/// </summary>
	public class Armor
	{
		/// <summary>
		/// type d'armur
		/// </summary>
		public enum ArmorType
		{
			armored = 1,
			light
		};

		/// <summary>
		/// liste de fonction de l'armur 
		/// </summary>
		private List<String> _types = new List<String>();

		/// <summary>
		/// type d'armur 
		/// </summary>
		private ArmorType _armorType;

		private int p;

		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="armorType">type de l'armur</param>
		/// <param name="p"></param>
		public Armor(ArmorType armorType, int p)
		{
			this._armorType = armorType;
			this.p = p;
		}
	}
}
