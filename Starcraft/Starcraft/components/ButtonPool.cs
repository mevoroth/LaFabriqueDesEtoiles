using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Client.components.graphics;

namespace Client.components
{
	/// <summary>
	/// Le pool de boutons
	/// </summary>
	public class ButtonPool
	{
		/// <summary>
		/// La liste des boutons
		/// </summary>
		private List<Drawable> _buttons;
		/// <summary>
		/// Crée un pool de boutons
		/// </summary>
		public ButtonPool()
		{
			this._buttons = new List<Drawable>();
		}
		/// <summary>
		/// Ajoute un bouton
		/// </summary>
		/// <param name="button">Sprite du bouton</param>
		/// <param name="position">Position du bouton</param>
		/// <param name="id">Identifiant du bouton</param>
		public void setSprite(Texture2D button, Vector2 position, uint id)
		{
			this._buttons.Add(new Drawable(button, position, null, id));
		}
		/// <summary>
		/// Récupère la liste des boutons
		/// </summary>
		/// <returns></returns>
		public List<Drawable> getButtons()
		{
			return (this._buttons);
		}
		/// <summary>
		/// Vide les boutons
		/// </summary>
		public void emptyButtonPanel()
		{
			this._buttons.Clear();
		}
	}
}