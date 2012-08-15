using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.entities;
using Server.server;

namespace Server.components.behaviors
{
	/// <summary>
	/// constructeur des actions
	/// </summary>
	public class BehaviorBuilder
	{
		/// <summary>
		/// target destination
		/// </summary>
		private ITarget _target;

		/// <summary>
		/// concrete entité source
		/// </summary>
		private ConcreteEntity _source;

		/// <summary>
		/// numéro de l'action
		/// </summary>
		private UInt16 _action;

		/// <summary>
		/// instance de Behavior Builder
		/// </summary>
		private static BehaviorBuilder _instance = null;
		private static readonly Object _lockInstance = new Object();

		/// <summary>
		/// Retourne l'instance behavior builder
		/// </summary>
		/// <returns> Behavior Builder </returns>
		public static BehaviorBuilder get()
		{
			lock (_lockInstance)
			{
				if (_instance == null)
					_instance = new BehaviorBuilder();
				return _instance;
			}
		}

		/// <summary>
		/// constructeur vide de BehaviorBuilder
		/// </summary>
		private BehaviorBuilder()
		{
		}

		/// <summary>
		/// Crée une action
		/// </summary>
		/// <returns> l'objet action (IBehavior)</returns>
		public IBehavior build()
		{
			IBehavior b;
			switch (this._action)
			{
				case (ushort)ServerProtocol.UNIT_ATTACK: // attaque
					b = new AttackBehavior();
					break;
				case (ushort)ServerProtocol.UNIT_MOVE: // move
					b = new MoveBehavior();
					break;
				case (ushort)ServerProtocol.UNIT_MUTATION: // mutation
					b = new MutateBehavior();
					break;
				case (ushort)ServerProtocol.UNIT_COLLECT: // récolter
					b = new RecoltBehavior();
					break;
				default :
					return null;
			}
			b.setSourceEntity(this._source);
			b.setTarget(this._target);
			return b;
		}

		/// <summary>
		/// Reception de la concrete entité
		/// </summary>
		/// <param name="entity"> Concrete entité </param>
		public void setSource(ConcreteEntity entity)
		{
			this._source = entity;
		}

		/// <summary>
		/// Reception du numéro de l'action
		/// </summary>
		/// <param name="action"> Numéro de l'action (ushort) </param>
		public void setAction(ushort action)
		{
			this._action = action;
		}

		/// <summary>
		/// Reception de la target destination
		/// </summary>
		/// <param name="it">Target destination</param>
		public void setTarget(ITarget it)
		{
			this._target = it;
		}

		/// <summary>
		/// envoie de du numéro de l'action
		/// </summary>
		public UInt16 Action
		{
			get
			{
				return this._action;
			}
		}
	}
}
