using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.components.graphics;

namespace Client.components
{
	/// <summary>
	/// Fabrique d'entités
	/// </summary>
	public static class Entities
	{
		/// <summary>
		/// Le dictionnaire des boutons associés à une entité
		/// </summary>
		private static Dictionary<String, Sprite[]> _bindEntitiesButtons = new Dictionary<String, Sprite[]>();
		private static Dictionary<String, int> _bindEntitiesSize = new Dictionary<String, int>();

		/// <summary>
		/// Crée les entités
		/// </summary>
		static Entities()
		{
			Entities._bindEntitiesButtons.Add("zergling", new Sprite[] {
				Buttons.getButton(Buttons.ButtonId.ATTACK),
				Buttons.getButton(Buttons.ButtonId.MOVE)
			});
			Entities._bindEntitiesSize.Add("zergling", 1);
			Entities._bindEntitiesButtons.Add("drone", new Sprite[] {
				Buttons.getButton(Buttons.ButtonId.ATTACK),
				Buttons.getButton(Buttons.ButtonId.MOVE),
				Buttons.getButton(Buttons.ButtonId.HARVEST)
			});
			Entities._bindEntitiesSize.Add("drone", 1);
			Entities._bindEntitiesButtons.Add("larvae", new Sprite[] {
				Buttons.getButton(Buttons.ButtonId.MUTATE)
			});
			Entities._bindEntitiesSize.Add("larvae", 1);
			Entities._bindEntitiesButtons.Add("overlord", new Sprite[] {
			});
			Entities._bindEntitiesSize.Add("overlord", 1);

			Entities._bindEntitiesButtons.Add("hatchery", new Sprite[] {
			});
			Entities._bindEntitiesSize.Add("hatchery", 5);

			Entities._bindEntitiesButtons.Add("vespene", new Sprite[] {
			});
			Entities._bindEntitiesSize.Add("vespene", 1);
			Entities._bindEntitiesButtons.Add("mineral", new Sprite[] {
			});
			Entities._bindEntitiesSize.Add("mineral", 1);
			Entities._bindEntitiesButtons.Add("richmineral", new Sprite[] {
			});
			Entities._bindEntitiesSize.Add("richmineral", 1);
		}

		/// <summary>
		/// Récupère les entités
		/// </summary>
		/// <param name="key">L'identifiant de l'entité</param>
		/// <returns>La liste des boutons d'une entité</returns>
		public static Sprite[] get(String key)
		{
			if (!Entities._bindEntitiesButtons.ContainsKey(key))
			{
				throw new EntitiesExistenceException();
			}
			return Entities._bindEntitiesButtons[key];
		}

		public static int getSize(String key)
		{
			if (!Entities._bindEntitiesSize.ContainsKey(key))
			{
				throw new EntitiesExistenceException();
			}
			return Entities._bindEntitiesSize[key];
		}

		public static bool mutate(String p, int x, int y)
		{
			return Buttons.slotPressed(x, y) == Buttons.Slot.SLOT01;
		}
	}
}
