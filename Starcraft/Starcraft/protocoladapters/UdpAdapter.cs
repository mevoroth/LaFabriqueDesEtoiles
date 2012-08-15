using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Client.info;
using System.Net;
using Client.protocoladapters;

namespace Client.protocoladapters
{
	/// <summary>
	/// L'adaptateur UDP
	/// </summary>
	class UdpAdapter : IProtocolAdapter
	{
        private UdpClient _udpc;

		public UdpAdapter()
		{
			this._udpc = new UdpClient();
		}
		public Object receive()
		{
			IPEndPoint remote = new IPEndPoint(IPAddress.Parse(ConnectionInfo.get().Host), ConnectionInfo.get().Port);
			return this._udpc.Receive(ref remote);
		}
		public void send(Byte[] bytes)
		{
			this._udpc.Send(bytes, bytes.Count(), ConnectionInfo.get().Host, ConnectionInfo.get().Port);
		}
	}
}
