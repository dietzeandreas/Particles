using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2DParticelEngine
{
    // Tutorial : http://rbwhitaker.wikidot.com/2d-particle-engine-1
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // XNA Objects
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Keyboard input
        KeyboardState kb, lastKb;

        // The particle system
        public ParticleEngine particleEngine;

        // GUI, debug info and controls
        public GUI gui;

        // Spritemanager (on/off with F1)
        public SpriteManager spriteManager;

        // Total screen resolution
        public int screenWidth, screenHeight;

        // Press F1 to swtich on/off
        bool drawBackground = true;

        // Press F2 to swtich on/off
        bool drawGUI = true;

        // Press F3 to switch on/off
        bool drawDebugInfo = true;

        // Press F4 to switch on/off
        bool drawControls = true;

        // Global access to Game1 class
        public static Game1 instance;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            lastKb = Keyboard.GetState();

            // Set game1 instance
            instance = this;

            // Set screen width and height
            screenWidth = 1280;
            screenHeight = 720;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            // Set mouse visible
            this.IsMouseVisible = true;

            // Max 60 update calls per second
            this.IsFixedTimeStep = true;
        }

        protected override void Initialize()
        {
            // Create GUI
            gui = new GUI(this);

            // and add it to game components
            this.Components.Add(gui);

            // Create SpriteManager
            spriteManager = new SpriteManager(this,             // Game1 instance
                                              screenWidth,      // Total screen width
                                              screenHeight);    // Total screen height
            // and add it to game components
            this.Components.Add(spriteManager);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create texture list
            List<Texture2D> textures = new List<Texture2D>();

            // Add all assets to the list
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Shapes/smallParticle"));  // 2x2 Pixel
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Shapes/circle"));
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Shapes/star"));
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Shapes/diamond"));
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/red"));
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/green"));
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/blue"));
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/yellow"));
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/bunt1"));
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/red1"));
            textures.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/yellow2"));

            // Create new ParticleEngine Object                                     
            particleEngine = new ParticleEngine(textures,                           // All textures
                                                new Vector2(screenWidth / 2,        // X-Coordinate; Center position
                                                            screenHeight / 2));     // Y-Coordiante; Center position
        }

        protected override void UnloadContent()
        {

        }

        // Update whole game
        protected override void Update(GameTime gameTime)
        {
            #region Keyinput
            // Close application
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            #endregion
            
            #region Keyinput - Event occurs when key was pressed AND released !
            // Get kb state
            kb = Keyboard.GetState();

            // Key is pressed AND key is released AND any other condition(s)
            // Background on/off
            if(kb.IsKeyDown(Keys.F1) && lastKb.IsKeyUp(Keys.F1) && drawBackground)
                drawBackground = false;
            else if(kb.IsKeyDown(Keys.F1) && lastKb.IsKeyUp(Keys.F1) && !drawBackground)
                drawBackground = true;

            // GUI on/off
            if(kb.IsKeyDown(Keys.F2) && lastKb.IsKeyUp(Keys.F2) && drawGUI)
                drawGUI = false;
            else if(kb.IsKeyDown(Keys.F2) && lastKb.IsKeyUp(Keys.F2) && !drawGUI)
                drawGUI = true;

            // DebugText on/off
            if(kb.IsKeyDown(Keys.F3) && lastKb.IsKeyUp(Keys.F3) && drawDebugInfo)
                drawDebugInfo = false;
            else if(kb.IsKeyDown(Keys.F3) && lastKb.IsKeyUp(Keys.F3) && !drawDebugInfo)
                drawDebugInfo = true;

            // Controls on/off
            if(kb.IsKeyDown(Keys.F4) && lastKb.IsKeyUp(Keys.F4) && drawControls)
                drawControls = false;
            else if(kb.IsKeyDown(Keys.F4) && lastKb.IsKeyUp(Keys.F4) && !drawControls)
                drawControls = true;

            // Toggle between window and fullscreen
            if(kb.IsKeyDown(Keys.F5) && lastKb.IsKeyUp(Keys.F5))
                graphics.ToggleFullScreen();

            // Get lastKb state
            lastKb = Keyboard.GetState();
            #endregion
            
            // Update the whole particle system
            particleEngine.Update(gameTime);

            base.Update(gameTime);
        }

        // Draw whole game
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //Paticle
            particleEngine.Draw(spriteBatch);

            //SpriteManager
            if(drawBackground)
                spriteManager.Draw(spriteBatch);

            // GUI
            if(drawGUI)
                gui.drawGUI(spriteBatch);

            // Debug info
            if(drawDebugInfo)
                gui.DrawDebugMonitor(gameTime, spriteBatch);

            // Controls
            if(drawControls)
                gui.DrawControls(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
