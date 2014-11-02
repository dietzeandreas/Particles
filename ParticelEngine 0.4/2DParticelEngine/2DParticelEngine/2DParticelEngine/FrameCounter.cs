using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace _2DParticelEngine
{
    public class FrameCounter
    {
        private float verstrichen, bilder, bildRate;
        private SpriteFont font;

        public FrameCounter(SpriteFont font)
        {
            this.font = font;
            verstrichen = 0.0f;
            bildRate = 0.0f;
            bilder = 0.0f;
        }

        public void Update(GameTime gameTime)
        {
            verstrichen += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch sp)
        {
            if (verstrichen >= 1.0f)
            {
                verstrichen = 0.0f;
                bildRate = ++bilder;
                bilder = 0.0f;
            }
            else bilder++;

            if(bildRate <= 30f)
                sp.DrawString(font, "FPS: " + bildRate.ToString("0"), new Vector2(0, 80), Color.Red);
            else if (bildRate <= 45)
                sp.DrawString(font, "FPS: " + bildRate.ToString("0"), new Vector2(0, 80), Color.Orange);
            else
                sp.DrawString(font, "FPS: " + bildRate.ToString("0"), new Vector2(0, 80), Color.YellowGreen);
        }
    }
}
