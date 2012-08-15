using System;
using Microsoft.Xna.Framework;
using System.IO;
using Server.components.entities;
using System.Collections.Generic;

namespace Server.components
{
	/// <summary>
	/// liste des cartes disponibles
	/// </summary>
	enum Mapfiles
	{
		STEPPES_OF_WAR = 1
	}
	/// <summary>
	/// class map
	/// </summary>
	/// <summary>
	/// La carte
	/// </summary>
	public class Map
	{
		/// <summary>
		/// Tableau de cases représentant la carte
		/// </summary>
		private Square[,] _squareArray;
		/// <summary>
		/// Longueur
		/// </summary>
		private int _xmax;
		/// <summary>
		/// Hauteur
		/// </summary>
		private int _ymax;


		/// <summary>
		/// Constructeur de la map suivant le numéro de la map
		/// </summary>
		/// <param name="xmax"> longueur de la map</param>
		/// <param name="ymax"> largeur de la map</param>
		/// <param name="fichier"> identifinat du fichier</param>
		public Map(uint fichier)
		{
			switch((Mapfiles)fichier){
				case Mapfiles.STEPPES_OF_WAR: 
				default :
					this.mapbuilder(@"..\..\..\Map\Map2.txt");
					break;
			}
		}

		/// <summary>
		/// Retourne la longueur de la map
		/// </summary>
		public int Xmax
		{
			get { return this._xmax; }
		}

		/// <summary>
		///  retourne la largeur de la map
		/// </summary>
		public int Ymax
		{
			get { return this._ymax; }
		}

		/// <summary>
		/// retourne le tableau de square
		/// </summary>
		public Square[,] SquareArray
		{
			get { return this._squareArray; }
		}

		/// <summary>
		/// retourn la square ayant la même position
		/// </summary>
		/// <param name="p"> Position </param>
		/// <returns> une square de position P </returns>
		public Square getSquare(Point p)
		{
			return this._squareArray[p.Y, p.X];
		}

		/// <summary>
		/// recherche une position position pour un joueur
		/// </summary>
		/// <returns> une square posible ou null</returns>
		public Square getStartPoint()
		{
			for (uint i = 0; i < this._ymax; ++i)
			{
				for (uint j = 0; j < this._xmax; ++j)
				{
					if (this._squareArray[i, j].IsStartPoint)
					{
						return this._squareArray[i, j];
					}
				}
			}
			return null;
		}

		/// <summary>
		/// constructeur de la map
		/// </summary>
		/// <param name="path"> chemin vers le fichier</param>
		public void mapbuilder(String path)
		{
			if(File.Exists(path)){
				StreamReader sr = File.OpenText(path);
				int.TryParse(sr.ReadLine(), out this._xmax);
				int.TryParse(sr.ReadLine(), out this._ymax);
				this._squareArray = new Square[this._ymax, this._xmax];
				String line = sr.ReadLine();
				for (int i = 0; i < this._ymax; ++i)
				{
					for (int j = 0; j < this._xmax ; ++j)
					{
						this._squareArray[i, j] = new Square(new Point(j, i));
						List<Square> lst = new List<Square>();
						lst.Add(this._squareArray[i, j]);
						ConcreteEntity ce;
						switch (line[j])
						{
							case '+':
								break;
							case 'C':
								ce = Entities.getInstance().getEntity("mineral", Entities.getInstance().Id);
								ce.addSquare(this._squareArray[i, j]);
								this._squareArray[i, j].Entity = ce;
								// ajout à la liste des ressource de game la concreteEntity
								Game.getInstance().addConcreteResource(ce);
								break;
							case 'G':
								ce = Entities.getInstance().getEntity("vespene", Entities.getInstance().Id);
								ce.addSquare(this._squareArray[i, j]);
								this._squareArray[i, j].Entity = ce;
								Game.getInstance().addConcreteResource(ce);
								break;
							case 'O':
								ce = Entities.getInstance().getEntity("richmineral", Entities.getInstance().Id);
								ce.addSquare(this._squareArray[i, j]);
								this._squareArray[i, j].Entity = ce;
								Game.getInstance().addConcreteResource(ce);
								break;
							case 'P':
								this._squareArray[i, j].IsStartPoint = true;
								break;
							case '#':
							default:
								this._squareArray[i, j].Wall = true;
								break;
						}
					}

					// if fin de fichier break sortie de la boucle.
					line = sr.ReadLine();
					if (line == null)
					{
						break;
					}
				}
			}
		}
	}
}
