using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.components.graphics
{
	/// <summary>
	/// Une Sprite
	/// </summary>
	public class Sprite
	{
		/// <summary>
		/// Le chemin du sprite
		/// </summary>
		private String _path;
		/// <summary>
		/// La position du sprite
		/// </summary>
		private Vector2 _position;
		/// <summary>
		/// L'identifiant du sprite
		/// </summary>
		private uint _id;
		/// <summary>
		/// Affecte le chemin du sprite
		/// </summary>
		/// <param name="path">Le chemin du sprite</param>
		/// <param name="id">L'Id de l'unité</param>
		public Sprite (Vector2 position, uint? id)
		{
			this._position = position;
			if (id != null)
			{
				this._id = (uint)id;
			}
		}

		/// <summary>
		/// Affecter le chemin du sprite
		/// </summary>
		/// <param name="path"></param>
		public void setPath(String path)
		{
			this._path = path;
		}
		/// <summary>
		/// Retourne le chemin du sprite
		/// </summary>
		/// <returns>Le chemin du sprite</returns>
		public String getPath()
		{
			return this._path;
		}

		/// <summary>
		/// Récupère la position
		/// </summary>
		/// <returns>La position</returns>
		public Vector2 getPosition()
		{
			return this._position;
		}

		/// <summary>
		/// Récupère l'identifiant
		/// </summary>
		/// <returns>L'identifiant</returns>
		public uint getId()
		{
			return this._id;
		}

		public Point ServerLoc
		{
			get
			{
				return new Point((int)this._position.X,
					(int)this._position.Y);
			}
		}
	}
}