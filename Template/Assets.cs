using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template {
    static class Assets {

        public static Texture2D Pixel;
        public static SpriteFont UIFont;
        public static Texture2D PlayerTexture;
        public static Texture2D PlayerTextureRight;

        public static void CreatePixel(GraphicsDevice device) {

            Pixel = new Texture2D(device, 1, 1);    
            Pixel.SetData(new Color[] { Color.White });

        }

        public static void LoadContent(ContentManager content) {
            UIFont = content.Load<SpriteFont>("UIFont");
            PlayerTexture = content.Load<Texture2D>("Worm");
            PlayerTextureRight = content.Load<Texture2D>("WormRight"); 
        }


    }
}
