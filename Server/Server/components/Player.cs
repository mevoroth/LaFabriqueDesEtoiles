using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.behaviors;
using Microsoft.Xna.Framework;
using Server.components.entities;

namespace Server.components
{
	/// <summary>
	/// Joueur
	/// </summary>
	public class Player
	{
		/// <summary>
		/// Race
		/// </summary>
		private Specy _specy;
		/// <summary>
		/// La liste des entités
		/// </summary>
		private List<ConcreteEntity> _ListEntity = new List<ConcreteEntity>();
		/// <summary>
		/// Numéro du joueur
		/// </summary>
		private uint _idPlayer;
		/// <summary>
		/// nom du player
		/// </summary>
		private String _pseudo;

		/// <summary>
		/// nombre de ressouce du joueur
		/// </summary>
		private uint _mineralNumber;

		/// <summary>
		/// nombre de ressouce du joueur
		/// </summary>
		private uint _vespeneNumber;

		/// <summary>
		/// Constructeur de player ajoute au player les unites "de bases" (hatchery...)
		/// </summary>
		/// <param name="id">Identifiant du joueur</param>
		/// <param name="specy">Race choisie</param>
		/// <param name="s">Position initiale du joueur</param>
		public Player(uint id, Specy specy, Square s, String pseudo)
		{
			this._vespeneNumber = 0;
			this._mineralNumber = 50;
			this._pseudo = pseudo;
			this._idPlayer = id;
			this._specy = specy;

			//ajout d'unite(drone) au joueur
			for (int n = 0; n < 5; ++n)
			{
				ConcreteEntity u = Server.components.entities.Entities.getInstance().getEntity("drone", Server.components.entities.Entities.getInstance().Id);
				u.addSquare(Game.getInstance().getSquare(new Point(s.Point.X, s.Point.Y + n)));
				this.addConcreteEntity(u.Squares, u);
			}

			// 3 larve 
			for (int n = 0; n < 3; ++n)
			{
				ConcreteEntity u = Server.components.entities.Entities.getInstance().getEntity("larvae", Server.components.entities.Entities.getInstance().Id);
				u.addSquare(Game.getInstance().getSquare(new Point(s.Point.X - 1, s.Point.Y + n)));
				this.addConcreteEntity(u.Squares, u);
			}

			// ajout de overland
			ConcreteEntity o = Server.components.entities.Entities.getInstance().getEntity("overlord", Server.components.entities.Entities.getInstance().Id);
			o.addSquare(Game.getInstance().getSquare(new Point(s.Point.X, s.Point.Y + 5)));
			this.addConcreteEntity(o.Squares, o);

			//ajout d'un batiment (hatchery) au joueur
			int bat_id = Server.components.entities.Entities.getInstance().Id;
			PlayableConcreteEntity b = (PlayableConcreteEntity)Server.components.entities.Entities.getInstance().getEntity("hatchery", bat_id);
			//Square firstSquare = Game.getInstance().getSquare(new Point(, s.Point.Y + 1));
			int i = s.Point.X + 1;
			int j = s.Point.Y + 1;
			for (int xmax = i + b.Size; i < xmax; ++i, j = s.Point.Y + 1)
			{
				for (int ymax = j + b.Size; j < ymax; ++j)
				{
					b.addSquare(Game.getInstance().getSquare(new Point(i, j)));
				}
			}
			this.addConcreteEntity(b.Squares, b);
		}

		/// <summary>
		/// nombre de mineré
		/// </summary>
		public uint MineralNumber
		{
			get { return this._mineralNumber; }
			set { this._mineralNumber = value; }
		}

		/// <summary>
		/// nombre de gaz
		/// </summary>
		public uint VespeneNumber
		{
			get { return this._vespeneNumber; }
			set { this._vespeneNumber = value; }
		}

		/// <summary>
		/// Ajoute une entité
		/// </summary>
		/// <param name="sq">Les emplacements occupés</param>
		/// <param name="ce">L'entité</param>
		public void addConcreteEntity(List<Square> sq, ConcreteEntity ce)
		{
			//définir par rapport à la position la liste des position possible
			//ce.setSquare(sq);
			foreach(Square s in sq)
				s.Entity = ce;
			this._ListEntity.Add(ce);
		}

