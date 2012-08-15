using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Server.info;
using System.Net;
using System.IO;

namespace Server.servertools.protocoladapters
{
	class TcpAdapter : IProtocolAdapter
	{
		private static Socket _serversocket;
		private Socket _socket;

		static TcpAdapter()
		{
			TcpAdapter._serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			TcpAdapter._serversocket.Bind(
				new IPEndPoint(IPAddress.Any, ConnectionInfo.Port)
			);
			TcpAdapter._serversocket.Listen(Int32.MaxValue);
		}

		public TcpAdapter()
		{
			this._socket = TcpAdapter._serversocket.Accept();
		}

		~TcpAdapter()
		{
			this._socket.Close();
		}

		#region IProtocolAdapter Membres

		public Object receive()
		{
			return new NetworkStream(this._socket, true);
		}

		public void send(byte[] bytes)
		{
			//this._socket.Send(bytes);
			NetworkStream ns = new NetworkStream(this._socket, true);
			ns.Write(bytes, 0, bytes.Length);
		}

		#endregion

		#region IProtocolAdapter Members


		public String Ip()
		{
			return this._socket.RemoteEndPoint.ToString().Split(":".ToCharArray())[0];
		}

		#endregion
	}
}
