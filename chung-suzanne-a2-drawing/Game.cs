// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Reflection.Metadata;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        //Color water = new Color("#88D2F0");
        //Color darksand = new Color("#CE9963");
        Color cloud = new Color(197, 226, 247);
        Color sun = new Color(253, 184, 19);
        Color water = new Color(35, 137, 218);
        float speed = 80;
        float cloudspeed;
        float angle;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Set up window
            Window.SetTitle("Weather Changer");
            Window.SetSize(800, 600);
            // Remove outlines
            Draw.LineColor = Color.Clear;
        
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // Reset background
            Window.ClearBackground(Color.OffWhite);

            //create colour palette for colouring
            
            //Create moving clouds
            Draw.FillColor = cloud;
            cloudspeed += Time.DeltaTime * speed;

            if (cloudspeed > Window.Width)
            {
                cloudspeed = 0;
            }
            for (int i = 0; i < 3; i++)
            {
              
                int x2 = 40 + i * 50;
                Draw.Circle(x2 + cloudspeed, 100, 50);
  
                int x3 = 300 + i * 50;
                Draw.Circle(x3 + cloudspeed, 200, 50);

                int x4 = 500 + i * 50;
                Draw.Circle(x4 + cloudspeed, 150, 50);
             

            }

            //Draw the sun
            Draw.FillColor = sun;
            Draw.Circle(650, 100, 80);

         

            for (int i = 0; i < 12; i++)  // Adjust for desired number of rays

            {

                double angle = (Math.PI * 2 * i) / 12;

                float x1 = (float)(650 + Math.Cos(angle) * 80);

                float y1 = (float)(100 + Math.Sin(angle) * 80);

                float x6 = (float)(650 + Math.Cos(angle) * (80 * 1.5)); // Extend ray length

                float y2 = (float)(100 + Math.Sin(angle) * (80 * 1.5));

                
                DrawSunRays(x1, y1, x6, y2);

            }
            
            void DrawSunRays (float positionx1, float positiony1, float positionx2, float positiony2)
            {
                Draw.LineSize = 5;
                Draw.LineColor = sun;
                Draw.Line(positionx1, positiony1, positionx2, positiony2);
            }

        }
    }

}
