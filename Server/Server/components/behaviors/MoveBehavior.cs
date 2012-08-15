using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Server.components.entities;
using System.Threading;


namespace Server.components.behaviors
{
    /// <summary>
    /// Déplacement
    /// </summary>
	public class MoveBehavior : IBehavior
	{
        /// <summary>
        /// La source
        /// </summary>
		private ConcreteEntity _source;

        /// <summary>
        /// La destination
        /// </summary>
		private Square _target;

		/// <summary>
		/// arrêt de l'action
		/// </summary>
		private bool _stop = false;


		/// <see cref="IBehavior#doAction"/>
		public void doAction()
		{
			bool equals = false;
			while (!equals && !this._stop)
			{
				lock (this._source)
				{
					Square sub = this.getSubSquare();
					List<Square> squares = this._source.Squares;
					squares.ElementAt(0).Entity = null;
					squares.Clear();
					squares.Add(sub);
					this._source.Squares=squares;
					sub.Entity = this._source;
					equals = this._target.Equals(sub);
				}
				Thread.Sleep(1000);
			}
			this._stop = true;
		}

		

        /// <summary>
        /// Cherche la position intermédiare pour arriver à la position finale 
        /// et retourne la square correspondante
        /// </summary>
        /// <returns> Square intermédiare </returns>
		private Square getSubSquare()
		{
			lock (this._source)
			{
				Point source = this._source.Position;
				Point vec = new Point(this._target.Point.X - source.X, this._target.Point.Y - source.Y);

				if (vec.X > 0)
				{
					source.X++;
				}
				else if (vec.X < 0)
				{
					source.X--;
				}
				if (vec.Y > 0)
				{
					source.Y++;
				}
				else if (vec.Y < 0)
				{
					source.Y--;
				}

				return Game.getInstance().getSquare(source);
			}
		}


		/// <summary>
		/// Reception de la Itaget - Square destination
		/// </summary>
		/// <param name="o"> Itaget</param>
		public void setTarget(ITarget o)
		{
			this._target = (Square)o;
		}

		/// <summary>
		/// Reception de la concrete entité source
		/// </summary>
		/// <param name="e"> ConcreteEntity </param>
		public void setSourceEntity(ConcreteEntity e)
		{
			this._source = e;
		}

		/// <summary>
		/// arrêt prématuré de l'action
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
