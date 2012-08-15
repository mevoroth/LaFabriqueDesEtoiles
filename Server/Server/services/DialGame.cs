using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.servertools;
using Server.server;
using Server.components;
using System.Collections;
using System.Net;
using System.Threading;

namespace Server.services
{
	class DialGame : Dialog
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
			Byte[] clientdata = (Byte[])this._protocol.receive();
			lock (this._iptable)
			{
				while (this._iptable.Count() == 0)
				{
					Monitor.Wait(this._iptable);
				}
			}
			if (!this._iptable.ContainsKey(this._protocol.Ip()))
			{
				// Erreur
				Console.WriteLine("ERREUR");
			}
			int playerid = this._iptable[this._protocol.Ip()];
			Protocol_handler ph = new Protocol_handler();

			uint action = ph.getAction(clientdata);
			uint target = 0, pos_x = 0, pos_y = 0;

			//use DoAction from 0 to 99
			if (action < (uint)DoActionProtocol.END_SOURCEPOSITION)
			{
				if (action < (uint)DoActionProtocol.END_SOURCETARGET)
				{
					target = ph.getTarget(clientdata);
				}
				else
				{
                    ph.getPosition(clientdata, out pos_x, out pos_y);
				}
			}

			switch(action)
			{
				case (int)ServerProtocol.UNIT_GETALL :
					Controller.get().sendAllUnits(this._protocol);
					break;
				case (int)ServerProtocol.UNIT_GETPOSITION :
					Controller.get().sendPosition(this._protocol, playerid, (int)ph.getSource(clientdata));
					break;
				case (int)ServerProtocol.UNIT_MOVE :
                    Controller.get().doAction((ushort)action, playerid, (int)ph.getSource(clientdata), (int)pos_x, (int)pos_y);
					break;
                case (int)ServerProtocol.UNIT_MUTATION:
					Controller.get().doAction((ushort)action, playerid, (int)ph.getSource(clientdata), ph.getEntityTarget(clientdata));
                    break;
				case (int)ServerProtocol.PLAYER_GETRESS :
					Controller.get().getInfoPlayer(this._protocol, playerid);
					break;
				case (int)ServerProtocol.UNIT_GETINFO :
					uint uid;
					ph.Entity_getInfo(clientdata, out uid);
					Controller.get().getInformationEntity(this._protocol, (int)uid);
					break;
				case (int)ServerProtocol.UNIT_ATTACK :
				case (int)ServerProtocol.UNIT_COLLECT :
					Controller.get().doAction((ushort)action, playerid, (int)ph.getSource(clientdata), (int)target);
					break;
				case (int)ServerProtocol.RESSOURCES_GETALL :
					Controller.get().sendAllResource(this._protocol);
					break;
				//case (int)ServerProtocol
			}

			//Controller.get().process(playerid, clientdata);
		}
	}
}
