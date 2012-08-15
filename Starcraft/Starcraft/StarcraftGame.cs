using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Client.components.mouse;
using Client.components.graphics;
using Client.components;
using Client.client;
using Client.protocoladapters;

namespace Client
{
	/// <summary>
	/// Contrôleur
	/// </summary>
	public class StarcraftGame : Microsoft.Xna.Framework.Game
	{
		/// <summary>
		/// L'affichage
		/// </summary>
		GraphicsDeviceManager graphicManager;
		/// <summary>
		/// Le lot de traitement des sprites
		/// </summary>
		SpriteBatch spriteBatch;
		/// <summary>
		/// Gestionnaire de souris
		/// </summary>
		private MouseHandler _mouse;
		/// <summary>
		/// Pool d'objets à dessiner
		/// </summary>
		private Pool _pool;
		/// <summary>
		/// L'élément actuel sélectionné
		/// </summary>
		private Drawable _currentSel;
		private PlayerInfo _playerinfo = new PlayerInfo();
		/// <summary>
		/// Le moteur graphique
		/// </summary>
		private Graphics _graphics;
		private static StarcraftGame _instance;
		private static Object _instanceLock = new Object();
		private uint _playerId;
		private KeyboardHandler _keyboard;

		public static StarcraftGame getInstance()
		{
			lock (StarcraftGame._instanceLock)
			{
				if (StarcraftGame._instance == null)
				{
					StarcraftGame._instance = new StarcraftGame();
				}
				return StarcraftGame._instance;
			}
		}

		private StarcraftGame()
		{
			_graphics = new Graphics(this);
			this.IsMouseVisible = true;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Protocol_handler protocol = new Protocol_handler();
			UdpAdapter udpa = new UdpAdapter();
			udpa.send(protocol.Unit_getAll());
			List<Sprite> entityList;
			protocol.Entity_receivelist((Byte[])udpa.receive(), out entityList);
			List<Sprite> resources;
			udpa.send(protocol.Ressources_getAll());
			protocol.Entity_receivelist((Byte[])udpa.receive(), out resources);
			entityList.AddRange(resources);
			// Chargement de la map
			Sprite map = new Sprite(new Vector2(0, 0), null);
			map.setPath("map");
			// Chargement du HUD
			Sprite hud = new Sprite(new Vector2(0, 289), null);
			hud.setPath("hud");
			// Chargement des boutons
			List<Sprite> buttonList = new List<Sprite>();

			// TODO: use this.Content to load your game content here
			_graphics.loadGame(entityList, map, hud, this._playerinfo, buttonList, out this._pool);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

			// TODO: Add your update logic here
			base.Update(gameTime);

			// Ressources
			this._updateResources();

			// Evénement souris
			this._mouse = new MouseHandler(Mouse.GetState());
			this._mouse.process();

			// Evénement clavier
			this._keyboard = new KeyboardHandler(Keyboard.GetState());
			this._keyboard.process();

			// Boutons
			this._updateButtons();

			// Scroll de la map
			this._scrollMap();

			// Update de la position
			this._updateLocation();
		}

		private void _updateResources()
		{
			IProtocolAdapter ipa = new UdpAdapter();
			Protocol_handler ph = new Protocol_handler();
			ipa.send(ph.Player_getressources());
			int crystal, pop, popmax, vespen;
			ph.Unit_receiveRessources((Byte[])ipa.receive(), out crystal, out pop, out popmax, out vespen);
			this._playerinfo.Crystals = crystal;
			this._playerinfo.Gas = vespen;
			this._playerinfo.Pop = pop;
			this._playerinfo.PopMax = popmax;
		}

		/// <summary>
		/// Mets à jour les boutons
		/// </summary>
		private void _updateButtons()
		{
			this._pool.emptyButtonPanel();
			if (this._currentSel != null)
			{
				Sprite[] buttons = Entities.get(this._currentSel.Name);
				for (int i = 0; i < buttons.Length; ++i)
				{
					this._pool.loadButton(buttons[i]);
				}
			}
		}

