using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Client.components.vector2tools;

namespace Client.components.graphics
{
	/// <summary>
	/// Moteur graphique
	/// </summary>
	public class Graphics
	{
		/// <summary>
		/// L'affichage
		/// </summary>
		GraphicsDeviceManager graphics;
		/// <summary>
		/// Les actions à faire pour dessiner
		/// </summary>
		private SpriteBatch batch;
		/// <summary>
		/// Le contenu
		/// </summary>
		ContentManager content;

		/// <summary>
		/// Le pool d'objets à dessiner
		/// </summary>
		private Pool _pool;
		/// <summary>
		/// Informations sur le joueur
		/// </summary>
		private PlayerInfo _pi;

		/// <summary>
		/// Crée un moteur graphique
		/// </summary>
		/// <param name="game">Le framework</param>
		public Graphics(Game game)
		{
			graphics = new GraphicsDeviceManager(game);
			content = game.Content;
			//content = new ContentManager(Services);
			content.RootDirectory = "Content"; 
			graphics.PreferredBackBufferWidth = 640;
			graphics.PreferredBackBufferHeight = 480;
			//graphics.IsFullScreen = true; // Fullscreen
			graphics.ApplyChanges();
		}

		/// <summary>
		/// Charge le jeu
		/// </summary>
		/// <param name="entityList">La liste des entités</param>
		/// <param name="map">La carte</param>
		/// <param name="hud">Le HUD</param>
		/// <param name="buttonList">La liste des boutons</param>
		/// <param name="pool">Le pool d'objet à dessiner</param>
		public void loadGame(List<Sprite> entityList, Sprite map, Sprite hud, PlayerInfo pi, List<Sprite> buttonList, out Pool pool)
		///fournir list<Sprite>, Sprite, Sprite, list<Sprite>
		{
			batch = new SpriteBatch(graphics.GraphicsDevice);
			_pool = new Pool(ref this.content);
			_pool.loadMap(map);
			Rectangle r_map = _pool.getMap().getSprite().Bounds;
			PointConverter.Height = r_map.Height;
			PointConverter.Width = r_map.Width;
			_pool.loadHUD(hud);
			_pool.loadFonts();
			this._pi = pi;
			foreach (Sprite entity in entityList)
			{
				Point real_loc = PointConverter.ToClientPoint(new Point((int)entity.ServerLoc.X, entity.ServerLoc.Y));
				_pool.loadEntity(entity);
				_pool.getEntities().Last().Location = new Point((int)entity.ServerLoc.X, entity.ServerLoc.Y);
				_pool.getEntities().Last().Position = new Vector2((float)-real_loc.X, (float)-real_loc.Y);
			}
			foreach (Sprite button in buttonList)
			{
				_pool.loadButton(button);
			}
			pool = this._pool;
		}

		/// <summary>
		/// Dessin du jeu
		/// </summary>
		public void drawGame()
		{
			Drawable map = _pool.getMap();
			Drawable hud = _pool.getHUD();
			List<Drawable> entities = _pool.getEntities();
			List<Drawable> buttons = _pool.getButtons();

			batch.Begin();
			batch.Draw(map.getSprite(), map.Position, Color.White);

			foreach (Drawable entity in entities)
			{
				batch.Draw(entity.getSprite(), Vector2Tools.minus(map.Position, entity.Position), Color.White);
			}

			batch.Draw(hud.getSprite(), hud.Position, Color.White);
			//Vector2 FontOrigin = this._pool.Font.MeasureString("Cristaux : "+this._pi.Crystals.ToString()) / 2;
			batch.DrawString(this._pool.Font, "Cristaux : " + this._pi.Crystals.ToString(), new Vector2(15, 0), Color.White);
			batch.DrawString(this._pool.Font, "Gaz : " + this._pi.Gas.ToString(), new Vector2(15, 20), Color.White);
			batch.DrawString(this._pool.Font,
				"Population : " + this._pi.Pop.ToString() + "/" + this._pi.PopMax.ToString(), new Vector2(15, 40), Color.White);
			try
			{
				foreach (Drawable button in buttons)
				{
					batch.Draw(button.getSprite(), button.Position, Color.White);
				}
			}
			catch (NullReferenceException e)
			{
				//Erreur =3
			}
			batch.End();
		}

		/// <summary>
		/// Ajout, mort, transformation d'unités dans l'update
		/// </summary>
		/// <param name="entity">L'entité</param>
		public void addEntity(Sprite entity)
		{
			_pool.loadEntity(entity);
		}
		/// <summary>
		/// Suppression d'une entité
		/// </summary>
		/// <param name="entity">L'entité</param>
		public void deleteEntity(Sprite entity)
		{
			_pool.unloadEntity(entity);
		}
		/// <summary>
		/// Transformation d'une entité
		/// </summary>
		/// <param name="entity">L'entité</param>
		public void transformEntity(Sprite entity)
		{
			_pool.transformEntity(entity);
		}

	}
}