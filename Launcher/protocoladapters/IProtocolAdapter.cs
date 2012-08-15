using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Launcher.protocoladapters
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
	}
}
