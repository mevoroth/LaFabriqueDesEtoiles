using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
	public class KeyboardHandler
	{
		private Microsoft.Xna.Framework.Input.KeyboardState keyboardState;

		public KeyboardHandler(Microsoft.Xna.Framework.Input.KeyboardState keyboardState)
		{
			// TODO: Complete member initialization
			this.keyboardState = keyboardState;
		}

		public void process()
		{
			if (this.keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
			{
				StarcraftGame.getInstance().Exit();
			}
		}
	}
}
