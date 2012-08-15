using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{

    public class Technology
    {
		/// <summary>
		/// nom de la technologie
		/// </summary>
		private String _name;
		/// <summary>
		/// cout de la technologie
		/// </summary>
		private Cost _cost;
		/// <summary>
		/// description de l'effet du développement de la technologie
		/// </summary>
		private string _description;
		/// <summary>
		/// liste des unites affecte par le développement de la technologie
		/// </summary>
		private List<PlayableEntity> _affectedEntities;
		 
		
		/// <summary>
		/// Constructeur de la technologie
		/// </summary>
		/// <param name="name"> nom de la technologie </param>
		/// <param name="cost"> cout de la technologie </param>
		/// <param name="description"> description de l'effet du développement de la technologie </param>
		public Technology(String name, Cost cost, string description/*, List<PlayableEntity> affectedEntities*/)
		{
			this._name = name;
			this._cost = cost;
			this._description = description;
			//this._affectedEntities = affectedEntities;
		}
    }
}
