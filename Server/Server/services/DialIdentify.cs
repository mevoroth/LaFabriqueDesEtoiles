using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.servertools;
using Server.server;
using Server.components;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server.services
{
	class DialIdentify : Dialog
	{
		private Dictionary<String, int> _iptable;

		public Dictionary<String, int> Iptable
		{
			set { this._iptable = value; }
		}

		protected override Dialog.RunFunc getRunnable()
		{
			return this._run;
		}

		private void _run()
		{
			NetworkStream ns = (NetworkStream)this._protocol.receive();
			Byte[] clientdata = new Byte[256];
			ns.Read(clientdata, 0, 256);

			Protocol_handler ph = new Protocol_handler();

			uint action = ph.getAction(clientdata);

			switch(action)
			{
				case (int)ServerProtocol.IDENTIFY_SEND :
                    string pseudo;
					ph.Identify_receive(clientdata, out pseudo);
					lock (this._iptable)
					{
						Controller.get().AddPlayer(this._protocol, this._iptable,
							this._protocol.Ip(), (uint)PlayerSpecy.ZERG, pseudo);
						Monitor.PulseAll(this._iptable);
					}
					break;
			}

			//Controller.get().process(playerid, clientdata);
		}
	}
}
