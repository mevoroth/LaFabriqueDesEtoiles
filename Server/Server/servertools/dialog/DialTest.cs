using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starcraft.server.servertools.dialog
{
    class DialTest : Dialog
    {
		public DialTest()
		{
			this._run.Run = doWork;
		}
        void doWork()
        {
			Console.WriteLine(this._buffer);
        }
    }   
}
