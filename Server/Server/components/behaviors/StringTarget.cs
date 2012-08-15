using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components.behaviors
{
	public class StringTarget : ITarget
	{
		/// <summary>
		/// String 
		/// </summary>
		private String _entity;

		/// <summary>
		/// constructeur 
		/// </summary>
		/// <param name="entity"> nom de l'entité qui sera crée</param>
		public StringTarget(String entity)
		{
			this._entity = entity;
		}

		/// <summary>
		/// gget et set du nom de l'entité
		/// </summary>
		public String StringEntity
		{
			get { return this._entity; }
			set { this._entity = value; }
		}
	}
}
