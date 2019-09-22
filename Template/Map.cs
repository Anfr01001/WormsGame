using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Template
{
    class Map
    {
        private List<ColisionTiles> colisionTiles = new List<ColisionTiles>();

        public List<ColisionTiles>  ColisionTiles {
            get { return colisionTiles;  }
        }

        private int width, height;

        public int Width {
            get { return width; }
        }

        public int Height {
            get { return height; }
        }

        public Map() { }

        public void Generate(int[,] map, int size)
        {
            //map.getLenght = bitmap kartan map 
            for (int x = 0; x < map.GetLength(1); x++) {
                for (int y = 0; y < map.GetLength(0); y++) {

                    //ändra numret till 1 eller 0 land eller inte
                    int number = map[y, x];

                    if (number > 0) {
                        //skapa blocket
                        colisionTiles.Add(new ColisionTiles(number, new Rectangle(x * size, y * size, size, size)));

                        width = (x + 1) * size;
                        height = (y + 1) * size;

                    }

                }
            }
        }

        public void Generate(int[,] map, int size, bool Clear)
        {
            //Clear används för att helt rita om mapen (när något strängs) (samma som ovan)
            if (Clear) { colisionTiles.Clear(); }
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {

                    int number = map[y, x];

                    if (number > 0)
                    {
                        colisionTiles.Add(new ColisionTiles(number, new Rectangle(x * size, y * size, size, size)));

                        width = (x + 1) * size;
                        height = (y + 1) * size;

                    }

                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            foreach(ColisionTiles tile in colisionTiles)
            {
                tile.Draw(spritebatch);
            }
        }


    }
}
