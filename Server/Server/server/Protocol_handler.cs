using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.servertools.protocoladapters;
using Server.components;
using Microsoft.Xna.Framework;
using Server.components.entities;

namespace Server.server
{
    class Protocol_handler
    {
        /// <summary>
        /// Récupère le type d'action à partire des bytes lu sur le réseau
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
        /// <returns>le type d'action</returns>
        public uint getAction(Byte[] bytes)
        {
            return BitConverter.ToUInt16(bytes, 0);
        }

        /// <summary>
        /// Récupère l'id de la source à partire des bytes lu sur le réseau
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
        /// <returns>l'id de la source</returns>
        public uint getSource(Byte[] bytes)
        {
            return BitConverter.ToUInt16(bytes, 2);
        }

        /// <summary>
        /// Récupère l'id de la cible à partire des bytes lu sur le réseau
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
        /// <returns>l'id de la cible</returns>
        public uint getTarget(Byte[] bytes)
        {
            return BitConverter.ToUInt16(bytes, 4);
        }

        public string getEntityTarget(Byte[] bytes)
        {
            //0,1 type
            //2,3 target
            int str_size = bytes[4];
            Byte[] str = new Byte[str_size];
            System.Buffer.BlockCopy(bytes, 5, str, 0, str_size);
            return Encoding.ASCII.GetString(str);
        }

        /// <summary>
        /// Récupère une position à partire des bytes lu sur le réseau
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
        /// <param name="X">la position en X</param>
        /// <param name="Y">la position en Y</param>
        public void getPosition(Byte[] bytes, out uint X, out uint Y)
        {
            X = BitConverter.ToUInt32(bytes, 4);
            Y = BitConverter.ToUInt32(bytes, 8);
        }

        /// <summary>
        /// Ajoute le type d'action au tableau de bytes
        /// </summary>
        /// <param name="bytes">bytes à envoyer sur le réseau</param>
        /// <param name="id">offset d'écriture</param>
        /// <param name="p">type d'action</param>
        private void setType(ref Byte[] bytes, ref int id, ServerProtocol p)
        {
            addInt16(ref bytes, ref id, (UInt16)p);
        }

        /// <summary>
        /// Ajoute un int16 au tableau de bytes
        /// </summary>
        /// <param name="bytes">bytes à envoyer sur le réseau</param>
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
        /// <param name="bytes">bytes à envoyer sur le réseau</param>
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
        /******************buildings******************/
        /*********************************************/

        //send position
        /*public void Unit_position(Building b, Point p)
        {
            //2+2+4+4
            Byte[] bytes = new Byte[12];//2+2+4+4
            int i = 0;
            setType(ref bytes, ref i, ServerProtocol.UNIT_POSITION);
            addInt16(ref bytes, ref i, (uint)b.Identity);
            addInt32(ref bytes, ref i, p.X);
            addInt32(ref bytes, ref i, p.Y);
            _udp.send(bytes);
        }*/

        /*********************************************/
        /********************Units********************/
        /*********************************************/

        /// <summary>
        /// Génère le code réseau pour envoyer la position d'une unité
        /// </summary>
        /// <param name="id">l'id du joueur</param>
        /// <param name="p">position de l'unité</param>
        /// <returns>bytes à envoyer sur le réseau</returns>
        public Byte[] Unit_position(int id, Point p)
        {
            //2+2+4+4
            Byte[] bytes = new Byte[12];//2+2+4+4
            int i = 0;
            setType(ref bytes, ref i, ServerProtocol.UNIT_POSITION);
            addInt16(ref bytes, ref i, (uint)id);
            addInt32(ref bytes, ref i, (uint)p.X);
            addInt32(ref bytes, ref i, (uint)p.Y);
            return (bytes);
        }

