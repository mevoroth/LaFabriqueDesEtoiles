using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	public class Technologies
	{
		private static Technologies _instance = null;
		private static readonly object _instanceLock = new object();
		private static Dictionary<String, Technology> _common = new Dictionary<String, Technology>();

		static Technologies()
		{
			//Creation des unitées
			Technologies._common.Add("Adrenal_glands",
				new Technology("Adrenal Glands", new Cost(100, 100, 160), "Increases the attack speed of Zerglings by 20%."));
			Technologies._common.Add("zerg_melee_attacks",
				new Technology("zerg_melee_attacks",new Cost(100,100,160),"Upgrades all Zerg melee attacks."));
		}

		/// <summary>
		/// constructeur null
		/// </summary>
		private Technologies()
		{
		}

		/// <summary>
		/// Retourne l'instance Technologies 
		/// </summary>
		/// <returns></returns>
		public static Technologies getInstance()
		{
			lock (_instanceLock)
			{
				if (Technologies._instance == null)
					Technologies._instance = new Technologies();
				return _instance;
			}
		}
	}
}
