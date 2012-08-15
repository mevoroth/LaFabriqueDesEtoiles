using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.behaviors;
using Microsoft.Xna.Framework;
using Server.components.entities;

namespace Server.components
{
	/// <summary>
	/// Case
	/// </summary>
	public class Square : ITarget
	{
		/// <summary>
		/// L'entité se trouvant sur la case
		/// </summary>
		private ConcreteEntity _concreteEntity;

		/// <summary>
		/// La coordonnée de la case
		/// </summary>
		private Point _point;

		/// <summary>
		/// booléen spécifiant si cette case est un murm
		/// </summary>
		private bool _wall;

		/// <summary>
		/// booléan spécifiant une position de début (pour un joueur)
		/// </summary>
		private bool _isStartPoint;

		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="point"> coordonnée </param>
		public Square(Point point)
		{
			this._point = point;
			this._isStartPoint = false;
			this._concreteEntity = null;
			this._wall = false;
		}

		/// <summary>
		/// coordonnée
		/// get : renvoye la coordonnée correspondante à la square
		/// set : attribue une nouvelle coordonnée à la square
		/// </summary>
		public Point Point
		{
			get { return this._point; }
			set { this._point = value; }
		}

		/// <summary>
		/// c'est une position de début pour un joueur? 
		/// get : retourne vrai si la position peut être attribuer à un joueur
		/// </summary>
		public bool IsStartPoint
		{
			get {
				if (this._isStartPoint == true)
				{
					// la possition du joueur n'est plus acccéssible par les autres playeur
					// ainsi deux joueurs non pas la même possition.
					this._isStartPoint = false;
					return true;
				}
				else
					return false;
			}
			set { this._isStartPoint = value; }
		}

		/// <summary>
		/// La square est un mur?
		/// </summary>
		public bool Wall
		{
			get { return this._wall; }
			set { this._wall = value; }
		}

		/// <summary>
		/// retourne la concrete entity
		/// </summary>
		public ConcreteEntity Entity
		{
			get { return this._concreteEntity; }
			set { this._concreteEntity = value; }
		}

		/// <summary>
		/// vérifie si la square est accéssible.
		/// </summary>
		/// <returns> retourne vrai si la square est accéssible sinon return false</returns>
		public bool IsAccessible()
		{
			if (!Wall && this._concreteEntity == null)
			{
				return true;
			}
			else return false;
		}
	}
}
