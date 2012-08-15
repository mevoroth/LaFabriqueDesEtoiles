using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.entities;
using Microsoft.Xna.Framework;
using Server.server;
using System.Threading;

namespace Server.components.behaviors
{
	public class RecoltBehavior : IBehavior
	{

		/// <summary>
		/// La cible
		/// </summary>
		private ConcreteResource _target;
		/// <summary>
		/// La source
		/// </summary>
		private PlayableConcreteEntity _source;
        
        /// <summary>
        /// arrêt de l'action
        /// </summary>
		private bool _stop = false;

        /// <summary>
        /// Action de recolte des ressources minerais et vespene
        /// </summary>
		public void doAction()
		{
			Point pMineral = this._target.Position;
			Point pHatchery;
			foreach (Player p in Game.getInstance().ListPlayers)
			{
                if (this._source.Player == p)
                {
                    pHatchery = p.Hatchery.Position;
                }
			}
			while (!this._stop)
			{
				lock(_source)
				{
					//this._source.doAction((ushort)ServerProtocol.UNIT_MOVE, this._target.Square);

					BehaviorBuilder b = BehaviorBuilder.get();
					b.setSource(this._source);
					b.setAction((ushort)ServerProtocol.UNIT_MOVE);
					b.setTarget(this._target.Square);
					IBehavior ib = b.build();
					ib.doAction();
					// attendre tanque l'action n'est pas terminer
					while (!ib.Stop()) ;

					this._target.Hp=this._target.Hp - (uint)this._target.Recolt;

					//Thread.Sleep(1000);

					//this._source.doAction((ushort)ServerProtocol.UNIT_MOVE, this._source.Player.Hatchery.Square);
					b = BehaviorBuilder.get();
					b.setSource(this._source);
					b.setAction((ushort)ServerProtocol.UNIT_MOVE);
					b.setTarget(this._source.Player.Hatchery.Square);
					ib = b.build();
					ib.doAction();
					while (!ib.Stop()) ;


                    if (this._target.Name == "vespene")
                    {
                        this._source.Player.VespeneNumber += (uint)this._target.Recolt;
                    }
                    else
                    {
                        this._source.Player.MineralNumber += (uint)this._target.Recolt;
                    }
				}
			}
			this._stop = true;
		}
		
		public void setSourceEntity(ConcreteEntity e)
		{
			this._source = (PlayableConcreteEntity)e;
		}

		public void setTarget(ITarget o)
		{
			this._target = (ConcreteResource)o;
		}

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
