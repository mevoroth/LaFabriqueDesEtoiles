using System;
using Client.protocoladapters;
using System.Text;
using System.Net.Sockets;
using Client.info;
using Client.client;
using Client.components;

namespace Client
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			args = new String[]
			{
				"Player",
				"127.0.0.1",
				"970"
			};
            if (args.Length != 3)
                return;
            //args: [0]pseudo [1]ip [2]port

            UInt16 port;
            UInt16.TryParse(args[2], out port);
            ConnectionInfo.set(args[1], port);

            InitConnexion(args[0]);

			// Lancement du jeu
			StarcraftGame.getInstance().Run();
        }

        static void InitConnexion(string pseudo)
        {
            TcpAdapter tcpa = new TcpAdapter();
            Protocol_handler ph = new Protocol_handler();
            tcpa.send(ph.Identify_send(pseudo));
            uint height, width;
			NetworkStream ns = (NetworkStream)tcpa.receive();
			Byte[] id = new Byte[8];
			ns.Read(id, 0, 8);
            ph.Identify_mapSize(id, out width, out height);
            PointConverter.ServerHeight = (int)height;
			PointConverter.ServerWidth = (int)width;
        }        
    }
#endif
}

