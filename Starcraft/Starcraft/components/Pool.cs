using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Client.components.graphics;

namespace Client.components
{
	/// <summary>
	/// Un pool d'objet dessinable
	/// </summary>
	public class Pool
	{
		/// <summary>
		/// La carte
		/// </summary>
		private Drawable map;
		/// <summary>
		/// Le HUD
		/// </summary>
		private Drawable hud;
		/// <summary>
		/// Pool d'entit�s
		/// </summary>
		private EntityPool entities;
		/// <summary>
		/// Pool de boutons
		/// </summary>
		private ButtonPool buttons;
		/// <summary>
		/// Le contenu
		/// </summary>
		ContentManager content;
		/// <summary>
		/// Une police
		/// </summary>
		private SpriteFont _font;

		/// <summary>
		/// Cr�e un pool
		/// </summary>
		/// <param name="content">Le contenu</param>
		public Pool(ref ContentManager content)
		{
			this.content = content;
			this.entities = new EntityPool();
			this.buttons = new ButtonPool();
		}

		/// <summary>
		/// Charge une entit�
		/// </summary>
		/// <param name="entity">Le sprite de l'entit�</param>
		public void loadEntity(Sprite entity)
		{
			this.entities.setSprite((content.Load<Texture2D>(entity.getPath())), entity.getPosition(), entity.ServerLoc, entity.getId(), entity.getPath());
		}

		/// <summary>
		/// Charge une carte
		/// </summary>
		/// <param name="map">Le sprite de la carte</param>
		public void loadMap(Sprite map)
		{
			this.map = new Drawable(content.Load<Texture2D>(map.getPath()), map.getPosition(), null, map.getId());
		}

		/// <summary>
		/// Charge l'HUD
		/// </summary>
		/// <param name="hud">Le sprite du HUD</param>
		public void loadHUD(Sprite hud)
		{
			this.hud = new Drawable(content.Load<Texture2D>(hud.getPath()), hud.getPosition(), null, hud.getId());
		}

		/// <summary>
		/// Charge les boutons
		/// </summary>
		/// <param name="button">Le sprite du bouton</param>
		public void loadButton(Sprite button)
		{
			this.buttons.setSprite((content.Load<Texture2D>(button.getPath())), button.getPosition(), hud.getId());
		}

		/// <summary>
		/// Vide le panneau de boutons
		/// </summary>
		public void emptyButtonPanel()
		{
			this.buttons.emptyButtonPanel();
		}

		/// <summary>
		/// D�charge un sprite
		/// </summary>
		/// <param name="entity">Le sprite de l'entit�</param>
		public void unloadEntity(Sprite entity)
		{
			this.entities.unloadEntity(entity);
		}

		/// <summary>
		/// Transforme une entit�
		/// </summary>
		/// <param name="entity">Le sprite de l'entit�</param>
		public void transformEntity(Sprite entity)
		{
			Drawable entityD = new Drawable((content.Load<Texture2D>(entity.getPath())), entity.getPosition(), entity.ServerLoc, entity.getId());
			this.entities.transformEntity(entityD);
		}

		/// <summary>
		/// R�cup�re la carte
		/// </summary>
		/// <returns>La carte</returns>
		public Drawable getMap()
		{
			return this.map;
		}

		/// <summary>
		/// R�cup�re le HUD
		/// </summary>
		/// <returns>Le HUD</returns>
		public Drawable getHUD()
		{
			return this.hud;
		}

		/// <summary>
		/// R�cup�re la liste des entit�s
		/// </summary>
		/// <returns>La liste de boutons</returns>
		public List<Drawable> getEntities()
		{
			return (this.entities.getEntities());
		}

		/// <summary>
		/// R�cup�re la liste des boutons
		/// </summary>
		/// <returns>La liste des boutons</returns>
		public List<Drawable> getButtons()
		{
			return (this.buttons.getButtons());
		}
		
		public void scrollMap(Drawable map)
		{
			this.map = map;
		}

		public void loadFonts()
		{
			this._font = this.content.Load<SpriteFont>("Calibri");
		}

		public SpriteFont Font
		{
			get { return this._font; }
		}
	}
}