using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.behaviors;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;

namespace Server.components
{
	/// <summary>
	/// class enité spec 
	/// </summary>
	public class EntitySpec : ISerializable
	{
		/// <summary>
		/// numéro de l'Entity
		/// </summary>
		private Int32 _identity;
		/// <summary>
		/// position
		/// </summary>
		private List<Square> _squares;
		/// <summary>
		/// point de vie de l'entité
		/// </summary>
		private UInt32 _hp;

		/// <summary>
		/// constructeur entité spec
		/// </summary>
		/// <param name="square"> Liste de square (position de l'entité) </param>
		/// <param name="hp"> hitPoints </param>
		public EntitySpec(List<Square> square, UInt32 hp)
		{
			this._squares = square;
			this._hp = hp;
		}

		/// <summary>
		/// Retourne et attribue un identifiant à l'entité spec
		/// </summary>
		public int Identity
		{
			get { return this._identity; }
			set { this._identity = value; }
		}

		/// <summary>
		/// retourne et attribue une liste des squares
		/// </summary>
		public List<Square> Squares
		{
			get { return this._squares; }
			set { this._squares = value; }
		}

		/// <summary>
		/// retourne la position de l'entité spec
		/// </summary>
		/// <returns></returns>
		public Point getPosition()
		{
			return _squares.ElementAtOrDefault(0).Point;
		}

		#region ISerializable Membres

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			/*
			info.AddValue("hp", this._hp);
			info.AddValue("energy", this._energy);
			info.AddValue("Point", this._point);
			info.AddValue("behaviorQueue", this._behaviorQueue);
			
			 */
		}

		#endregion

		/// <summary>
		/// attribue une nouvelle hitpoint et retourne la valeur
		/// </summary>
		public uint Hp
		{
			get { return this._hp; }
			set { this._hp = value; }
		}

		public Square firstSquare()
		{
			return this._squares.ElementAt(0);
		}
	}
}
