using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	public class UnitSpec : PlayableEntitySpec
	{
		/// <summary>
		/// constructeur unit spec
		/// </summary>
		/// <param name="square"> Liste de square (position de l'entité) </param>
		/// <param name="hp"> hitPoints </param>
		public UnitSpec(List<Square> square, UInt32 hp, UInt32 energy): base(square, hp, energy)
		{
		}
	}
}
