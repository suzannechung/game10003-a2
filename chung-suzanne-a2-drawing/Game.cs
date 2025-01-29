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
            Draw.FillColor = cloud;
            for (int i=0; i <3; i++)
            {
                int x1 = 40 + i * 50;
                Draw.Circle(x1, 100, 50);

                int x2 = 250 + i * 50;
                Draw.Circle(x2, 200, 50);

                int x3 = 500 + i * 50;
                Draw.Circle(x3, 150, 50);
            }
        }
    }

}
