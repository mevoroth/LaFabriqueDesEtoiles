using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.behaviors;

namespace Server.components
{
	/// <summary>
	/// Entité jouable (attributs variables)
	/// </summary>
	public class PlayableEntitySpec : EntitySpec
	{
		/// <summary>
		/// Energie
		/// </summary>
		private UInt32 _energy;
		/// <summary>
		/// La file des actions
		/// </summary>
		private Queue<IBehavior> _behaviorQueue = new Queue<IBehavior>();

		/// <summary>
		/// Créer une entité jouable (attributs variables)
		/// </summary>
		/// <param name="square">La case qui la contient</param>
		/// <param name="hp">La vie</param>
		/// <param name="energy">L'énergie</param>
		public PlayableEntitySpec(List<Square> square, UInt32 hp, UInt32 energy)
			: base(square, hp)
		{
			this._energy = energy;
		}

		public Queue<IBehavior> BehaviorQueue
		{
			get
			{
				return this._behaviorQueue;
			}
		}

		public UInt32 Energy
		{
			get { return this._energy; }
		}
	}
}
