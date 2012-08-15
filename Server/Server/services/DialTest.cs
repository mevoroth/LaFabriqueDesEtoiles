using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.servertools;
using System.Net.Sockets;

namespace Server.services
{
	class DialTest : Dialog
	{
		protected override Dialog.RunFunc getRunnable()
		{
			return this.run;
		}

		private void run()
		{
			UInt32 i = BitConverter.ToUInt32((Byte[])this._protocol.receive(), 0);
			Console.WriteLine("Server : "+i);
			this._protocol.send(BitConverter.GetBytes(i));
		}
	}
}
