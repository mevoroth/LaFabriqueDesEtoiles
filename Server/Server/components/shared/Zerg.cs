using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	public class Zerg : Unit
	{
		/// <summary>
		/// La vitesse de déplacement sur le creep
		/// </summary>
		private UInt16 _creep_mult;

	
		public Zerg(UInt16 creep_mult,
			String name, Specy specy,
			//int sighRange,
			Cost cost,
			//float collisionRadius,
			UInt32 hitPoints,
			//int targetPriority,
			//Armor armor,
			//List<Armament> armaments,
			float supply, UInt16 pick_size,
			float speed, float hp_regen)
			:base(name,specy,cost,hitPoints,
			//armor,
			supply ,pick_size,speed,hp_regen)
		{
			this._creep_mult = creep_mult;
		}
	
		/// <summary>
		/// retourne la vitesse de déplacement sur le creep
		/// </summary>
		public UInt16 CreepMult
		{
			get { return this._creep_mult; }
		}
	}
}
