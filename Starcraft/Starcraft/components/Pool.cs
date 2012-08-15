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
		/// Pool d'entités
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
		/// Crée un pool
		/// </summary>
		/// <param name="content">Le contenu</param>
		public Pool(ref ContentManager content)
		{
			this.content = content;
			this.entities = new EntityPool();
			this.buttons = new ButtonPool();
		}

		/// <summary>
		/// Charge une entité
		/// </summary>
		/// <param name="entity">Le sprite de l'entité</param>
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
		/// Décharge un sprite
		/// </summary>
		/// <param name="entity">Le sprite de l'entité</param>
		public void unloadEntity(Sprite entity)
		{
			this.entities.unloadEntity(entity);
		}

		/// <summary>
		/// Transforme une entité
		/// </summary>
		/// <param name="entity">Le sprite de l'entité</param>
		public void transformEntity(Sprite entity)
		{
			Drawable entityD = new Drawable((content.Load<Texture2D>(entity.getPath())), entity.getPosition(), entity.ServerLoc, entity.getId());
			this.entities.transformEntity(entityD);
		}

		/// <summary>
		/// Récupère la carte
		/// </summary>
		/// <returns>La carte</returns>
		public Drawable getMap()
		{
			return this.map;
		}

		/// <summary>
		/// Récupère le HUD
		/// </summary>
		/// <returns>Le HUD</returns>
		public Drawable getHUD()
		{
			return this.hud;
		}

		/// <summary>
		/// Récupère la liste des entités
		/// </summary>
		/// <returns>La liste de boutons</returns>
		public List<Drawable> getEntities()
		{
			return (this.entities.getEntities());
		}

		/// <summary>
		/// Récupère la liste des boutons
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