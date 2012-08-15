using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components.entities
{
	public class ConcreteBuilding : PlayableConcreteEntity
	{
		/// <summary>
		/// concrete Bulding
		/// </summary>
		/// <param name="b"> Building</param>
		/// <param name="bs"> BuildingSpec</param>
		public ConcreteBuilding(Building b, BuildingSpec bs)
			: base(b, bs)
		{
		}
	}
}
