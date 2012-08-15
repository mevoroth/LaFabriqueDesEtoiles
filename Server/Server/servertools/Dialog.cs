using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.servertools.protocoladapters;

namespace Server.servertools
{
	/// <summary>
	/// Le service
	/// </summary>
	abstract class Dialog
	{
		protected delegate void RunFunc();
		protected IProtocolAdapter _protocol;

        public Dialog()
        {
        }

		abstract protected RunFunc getRunnable();

		public IProtocolAdapter Protocol
		{
			get { return this._protocol; }
			set { this._protocol = value; }
		}

		public void start()
		{
			this.getRunnable()();
		}

	}
}
