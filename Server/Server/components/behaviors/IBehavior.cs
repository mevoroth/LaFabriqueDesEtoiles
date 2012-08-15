using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.components.entities;

namespace Server.components.behaviors
{
    /// <summary>
    /// Une action
    /// </summary>
	public interface IBehavior
	{
        /// <summary>
        /// Exécute l'action
        /// </summary>
		void doAction();

        /// <summary>
        /// Affecte la source
        /// </summary>
        /// <param name="e">Entité source</param>
		void setSourceEntity(ConcreteEntity e);

        /// <summary>
        /// Affecte la cible
        /// </summary>
        /// <param name="o">La cible</param>
		void setTarget(ITarget o);

		/// <summary>
		/// Arrête l'action
		/// </summary>
		void prematureStop();

        /// <summary>
        /// indique sui l'action est terminé
        /// </summary>
        /// <returns></returns>
        bool Stop();
	}
}
