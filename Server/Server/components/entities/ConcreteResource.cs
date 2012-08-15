using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.unshared;

namespace Server.components.entities
{
	public class ConcreteResource : ConcreteEntity
	{
		public ConcreteResource(Resource resource, ResourceSpec resourceSpec) : base(resource,resourceSpec)
		{
		}

		/// <summary>
		/// retourne le nombre récolter
		/// </summary>
		/// <returns></returns>
		public int Recolt
		{
			get
			{
				Resource r = (Resource)this.Shared;
				return r.Recolt;
			}
		}
	}
}
