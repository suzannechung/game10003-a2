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

        //Background variables
        Color night = new Color(22,21,78);
        Color sun = new Color(253,221,246);
        Color cloud = new Color(139,85,186);
        Color stars = new Color(255,231,119, 200);
        Color cross = new Color(110,69,16);
        Color hill = new Color(48, 59, 118);
        Color hill2 = new Color(62, 81,141);
        float speed = 80;
        float cloudspeed;
        float fogspeed;
        Color fog = new Color(219,219,226,30);
        Color fog2 = new Color(219, 219, 226, 60);
        Color fog3 = new Color(219, 219, 226, 80);

        //Ghost Colors
        Color eyes = new Color(0,0,0);
        Color ghostbody = new Color(201,205,221);

        //Star variables
        int starCount = 60;
        int[] starPositionsX;
        int[] starPositionsY;
        
        //Cross variables
        int crossCount = 1;
        int[] cross1X;
        int[] cross1Y;
        int[] cross2X;
        int[] cross2Y;
        int[] cross3X;
        int[] cross3Y;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Set up window
            Window.SetTitle("Boo!");
            Window.SetSize(800, 600);
            // Remove outlines
            Draw.LineColor = Color.Clear;

            //Set up stars
            starPositionsX = new int[starCount];
            starPositionsY = new int[starCount];

            // Next, go through array and assign each index a value
            //randomize location of starts each time drawing is launched
            for (int i = 0; i < starCount; i++)
            {
                starPositionsX[i] = Random.Integer(0, 800); // the entire x axis of the window size
                starPositionsY[i] = Random.Integer(0, 250); // sky limits based on where the ground is
            }

            //Set up cross
            cross1X = new int[crossCount];
            cross1Y = new int[crossCount];
            cross2X = new int[crossCount];
            cross2Y = new int[crossCount];
            cross3X = new int[crossCount];
            cross3Y = new int[crossCount];
            
            // Next, go through array and assign each index a value
            //randomize location of the crosses each time drawing is launched
            for (int i = 0; i < crossCount; i++)
            {
                cross1X[i] = Random.Integer(90, 200);
                cross1Y[i] = Random.Integer(200, 300);
                cross2X[i] = Random.Integer(300, 400);
                cross2Y[i] = Random.Integer(190, 250);
                cross3X[i] = Random.Integer(600, 700);
                cross3Y[i] = Random.Integer(200, 300);
            }

        }

        
        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // Reset background
            Window.ClearBackground(night);

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
                int x2 = 40 + i * 80;
                Draw.Circle(x2 + cloudspeed, 100, 60);
  
                int x3 = 280 + i * 70;
                Draw.Circle(x3 + cloudspeed, 200, 50);

                int x4 = 500 + i * 80;
                Draw.Circle(x4 + cloudspeed, 110, 55);
            }

            //when user holds down space bar, stars will light up the sky
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            { 
                //draw stars
                Draw.FillColor = stars;
                for (int i = 0; i < starCount; i++)
                {
                    Draw.Circle(starPositionsX[i], starPositionsY[i], 3);
                }
            }

        //Draw the moon
        Draw.FillColor = sun;
            Draw.Circle(110, 80, 125);

            //Draw hill
            Draw.FillColor = hill;
            Draw.Ellipse(700, Window.Height+90, 1700, 700);

            //Draw second hill
            Draw.FillColor = hill2;
            Draw.Ellipse(50, Window.Height + 120, 1700, 700);

            //draw crosses
            Draw.FillColor = cross;
            for (int i = 0; i < crossCount; i++)
            {
                Draw.Rectangle(cross1X[i], cross1Y[i], 20, 200);
                Draw.Rectangle(cross1X[i]-60, cross1Y[i]+40, 140, 20);

                Draw.Rectangle(cross2X[i], cross2Y[i], 20, 200);
                Draw.Rectangle(cross2X[i] - 60, cross2Y[i] + 40, 140, 20);

                Draw.Rectangle(cross3X[i], cross3Y[i], 20, 200);
                Draw.Rectangle(cross3X[i] - 60, cross3Y[i] + 40, 140, 20);
            }

            //when user presses left mouse button, ghost will appear!
            if (Input.IsMouseButtonDown(0))
            {
                DrawGhost(300, 200, ghostbody, eyes);
                DrawGhost(600, 400, ghostbody, eyes);
                DrawGhost(150, 500, ghostbody, eyes);
            }

            //All fog layers will have movement
            //First fog layer
            Draw.FillColor = fog;
            fogspeed += Time.DeltaTime * speed/5;

            if (fogspeed+750 > Window.Width)
            {
                fogspeed = 0;
            }
            for (int i = 0; i < 16; i++)
            {
                int x = 12 + i * 145;
                Draw.Ellipse(x+fogspeed, Window.Height - 125, 150, 120);
                Draw.Ellipse(x + fogspeed, Window.Height - 175, 150, 120);
            }

            //second fog layer
            Draw.FillColor = fog2;
            for (int i = 0; i < 16; i++)
            {
                int x = 12 + i * 130;
                Draw.Ellipse(x + fogspeed, Window.Height - 75, 130, 120);
            }

            //third fog layer
            Draw.FillColor = fog3;
            for (int i = 0; i < 16; i++)
            {
                int x = 12 + i * 125;
                Draw.Ellipse(x + fogspeed, Window.Height - 10, 130, 150);
            }
        }

        //FUNCTION: To draw ghosts
        public void DrawGhost(float x, float y, Color ghostColor, Color faceColour)
        {
            // No shape outline
            Draw.LineColor = Color.Clear;


                //ghost body
                Draw.FillColor = ghostbody;
                Draw.Capsule(x , y, x, y+60, 50);

                //ghostarms
                Draw.FillColor = ghostbody;
                Draw.Capsule(x, y+40, x+60, y+10, 30);

                Draw.FillColor = ghostbody;
                Draw.Capsule(x, y+40 , x-60, y+10, 30);

                //draw eyes and mouth
                Draw.FillColor = faceColour;
                Draw.Circle(x-20, y-20, 8);
                Draw.Circle(x + 20, y - 20 , 8);
                Draw.Circle(x , y +5, 8);


        }

    }

}
