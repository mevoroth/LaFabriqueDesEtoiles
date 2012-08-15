using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	/// <summary>
	/// Coût
	/// </summary>
	public struct Cost
	{
		/// <summary>
		/// Cristaux
		/// </summary>
		public UInt32 _mineralCost;
		/// <summary>
		/// Gaz
		/// </summary>
		public UInt32 _gasCost;
		/// <summary>
		/// Temps de construction
		/// </summary>
		public UInt32 _buildTime;

		/// <summary>
		/// Crée un coût
		/// </summary>
		/// <param name="mineralCost">Cristaux</param>
		/// <param name="gasCost">Gaz</param>
		/// <param name="buildTime">Temps de construction</param>
		public Cost(UInt32 mineralCost, UInt32 gasCost, UInt32 buildTime)
		{
			this._mineralCost = mineralCost;
			this._gasCost = gasCost;
			this._buildTime = buildTime;
		}
	}
}
