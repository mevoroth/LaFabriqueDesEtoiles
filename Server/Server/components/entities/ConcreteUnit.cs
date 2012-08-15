using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components.entities
{
	public class ConcreteUnit : PlayableConcreteEntity
	{
		public ConcreteUnit(Unit u, UnitSpec cu)
			: base(u, cu)
		{}
	}
}
