using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	public struct InfoPlayer
	{
		/// <summary>
		/// quantité de gaz
		/// </summary>
		public uint _vespene;

		/// <summary>
		/// quantité de mineré
		/// </summary>
		public uint _mineral;

		/// <summary>
		/// nombre de populattion maximal
		/// </summary>
		public uint _popMax;

		/// <summary>
		/// nombre de population actuelle
		/// </summary>
		public uint _pop;

		/// <summary>
		/// constrcuteur
		/// </summary>
		/// <param name="Vespene"> gaz</param>
		/// <param name="Mineral"> cristaux</param>
		/// <param name="Pop"> compossant actuelle</param>
		/// <param name="PopMax"> compossant maximal</param>
		public InfoPlayer(uint Vespene, uint Mineral, uint PopMax, uint Pop)
		{
			this._mineral = Mineral;
			this._vespene = Vespene;
			this._popMax = PopMax;
			this._pop = Pop;
		}
	}
}
