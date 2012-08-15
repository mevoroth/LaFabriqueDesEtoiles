using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.entities;
using System.Threading;

namespace Server.components.behaviors
{
	/// <summary>
	/// Transformation d'une Entité en une autre.
	/// </summary>
	public class MutateBehavior : IBehavior
	{
		/// <summary>
		/// La source
		/// </summary>
		private ConcreteEntity _source;

		/// <summary>
		/// La destination
		/// </summary>
		private StringTarget _target;

		/// <summary>
		/// arrêt du thread
		/// </summary>
		private bool _stop = false;

		/// <summary>
		/// Exécute l'action
		/// </summary>
		public void doAction()
		{
			Thread.Sleep(1000);
			lock (Game.getInstance().Map)
			{
				ConcreteEntity u = Server.components.entities.Entities.getInstance().getEntity(_target.StringEntity, Server.components.entities.Entities.getInstance().Id);
				u.addSquare(_source.Square);
				Game.getInstance().Map.getSquare(_source.Position).Entity = u;

				//on remplace dans la liste du joueur par la nouvelle entité
				lock (Game.getInstance().ListPlayers)
				{
					foreach (Player p in Game.getInstance().ListPlayers)
					{
						foreach (ConcreteEntity ce in p.Entities)
						{
							if (ce.IDEntity == this._source.IDEntity)
							{
								p.Entities[p.Entities.IndexOf(ce)] = u;
								break;
							}
						}
					}
				}
			}
			this._stop = true;
		}

		/// <summary>
		/// Affecte la source
		/// </summary>
		/// <param name="e">Entité source</param>
		public void setSourceEntity(ConcreteEntity e)
		{
			this._source = e;
		}

		/// <summary>
		/// Affecte la cible
		/// </summary>
		/// <param name="o">La cible</param>
		public void setTarget(ITarget o)
		{
			this._target = (StringTarget)o;
		}

		/// <summary>
		/// Arrête l'action
		/// </summary>
		public void prematureStop()
		{
			lock (this)
			{
				this._stop = true;
			}
		}

		public bool Stop()
		{
			return this._stop;
		}
	}
}
