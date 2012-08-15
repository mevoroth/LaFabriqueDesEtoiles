using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.protocoladapters;
using Client.components.graphics;
using Microsoft.Xna.Framework;

namespace Client.client
{
    class Protocol_handler
    {
		/// <summary>
		/// Ajoute le type d'action au tableau de bytes
		/// </summary>
		/// <param name="bytes">bytes a envoyer sur le réseau</param>
		/// <param name="id">offset d'écriture</param>
		/// <param name="p">type d'action</param>
        private void setType(ref Byte[] bytes, ref int id, Protocol p)
        {
            addInt16(ref bytes, ref id, (UInt16)p);
        }

        /// <summary>
        /// Ajoute un int16 au tableau de bytes
        /// </summary>
        /// <param name="bytes">bytes a envoyer sur le réseau</param>
        /// <param name="id">offset d'écriture</param>
        /// <param name="i">entier à écrire</param>
        private void addInt16(ref Byte[] bytes, ref int id, uint i)
        {
            Byte[] data = BitConverter.GetBytes((UInt16)i);

            bytes[id++] = data[0];
            bytes[id++] = data[1];
        }

        /// <summary>
        /// Ajoute un int32 au tableau de bytes
        /// </summary>
        /// <param name="bytes">bytes a envoyer sur le réseau</param>
        /// <param name="id">offset d'écriture</param>
        /// <param name="i">entier à écrire</param>
        private void addInt32(ref Byte[] bytes, ref int id, uint i)
        {
            Byte[] data = BitConverter.GetBytes((UInt32)i);

            bytes[id++] = data[0];
            bytes[id++] = data[1];
            bytes[id++] = data[2];
            bytes[id++] = data[3];
        }

        /*********************************************/
        /********************Units********************/
        /*********************************************/

		/// <summary>
		/// Génère le code réseau pour un déplacement d'unité
		/// </summary>
		/// <param name="u">l'unité à déplacer</param>
		/// <param name="p">la position cible</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
        public Byte[] Unit_move(Drawable u, Point p)
        {
            Byte[] bytes = new Byte[12];//2+2+4+4
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_MOVE);
            addInt16(ref bytes, ref i, u.getId());
            addInt32(ref bytes, ref i, (uint)p.X);
			addInt32(ref bytes, ref i, (uint)p.Y);
			return (bytes);
        }

