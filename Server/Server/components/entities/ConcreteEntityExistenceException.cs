using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components.entities
{
	class ConcreteEntitiesExistenceException : Exception
	{
		/// <summary>
		/// ConcretEntiyExistenceException
		/// L'entité n'existe pas
		/// </summary>
		public ConcreteEntitiesExistenceException()
		{
		}
	}
}
