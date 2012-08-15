using System;
using Server.services;
using System.Threading;
using Server.servertools.protocoladapters;
using System.Text;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace Server
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry Point for the application.
        /// </summary>
        static void Main(string[] args)
        {
			Dictionary<String, int> iptable = new Dictionary<String, int>();

			DialIdentify di = new DialIdentify();
			di.Iptable = iptable;

			DialGame dg = new DialGame();
			dg.Iptable = iptable;

			servertools.Server sl = new servertools.Server("Server.servertools.protocoladapters.TcpAdapter", di);
			Thread thlogin = new Thread(new ThreadStart(sl.run));
			thlogin.Start();

			servertools.Server sg = new servertools.Server("Server.servertools.protocoladapters.UdpAdapter", dg);
			Thread thgame = new Thread(new ThreadStart(sg.run));
			thgame.Start();
			/*
			servertools.Server sl = new servertools.Server("Server.servertools.protocoladapters.UdpAdapter", new DialTest());
			Thread thlogin = new Thread(new ThreadStart(sl.run));
			thlogin.Start();
			*/
        }
    }
#endif
}

