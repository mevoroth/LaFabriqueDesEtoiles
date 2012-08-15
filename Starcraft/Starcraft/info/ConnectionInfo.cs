using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.info
{
	public class ConnectionInfo
	{
		/// <summary>
		/// Le serveur
		/// </summary>
		private String _host;
		/// <summary>
		/// Le port
		/// </summary>
        private UInt16 _port;

        private static ConnectionInfo _instance;

        public static void set(string host, UInt16 port)
        {
            _instance = new ConnectionInfo(host, port);
        }

        public static ConnectionInfo get()
        {
            return _instance;
        }

        private ConnectionInfo(string host, UInt16 port)
        {
            _host = host;
            _port = port;
        }


        public String Host
        {
            get
            {
                return this._host;
            }
        }

        public UInt16 Port
        {
            get
            {
                return this._port;
            }
        }
	}
}
