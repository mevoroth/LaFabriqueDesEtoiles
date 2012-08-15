using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	/// <summary>
	/// Une race du jeu
	/// </summary>
	public class Specy
	{
		/// <summary>
		/// Son nom
		/// </summary>
		private String _name;

		/// <summary>
		/// Crée une race
		/// </summary>
		/// <param name="name">Le nom de la race</param>
		public Specy(String name)
		{
			this._name = name;
		}

		/// <summary>
		/// retourne le nom de la race
		/// </summary>
		public String Name
		{
			get
			{
				return this._name;
			}
		}
	}

	public enum PlayerSpecy
	{
		ZERG = 0
	};
}
