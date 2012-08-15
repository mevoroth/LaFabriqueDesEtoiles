using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Server.components.entities;
using Server.server;
using System.Threading;

namespace Server.components.behaviors
{
	/// <summary>
	/// action patrouller
	/// action exécuter par les uniter seulement
	/// </summary>
	public class PatrolBehavior : IBehavior
	{
		/// <summary>
		/// conrete entité source
		/// </summary>
		private ConcreteEntity _source;
		/// <summary>
		/// case de destination
		/// </summary>
		private Square _target;

        /// <summary>
        /// arrêt de l'action
        /// </summary>
        private bool _stop = false;

		/// <summary>
		/// éxecution de l'action patrouiller
		/// </summary>
        public void doAction()
        {
            Square Other = this._source.Square; // possition
            while (!this._stop)
            {
                this._source.doAction((ushort)ServerProtocol.UNIT_MOVE, this._target);
                Thread.Sleep(1000);
                this._source.doAction((ushort)ServerProtocol.UNIT_MOVE, Other);
            }
        }

		/// <summary>
		/// reception de la concrete entité source
		/// </summary>
		/// <param name="e"> Concrete entité source </param>
		public void setSourceEntity(ConcreteEntity e)
		{
			this._source = e;
		}

		/// <summary>
		/// reception de la square de destination
		/// </summary>
		/// <param name="o"> Square de destination </param>
		public void setTarget(ITarget o)
		{
			this._target = (Square) o;
		}

        /// <summary>
        /// arrêt del'action
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
