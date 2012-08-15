using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	/// <summary>
	/// Environnement de la map
	/// </summary>
	public class Resource : Entity
	{
		/// <summary>
		/// Récolte
		/// </summary>
		private int _recolt;
		
		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="name"> nom</param>
		/// <param name="hitpoint"> point de vie</param>
		/// <param name="recolt"> nombre récolter</param>
		public Resource(String name, UInt32 hitpoint, int recolt)
			: base(name, hitpoint)
		{
			this._recolt = recolt;
		}

		/// <summary>
		/// Retourne le nombre cristaux enlevé a chaque RecolteBehavior
		/// </summary>
		public int Recolt
		{
			get { return this._recolt; }
		}
	}
}
