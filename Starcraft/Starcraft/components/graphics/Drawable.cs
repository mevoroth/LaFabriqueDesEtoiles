using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Client.components.graphics
{
	/// <summary>
	/// Objet dessinable
	/// </summary>
	public class Drawable
	{
		/// <summary>
		/// Son sprite
		/// </summary>
		private Texture2D sprite;
		/// <summary>
		/// Sa position
		/// </summary>
		private Vector2 position;
		/// <summary>
		/// Sa position sur le serveur
		/// </summary>
		private Point _p;
		//private Point _p = new Point();
		/// <summary>
		/// Son identifiant
		/// </summary>
		private uint id;
		/// <summary>
		/// Son nom
		/// </summary>
		private String _name;

		/// <summary>
		/// Crée un bouton
		/// </summary>
		/// <param name="name">Nom</param>
		/// <param name="sprite">Sprite</param>
		/// <param name="position">Position</param>
		/// <param name="p">Coordonnées serveur</param>
		/// <param name="id">Identifiant</param>
		public Drawable(String name, Texture2D sprite, Vector2 position, Point p, uint id)
			: this(sprite, position, p, id)
		{
			this._name = name;
		}

		/// <summary>
		/// Crée un objet dessinable
		/// </summary>
		/// <param name="sprite">Sprite</param>
		/// <param name="position">Position</param>
		/// <param name="id">Identifiant</param>
		public Drawable(Texture2D sprite, Vector2 position, Point? p, uint id)
		{
			if (p != null)
			{
				this._p = (Point)p;
			}
			this.sprite = sprite;
			this.position = position;
			this.id = id;
		}

		/// <summary>
		/// Récupère le sprite
		/// </summary>
		/// <returns>Le sprite</returns>
		public Texture2D getSprite()
		{
			return this.sprite;
		}

		/// <summary>
		/// La position
		/// </summary>
		public Vector2 Position
		{
			get { return this.position; }
			set { this.position = value; }
		}

		public Point Location
		{
			set { this._p = value; }
		}

		/// <summary>
		/// Vérifie si le point se trouve dans le sprite
		/// </summary>
		/// <param name="p">Le point</param>
		/// <returns>La vérification</returns>
		public bool Contains(Point p)
		{
			return p.X >= this._p.X && p.Y >= this._p.Y
				&& p.X < Entities.getSize(this._name) + this._p.X
				&& p.Y < Entities.getSize(this._name) + this._p.Y;
		}

		/// <summary>
		/// Récupère l'identifiant
		/// </summary>
		/// <returns>L'identifiant</returns>
		public uint getId()
		{
			return this.id;
		}

		public String Name { get { return this._name; } }
	}
}
