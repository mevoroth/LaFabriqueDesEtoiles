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
	/// Point d'entrée de l'application
	/// </summary>
	public class Game
	{
		/// <summary>
		/// Singleton
		/// </summary>
		private static volatile Game _instance;
		//private static Game _instance = null;
		private static Object InstanceLock = new Object();

		/// <summary>
		/// La carte
		/// </summary>
		private Map _mapArray;

		/// <summary>
		/// Les joueurs
		/// </summary>
		private List<Player> _players = new List<Player>();

		/// <summary>
		/// Le nombre de joueurs
		/// </summary>
		private int _player_count = 0;

		/// <summary>
		/// Liste des ressource
		/// Les cristaux(bleu et jaune), les gaz
		/// </summary>
		private List<ConcreteEntity> _RessourceArray = new List<ConcreteEntity>();

		/// <summary>
		/// constructeur de game
		/// choisit automatiquement la map 1
		/// </summary>
		private Game()
		{
		}

		/// <summary>
		/// retourne Game (le singleton)
		/// </summary>
		/// <returns>Game </returns>
		public static Game getInstance()
		{
			if (Game._instance == null)
			{
				lock (InstanceLock)
				{
					if (Game._instance == null)
					{
						Game._instance = new Game();
						Game._instance._mapArray = new Map(1);
					}
				}
			}
			return Game._instance;
		}

		/// <summary>
		/// retoutne la liste de joueur
		/// </summary>
		public List<Player> ListPlayers
		{
			get { return this._players; }
		}

		/// <summary>
		/// retourne la map
		/// </summary>
		public Map Map
		{
			get { return this._mapArray; }
		}

		/// <summary>
		/// Interprète l'action d'un joueur
		/// </summary>
		/// <param name="action">Le numéro d'action</param>
		/// <param name="IdPlayer">Le numéro du joueur</param>
		/// <param name="IdentitySource">Le numéro de l'entité source</param>
		/// <param name="IdEntityTarget">Le numéro de l'entité cible</param>
		public void doAction(UInt16 action, int IdPlayer, int IdentitySource, int IdEntityTarget)
		{
			Player player = this.getPlayer(IdPlayer);
			ConcreteEntity E1 = this.getConcreteEntity(player, IdentitySource);
			ConcreteEntity E2 = this.getConcreteEntity(IdEntityTarget);
			if (E2 != null && E1 != null && player != null)
			{
				player.doAction(action, E1, E2);
			}
			else throw new ConcreteEntitiesExistenceException();
		}

		/// <summary>
		/// exécuter une action à une entité
		/// </summary>
		/// <param name="action"> numéro de l'action </param>
		/// <param name="player"> objet player</param>
		/// <param name="E1"> la concrete entity (entité source) </param>
		/// <param name="target"> la target (entité destination) </param>
		public void doAction(UInt16 action, int IdPlayer, int IdentitySource, int X, int Y)
		{
			// recherche l'oid du joueur et l'oid de l'entité qui éxecutera l'action
			Player player = this.getPlayer(IdPlayer);
			ConcreteEntity E1 = this.getConcreteEntity(player, IdentitySource);
			Square target = this.getSquare(new Point(X, Y));
			if (E1 != null && target != null && player != null)
			{
				player.doAction(action, E1, target);
			}
		}

		/// <summary>
		/// Interprète l'action d'un joueur (transformation d'une unitée)
		/// </summary>
		/// <param name="action"> numéro de l'action </param>
		/// <param name="IdPlayer"> Le numéro du joueur </param>
		/// <param name="IdentitySource"> Le numéro de l'entité source </param>
		/// <param name="EntityTarget"> Le nom de l'unitée en quoi on veut transformer la source </param>
		public void doAction(ushort action, int IdPlayer, int IdentitySource, string EntityTarget)
		{
			Player player = this.getPlayer(IdPlayer);
			ConcreteEntity E1 = this.getConcreteEntity(player, IdentitySource);
			StringTarget st = new StringTarget(EntityTarget);

			if (E1 != null && player != null)
			{
				player.doAction(action, E1, st);
			}
		}

		/// <summary>
		/// Récupère la position d'une entité
		/// </summary>
		/// <param name="p">Joueur</param>
		/// <param name="e">Entité</param>
		/// <returns>Position</returns>
		public Point? getPosition(int IdPlayer, int IdentitySource)
		{
			Player player = this.getPlayer(IdPlayer);
			ConcreteEntity ce = this.getConcreteEntity(player, IdentitySource);
			if( player != null && ce != null)
				return player.getPosition(ce);
			return null;
		}

		/// <summary>
		/// Récupère la case à la position p
		/// </summary>
		/// <param name="p">La position</param>
		/// <returns>La case</returns>
		public Square getSquare(Point p)
		{
			return this._mapArray.getSquare(p);
		}

		/// <summary>
		/// création d'un nouveau player
		/// </summary>
		/// <param name="sp"> race choisie par le player </param>
		public int AddPlayer(Specy sp, String pseudo)
		{
			// trouver une position
			Square s = this._mapArray.getStartPoint();
			if (s != null)
			{
				this._players.Insert(this._player_count, new Player((uint)this._player_count, sp, s, pseudo));
				return this._player_count ++;
			}
			return -1;
		}

		/// <summary>
		/// retourne l'enitité de numéro IdEntity
		/// </summary>
		/// <param name="IdEntity"></param>
		/// <returns></returns>
		public ConcreteEntity getConcreteEntity(int IdEntity)
		{
			foreach (Player p in this._players)
			{
				ConcreteEntity c = p.getConcreteEntity(IdEntity);
				if (c != null) return c;
			}
			foreach (ConcreteEntity c in this._RessourceArray)
			{
				if (c.IDEntity == IdEntity)
				{
					return c;
				}
			}
			return null;
		}

		/// <summary>
		/// retourne la concrete entity d'identifiant Identity du player d'identifiant IdPlayer
		/// </summary>
		/// <param name="IdPlayer"> numéro du player </param>
		/// <param name="IdEntity"> identifiant de l'entity</param>
		/// <returns></returns>
		public ConcreteEntity getConcreteEntity(Player player, int IdEntity)
		{
			return player.getConcreteEntity(IdEntity);
		}
		
		/// <summary>
		/// Retourne le player d'identifiant idPlayer
		/// </summary>
		/// <param name="IdPlayer"> Identifiant du player</param>
		/// <returns> Le player </returns>
		public Player getPlayer(int IdPlayer)
		{
			foreach (Player p in this._players)
			{
				if (p.Idplayer == IdPlayer)
				{
					return p;
				}
			}
			return null;
		}

		/// <summary>
		/// Récupère la liste des unités
		/// </summary>
		/// <returns>La liste des entités</returns>
		public List<ConcreteEntity> getAllUnits()
		{
			List<ConcreteEntity> tmp = new List<ConcreteEntity>();
			foreach (Player p in ListPlayers)
			{
				/*foreach (ConcreteEntity c in p.Entities)
				{
					tmp.Add(c);
				}*/
				tmp.AddRange(p.Entities);
			}
			return tmp;
		}

		/// <summary>
		/// récuperer les liste des ressources
		/// </summary>
		/// <returns></returns>
		public List<ConcreteEntity> getAllRessource(){
			return this._RessourceArray;
		}

		/// <summary>
		/// ajout une nouvelle ressource à la liste des Ressource
		/// </summary>
		/// <param name="cr"></param>
		public void addConcreteResource(ConcreteEntity cr)
		{
			this._RessourceArray.Add(cr);
		}

		/// <summary>
		/// renvoie de la hauteur de la map
		/// </summary>
		public int getMapHeight()
		{
			return this._mapArray.Ymax;
		}

		/// <summary>
		/// renvoie de la largeur de la map
		/// </summary>
		public int getMapWidth()
		{
			return this._mapArray.Xmax;
		}

		/// <summary>
		/// retourne les information sur l'entité
		/// </summary>
		/// <param name="IdEntity"> identifiant de l'entité</param>
		/// <returns> information </returns>
		public Information getInformationEntity(int IdEntity)
		{
			Information inf = new Information();
			foreach (Player p in this._players)
			{
				inf = p.getInformationEntity(IdEntity);
			}
			return inf;
		}

		/// <summary>
		/// suppression de la concrete entity
		/// </summary>
		/// <param name="ce"></param>
		/*public void killEntity(ConcreteEntity ce)
		{
			foreach (Player p in this._players)
			{
				p.killEntity(ce);
			}
		}*/

		/// <summary>
		/// récuprérer les information sur le player
		/// le nombre de cristaux 
		/// le nombre d'armée max et actuuelle
		/// le nombre de gaz
		/// </summary>
		/// <param name="IdPlayer"></param>
		/// <returns></returns>
		public InfoPlayer getInfoPlayer(int IdPlayer)
		{
			InfoPlayer inf = new InfoPlayer();
			foreach (Player p in this._players)
			{
				if (p.Idplayer == IdPlayer)
				{
					return p.getInfoPlayer();
				}
			}
			return inf;
		}
	}
}
