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
	/// class abstract entity
	/// </summary>
	public abstract class Entity : IPrototype, ISerializable
	{

		/// <summary>
		/// Nom
		/// </summary>
		private String _name;

		/// <summary>
		/// HP
		/// </summary>
		private UInt32 _hitPoints;

		/// <summary>
		/// Crée une entité
		/// </summary>
		/// <param name="name">Le nom</param>
		/// <param name="hitPoint">La vie</param>
		public Entity(String name,	UInt32 hitPoint)
		{
			this._name = name;
			this._hitPoints = hitPoint;
		}

		/// <summary>
		/// retoune le nom de l'enité
		/// </summary>
		public String Name
		{
			get
			{
				return this._name;
			}
		}

		/// <summary>
		/// return false si hitPoint > 0 sinon true
		/// </summary>
		/// <returns></returns>
		public bool isNull()
		{
			if (this._hitPoints > 0)
				return false;
			else return true;
		}

		/// <summary>
		/// retourne et attribue une valeur à hitPoint
		/// </summary>
		public UInt32 HitPoints
		{
			get
			{
				return this._hitPoints;
			}
			set
			{
				this._hitPoints = value;
			}
		}

		#region ICloneable Membres
		public object Clone()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region ISerializable Membres

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("name", this._name);
			throw new NotImplementedException();
		}

		#endregion
	}
}
