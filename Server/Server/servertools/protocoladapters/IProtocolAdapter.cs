using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Server.servertools.protocoladapters
{
	interface IProtocolAdapter
	{
		/// <summary>
		/// Reçoit les données
		/// </summary>
        Object receive();
		/// <summary>
		/// Envoi les données
		/// </summary>
		/// <param name="bytes">Les données</param>
        void send(Byte[] bytes);
		/// <summary>
		/// Récupère l'ip du client
		/// </summary>
		String Ip();
    }
}
