using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.behaviors;
using System.Threading;
using Microsoft.Xna.Framework;

namespace Server.components.entities
{
	/// <summary>
	/// Une entité concrète
	/// </summary>
	public class ConcreteEntity : ITarget
	{
		/// <summary>
		/// Attributs partagés
		/// </summary>
		private Entity _shared;

		/// <summary>
		/// Attributs variables
		/// </summary>
		private EntitySpec _unshared;

		/// <summary>
		/// Crée une entité concrète
		/// </summary>
		/// <param name="shared">Attributs partagés</param>
		/// <param name="unshared">Attributs variables</param>
		public ConcreteEntity(Entity shared, EntitySpec unshared)
		{
			this._shared = shared;
			this._unshared = unshared;
		}

		/// <summary>
		/// Effectue une action
		/// </summary>
		/// <param name="action">Le numéro de l'action</param>
		/// <param name="it">La cible</param>
		public void doAction(UInt16 action, ITarget it)
		{
					
			BehaviorBuilder b = BehaviorBuilder.get();
			b.setSource(this);
			b.setAction(action);
			b.setTarget(it);

			PlayableEntitySpec source = (PlayableEntitySpec) this._unshared;
			Queue<IBehavior> behaviors = source.BehaviorQueue;
			if (behaviors.Count > 0)
			{
				behaviors.Peek().prematureStop();
				behaviors.Dequeue();
			}
			IBehavior ib = b.build();
			behaviors.Enqueue(ib);
			Thread th = new Thread(new ThreadStart(ib.doAction));
			th.Start();
		}

		/// <summary>
		/// Récupère la position de l'unité
		/// </summary>
		/// <returns>La position de l'unité</returns>
		public Point Position
		{
			get { return _unshared.getPosition(); }
		}

		/// <summary>
		/// Liste des Squares de la concreteEntity
		/// </summary>
		/// <returns>Liste des Squares de la concreteEntity</returns>
		public List<Square> Squares
		{
			get { return this._unshared.Squares; }
			set { this._unshared.Squares = value; }
		}

		/// <summary>
		/// retourne la premiere Square de la concreteEntity
		/// </summary>
		/// <returns>Square</returns>
		public Square Square
		{
			get { return this._unshared.firstSquare(); }
		}

		public Int32 IDEntity
		{
			get { return this._unshared.Identity; }
		}

		public UInt32 Hp
		{
			get { return this._unshared.Hp;}
			set { this._unshared.Hp = value; }
		}

		public String Name
		{
			get { return this._shared.Name; }
		}

		public UInt32 HpMax
		{
			get { return this._shared.HitPoints; }
		}

		/// <summary>
		/// ajouter  une square à la liste des square de l'entité
		/// </summary>
		/// <param name="sq"> Square</param>
		public void addSquare(Square sq)
		{
			this._unshared.Squares.Add(sq);
		}

		/// <summary>
		/// Retourne l'entité
		/// </summary>
		public Entity Shared
		{
			get { return this._shared; }
		}
		
		/// <summary>
		/// Retourne L'entitéSpec
		/// </summary>
		public EntitySpec UnShared
		{
			get { return this._unshared; }
		}
	}
}
