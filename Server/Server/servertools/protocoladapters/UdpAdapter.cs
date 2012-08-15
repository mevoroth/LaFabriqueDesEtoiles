using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Server.info;
using System.Net;

namespace Server.servertools.protocoladapters
{
	class UdpAdapter : IProtocolAdapter
	{
		private static UInt64 count = 0;
		private static UdpClient _udpc;
		private IPEndPoint _ipep;

		static UdpAdapter()
		{
			IPEndPoint ipep = new IPEndPoint(IPAddress.Any, ConnectionInfo.Port);
			UdpAdapter._udpc = new UdpClient(ipep);
		}
		public UdpAdapter()
		{
			
		}
        public Object receive()
		{
			lock (UdpAdapter._udpc)
			{
				this._ipep = new IPEndPoint(IPAddress.Any, 0);
				return UdpAdapter._udpc.Receive(ref this._ipep);
			}
		}
        public void send(Byte[] bytes)
		{
			lock (UdpAdapter._udpc)
			{
				Byte[] b = new Byte[bytes.Count() + 8];
				Buffer.BlockCopy(bytes, 0, b, 0, bytes.Count());
				Buffer.BlockCopy(BitConverter.GetBytes(UdpAdapter.count++), 0, b, bytes.Count(), 8);
				UdpAdapter._udpc.Send(b, b.Count(),
					new IPEndPoint(this._ipep.Address, this._ipep.Port));
			}
		}
		public String Ip()
		{
			return this._ipep.ToString().Split(":".ToCharArray())[0];
		}
	}
}
