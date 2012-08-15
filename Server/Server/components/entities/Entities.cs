using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Server.components.unshared;
using System.Threading;

namespace Server.components.entities
{
	/// <summary>
	/// class enitites : contitent toute les entité du jeu 
	/// </summary>
	public class Entities
	{
		private static int _id = 0;
		private static Entities _instance = null;
		private static readonly object _instanceLock = new object();
		private static Dictionary<String, Entity> _common = new Dictionary<String, Entity>();
		private static List<EntitySpec> _flyweight = new List<EntitySpec>();

		static Entities()
		{
			//Creation des unitées
			Entities._common.Add("zergling", new Unit("zergling",new Specy("zerg"),/*8,*/new Cost(50,0,24),/*0.375f,*/35,/*20,*/0.5f,1,2.9531f,0.2734f));
			PlayableEntity zergling = (PlayableEntity)Entities._common["zergling"];
			zergling.Armaments.Add(Armaments.getInstance().getArmament("zergling_claw"));
			zergling.Armor = Armors.getInstance().getArmor("light");
			
			Entities._common.Add("drone", new Unit("drone", new Specy("Zerg"),/*8,*/new Cost(50, 0, 20),/*0.375f,*/40,/*20,*/ 1f, 1, 2.8125f, 0.2734f));
			PlayableEntity drone = (PlayableEntity)Entities._common["drone"];
			drone.Armor = Armors.getInstance().getArmor("light");
			drone.Armaments.Add(Armaments.getInstance().getArmament("drone_claws"));

			Entities._common.Add("overlord", new Unit("overlord", new Specy("Zerg"),/*8,*/new Cost(100, 0, 25),/*0.375f,*/200,0,0,0.4687f,0.2734f));
			PlayableEntity overlord = (PlayableEntity)Entities._common["overlord"];
			overlord.Armor = Armors.getInstance().getArmor("armored");

			Entities._common.Add("larvae", new Unit("larvae", new Specy("Zerg"),/*8,*/new Cost(0, 0, 15),/*0.375f*/25,/*20,*/ 0, 0, 0.5625f, 0.2734f));

			//Entities._common.Add("Baneling cocoon", new Unit("Baneling cocoon", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			//Entities._common.Add("Brood lord", new Unit("Brood lord", new Specy("Zerg"),/*8,*/new Cost(150, 150, 34),/*0.375f,*/225,/*20,*/new Armor(1), 4f, 0, 1.4062f, 0.2734f));
			//Entities._common.Add("Brood lord cocoon", new Unit("Brood lord cocoon", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			////Entities._common.Add("Broodling", new Unit("Broodling", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			////Entities._common.Add("Changeling", new Unit("Changeling", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			//Entities._common.Add("Corruptor", new Unit("Corruptor", new Specy("Zerg"),/*8,*/new Cost(150, 100, 40),/*0.375f,*/200,/*20,*/new Armor(2), 2f, 0, 2.9531f, 0.2734f));
			
			//Entities._common.Add("Hydralisk", new Unit("Hydralisk", new Specy("Zerg"),/*8,*/new Cost(100, 50, 33),/*0.375f,*/80,/*20,*/new Armor(0), 2f, 2, 2.25f, 0.2734f));
			////Entities._common.Add("Infested swarm egg", new Unit("Infested swarm egg", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			////Entities._common.Add("Infested terran", new Unit("Infested terran", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			//Entities._common.Add("Infestor", new Unit("Infestor", new Specy("Zerg"),/*8,*/new Cost(100, 150, 50),/*0.375f,*/90,/*20,*/new Armor(0), 2f, 2, 2.5f, 0.2734f));
			
			//Entities._common.Add("zergling", new Unit("Zergling", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			//Entities._common.Add("zergling", new Unit("Zergling", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			//Entities._common.Add("zergling", new Unit("Zergling", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			//Entities._common.Add("zergling", new Unit("Zergling", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			//Entities._common.Add("zergling", new Unit("Zergling", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			//Entities._common.Add("zergling", new Unit("Zergling", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));
			//Entities._common.Add("zergling", new Unit("Zergling", new Specy("Zerg"),/*8,*/new Cost(50, 0, 24),/*0.375f,*/35,/*20,*/new Armor(0), 0.5f, 1, 2.9531f, 0.2734f));

			//creation des batiments
			Entities._common.Add("hatchery", new Building("hatchery", new Specy("Zerg"), new Cost(300, 0, 100), 1500, 9, 5));
			
			//Entities._common.Add("Baneling nest", new Building("Baneling nest", new Specy("Zerg"), new Cost(100, 50, 60), 850, new Armor(1), 6));
			//Entities._common.Add("Creep tumor", new Building("Creep tumor", new Specy("Zerg"), new Cost(300, 0, 100), 1500, new Armor(1), 9));
			//Entities._common.Add("Evolution chamber", new Building("Evolution chamber", new Specy("Zerg"), new Cost(75, 0, 35), 750, new Armor(1), 6));
			//Entities._common.Add("Extractor", new Building("Extractor", new Specy("Zerg"), new Cost(50, 0, 40), 750, new Armor(1), 0));
			//Entities._common.Add("Greater spire", new Building("Greater spire", new Specy("Zerg"), new Cost(100, 150, 100), 1000, new Armor(1), 6));
			//Entities._common.Add("Hive", new Building("Hive", new Specy("Zerg"), new Cost(200, 150, 100), 2500, new Armor(1), 9));
			//Entities._common.Add("Hydralisk den", new Building("Hydralisk den", new Specy("Zerg"), new Cost(100, 100, 40), 850, new Armor(1), 6));
			//Entities._common.Add("Infestation pit", new Building("Infestation pit", new Specy("Zerg"), new Cost(100, 100, 50), 850, new Armor(1), 6));
			//Entities._common.Add("Lair", new Building("Lair", new Specy("Zerg"), new Cost(150, 100, 80), 2000, new Armor(1), 9));
			//Entities._common.Add("Nydus network", new Building("Nydus network", new Specy("Zerg"), new Cost(150, 200, 50), 850, new Armor(1), 6));
			//Entities._common.Add("Nydus worm", new Building("Nydus worm", new Specy("Zerg"), new Cost(100, 100, 20), 200, new Armor(1), 0));
			//Entities._common.Add("Roach warren", new Building("Roach warren", new Specy("Zerg"), new Cost(150, 0, 55), 850, new Armor(1), 6));
			//Entities._common.Add("Spawning pool", new Building("Spawning pool", new Specy("Zerg"), new Cost(200, 0, 65), 1000, new Armor(1), 6));
			//Entities._common.Add("Spine crawler", new Building("Spine crawler", new Specy("Zerg"), new Cost(100, 0, 50), 300, new Armor(2), 0));
			//Entities._common.Add("Spire", new Building("Spire", new Specy("Zerg"), new Cost(200, 200, 100), 850, new Armor(1), 6));
			//Entities._common.Add("Spore crawler", new Building("Spore crawler", new Specy("Zerg"), new Cost(75, 0, 30), 400, new Armor(1), 0));
			//Entities._common.Add("Ultralisk cavern", new Building("Ultralisk cavern", new Specy("Zerg"), new Cost(150, 200, 65), 850, new Armor(1), 6));
                                               
            Entities._common.Add("mineral", new Resource("mineral", 1500, 5));
            Entities._common.Add("richmineral", new Resource("richmineral", 1500, 7));
            Entities._common.Add("vespene", new Resource("vespene", 2500, 4));

		}

