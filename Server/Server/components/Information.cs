using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	public struct Information
	{
		/// <summary>
		/// Numérau du joueur
		/// </summary>
		public uint _idPlayer;

		/// <summary>
		/// numéraux du l'entité
		/// </summary>
		public uint _idEntity;

		/// <summary>
		/// nom de l'entité
		/// </summary>
		public String _entityName;

		/// <summary>
		/// point de vie maximal
		/// </summary>
        public UInt32 _hitPointsMax;

		/// <summary>
		/// point de vie actuelle
		/// </summary>
        public UInt32 _hitPoints;

		/// <summary>
		/// énergie
		/// </summary>
		public UInt32 _energy;


		/// <summary>
		/// Constructeur de la structure
		/// </summary>
		/// <param name="IdPlayer">identifiant du joueur</param>
		/// <param name="IdEntity">identifiant de l'entité </param>
		/// <param name="Name">nom de l'entité</param>
		/// <param name="hitPointsMax"> point de vie maximal</param>
		/// <param name="hitPoint">point de vie actuelle </param>
		/// <param name="Energy"> énergie </param>
		public Information(uint IdPlayer, uint IdEntity, String Name, UInt32 hitPointsMax, UInt32 hitPoint, UInt32 Energy)
		{
			this._idPlayer = IdPlayer;
			this._idEntity = IdEntity;
			this._entityName = Name;
			this._hitPointsMax = hitPointsMax;
			this._hitPoints = hitPoint;
			this._energy = Energy;
		}
	}
}
