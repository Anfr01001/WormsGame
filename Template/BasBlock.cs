using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template {
    class BasBlock {

        protected Vector2 pos = new Vector2();
        protected Vector2 velocity;
        protected Texture2D pixel = Assets.Pixel;
        protected Rectangle rectangle;
        protected Color color = Color.White;
        protected bool dead = false;
        public Color Color {
           get { return color; }
           set { color = value; }
        }

        public bool Dead {
            get { return dead; }
            set { dead = value; }
        }

        public Vector2 Pos {
            get { return pos; }
            set { pos = value; }
        }

        public virtual void Update() {
        }


        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Pixel, rectangle, color);
        }
    }
}
