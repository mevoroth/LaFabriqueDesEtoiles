using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.components
{
	public class PlayerInfo
	{
		private int _crystals;
		private int _gas;
		private int _pop;
		private int _popmax;
		public int Crystals
		{
			set { this._crystals = value; }
			get { return this._crystals; }
		}
		public int Gas
		{
			set { this._gas = value; }
			get { return this._gas; }
		}
		public int Pop
		{
			set { this._pop = value; }
			get { return this._pop; }
		}
		public int PopMax
		{
			set { this._popmax = value; }
			get { return this._popmax; }
		}
	}
}