		/// <summary>
		/// Mets à jour les positions
		/// </summary>
		private void _updateLocation()
		{
			UdpAdapter udpa = new UdpAdapter();
			Protocol_handler ph = new Protocol_handler();
			List<Sprite> entityList;
			List<Sprite> resources;
			udpa.send(ph.Unit_getAll());
			ph.Entity_receivelist((Byte[])udpa.receive(), out entityList);
			udpa.send(ph.Ressources_getAll());
			ph.Entity_receivelist((Byte[])udpa.receive(), out resources);
			entityList.AddRange(resources);
			List<Drawable> dl = this._pool.getEntities();
			for (int i = 0; i < entityList.Count(); ++i)
			{
				int j = 0;
				for (; j < dl.Count() ; ++j)
				{
					if (dl[j].getId() == entityList[i].getId())
					{
						Point real_loc = PointConverter.ToClientPoint(new Point((int)entityList[i].ServerLoc.X, (int)entityList[i].ServerLoc.Y));
						dl[j].Location = new Point((int)entityList[i].ServerLoc.X, (int)entityList[i].ServerLoc.Y);
						dl[j].Position = new Vector2((float)-real_loc.X, (float)-real_loc.Y);
						break;
					}
				}
				if (j >= dl.Count())
				{
					this._pool.loadEntity(entityList[i]);
				}
			}
			for (int i = 0; i < dl.Count(); ++i)
			{
				int j = 0;
				for (; j < entityList.Count(); ++j)
				{
					if (dl[i].getId() == entityList[j].getId())
					{
						break;
					}
				}
				if (j >= entityList.Count())
				{
					this._pool.getEntities().RemoveAt(i);
				}
			}
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Pink);

			// TODO: Add your drawing code here
			_graphics.drawGame();

			base.Draw(gameTime);
		}

		/// <summary>
		/// Sélection d'une unité
		/// </summary>
		/// <param name="x">Abscisse</param>
		/// <param name="y">Ordonnée</param>
		public void selectEntity(int x, int y)
		{
			Point p = PointConverter.ToServerPoint(new Point(
				(x - (int)Math.Floor(this._pool.getMap().Position.X)),
				(y - (int)Math.Floor(this._pool.getMap().Position.Y))
			));
			foreach (Drawable d in this._pool.getEntities())
			{
				if (d.Contains(p))
				{
					this._currentSel = d;
					return;
				}
			}

			if (this._currentSel != null)
			{
				if (Entities.mutate(this._currentSel.Name, x, y))
				{
					UdpAdapter udpa = new UdpAdapter();
					Protocol_handler ph = new Protocol_handler();
					udpa.send(ph.Unit_mutation(this._currentSel, "zergling"));
					return;
				}
			}
			this._currentSel = null;
		}
		/// <summary>
		/// Effectue une action dans un contexte
		/// </summary>
		/// <param name="x">Abscisse</param>
		/// <param name="y">Ordonnée</param>
		public void doContext(int x, int y)
		{
			if (this._currentSel != null)
			{
				UdpAdapter udpa = new UdpAdapter();
				Protocol_handler ph = new Protocol_handler();
				Point p = PointConverter.ToServerPoint(new Point(
					(x - (int)Math.Floor(this._pool.getMap().Position.X)),
					(y - (int)Math.Floor(this._pool.getMap().Position.Y))
				));
				foreach (Drawable d in this._pool.getEntities())
				{
					if (d.Contains(p))
					{
						if (d.Name == "mineral"
							|| d.Name == "richmineral"
							|| d.Name == "vespene")
						{
							udpa.send(ph.Unit_collect(this._currentSel, d));
						}
						else
						{
							udpa.send(ph.Unit_attack(this._currentSel, d));
						}
						return;
					}
				}
				udpa.send(ph.Unit_move(this._currentSel, p));
			}
		}

		public void setPlayerId(uint pId)
		{
			this._playerId = pId;
		}

		private void _scrollMap()
		{
			Drawable map = this._pool.getMap();
			if (this._mouse.IsScroll)
			{
				Vector2 position = map.Position;
				position.X -= (float)this._mouse.Direction.Dx * this._mouse.Speed;
				position.Y -= (float)this._mouse.Direction.Dy * this._mouse.Speed;
				if (position.X < -map.getSprite().Width + 640)
				{
					position.X = -map.getSprite().Width + 640;
				}
				if (position.Y < -map.getSprite().Height + 480)
				{
					position.Y = -map.getSprite().Height + 480;
				}
				if (position.X > 0)
				{
					position.X = 0;
				}
				if (position.Y > 0)
				{
					position.Y = 0;
				}
				map.Position = position;
			}
		}
	}
}