        /// <summary>
        /// Génère le code réseau pour une interruption d'unité
        /// </summary>
        /// <param name="u">l'unité à interrompre</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
		public Byte[] Unit_interrupt(Drawable u)
        {
            Byte[] bytes = new Byte[4];//2+2
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_INTERRUPT);
			addInt16(ref bytes, ref i, u.getId());
			return (bytes);
        }

        /// <summary>
        /// Génère le code réseau pour arreter le déplacement d'une unité
        /// </summary>
        /// <param name="u">l'unité</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
		public Byte[] Unit_holdPosition(Drawable u)
        {
            Byte[] bytes = new Byte[4];//2+2
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_HOLDPOSITION);
			addInt16(ref bytes, ref i, u.getId());
			return (bytes);
        }

        /// <summary>
        /// Génère le code réseau pour faire patrouiller une unité
        /// </summary>
        /// <param name="u">l'unité</param>
        /// <param name="p">la position à la quel patrouiller</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
		public Byte[] Unit_patrol(Drawable u, Point p)
        {
            Byte[] bytes = new Byte[12];//2+2+4+4
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_PATROL);
            addInt16(ref bytes, ref i, u.getId());
            addInt32(ref bytes, ref i, (uint)p.X);
			addInt32(ref bytes, ref i, (uint)p.Y);
			return (bytes);
        }

        /// <summary>
        /// Génère le code réseau pour une attaque d'une unité
        /// </summary>
        /// <param name="u">l'unité attaquante</param>
        /// <param name="target">l'unité attaqué</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
		public Byte[] Unit_attack(Drawable u, Drawable target)
        {
            Byte[] bytes = new Byte[6];//2+2+2
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_ATTACK);
            addInt16(ref bytes, ref i, u.getId());
            addInt16(ref bytes, ref i, target.getId());
            return(bytes);
        }

        /// <summary>
        /// Génère le code réseau pour demander la position d'une unité
        /// </summary>
        /// <param name="u">l'unité dont on demande la position</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
        public Byte[] Unit_getPosition(Drawable u)
        {
            Byte[] bytes = new Byte[4];
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_GETPOSITION);
            addInt16(ref bytes, ref i, u.getId());
            return (bytes);
        }

        /// <summary>
        /// Convertie bytes lu sur le réseau en player Id et sa position
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
        /// <param name="uId">l'id de l'unité</param>
        /// <param name="uX">position en X de l'unité</param>
        /// <param name="uY">position en Y de l'unité</param>
        public void Unit_position(Byte[] bytes, out uint uId, out uint uX, out uint uY)
        {
            //2+2+4+4
            uId = BitConverter.ToUInt16(bytes, 2);
            uX = BitConverter.ToUInt32(bytes, 4);
            uY = BitConverter.ToUInt32(bytes, 8);
        }

        /// <summary>
        /// Génère le code réseau pour demander la liste de toute les unités
        /// </summary>
        /// <returns>bytes a envoyer sur le réseau</returns>
        public Byte[] Unit_getAll()
        {
            Byte[] bytes = new Byte[2];
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_GETALL);
            return (bytes);
        }

        /// <summary>
        /// Convertie bytes lu sur le réseau en liste d'unités (sprites)
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
        /// <param name="lstSprite">la liste d'unités</param>
        public void Entity_receivelist(Byte[] bytes, out List<Sprite> lstSprite)
        {
            uint nbUnits = BitConverter.ToUInt16(bytes, 2);
            lstSprite = new List<Sprite>();

            int done = 4;
            for (int i = 0; i < nbUnits; ++i)
            {
                Sprite s = new Sprite(new Vector2(
						BitConverter.ToUInt32(bytes, done + 2),
						BitConverter.ToUInt32(bytes, done + 6)),
                        BitConverter.ToUInt16(bytes, done));
				
                int str_size = bytes[done + 10];
                Byte[] str = new Byte[str_size];
                System.Buffer.BlockCopy(bytes, done + 11, str, 0, str_size);

                s.setPath(Encoding.ASCII.GetString(str));
                lstSprite.Add(s);
                done += (11 + str_size);
            }
        }

        /// <summary>
        /// Génère le code réseau pour demander les infos d'une unité
        /// </summary>
        /// <param name="uId">Id de l'unité</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
        public Byte[] Unit_getInfo(uint uId)
        {
            Byte[] bytes = new Byte[4];
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_GETINFO);
            addInt16(ref bytes, ref i, uId);
            return (bytes);
        }

        /// <summary>
        /// Convertie bytes lu sur le réseau en informations sur une unité
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
        /// <param name="pId">Identifiant du player possesseur</param>
        /// <param name="uId">Identifiant de l'unité</param>
        /// <param name="name">Nom de l'unité</param>
        /// <param name="energy">Energy de l'unité</param>
        /// <param name="hitPoints">points de vie actuels</param>
        /// <param name="hitPointsMax">points de vie max</param>
        public void Unit_receiveInfo(Byte[] bytes, out uint pId, out uint uId, out string name, 
                                    out uint energy, out uint hitPoints, out uint hitPointsMax)
        {
            pId = BitConverter.ToUInt16(bytes, 2);
            uId = BitConverter.ToUInt16(bytes, 4);
            energy = BitConverter.ToUInt32(bytes, 6);
            hitPoints = BitConverter.ToUInt16(bytes, 10);
            hitPointsMax = BitConverter.ToUInt16(bytes, 12);
            int str_size = bytes[14];
            Byte[] str = new Byte[str_size];
            System.Buffer.BlockCopy(bytes, 15, str, 0, str_size);
            name = Encoding.ASCII.GetString(str);
        }

        /// <summary>
        /// Génère le code réseau pour demander une mutation d'une unité
        /// </summary>
        /// <param name="u">l'unité à muter</param>
        /// <param name="type">le type vers lequel l'unité doit muter</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
        public Byte[] Unit_mutation(Drawable u, string type)
        {
            Byte[] btype = Encoding.ASCII.GetBytes(type);

            Byte[] bytes = new Byte[5 + btype.Length];
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_MUTATION);
            addInt16(ref bytes, ref i, u.getId());
            bytes[4] = (byte)btype.Length;
            System.Buffer.BlockCopy(btype, 0, bytes, 5, btype.Length);
            return (bytes);
        }

        /// <summary>
        /// Génère le code réseau pour demander à une unité de récolter une ressource
        /// </summary>
        /// <param name="u">l'unité cible</param>
        /// <param name="res">la ressource a récolter</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
        public Byte[] Unit_collect(Drawable u, Drawable res)
        {
            Byte[] bytes = new Byte[6];//2+2+2
            int i = 0;
            setType(ref bytes, ref i, Protocol.UNIT_COLLECT);
            addInt16(ref bytes, ref i, u.getId());
            addInt16(ref bytes, ref i, res.getId());
            return (bytes);
        }

        public Byte[] Ressources_getAll()
        {
            Byte[] bytes = new Byte[2];
            int i = 0;
            setType(ref bytes, ref i, Protocol.RESSOURCES_GETALL);
            return (bytes);
        }

        /*********************************************/
        /*******************Player********************/
        /*********************************************/

        /// <summary>
        /// Génère le code réseau pour demander les ressources d'un joueur
        /// </summary>
        /// <param name="pId">Id du joueur</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
        public Byte[] Player_getressources()
        {
            Byte[] bytes = new Byte[2];
            int i = 0;
            setType(ref bytes, ref i, Protocol.PLAYER_GETRESS);
            return (bytes);
        }

        /// <summary>
        /// Convertie bytes lu sur le réseau en informations sur les ressources du joueur
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
        /// <param name="mineral">minerai du joueur</param>
        /// <param name="pop">population du joueur</param>
        /// <param name="popMax">population max du joueur</param>
        /// <param name="vespen">vespen du joueur</param>
        public void Unit_receiveRessources(Byte[] bytes, out int mineral, out int pop, out int popMax, out int vespen)
        {
            mineral = BitConverter.ToUInt16(bytes, 2);
            pop = BitConverter.ToUInt16(bytes, 4);
            popMax = BitConverter.ToUInt16(bytes, 6);
            vespen = BitConverter.ToUInt16(bytes, 8);
        }

        /*********************************************/
        /******************Identify*******************/
        /*********************************************/

        /// <summary>
        /// Génère le code réseau pour envoyer le pseudo du joueur
        /// </summary>
        /// <param name="pseudo">notre pseudo</param>
        /// <returns>bytes a envoyer sur le réseau</returns>
        public Byte[] Identify_send(string pseudo)
        {
            Byte[] bytes = new Byte[3 + pseudo.Length];
            int i = 0;
            setType(ref bytes, ref i, Protocol.IDENTIFY_SEND);
            bytes[2] = (byte)pseudo.Length;
            Byte[] bpseudo = Encoding.ASCII.GetBytes(pseudo);
            System.Buffer.BlockCopy(bpseudo, 0, bytes, 3, bpseudo.Length);
            return (bytes);
        }

        /// <summary>
        /// Convertie bytes lu sur le réseau en taille de la map
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
		/// <param name="width">largeur de le carte</param>
		/// <param name="height">largeur de le carte</param>
		public void Identify_mapSize(Byte[] bytes, out uint width, out uint height)
        {
			width = BitConverter.ToUInt32(bytes, 0);
			height = BitConverter.ToUInt32(bytes, 4);
        }

    }
}
