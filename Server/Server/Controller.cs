using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.behaviors;
using Server.components.entities;
using Server.server;
using Server.components;
using Microsoft.Xna.Framework;
using Server.servertools.protocoladapters;
using System.Net;

namespace Server
{
	/// <summary>
	/// Le contrôleur
	/// </summary>
	class Controller
	{
		/// <summary>
		/// Singleton (Controller)
		/// </summary>
		private static Controller _controller;
		/// <summary>
		/// Singleton (Accès unique, lock)
		/// </summary>
		private static Object _controllerLock = new Object();

		/// <summary>
		/// Singleton (récupère l'instance unique)
		/// </summary>
		/// <returns>Le contrôleur</returns>
		public static Controller get()
		{
			lock (Controller._controllerLock)
			{
				if (Controller._controller == null)
				{
					Controller._controller = new Controller();
				}
				return Controller._controller;
			}
		}

		/// <summary>
		/// Singleton (interdit la construction de l'extérieur)
		/// </summary>
		private Controller()
		{
		}

		/// <summary>
		/// Interprète l'action d'un joueur
		/// </summary>
		/// <param name="action">Le numéro d'action</param>
		/// <param name="IdPlayer">Le numéro du jouer</param>
		/// <param name="IdentitySource">Le numéro de l'entité source</param>
		/// <param name="IdEntityTarget">Le numéro de l'entité cible</param>
		public void doAction(UInt16 action, int IdPlayer, int IdentitySource, int IdEntityTarget)
		{
			Server.components.Game.getInstance().doAction(action, IdPlayer, IdentitySource, IdEntityTarget);
		}

		public void doAction(UInt16 action, int IdPlayer, int IdentitySource, String EntityTarget)
		{
			Server.components.Game.getInstance().doAction(action, IdPlayer, IdentitySource, EntityTarget);
		}

		/// <summary>
		/// Interprète le mouvement d'un joueur
		/// </summary>
		/// <param name="action">Le numéro d'action</param>
		/// <param name="IdPlayer">Le numéro du joueur</param>
		/// <param name="IdentitySource">Le numéro de l'entité source</param>
		/// <param name="X">L'abscisse</param>
		/// <param name="Y">L'ordonnée</param>
		public void doAction(UInt16 action, int IdPlayer, int IdentitySource, Int32 X, Int32 Y)
		{
			Server.components.Game.getInstance().doAction(action, IdPlayer, IdentitySource, X, Y);
		}

		/// <summary>
		/// Récupère la position d'une unité
		/// </summary>
		/// <param name="numPlayer">Le numéro du joueur</param>
		/// <param name="IdentitySource">Le numéro de l'entité source</param>
		/// <returns>La coordonnée et null si la source n'existe pas</returns>
		public Point? getPosition(int numPlayer,int IdentitySource)
		{
			return Server.components.Game.getInstance().getPosition(numPlayer, IdentitySource);
		}

		/// <summary>
		/// Envoie la position
		/// </summary>
		/// <param name="ipa">L'adaptateur réseau</param>
		/// <param name="pid">Le numéro du joueur</param>
		/// <param name="srcid">Le numéro de l'entité source</param>
		public void sendPosition(IProtocolAdapter ipa, int pid, int srcid)
		{
			lock (this)
			{
				Protocol_handler ph = new Protocol_handler();
				Point p = (Point)this.getPosition(pid, srcid);
				if (p == null)
				{
					throw new ConcreteEntitiesExistenceException();
				}
				ipa.send(ph.Unit_position(srcid, p));
			}
		}

		/// <summary>
		/// Ajoute un nouveau joueur
		/// </summary>
		/// <param name="iptable">La table des IP</param>
		/// <param name="ip">L'adresse IP</param>
		/// <param name="idspecy">La race jouée</param>
		/// <param name="pseudo">Le pseudo du joueur</param>
		public void AddPlayer(IProtocolAdapter ipa, Dictionary<String, int> iptable, String ip, uint idspecy, string pseudo)
		{
			Specy sp;
			switch(idspecy){
				case (uint)PlayerSpecy.ZERG :
				default :
					sp = new Specy("Zerg");
					break;
			}
			iptable.Add(ip, Server.components.Game.getInstance().AddPlayer(sp, pseudo));
			Protocol_handler ph = new Protocol_handler();
			int width = Server.components.Game.getInstance().getMapWidth();
			int height = Server.components.Game.getInstance().getMapHeight();
			ipa.send(ph.Identify_mapSize(width, height));
		}

		/// <summary>
		/// Récupère la liste des unités
		/// </summary>
		/// <returns>La liste des unités</returns>
		public List<ConcreteEntity> getAllUnits()
		{
			return Server.components.Game.getInstance().getAllUnits();                                                                                                                                                                                                                                                                                                      
		}

		/// <summary>
		/// Envoie la liste des unités
		/// </summary>
		/// <param name="ipa"></param>
		public void sendAllUnits(IProtocolAdapter ipa)
		{
			Protocol_handler ph = new Protocol_handler();
			ipa.send(ph.Entity_sendlist(this.getAllUnits()));
		}

		/// <summary>
		/// Récupère la liste des Ressources
		/// </summary>
		/// <returns>La liste des Ressource</returns>
		public List<ConcreteEntity> getAllResource()
		{
			return Server.components.Game.getInstance().getAllRessource();
		}

		/// <summary>
		/// Envoie la liste des Ressources
		/// </summary>
		/// <param name="ipa"></param>
		public void sendAllResource(IProtocolAdapter ipa)
		{
			Protocol_handler ph = new Protocol_handler();
			ipa.send(ph.Entity_sendlist(this.getAllResource()));
		}

		/// <summary>
		/// retourne les informations du player
		/// le vespen
		/// le mineraux
		/// popmax
		/// pop
		/// </summary>
		/// <param name="IdPlayer">  identifiant du  player</param>
		public void getInfoPlayer(IProtocolAdapter ipa, int IdPlayer)
		{
			Protocol_handler ph = new Protocol_handler();
			ipa.send(ph.Player_sendressources(
				Server.components.Game.getInstance().getInfoPlayer(IdPlayer)
			));
		}

		/// <summary>
		/// retourne les informations sur l'entité
		/// </summary>
		/// <param name="IdEntity"> identifiant de l'entité</param>
		/// <returns>informations sur l'entité</returns>
		public void getInformationEntity(IProtocolAdapter ipa, int IdEntity) 
		{
			Protocol_handler ph = new Protocol_handler();
			ipa.send(ph.Entity_sendinfo(
				Server.components.Game.getInstance().getInformationEntity(IdEntity)
			));
		}
	}
}



