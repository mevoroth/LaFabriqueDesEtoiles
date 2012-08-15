using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	public class PlayableEntity : Entity
	{

		/// <summary>
		/// Race
		/// </summary>
		private Specy _specy;

		/// <summary>
		/// Portée de la vue
		/// </summary>
		private int _sighRange;

		/// <summary>
		/// Coût
		/// private int _mineralCost; // nbcristaux
		///	private int _gasCost; // nbgaz
		/// private int _buildTime; // nombre de temps pour une mutation
		/// </summary>
		private Cost _cost;

		/// <summary>
		/// Rayon de collision
		/// </summary>
		private float _collisionRadius;

		/// <summary>
		/// Priorité (pour l'algo d'attaque)
		/// </summary>
		private int _targetPriority;

		/// <summary>
		/// Armure
		/// </summary>
		private Armor _armor;

		/// <summary>
		/// Taille du bâtiment
		/// </summary>
		private int _size;

		/// <summary>
		/// Armements
		/// </summary>
		private List<Armament> _armaments = new List<Armament>();

		/// <summary>
		/// Population requise
		/// </summary>
		private float _supply;

		public PlayableEntity(
			String name,
			Specy specy,
			//int sighRange,
			Cost cost,
			//float collisionRadius,
			UInt32 hitPoints,
			int size,
			float supply
			//,int targetPriority,
			//Armor armor
			//,List<Armament> armaments
		) : base(name, hitPoints)
		{
			this._specy = specy;
			//this._sighRange = sighRange;
			this._cost = cost;
			this._size = size;
			this._supply = supply;
			//this._collisionRadius = collisionRadius;
			//this._targetPriority = targetPriority;
			//this._armor = armor;
			//this._armaments = armaments;
		}

		/// <summary>
		/// Retourne ou attribue une armur
		/// </summary>
		public Armor Armor
		{
			get { return this._armor; }
			set { this._armor = value; }
		}

		/// <summary>
		/// retourne la première armement
		/// </summary>
		public Armament Weapon
		{
			get
			{
				return this._armaments.ElementAt(0);
			}
		}

		/// <summary>
		/// Retourne la liste des armures
		/// </summary>
		public List<Armament> Armaments
		{
			get
			{
				return this._armaments;
			}
		}

		/// <summary>
		/// Retourne la Taille du bâtiment
		/// </summary>
		public int Size
		{
			get { return this._size; }
		}

		/// <summary>
		/// Retourne la Population requise
		/// </summary>
		public float Supply
		{
			get { return this._supply; }
		}
	}
}
