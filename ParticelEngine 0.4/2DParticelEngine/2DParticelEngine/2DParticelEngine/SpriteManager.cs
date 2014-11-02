using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DParticelEngine
{
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Variables
        private Texture2D blue;
        private Texture2D green;
        private Texture2D red;
        private Texture2D yellow;
        private Texture2D yellow2;
        private Texture2D mixed;
        private Texture2D red1;

        private int screenWidth, screenHeight;

        Random rand;

        private float blueAngle = 0;
        private float greenAngle = 0;
        private float redAngle = 0;
        private float yellowAngle = 0;
        private float yellowAngle2 = 0;
        private float shake;

        private float blueSpeed = 0.025f;
        private float greenSpeed = 0.017f;
        private float redSpeed = 0.022f;
        private float yellowSpeed = 0.021f;

        private float distance = 0;

        #endregion

        #region Constructor
        public SpriteManager(Game game, int screenWidth, int screenHeight)
            : base(game)
        {
            rand = new Random();
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            distance = screenWidth / 10;
        }
        #endregion

        #region Init and Load
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {

            red = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/red");
            green = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/green");
            blue = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/blue");
            yellow = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/yellow");
            yellow2 = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/yellow2");
            mixed = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/bunt1");
            red1 = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/red1");
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            blueAngle += blueSpeed;
            greenAngle += greenSpeed;
            redAngle += redSpeed;
            yellowAngle += yellowSpeed;
            yellowAngle2 -= yellowSpeed;
            shake += 0.11f;

            base.Update(gameTime);
        }

        #endregion

        #region Draw
        public void Draw(SpriteBatch sp)
        {
            DrawSpriteChain01(sp);
            DrawSpriteChain02(sp);
            DrawSpriteChain03(sp);
        }

        public void DrawSpriteChain01(SpriteBatch spriteBatch)
        {

            Vector2 redPosition = new Vector2((float)Math.Cos(redAngle) * distance, 5);
            Vector2 greenPosition = new Vector2((float)Math.Sin(0) * distance, 5);
            Vector2 bluePosition = new Vector2((float)Math.Cos(blueAngle) * distance, (float)Math.Sin(blueAngle) * distance);
            Vector2 center = new Vector2((screenWidth / 2) - (green.Width / 2), (screenHeight / 2) - (green.Height / 2));

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            spriteBatch.Draw(blue, center + bluePosition, Color.White);
            spriteBatch.Draw(blue, center - bluePosition, Color.White);
            spriteBatch.Draw(red, center + redPosition, Color.White);
            spriteBatch.Draw(red, center - redPosition, Color.White);
            spriteBatch.Draw(green, center - greenPosition, Color.White);
            spriteBatch.End();
        }

        public void DrawSpriteChain02(SpriteBatch spriteBatch)
        {
            int multiA = screenWidth / 5;
            int multiB = screenWidth / 8;
            Vector2 yellowPosition = new Vector2(((float)Math.Cos(yellowAngle) * multiA) + ((float)Math.Cos(shake) * -3),
                ((float)Math.Sin(greenAngle) * multiB) + (float)Math.Sin(shake) * -10);
            Vector2 yellowPosition2 = new Vector2(((float)Math.Cos(yellowAngle) * multiA) + ((float)Math.Cos(shake) * 9),
                ((float)Math.Sin(greenAngle) * multiB) + (float)Math.Sin(shake) * 15);

            Vector2 yellowPosition3 = new Vector2((-(float)Math.Cos(yellowAngle2) * multiA) + ((float)Math.Cos(shake) * -3),
                    ((float)Math.Sin(greenAngle) * multiB) + (float)Math.Sin(shake) * -10);
            Vector2 yellowPosition4 = new Vector2(-((float)Math.Cos(yellowAngle2) * multiA) + ((float)Math.Cos(shake) * 9),
                ((float)Math.Sin(greenAngle) * multiB) + (float)Math.Sin(shake) * 15);

            Vector2 center = new Vector2((screenWidth / 2) - (green.Width / 2), (screenHeight / 2) - (green.Height / 2));
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            for (int i = 0; i < 2; i++)
            {
                spriteBatch.Draw(red, center - yellowPosition, Color.White);
                spriteBatch.Draw(yellow, center - yellowPosition, Color.White);
                spriteBatch.Draw(red, center - yellowPosition2, Color.White);
                spriteBatch.Draw(yellow, center - yellowPosition2, Color.White);

                spriteBatch.Draw(red, center + yellowPosition, Color.White);
                spriteBatch.Draw(yellow, center + yellowPosition, Color.White);
                spriteBatch.Draw(red, center + yellowPosition2, Color.White);
                spriteBatch.Draw(yellow, center + yellowPosition2, Color.White);
            }
            spriteBatch.End();
        }

        public void DrawSpriteChain03(SpriteBatch spriteBatch)
        {
            int multiA = screenWidth / 5;
            int multiB = screenWidth / 8;
            Vector2 greenPosition1 = new Vector2(((float)Math.Cos(greenAngle) * multiA)
                + ((float)Math.Cos(shake) * 7), ((float)Math.Sin(greenAngle) * multiB)
                + (float)Math.Sin(shake) * 10);
            Vector2 greenPosition2 = new Vector2(((float)Math.Cos(greenAngle) * multiA)
                + ((float)Math.Cos(shake) * 7), ((float)Math.Sin(greenAngle) * multiB)
                + (float)Math.Sin(shake) * 10);
            Vector2 greenPosition4 = new Vector2(((float)Math.Cos(greenAngle) * multiA)
                + ((float)Math.Cos(shake) * -1), ((float)Math.Sin(greenAngle) * multiB)
                + (float)Math.Sin(shake) * -1);
            Vector2 greenPosition3 = new Vector2(((float)Math.Cos(greenAngle) * multiA)
                + ((float)Math.Cos(shake) * -3), ((float)Math.Sin(greenAngle) * multiB)
                + (float)Math.Sin(shake) * -10);
            Vector2 center = new Vector2((screenWidth / 2) - (green.Width / 2), (screenHeight / 2) - (green.Height / 2));

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            for (int i = 0; i < 3; i++)
            {
                spriteBatch.Draw(red, center - greenPosition2 / 2 * 3.7f, Color.White);
                spriteBatch.Draw(blue, center - greenPosition3 / 2 * 3.7f, Color.White);
                spriteBatch.Draw(yellow, center - greenPosition2 / 2 * 3.7f, Color.White);

                spriteBatch.Draw(red, center + greenPosition2 / 2 * 3.7f, Color.White);
                spriteBatch.Draw(blue, center + greenPosition3 / 2 * 3.7f, Color.White);
                spriteBatch.Draw(yellow, center + greenPosition2 / 2 * 3.7f, Color.White);

            }
            for (int i = 0; i < 1; i++)
            {
                spriteBatch.Draw(red, center + greenPosition2, Color.White);
                spriteBatch.Draw(blue, center + greenPosition3, Color.White);
                spriteBatch.Draw(yellow, center + greenPosition2, Color.White);

                spriteBatch.Draw(red, center - greenPosition2, Color.White);
                spriteBatch.Draw(blue, center - greenPosition3, Color.White);
                spriteBatch.Draw(yellow, center - greenPosition2, Color.White);
            }
            spriteBatch.End();
        }
        #endregion
    }
}
