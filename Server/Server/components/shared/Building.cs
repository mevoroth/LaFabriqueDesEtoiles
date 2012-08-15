using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.behaviors;

namespace Server.components
{
	/// <summary>
	/// class batiment
	/// </summary>
	public class Building : PlayableEntity
	{
		//private List<ResearchBehavior> _pastResearch;

		/// <summary>
		/// liste d'entité pour construire le batiment
		/// </summary>
		private List<Entity> _unlockedEntities;

		/// <summary>
		/// nombre de bestiole créer lors de la destruction
		/// </summary>
		private int _broodlingproduced;

		//private List<ResearchBehavior> _AvaillableResearch;

		/// <summary>
		/// constructeur de Building
		/// </summary>
		/// <param name="name"> nom</param>
		/// <param name="specy"> race </param>
		/// <param name="cost"> prix </param>
		/// <param name="hitPoints"> point de vie</param>
		/// <param name="armor"> armure </param>
		/// <param name="Broodlingproduced"> nombre de broodling crée lor de la destructions</param>
		public Building(
			String name,
			Specy specy,
			// int sighRange,
			Cost cost,
			// float collisionRadius,
			UInt32 hitPoints,
			//int targetPriority,
			//Armor armor,
			//List<Armament> armaments,
			//List<ResearchBehavior> pastResearch,
			//List<Entity> unlockedEntities,
			int Broodlingproduced,
			int size
		) : base(
				name, specy, cost, hitPoints, size,0
			//, armor
			)
		{
			//this._pastResearch = pastResearch;
			//this._unlockedEntities = unlockedEntities;
			this._broodlingproduced = Broodlingproduced;
		}
	}
}
