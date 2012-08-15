using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components.unshared
{
	public class ResourceSpec : EntitySpec
	{

		/// <summary>
		/// constructeur Resource spec
		/// </summary>
		/// <param name="square"> Liste de square (position de l'entité) </param>
		/// <param name="hp"> hitPoints </param>
		public ResourceSpec(List<Square> square, UInt32 hp): base(square, hp)
		{
		}
	}
}
