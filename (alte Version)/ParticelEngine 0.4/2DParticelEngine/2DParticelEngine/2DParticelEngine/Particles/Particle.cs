using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DParticelEngine
{
    // Defintion of a single particle
    public class Particle
    {
        // Properties for a single particle
        public Texture2D Texture { get; set; }      // Texture for the Particle
        public Vector2 Position { get; set; }       // Current Pos of Particle
        public Vector2 Velocity { get; set; }       // Speed of the Particle
        public float Angle { get; set; }            // Angle of the Particle
        public float AngularVelocity { get; set; }  // Speed that changes angle
        public Color Color { get; set; }            // Color for the Particel
        public float Size { get; set; }             // Size of the Particel
        public float LT { get; set; }               // LifeTime of the Particel in Milliseconds

        // Constructor for a single particle
        public Particle(Texture2D texture, Vector2 position, Vector2 velocity, float angle, float angularVelocity, Color color, float size, float lt)
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Angle = angle;
            AngularVelocity = angularVelocity;
            Color = color;
            Size = size;
            LT = lt;
        }

        // Update a singel particle
        public void Update(GameTime gt)
        {
            // Once a particle is generated, its current lifetime is subtracted from its total livetime
            LT -= (float)gt.ElapsedGameTime.TotalMilliseconds;
            Position += Velocity;
            Angle += AngularVelocity;
        }

        // Draw a singel particle
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle source = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            spriteBatch.Draw(Texture, Position, source, Color, Angle, origin, Size, SpriteEffects.None, 0f);
        }
    }
}
