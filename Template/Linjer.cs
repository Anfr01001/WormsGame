using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    static class Linjer
    {
        static float Linjedistance;
        static float K, M;


        static public bool DrawLine(Vector2 V1, Vector2 V2, List<Rectangle> LinjeLista)
        {
            Linjedistance = Vector2.Distance(V1, V2);
            
            LinjeLista.Clear();

            V2.X += 10;
            V2.Y += 20;
            K = (V1.Y - V2.Y) / (V1.X - V2.X);
            M = V1.Y - K * V1.X;

            if (V1.X < V2.X)
            {
                for (int x = (int)V1.X; x < V2.X; x++)
                {
                    LinjeLista.Add(new Rectangle(x, (int)(K * x + M), 5, 5));
                }
            }
            else
            {
                for (int x = (int)V2.X; x < V1.X; x++)
                {
                    LinjeLista.Add(new Rectangle(x, (int)(K * x + M), 5, 5));
                }
            }

            return Linjedistance < 70; 
        }
    }
}