        /// <summary>
        /// Génère le code réseau pour envoyer la list des unites
        /// </summary>
        /// <param name="e">la liste d'unités</param>
        /// <returns>bytes à envoyer sur le réseau</returns>
        public Byte[] Entity_sendlist(List<ConcreteEntity> e)
        {
            Byte[][] entitys = new Byte[e.Count][];

            int i, total = 0;
            for (i=0; i < e.Count; ++i)
            {
                string type = e[i].Name;
                Byte[] btype  = Encoding.ASCII.GetBytes(type);

                entitys[i] = new Byte[11 + btype.Length];
                total += (11 + btype.Length);

                Byte[] uId = BitConverter.GetBytes((UInt16)e[i].IDEntity);
                Byte[] X = BitConverter.GetBytes((UInt32)e[i].Position.X);
                Byte[] Y = BitConverter.GetBytes((UInt32)e[i].Position.Y);
                
                System.Buffer.BlockCopy(uId, 0, entitys[i], 0, uId.Length);
                System.Buffer.BlockCopy(X, 0, entitys[i], 2, X.Length);
                System.Buffer.BlockCopy(Y, 0, entitys[i], 6, Y.Length);
                entitys[i][10] = (byte)btype.Length;
                System.Buffer.BlockCopy(btype, 0, entitys[i], 11, btype.Length);
            }

            Byte[] bytes = new Byte[total+4];
            i = 0;
            total = 4;
            setType(ref bytes, ref i, ServerProtocol.UNIT_GETALL);
            addInt16(ref bytes, ref i, (uint)entitys.Length);
            for (i = 0; i < entitys.Length; ++i)
            {
                System.Buffer.BlockCopy(entitys[i], 0, bytes, total, entitys[i].Length);
                total += entitys[i].Length;
            }
            return (bytes);
        }

        public void Entity_getInfo(Byte[] bytes, out uint uId)
        {
            uId = BitConverter.ToUInt32(bytes, 2);
        }

        /// <summary>
        /// Génère le code réseau pour envoyer la list des unites
        /// </summary>
        /// <param name="info">les infos sur l'entité</param>
        /// <returns>bytes à envoyer sur le réseau</returns>
        public Byte[] Entity_sendinfo(Information info)
        {
            Byte[] bname = Encoding.ASCII.GetBytes(info._entityName);

            int i = 0;
            Byte[] bytes = new Byte[15 + bname.Length];
            setType(ref bytes, ref i, ServerProtocol.UNIT_GETINFO);
            addInt16(ref bytes, ref i, info._idPlayer);
            addInt16(ref bytes, ref i, info._idEntity);
            addInt32(ref bytes, ref i, info._energy);
            addInt16(ref bytes, ref i, info._hitPoints);
            addInt16(ref bytes, ref i, info._hitPointsMax);
            bytes[14] = (byte)bname.Length;
            System.Buffer.BlockCopy(bname, 0, bytes, 15, bname.Length);
            return (bytes);
        }

        /*********************************************/
        /********************Player*******************/
        /*********************************************/

        /// <summary>
        /// Génère le code réseau pour envoyer les ressources d'un player
        /// </summary>
        /// <param name="info">les ressources du player</param>
        /// <returns>bytes à envoyer sur le réseau</returns>
        public Byte[] Player_sendressources(InfoPlayer info)
        {
            int i = 0;
            Byte[] bytes = new Byte[10];
            setType(ref bytes, ref i, ServerProtocol.PLAYER_GETRESS);
            addInt16(ref bytes, ref i, info._mineral);
            addInt16(ref bytes, ref i, info._pop);
            addInt16(ref bytes, ref i, info._popMax);
            addInt16(ref bytes, ref i, info._vespene);
            return (bytes);
        }


        /*********************************************/
        /******************Identify*******************/
        /*********************************************/

        /// <summary>
        /// Convertie bytes lu sur le réseau en pseudo du joueur
        /// </summary>
        /// <param name="bytes">bytes lu sur le réseau</param>
        /// <param name="pseudo">le pseudo demandé par le joueur</param>
        public void Identify_receive(Byte[] bytes, out string pseudo)
        {
            int str_size = bytes[2];
            Byte[] str = new Byte[str_size];
            System.Buffer.BlockCopy(bytes, 2, str, 0, str_size);
            pseudo = Encoding.ASCII.GetString(str);
        }

        /// <summary>
        /// Génère le code réseau pour envoyer la taille de la map
        /// </summary>
		/// <param name="width">largeur de la map</param>
		/// <param name="height">hauteur de la map</param>
        /// <returns>bytes à envoyer sur le réseau</returns>
		public Byte[] Identify_mapSize(int width, int height)
        {
            Byte[] bytes = new Byte[8];
            int i = 0;
			addInt32(ref bytes, ref i, (uint)width);
			addInt32(ref bytes, ref i, (uint)height);
            return (bytes);
        }
    }
}
