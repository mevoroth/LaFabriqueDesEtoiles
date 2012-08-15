using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Launcher.info
{
	class ConnectionInfo
	{
		/// <summary>
		/// Le serveur
		/// </summary>
		private static String _host = "127.0.0.1";
		/// <summary>
		/// Le port
		/// </summary>
		private static UInt16 _port = 970;
		public static String Host
		{
			get { return ConnectionInfo._host; }
			set { ConnectionInfo._host = value; }
		}
		public static UInt16 Port
		{
			get { return ConnectionInfo._port; }
			set { ConnectionInfo._port = value; }
		}
	}
}
