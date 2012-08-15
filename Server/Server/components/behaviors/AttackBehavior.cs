using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.entities;

namespace Server.components.behaviors
{
	/// <summary>
	/// Attaque
	/// </summary>
    public class AttackBehavior : IBehavior
    {
		/// <summary>
		/// La cible
		/// </summary>
		private PlayableConcreteEntity _target;

		/// <summary>
		/// La source
		/// </summary>
		private PlayableConcreteEntity _source;
		
		/// <summary>
		/// arrêt du thread
		/// </summary>
		private bool _stop = false;

		/// <summary>
		/// réception de la target
		/// </summary>
		/// <param name="o">ITarget</param>
		public void setTarget(ITarget o)
		{
			this._target = (PlayableConcreteEntity)o;
		}

		/// <summary>
		/// éxecution de l'action
		/// </summary>
		public void doAction()
		{
			while (this._target.Hp > 0)
			{
				this._target.Hp=this._target.Hp-this._source.Damage;
			}
			this.prematureStop();
		}

		/// <see cref="IBehavior#setSourceEntity"/>
		public void setSourceEntity(ConcreteEntity e)
		{
			this._source = (PlayableConcreteEntity)e;
		}

		public bool Stop()
		{
			return this._stop;
		}


		#region IBehavior Membres

		/// <summary>
		/// arrêt prématuré
		/// </summary>
		public void prematureStop()
		{
			lock (this)
			{
				this._stop = true;
			}
		}

		#endregion
	}
}
