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
        int hp = 100;
        int damage = 20;

        static Random r = new Random();

        const float GRAVITY = 9.82f;

        private bool hasJumped = false;

        SpriteFont uiFont;



        public Rectangle Rectangle {
            get { return rectangle;  }
        }
        public Player(int team) {
            //pos = new Vector2(r.Next(10, 300), 50);

            if (team == 1) {
                color = Color.Yellow;
                pos = new Vector2(r.Next(20, 380), 50);
                texture = Assets.PlayerTextureRight;
            } else if (team == 2) {
                color = Color.Purple;
                pos = new Vector2(r.Next(380, 780), 50);
                texture = Assets.PlayerTexture;
            }

            uiFont = Assets.UIFont;
        }



        public void TakeExplotionDamage (float Distance) {
            hp -= (int)(damage - (Distance/10));
        }

        private void DrawAmmo(SpriteBatch spriteBatch) {

            Vector2 position = pos;
            position.Y -= 25;
            string text = hp.ToString();

            spriteBatch.DrawString(uiFont, text, position, Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
            DrawAmmo(spriteBatch);
        }

        public void Update(GameTime gameTime, bool active)
        {
            pos += velocity;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 35, 40);

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

            if (hp <= 0) {
                dead = true;
            }

        }

        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                texture = Assets.PlayerTextureRight;
            } else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalSeconds * speed;
                texture = Assets.PlayerTexture;
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
