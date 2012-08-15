using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Launcher.info;

namespace Launcher.protocoladapters
{
	class UdpAdapter : IProtocolAdapter
	{
        private UdpClient _udpc;

		public UdpAdapter()
		{
			this._udpc = new UdpClient();
		}
		public Object receive()
		{
			IPEndPoint remote = new IPEndPoint(IPAddress.Parse(ConnectionInfo.Host), ConnectionInfo.Port);
			return this._udpc.Receive(ref remote);
		}
		public void send(Byte[] bytes)
		{
			this._udpc.Send(bytes, bytes.Count(), ConnectionInfo.Host, ConnectionInfo.Port);
		}
	}
}
