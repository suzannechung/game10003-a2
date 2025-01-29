// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Color lightbrown = new Color(197,163,121);
        Color brown = new Color(154, 102, 64);
        Color beige = new Color(240, 207, 167);
        Color stone = new Color(229, 223, 207);
        Color snow = new Color(244, 243, 237);

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Set up window
            Window.SetTitle("Colouring Book: Bunny");
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
            //Window.ClearBackground(Color.OffWhite);

            //create colour palette for colouring
            Draw.FillColor = lightbrown;
            Draw.Rectangle(10, 10, 50, 50);

            Draw.FillColor = brown;
            Draw.Rectangle(70, 10, 50, 50);
            
            Draw.FillColor = beige;
            Draw.Rectangle(130, 10, 50, 50);

            Draw.FillColor = stone;
            Draw.Rectangle(190, 10, 50, 50);

            Draw.FillColor = snow;
            Draw.Rectangle(250, 10, 50, 50);
        }
    }

}
