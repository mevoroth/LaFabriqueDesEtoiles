using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	public class Armors
	{
		private static Armors _instance = null;
		private static readonly object _instanceLock = new object();

		/// <summary>
		/// list des armur 
		/// </summary>
		private static Dictionary<String, Armor> _common = new Dictionary<String, Armor>();

		static Armors()
		{
			_common.Add("light",new Armor(Server.components.Armor.ArmorType.light,0));
			_common.Add("armored", new Armor(Server.components.Armor.ArmorType.armored, 1));
		}

		/// <summary>
		/// constructeur de Armors
		/// </summary>
		private Armors()
		{
		}

		public static Armors getInstance()
		{
			lock (_instanceLock)
			{
				if (Armors._instance == null)
					Armors._instance = new Armors();
				return _instance;
			}
		}

		public Armor getArmor(String armor)
		{
			if (_common.ContainsKey(armor))
			{
				return _common[armor];
			}
			else return null;
		}
	}
}
