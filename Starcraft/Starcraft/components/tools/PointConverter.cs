using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.components
{
	public static class PointConverter
	{
		private static int _realHeight;
		private static int _realWidth;
		private static int _serverHeight;
		private static int _serverWidth;
		//const int xMult = 35;
		//const int yMult = 35;
		public static Point ToClientPoint(Point cpoint)
		{
			return new Point(
				cpoint.X * PointConverter._realWidth / PointConverter._serverWidth,
				cpoint.Y * PointConverter._realHeight / PointConverter._serverHeight
			);
		}

		public static Point ToServerPoint(Point cpoint)
		{
			return new Point(
				cpoint.X * PointConverter._serverWidth / PointConverter._realWidth,
				cpoint.Y * PointConverter._serverHeight / PointConverter._realHeight
			);
		}

		public static int Height
		{
			set { PointConverter._realHeight = value; }
		}

		public static int Width
		{
			set { PointConverter._realWidth = value; }
		}

		public static int ServerHeight
		{
			set { PointConverter._serverHeight = value; }
		}

		public static int ServerWidth
		{
			set { PointConverter._serverWidth = value; }
		}
	}
}
