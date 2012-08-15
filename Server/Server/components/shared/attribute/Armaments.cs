using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.components
{
	public class Armaments
	{
		private static Armaments _instance = null;
		private static readonly object _instanceLock = new object();

		/// <summary>
		/// list des armament
		/// </summary>
		private static Dictionary<String, Armament> _common = new Dictionary<String, Armament>();

		static Armaments()
		{
			_common.Add("zergling_claw", new Armament("zergling_claw", 5, new bool[] {true,false}, 0.696, 0.1));
			_common.Add("drone_claws", new Armament("drone_claws", 5, new bool[] {true,false}, 1.5, 0));
			_common.Add("needle_spines", new Armament("needle_spines", 12, new bool[] {true,true}, 0.83, 5));
			_common.Add("scythe", new Armament("scythe", 12, new bool[] {true,false}, 0.83, 0.5));
			_common.Add("glaive_wurm ", new Armament("glaive_wurm", 9, new bool[] {true,true}, 1.5246, 3));
			_common.Add("queen_claws", new Armament("queen_claws", 5, new bool[] {true,false}, 0.696, 0.1));
			_common.Add("acid_spines", new Armament("acid_spines", 9, new bool[] {false,true}, 1, 7));
			_common.Add("acid_saliva", new Armament("acid_saliva", 16, new bool[] {true,false}, 2, 4));
			_common.Add("roach_claws", new Armament("roach_claws", 16, new bool[] {true,false}, 2, 0.1));
			_common.Add("kaiser_blades", new Armament("kaiser_blades", 15, new bool[] {true,false}, 0.861, 1));
			_common.Add("volatile_burst", new Armament("volatile_burst", 5, new bool[] {true,false}, 0.696, 0.1));
			_common.Add("attack_buildings", new Armament("attack_buildings", 5, new bool[] {true,false}, 0.696, 0.1));
			_common.Add("broodling_strike", new Armament("broodling_strike", 20, new bool[] {true,false}, 2.5, 9.5));
			_common.Add("parasite_spores", new Armament("parasite_spores ", 14, new bool[] { false, true }, 1.9, 6));
		}

		private Armaments()
		{
		}

		public static Armaments getInstance()
		{
			lock (_instanceLock)
			{
				if (Armaments._instance == null)
					Armaments._instance = new Armaments();
				return _instance;
			}
		}

		public Armament getArmament(String armament)
		{
			if(_common.ContainsKey(armament))
			{
				return _common[armament];
			}
			else return null;
		}

	}

}
