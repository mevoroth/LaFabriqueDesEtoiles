using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.components.mouse
{
	/// <summary>
	/// Classe représentant une direction
	/// </summary>
	public class Direction
	{
		/// <summary>
		/// Composante X
		/// </summary>
		private int _dx;
		/// <summary>
		/// Composante Y
		/// </summary>
		private int _dy;
		/// <summary>
		/// Crée une direction
		/// </summary>
		/// <param name="dx"></param>
		/// <param name="dy"></param>
		public Direction(int dx, int dy)
		{
			this._dx = dx;
			this._dy = dy;
		}
		/// <summary>
		/// Composante X
		/// </summary>
		public int Dx
		{
			get { return this._dx; }
		}
		/// <summary>
		/// Composante Y
		/// </summary>
		public int Dy
		{
			get{ return this._dy; }
		}
	}
}