		/// <summary>
		/// constructeur de vide
		/// </summary>
		private Entities()
		{
		}

		public static Entities getInstance()
		{
			lock (_instanceLock)
			{
				if (Entities._instance == null)
				{
					Entities._instance = new Entities();
					//Thread th = new Thread(new ThreadStart(Entities.Update()));
					//th.Start();
				}
				return _instance;
			}
		}

		/// <summary>
		/// mise à jour des entity Spec
		/// </summary>
		public void Update()
		{
			//
		}
		/// <summary>
		/// retourne un nouvelle identifiant
		/// </summary>
		public int Id
		{
			get
			{
				int val = Entities._id;
				++Entities._id;
				return val;
			}
		}

		public ConcreteEntity getEntity(String entity, Int32 i)
		{
			if (!Entities._common.ContainsKey(entity))
			{
				throw new ConcreteEntitiesExistenceException();
			}
			//if (Entities._flyweight[i] == null)
			if (i >= Entities._flyweight.Count
				|| Entities._flyweight[i] == null)
			{
				Entities._flyweight.Add(
					this._getReasSpec(Entities._common[entity])
				);
				Entities._flyweight[i].Identity = i;
			}
			return this._getRealConcreteEntity(Entities._common[entity], Entities._flyweight[i]);
		}

		private EntitySpec _getReasSpec(Entity e)
		{
			if (e is Building)
			{
				return new BuildingSpec(new List<Square>(), e.HitPoints, 0);
			}
			if (e is Unit)
			{
				return new UnitSpec(new List<Square>(), e.HitPoints, 0);
			}
			if (e is Resource)
			{
				return new ResourceSpec(
					new List<Square>(), 0
				);
			}
			return new EntitySpec(new List<Square>(), 0);
		}

		private ConcreteEntity _getRealConcreteEntity(Entity e, EntitySpec es)
		{
			if (e is Building)
			{
				return new ConcreteBuilding((Building)e, (BuildingSpec)es);
			}
			if (e is Unit)
			{
				return new ConcreteUnit((Unit)e, (UnitSpec)es);
			}
			if (e is Resource)
			{
				return new ConcreteResource((Resource)e, (ResourceSpec)es);
			}
			//if (e is )
			return new ConcreteEntity(e, es);
		}
	}
}
