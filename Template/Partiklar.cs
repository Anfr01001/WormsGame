using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Template
{
    class Partiklar : BasBlock
    {

        const float GRAVITY = 20f;
        private float speed = 5f;
        float liveTime = 0;

        public bool Dead {
            get;
            private set;
        }
        static Random r = new Random();

        double TimeToBeAlive = r.Next(0,4);

        public Partiklar(Vector2 orgpos, Texture2D pixel)
        {
            velocity = new Vector2(r.Next(-50,50), r.Next(-50, 50));
            pos = orgpos;
            this.pixel = pixel;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 5, 5);
        }

        public void Update(GameTime gameTime)
        {
            //hur ska bomberna åka
            pos += velocity * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity.Y += GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 5, 5);

            Dead =  liveTime >= (TimeToBeAlive *60);

            liveTime++;
        }

        public void Collision(Rectangle newrectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newrectangle) || rectangle.TouchBottomOf(newrectangle))
            {
                velocity.Y *= -0.8f;
            }

            if (rectangle.TouchLeftOf(newrectangle) || rectangle.TouchRightOf(newrectangle))
            {
                velocity.X *= -0.8f;
            }
        


            if (pos.X < 0) { pos.X = 0; }
            if (pos.X > xOffset - rectangle.Width) { pos.X = xOffset - rectangle.Width; }
            if (rectangle.Y < 0) { velocity.Y = 1f; }
            if (pos.Y > yOffset - rectangle.Height) { pos.Y = yOffset - rectangle.Height; }

        }

    }
}
