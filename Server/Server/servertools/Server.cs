using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Server.info;
using System.Net.Sockets;
using Server.servertools.protocoladapters;

namespace Server.servertools
{
	class Server
	{
		private Type _protocol;
		private Dialog _dial;

        public Server(String protocol, Dialog dial)
		{
			this._protocol = Type.GetType(protocol);
			this._dial = dial;
		}

		public void run()
		{
			while (true)
			{
				/*try
				{*/
					this._dial.Protocol = (IProtocolAdapter)Activator.CreateInstance(this._protocol);
					this._dial.start();
				/*}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}*/
			}
		}
	}
}
