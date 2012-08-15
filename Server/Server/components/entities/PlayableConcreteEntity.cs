using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.behaviors;

namespace Server.components.entities
{
	public class PlayableConcreteEntity : ConcreteEntity
	{
		/// <summary>
		/// Constructeur PlayableConcreteEntity
		/// </summary>
		/// <param name="pl"> PlayableEntity</param>
		/// <param name="pls"> PlayableEntitypec</param>
		public PlayableConcreteEntity(PlayableEntity pl, PlayableEntitySpec pls)
			: base(pl, pls)
		{ }

		/// <summary>
		/// retourne les points d'attaque
		/// </summary>
		public uint Damage
		{
			get
			{
				PlayableEntity p = (PlayableEntity)this.Shared;
				return p.Weapon.Damage;
			}
		}
		public Armor Armor
		{
			get
			{
				PlayableEntity p = (PlayableEntity)this.Shared;
				return p.Armor;
			}
		}

		public Armament Weapon
		{
			get
			{
				PlayableEntity p = (PlayableEntity)this.Shared;
				return p.Weapon;
			}
		}

		
		public int Size
		{
			get { return ((PlayableEntity)this.Shared).Size; }
		}

		public UInt32 Energy
		{
			get
			{
				PlayableEntitySpec p = (PlayableEntitySpec)this.UnShared;
				return p.Energy;
			}
		}

		public float Supply
		{
			get
			{
				PlayableEntity p = (PlayableEntity)this.Shared;
				return p.Supply;
			}
		}

		public Player Player
		{
			get
			{
				foreach (Player p in Game.getInstance().ListPlayers)
				{
					foreach (PlayableConcreteEntity ce in p.Entities)
					{
						if (ce.Equals(this))
						{
							return p;
						}
					}
				}
				return null;
			}
		}

		public Queue<IBehavior> BehaviorQueue
		{
			get
			{
				PlayableEntitySpec p = (PlayableEntitySpec)this.UnShared;
				return p.BehaviorQueue;
			}
		}
	}
}