		/// <summary>
		/// liste des concrete entité du joueur
		/// </summary>
		public List<ConcreteEntity> Entities
		{
			get { return this._ListEntity; }
		}
		
		/// <summary>
		/// identifiant du joueur
		/// </summary>
		public uint Idplayer
		{
			get { return this._idPlayer; }
			set { this._idPlayer = value; }
		}

		/// <summary>
		/// Effectuer une action
		/// </summary>
		/// <param name="action">Le numéro de l'action</param>
		/// <param name="e">L'entité</param>
		/// <param name="target">La source</param>
		public void doAction(UInt16 action, ConcreteEntity e, ITarget target)
		{
			e.doAction(action, target);
		}

		/// <summary>
		/// Récupère la position
		/// </summary>
		/// <param name="e">L'entité</param>
		/// <returns>La position</returns>
		public Point? getPosition(ConcreteEntity e)
		{
			foreach (ConcreteEntity ent in _ListEntity)
			{
				if (ent.Equals(e))
				{
					return e.Position;
				}
			}
			return null;
		}

		/// <summary>
		/// recherche la concrete entité d'identifiant IdEntity
		/// S'il existe retourne la concrete entity
		/// Sinon retourne null
		/// </summary>
		/// <param name="IdEntity"> identifiant de l'enité</param>
		/// <returns> Concrete entity </returns>
		public ConcreteEntity getConcreteEntity(int IdEntity)
		{
			foreach (ConcreteEntity c in this._ListEntity)
			{
				if (c.IDEntity == IdEntity) return c;
			}
			return null;
		}

		/// <summary>
		/// suppression de l'entité ce (mort)
		/// </summary>
		/// <param name="ce">Concrete entity</param>
		/*public void killEntity(ConcreteEntity ce)
		{
			foreach (ConcreteEntity c in this._ListEntity)
			{
				if (c.Equals(ce))
				{
					// suppimer la concrete entity
					Server.components.entities.Entities.getInstance().pullEntitySpec(ce.getIDEntity());
				}
			}
		}*/

		/// <summary>
		/// retourne une structure d'information sur l'netité
		/// </summary>
		/// <param name="IdEntity"> identifiant de l'entité</param>
		/// <returns> structure d'information </returns>
		public Information getInformationEntity(int IdEntity)
		{
			Information inf = new Information();
			PlayableConcreteEntity pce;
			foreach (PlayableConcreteEntity ce in this._ListEntity)
			{
				if (ce.IDEntity == IdEntity)
				{
					pce = (PlayableConcreteEntity) ce;
					//initialisation de la structure information
					inf = new Information(this._idPlayer, (uint)pce.IDEntity, pce.Name, pce.HpMax, pce.Hp, pce.Energy);
				}
			}
			return inf;
		}

		public InfoPlayer getInfoPlayer()
		{
			InfoPlayer inf = new InfoPlayer();

			// pop max
			uint hatcherynumber = 0;
			uint overlordnumber = 0;
			float pop = 0;
			foreach (ConcreteEntity ce in this._ListEntity)
			{
				if (ce.Name == "hatchery")
				{
					++hatcherynumber;
				}
				if (ce.Name == "overlord")
				{
					++overlordnumber;
				}
				// pop actuel
				PlayableConcreteEntity pce = (PlayableConcreteEntity)ce;
				pop += pce.Supply;
			}

			inf._popMax = (hatcherynumber * 2 + overlordnumber * 8);

			inf._pop = (uint) Math.Round(pop, MidpointRounding.AwayFromZero);

			// vespene
			inf._vespene = this._vespeneNumber;

			// mineral 
			inf._mineral = this._mineralNumber;
			return inf;
		}

		public PlayableConcreteEntity Hatchery
		{
			get
			{
				foreach (PlayableConcreteEntity ce in this._ListEntity)
				{
					if (ce.Name == "hatchery")
					{
						return ce;
					}
				}
				return null;
			}
		}
	}
}
