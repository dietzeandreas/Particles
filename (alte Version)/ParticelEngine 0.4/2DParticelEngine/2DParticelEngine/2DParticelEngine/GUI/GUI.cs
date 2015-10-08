using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DParticelEngine
{
    public class GUI : Microsoft.Xna.Framework.DrawableGameComponent
    {
        // Yellow Buttons
        public Texture2D YelArrowLeftTex, YelArrowRightTex;
        Rectangle YelArrowLeftRec, YelArrowRightRec;

        // Green Buttons
        public Texture2D GreArrowLeftTex, GreArrowRightTex;
        Rectangle GreArrowLeftRec, GreArrowRightRec;

        // Blue Buttons
        public Texture2D BluArrowLeftTex, BluArrowRightTex;
        Rectangle BluArrowLeftRec, BluArrowRightRec;

        // Framecount
        public SpriteFont guiDebug, menueFont;

        // Mouse input
        MouseState mouseState, lastMouseState;

        // Framcounter
        FrameCounter fc;

        public GUI(Game game)
            : base(game)
        {
            lastMouseState = Mouse.GetState();
        }

        public override void Initialize()
        {
            //Arrows
            BluArrowLeftRec = new Rectangle(25, 400, 75, 75);
            BluArrowRightRec = new Rectangle(100, 396, 75, 78);
            YelArrowLeftRec = new Rectangle(25, 500, 75, 75);
            YelArrowRightRec = new Rectangle(100, 500, 75, 78);
            GreArrowLeftRec = new Rectangle(25, 600, 75, 75);
            GreArrowRightRec = new Rectangle(100, 596, 75, 78);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Font
            guiDebug = Game.Content.Load<SpriteFont>("guiDebug");
            menueFont = Game.Content.Load<SpriteFont>("menueFont");

            // Framecounter
            fc = new FrameCounter(guiDebug);

            //Arrows
            BluArrowLeftTex = Game.Content.Load<Texture2D>(@"Tex/Gui/blauLinks");
            BluArrowRightTex = Game.Content.Load<Texture2D>(@"Tex/Gui/blauRechts");
            YelArrowLeftTex = Game.Content.Load<Texture2D>(@"Tex/Gui/gelbLinks");
            YelArrowRightTex = Game.Content.Load<Texture2D>(@"Tex/Gui/gelbRechts");
            GreArrowLeftTex = Game.Content.Load<Texture2D>(@"Tex/Gui/gruenLinks");
            GreArrowRightTex = Game.Content.Load<Texture2D>(@"Tex/Gui/gruenRechts");

            base.LoadContent();
        }

        // Update GUI
        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            
            // Gui-Button-Intersection
            // Blue
            if ((mouseState.X > 25 && mouseState.X < 90) && (mouseState.Y > 420 && mouseState.Y < 450))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    // Particle per frame --
                    Game1.instance.particleEngine.ParticlesPerSecondDown();
                }
                lastMouseState = Mouse.GetState();
            }
            if ((mouseState.X > 120 && mouseState.X < 185) && (mouseState.Y > 420 && mouseState.Y < 450))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    // Particles per frame ++
                    Game1.instance.particleEngine.ParticlesPerSecondUp();
                }
                lastMouseState = Mouse.GetState();
            }
            // Yellow
            if ((mouseState.X > 25 && mouseState.X < 90) && (mouseState.Y > 520 && mouseState.Y < 550))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    // Last Texture
                    Game1.instance.particleEngine.TextureDown();
                }
                lastMouseState = Mouse.GetState();
            }
            if ((mouseState.X > 120 && mouseState.X < 185) && (mouseState.Y > 520 && mouseState.Y < 550))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    // Next Texture
                    Game1.instance.particleEngine.TextureUp();
                }
                lastMouseState = Mouse.GetState();
            }
            // Red
            if ((mouseState.X > 25 && mouseState.X < 90) && (mouseState.Y > 620 && mouseState.Y < 650))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    // Last particleManager state
                    Game1.instance.particleEngine.ParticleManagerDown();
                }
                lastMouseState = Mouse.GetState();
            }

            if ((mouseState.X > 120 && mouseState.X < 185) && (mouseState.Y > 620 && mouseState.Y < 650))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    // Next particleManager state
                    Game1.instance.particleEngine.ParticleManagerUp();
                }
                lastMouseState = Mouse.GetState();
            }
            
            // Update framecounter
            fc.Update(gameTime);

            base.Update(gameTime);
        }

        // Draw gui buttons
        internal void drawGUI(SpriteBatch sp)
        {
            sp.Begin();
            sp.Draw(BluArrowLeftTex, BluArrowLeftRec, Color.White);
            sp.Draw(BluArrowRightTex, BluArrowRightRec, Color.White);
            sp.DrawString(menueFont, "Particles Per Frame", new Vector2(25, 380), Color.Aqua);
            sp.Draw(YelArrowLeftTex, YelArrowLeftRec, Color.White);
            sp.Draw(YelArrowRightTex, YelArrowRightRec, Color.White);
            sp.DrawString(menueFont, "Particle Texture", new Vector2(25, 480), Color.Yellow);
            sp.Draw(GreArrowLeftTex, GreArrowLeftRec, Color.White);
            sp.Draw(GreArrowRightTex, GreArrowRightRec, Color.White);
            sp.DrawString(menueFont, "Particla System State", new Vector2(25, 580), Color.YellowGreen);
            sp.End();
        }

        // Draw debug info strings
        public void DrawDebugMonitor(GameTime gt, SpriteBatch sp)
        {
            sp.Begin();
            sp.DrawString(guiDebug, "Mouse: " + "X " + mouseState.X.ToString() + " Y " + mouseState.Y.ToString(), new Vector2(0, 0), Color.White);
            sp.DrawString(guiDebug, "ParticleState: " + Game1.instance.particleEngine.particleManager.ToString(), new Vector2(0, 20), Color.White);
            sp.DrawString(guiDebug, "ParticleCount: " + Game1.instance.particleEngine.particles.Count.ToString(), new Vector2(0, 40), Color.White);
            sp.DrawString(guiDebug, "ParticlesPerFrame: " + Game1.instance.particleEngine.particlesPerFrame.ToString(), new Vector2(0, 60), Color.White);

            // Draw frame counter
            fc.Draw(sp);

            if(Game1.instance.particleEngine.particles.Count != 0)
                sp.DrawString(guiDebug, "LT: " + Game1.instance.particleEngine.particles[0].LT.ToString(), new Vector2(0, 100), Color.White);
            sp.End();
        }

        // Draw controls
        public void DrawControls(SpriteBatch sp)
        {
            sp.Begin();
            sp.DrawString(guiDebug, "F1 : Background", new Vector2((Game1.instance.screenWidth / 2) - 100, 0), Color.White);
            sp.DrawString(guiDebug, "F2 : Menue", new Vector2((Game1.instance.screenWidth / 2) - 100, 20), Color.White);
            sp.DrawString(guiDebug, "F3 : Debug info", new Vector2((Game1.instance.screenWidth / 2) - 100, 40), Color.White);
            sp.DrawString(guiDebug, "F4 : Controls", new Vector2((Game1.instance.screenWidth / 2) - 100, 60), Color.White);
            sp.DrawString(guiDebug, "F5 : Window/FS", new Vector2((Game1.instance.screenWidth / 2) - 100, 80), Color.White);
            sp.End();
        }
    }
}
