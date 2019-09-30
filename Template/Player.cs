using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    class Player : BasBlock
    {

        private float JumpForce = 5f;
        private float speed = 40;

        static Random r = new Random();

        const float GRAVITY = 9.82f;

        private bool hasJumped = false;


        public Rectangle Rectangle {
            get { return rectangle;  }
        }
        public Player() {
            pos = new Vector2(r.Next(10, 300), 50);

            color = Color.Yellow;
        }

        private static Texture2D Pixel;

        public static Texture2D Texture {
            protected get { return Pixel; }
            set { Pixel = value; }
        }

        public void Update(GameTime gameTime, bool active)
        {
            pos += velocity;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 20, 40);

            //gravitation
            if (velocity.Y < 10) {
                velocity.Y += 0.4f;
            }
            
            if (active)
            {
                Input(gameTime);
            } else
            {
                velocity.X = 0f;
            }

        }

        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
            } else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalSeconds * speed;
            } else
            {
                velocity.X = 0f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                pos.Y -= 5f;
                velocity.Y = -JumpForce;
                hasJumped = true;
            }

        }

        public void Collision(Rectangle newrectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newrectangle))
            {
                rectangle.Y = newrectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (rectangle.TouchLeftOf(newrectangle))
            {
                pos.X = newrectangle.X - rectangle.Width - 1;
            }


            if (rectangle.TouchRightOf(newrectangle))
            {
                pos.X = newrectangle.X + newrectangle.Width + 1;
            }


            if (rectangle.TouchBottomOf(newrectangle))
            {
                velocity.Y = 1f;
            }

            if (pos.X < 0) { pos.X = 0; }
            if (pos.X > xOffset - rectangle.Width) { pos.X = xOffset - rectangle.Width; }
            if (rectangle.Y < 0 ) { velocity.Y = 1f; }
            if (pos.Y > yOffset - rectangle.Height) { pos.Y = yOffset - rectangle.Height; }
  
        }



    }
}
