using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Client.components.graphics;

namespace Client.components
{
	/// <summary>
	/// Fabrique de boutons
	/// </summary>
	public static class Buttons
	{
		/// <summary>
		/// Informations du bouton
		/// </summary>
		private class ButtonInfo
		{
			/// <summary>
			/// Identifiant du bouton
			/// </summary>
			private ButtonId _id;
			/// <summary>
			/// Sprite du bouton (chemin)
			/// </summary>
			private String _path;
			/// <summary>
			/// Slot du bouton
			/// </summary>
			private Slot _slot;

			/// <summary>
			/// Crée un contexte d'information sur le bouton
			/// </summary>
			/// <param name="id">Identifiant du bouton</param>
			/// <param name="path">Sprite du bouton (chemin)</param>
			/// <param name="slot">Slot du bouton</param>
			public ButtonInfo(ButtonId id, String path, Slot slot)
			{
				this._id = id;
				this._path = path;
				this._slot = slot;
			}

			public int Id
			{
				get { return (int)this._id; }
			}
			public String Path
			{
				get { return this._path; }
			}
			public int Slot
			{
				get { return (int)this._slot; }
			}

			/// <summary>
			/// Crée un sprite du bouton
			/// </summary>
			public Sprite Sprite
			{
				get
				{
					Sprite s = new Sprite(Buttons._buttonLoc[this.Slot], 0);
					s.setPath(this.Path);
					return s;
				}
			}
		}
		/// <summary>
		/// Identifiant de bouton
		/// </summary>
		public enum ButtonId
		{
			MOVE = 0,
			ATTACK,
			HARVEST,
			MUTATE
			
		}
		/// <summary>
		/// Slot du bouton
		/// </summary>
		public enum Slot
		{
			SLOT01 = 0,
			SLOT02,
			SLOT03,
			SLOT04,
			SLOT05,
			SLOT06,
			SLOT07,
			SLOT08,
			SLOT09,
			SLOT10,
			SLOT11,
			SLOT12,
			SLOT13,
			SLOT14,
			SLOT15
		}
		/// <summary>
		/// La liste des boutons existants
		/// </summary>
		private static readonly ButtonInfo[] _buttons = new ButtonInfo[] {
			new ButtonInfo(ButtonId.MOVE, "action_move", Slot.SLOT01),
			new ButtonInfo(ButtonId.ATTACK, "action_attack", Slot.SLOT05),
			new ButtonInfo(ButtonId.HARVEST, "action_harvest", Slot.SLOT07),
			new ButtonInfo(ButtonId.MUTATE, "action_mutate", Slot.SLOT01)
		};
		/// <summary>
		/// La position des boutons (ligne)
		/// </summary>
		private static readonly int[] ROWS = new int[3] { 358, 385, 412 };
		/// <summary>
		/// La position des boutons (colonne)
		/// </summary>
		private static readonly int[] COLS = new int[5] { 498, 527, 556, 584, 613 };
		/// <summary>
		/// Le nombre de slots
		/// </summary>
		const int SLOTS = 15;
		/// <summary>
		/// La localisation des boutons
		/// </summary>
		private static Vector2[] _buttonLoc = new Vector2[SLOTS];

		/// <summary>
		/// Crée les boutons
		/// </summary>
		static Buttons()
		{
			for (int i = 0; i < SLOTS; ++i)
			{
				Buttons._buttonLoc[i] = new Vector2(COLS[i%5], ROWS[i/5]);
			}
		}

		public static Slot? slotPressed(int x, int y)
		{
			for (int i = 0; i < SLOTS; ++i)
			{
				if (x >= COLS[i % 5]
					&& x < COLS[i % 5] + 21
					&& y >= ROWS[i / 5]
					&& y < ROWS[i / 5] + 21)
				{
					return (Slot)i;
				}
			}
			return null;
		}

		/// <summary>
		/// Récupère un bouton
		/// </summary>
		/// <param name="bid">Identifiant du bouton</param>
		/// <returns>Le bouton</returns>
		public static Sprite getButton(ButtonId bid)
		{
			int i = 0;
			for ( ; i < SLOTS
				&& Buttons._buttons[i].Id != (int)bid; ++i);
			return Buttons._buttons[i].Sprite;
		}
	}
}
