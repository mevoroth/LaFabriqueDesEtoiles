using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.entities;

namespace Server.components.behaviors
{
	/// <summary>
	/// action stop
	/// </summary>
	public class StopBehavior : IBehavior
	{
		/// <summary>
		/// entité source
		/// </summary>
		private ConcreteEntity _source;

		/// <summary>
		/// exécution de l'action
		/// </summary>
		public void doAction()
		{
			//this._source.Unshared.BehaviorQueue.Clear();
		}
		
		/// <summary>
		/// reception de la concrete entité source
		/// </summary>
		/// <param name="e"> concrete entité source </param>
		public void setSourceEntity(ConcreteEntity e)
		{
			this._source = e;
		}

		/// <summary>
		/// reception de la target destination
		/// </summary>
		/// <param name="it"> Target destination </param>
		public void setTarget(ITarget it)
		{
			this._source = (ConcreteEntity)it;
		}
    }
}
