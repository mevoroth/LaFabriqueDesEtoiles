using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	public class Unit : PlayableEntity
	{
		/// <summary>
		/// Taille lors d'un pick/drop
		/// </summary>
		private UInt16 _pick_size;

		/// <summary>
		/// Vitesse de déplacement
		/// </summary>
		private float _speed;
				
	
		/// <summary>
		/// Régénération des HP
		/// </summary>
		private float _hp_regen;
		
		public Unit(
			String name,
			Specy specy,
			//int sighRange,
			Cost cost,
			//float collisionRadius,
			UInt32 hitPoint,
			//int targetPriority,
			//Armor armor,
			//List<Armament> armaments,
			float supply,
			UInt16 pick_size,
			float speed,
			float hp_regen
		) : base(
			name,
			specy,
			cost,
			//collisionRadius,
			hitPoint,
			1,
			supply
			//armor,
			//armaments
		)
		{
			this._pick_size = pick_size;
			this._speed = speed;
			this._hp_regen = hp_regen;
		}

		/// <summary>
		/// Retourne la Taille lors d'un pick/drop
		/// </summary>
		public UInt16 PickSize
		{
			get { return this._pick_size; }
		}

		/// <summary>
		/// vitesse d'exécution
		/// </summary>
		public float Speed
		{
			get { return this._speed; }
		}

		/// <summary>
		/// retourne le point de régénération
		/// </summary>
		public float HpRegen
		{
			get { return this._hp_regen; }
		}
	}
}
