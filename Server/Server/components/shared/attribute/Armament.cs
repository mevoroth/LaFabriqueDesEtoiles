
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
    public class Armament
    {
		/// <summary>
		/// nom de l'attack
		/// </summary>
		private String _attackName;

		/// <summary>
		/// nombre de domage fait
		/// </summary>
		private UInt32 _damage;

		private bool[] _targets = new bool[2];
		private double _cooldown;
		private double _range;
		//private List<Upgrade>;

		public Armament(string attackName, UInt32 damage, bool[] target, double cooldown, double range)
		{
			this._attackName = attackName;
			this._damage = damage;
			this._targets = target;
			this._cooldown = cooldown;
			this._range = range;
		}

		/// <summary>
		/// Retourne et attribue des point de domage
		/// </summary>
		public UInt32 Damage
		{
			get
			{
				return this._damage;
			}
			set
			{
				this._damage = value;
			}
		}
    }
}
