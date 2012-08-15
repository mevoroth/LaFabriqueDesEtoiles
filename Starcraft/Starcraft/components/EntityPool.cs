using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Client.components.graphics;

namespace Client.components
{
	/// <summary>
	/// Pool d'entit�
	/// </summary>
	public class EntityPool
	{
		/// <summary>
		/// La liste des entit�s
		/// </summary>
		private List<Drawable> _entities;

		/// <summary>
		/// Cr�e le pool d'entit�
		/// </summary>
		public EntityPool()
		{
			this._entities = new List<Drawable>();
		}

		/// <summary>
		/// Ajoute une entit�
		/// </summary>
		/// <param name="entity">L'entit�</param>
		/// <param name="position">Sa position</param>
		/// <param name="id">Son identification</param>
		public void setSprite(Texture2D entity, Vector2 position, Point p, uint id, String name)
		{
			this._entities.Add(new Drawable(name, entity, position, p, id));
		}

		/// <summary>
		/// R�cup�re la liste des entit�s
		/// </summary>
		/// <returns></returns>
		public List<Drawable> getEntities()
		{
			return (this._entities);
		}

		/// <summary>
		/// D�charge l'entit�
		/// </summary>
		/// <param name="entity"></param>
		public void unloadEntity(Sprite entity)
		{
			Drawable deletable = find(entity);
			_entities.Remove(deletable);
		}

		/// <summary>
		/// Transforme une entit�
		/// </summary>
		/// <param name="entity"></param>
		public void transformEntity(Drawable entity)
		{
			Drawable transformable = find(entity);
			_entities.Remove(transformable);
			_entities.Add(entity);
		}

		/// <summary>
		/// Trouve un dessinable � partir d'un sprite
		/// </summary>
		/// <param name="searched">Le sprite</param>
		/// <returns>Un objet dessinable</returns>
		private Drawable find(Sprite searched)
		{
			foreach (Drawable entity in this._entities)
			{
				if (entity.getId() == searched.getId())
				{
					return entity;
				}
			}
			return(null);
		}

		/// <summary>
		/// Trouve un objet dessinable
		/// </summary>
		/// <param name="searched">L'objet � rechercher</param>
		/// <returns>L'objet dessinable</returns>
		private Drawable find(Drawable searched)
		{
			foreach (Drawable entity in this._entities)
			{
				if (entity.getId() == searched.getId())
				{
					return entity;
				}
			}
			return (null);
		}
	}
}