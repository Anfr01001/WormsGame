using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Template
{
    class Bombs
    {
        private Vector2 pos;
        private Vector2 velocity;
        private Texture2D pixel;
        private Rectangle rectangle;
        const float GRAVITY = 15f;
        private float speed = 4f;

        int mapArrayX, mapArrayY;


        //Spräng
         Vector2 TopRightCorner, TopLeftCorner, BottomRightCorner, BottomLeftCorner;
        int[,] maparray;

        public Bombs(Vector2 orgpos, Vector2 velocity, Texture2D pixel)
        {
            pos = orgpos;
            this.pixel = pixel;
            this.velocity = velocity;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 5, 5);

        }

        public Vector2 Getpos()
        {
            return pos;
        }

        public void Update(GameTime gameTime)
        {
            //hur ska bomberna åka
            pos += velocity * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity.Y += GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 5, 5);
   
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixel, rectangle, Color.Red);
        }

       
        public int[,] Maparray {
            get { return maparray; }
            set { maparray = value; }
        }

        public bool Collision(Rectangle newrectangle, int xOffset, int yOffset, int[,] maparray)
        {
            this.maparray = maparray;

            if (rectangle.TouchTopOf(newrectangle) || rectangle.TouchLeftOf(newrectangle) || rectangle.TouchRightOf(newrectangle) || rectangle.TouchBottomOf(newrectangle))
            {
                //sprängs 
                for (int y = -3; y != 3; y++)
                {
                     for (int x = -3; x != 3; x++)
                     {
                        mapArrayX = ((int)pos.X / 10) + x;
                        mapArrayY = ((int)pos.Y / 10) + y;
                       
                        //kolla så att vi inte försöker spränga utanför mappen
                        if (mapArrayX < 0) { mapArrayX = 0; }
                        if (mapArrayX > 79) { mapArrayX = 79; }
                        if (mapArrayY > 49) { mapArrayY = 49; }

                        //ändra arrayen
                        maparray[mapArrayY, mapArrayX] = 0;
                     }
                }

                return true;
            }

            

            if (pos.X < 0) { pos.X = 0; }
            if (pos.X > xOffset - rectangle.Width) { pos.X = xOffset - rectangle.Width; }
            if (rectangle.Y < 0) { velocity.Y = 1f; }
            

            return false;
        }


        private void spawnParticles()
        {

        }
    }
}
