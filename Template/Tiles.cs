using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Template
{
    class Tiles
    {
  
        private Rectangle rectangle;

        public Rectangle Rectangle {
            get { return rectangle; }

            protected set { rectangle = value; }
        }



        private static Texture2D Pixel;

        public static Texture2D Texture {
            protected get { return Pixel; }
            set { Pixel = value; }
        }


        public void Draw (SpriteBatch spriteBatch){
            spriteBatch.Draw(Pixel, rectangle, Color.White);
        }
    }

    class ColisionTiles : Tiles { 
        public ColisionTiles(int i, Rectangle newRectangle)
        {
            this.Rectangle = newRectangle;
        }

    }
}
