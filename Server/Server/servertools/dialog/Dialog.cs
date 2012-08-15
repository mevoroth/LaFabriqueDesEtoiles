using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Starcraft.server.servertools
{
	/// <summary>
	/// Le service
	/// </summary>
	abstract class Dialog
	{
		protected Runnable _run;
		protected Byte[] _buffer;

		public Dialog()
		{
		}

		public Byte[] Buffer
		{
			set { this._buffer = value; }
		}
		public void start()
		{
			Thread th = new Thread(new ThreadStart(this._run.Run));
			th.Start();
		}
	}
}
