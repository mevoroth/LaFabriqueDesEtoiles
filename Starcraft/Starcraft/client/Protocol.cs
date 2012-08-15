using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.client
{
    /// <summary>
    /// Plage sur laquel on utilise la methode DoAction de Unit
    /// </summary>
    public enum DoActionProtocol
    {
        END_SOURCETARGET = 50,
        END_SOURCEPOSITION = 100
    }

    /// <summary>
    /// Identifiant d'action envoyés sur le réseau
    /// </summary>
    public enum Protocol
    {
        UNIT_ATTACK = 0,
        UNIT_COLLECT,

        UNIT_MOVE = DoActionProtocol.END_SOURCETARGET,
        UNIT_MUTATION,
        UNIT_INTERRUPT,
        UNIT_HOLDPOSITION,
        UNIT_PATROL,

        UNIT_POSITION = DoActionProtocol.END_SOURCEPOSITION,

        UNIT_GETPOSITION,
        UNIT_GETALL,
        UNIT_GETINFO,

        BUILDING_CREATE,
        BUILDING_GENERATEQUEEN,
        BUILDING_LARVAE,
        BUILDING_RALLYINGPOINT,
        BUILDING_MUTATION,

        RESSOURCES_GETALL,

        IDENTIFY_SEND,
        IDENTIFY_JOINORCREATE,
        IDENTIFY_HASJOIN,

        PLAYER_GETRESS
    }

    /// <summary>
    /// Différent types d'unités
    /// </summary>
    public enum TypeID
    {
        BUILDING_BASE = 0,
        BUILDING_NEDDLE,


        UNIT_LARVAE,
        UNIT_GATHERER,
        UNIT_DOMINANT,
        UNIT_ZERGLING
    }
}
