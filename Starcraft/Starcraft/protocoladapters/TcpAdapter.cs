using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Client.info;

namespace Client.protocoladapters
{
	/// <summary>
	/// L'adaptateur TCP
	/// </summary>
	class TcpAdapter : IProtocolAdapter
	{
		private TcpClient _client;

		public TcpAdapter()
		{
			this._client = new TcpClient(ConnectionInfo.get().Host, ConnectionInfo.get().Port);
		}
		#region IProtocolAdapter Membres

		public Object receive()
		{
			return this._client.GetStream();
		}

		public void send(byte[] bytes)
		{
			this._client.GetStream().Write(bytes, 0, bytes.Count());
		}

		#endregion
	}
}
