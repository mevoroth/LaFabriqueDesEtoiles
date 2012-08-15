using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Client.components.mouse
{
	/// <summary>
	/// Gestionnaire de souris
	/// (Appel des fonctions du programme en fonction de l'événement souris)
	/// </summary>
	class MouseHandler
	{
		/// <summary>
		/// L'état de la souris
		/// </summary>
		private MouseState _mouseState;

		/// <summary>
		/// Crée un gestionnaire de souris
		/// </summary>
		/// <param name="mouseState">L'état de la souris</param>
		public MouseHandler(MouseState mouseState)
		{
			// TODO: Complete member initialization
			this._mouseState = mouseState;
		}

		/// <summary>
		/// Traite la souris
		/// </summary>
		public void process()
		{
			if (this._mouseState.LeftButton == ButtonState.Pressed)
			{
				StarcraftGame.getInstance().selectEntity(this._mouseState.X, this._mouseState.Y);
			}
			if (this._mouseState.RightButton == ButtonState.Pressed)
			{
				StarcraftGame.getInstance().doContext(this._mouseState.X, this._mouseState.Y);
			}
		}

		/// <summary>
		/// La vitesse du scroll
		/// </summary>
		public float Speed
		{
			get
			{
				int speedx = 0;
				int speedy = 0;
				if (this._mouseState.X < 50)
				{
					speedx = Math.Abs(this._mouseState.X - 50);
				}
				else if (this._mouseState.X > 590)
				{
					speedx = Math.Abs(this._mouseState.X - 590);
				}

				if (this._mouseState.Y < 50)
				{
					speedy = Math.Abs(this._mouseState.Y - 50);
				}
				else if (this._mouseState.Y > 430)
				{
					speedy = Math.Abs(this._mouseState.Y - 430);
				}

				return (float)Math.Sqrt(Math.Pow(speedx, 2) + Math.Pow(speedy, 2)) < 20 ? (float)Math.Sqrt(Math.Pow(speedx, 2) + Math.Pow(speedy, 2)) : 20;
			}
		}

		/// <summary>
		/// Test de scrolling
		/// </summary>
		public bool IsScroll
		{
			get
			{

				return this._mouseState.X < 50
					|| this._mouseState.X > 590
					|| this._mouseState.Y < 50
					|| this._mouseState.Y > 430;
			}
		}

		/// <summary>
		/// Retourne la direction du scroll
		/// </summary>
		public Direction Direction
		{
			get
			{
				int dx = 0;
				int dy = 0;
				if (this._mouseState.X < 50)
				{
					dx = -1;
				}
				else if (this._mouseState.X > 590)
				{
					dx = 1;
				}

				if (this._mouseState.Y < 50)
				{
					dy = -1;
				}
				else if (this._mouseState.Y > 430)
				{
					dy = 1;
				}
				return new Direction(dx, dy);
			}
		}
	}
}

