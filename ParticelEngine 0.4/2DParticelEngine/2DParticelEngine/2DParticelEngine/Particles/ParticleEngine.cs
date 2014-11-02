using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DParticelEngine
{
    // Defintion of a particle emitter which can generate particles
    public class ParticleEngine
    {
        // RND
        private Random random;

        // List of particles 
        public List<Particle> particles;

        // List of textures
        private List<Texture2D> textures;
        // Single texture object
        private Texture2D texture;
        // Texture index (switch texture for a particle)
        public int textureIndex = 0;

        // Pre-defined particle systems
        public enum ParticleManager { none, mouse, mixed, snow, sin }
        public ParticleManager particleManager = ParticleManager.mouse;
        // ParticleManager index (switch particle stream)
        public int ParticleManagerIndex = 0;

        // Particles spawn at this position
        public Vector2 EmitterLocation { get; set; }

        // Particle system properties 
        public int particlesPerFrame;
        int maxParticles;
        // Particle movement
        Vector2 position;
        Vector2 velocity;
        float angle = 0;
        float angularVelocity;
        // Verticla and horizontal velocity
        float verVel = 0, horVel = 0;
        // Particle color
        Color color;
        // LiveTime
        float lt = 0;
        // Particle size
        float size = 0;

        // For Sin particleManager state
        float rad = 0;

        // Total resolution
        int screenWidth;
        int screenHeight;
        
        // Constructor for particleEngine
        public ParticleEngine(List<Texture2D> textures, Vector2 location)
        {
            EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();

            // Get and set screenWidth and height
            screenWidth = Game1.instance.screenWidth;
            screenHeight = Game1.instance.screenHeight;

            // Number of particles generated per frame
            particlesPerFrame = 2;

            // Max number fo particles
            maxParticles = 30000;

        }

        // Update all particles
        public void Update(GameTime gt)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                // Particles per frame (PPF * FPS * LT in seconds = total particle count)
                //particlesPerFrame = 2;

                for (int i = 0; i < particlesPerFrame; i++)
                {
                    if(particles.Count <= maxParticles && particleManager != ParticleManager.none)
                        particles.Add(GenerateNewParticelStream());
                }
            }
            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update(gt);
                if (particles[particle].LT <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        // Generate new particle system (particleStream) and
        // set the properties
        private Particle GenerateNewParticelStream()
        {
            switch (particleManager)
            {
                case ParticleManager.none:
                    texture = null;
                    size = 0;
                    horVel = 0.0f;
                    verVel = 0.0f;
                    velocity = Vector2.Zero;
                    angle = 0;
                    angularVelocity = 0;

                    // Zero emitter
                    EmitterLocation = Vector2.Zero;
                    position = EmitterLocation;
                    color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                    lt = 0;
                    break;
                case ParticleManager.mouse:
                    if (textureIndex < 4)
                        size = (float)random.NextDouble();
                    else
                        size = (float)random.NextDouble() / 8;
                    texture = textures[textureIndex];
                    horVel = 10.0f;
                    verVel = 2.0f;
                    velocity = new Vector2(1f * (float)(random.NextDouble() * verVel - 1), 1f * (float)(random.NextDouble() * horVel - 1));
                    angle = 0;
                    angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);

                    // Emitter for Mouse
                    EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                    position = EmitterLocation;
                    color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                    lt = 2000; // 3 seconds
                    break;

               case ParticleManager.snow:
                    if (textureIndex < 4)
                        size = (float)random.NextDouble();
                    else
                        size = (float)random.NextDouble() / 8;
                    texture = textures[textureIndex];
                    horVel = 10.0f;
                    verVel = 0.0f;
                    velocity = new Vector2(1f * (float)(random.NextDouble() * verVel - 1), 1f * (float)(random.NextDouble() * horVel - 1));
                    angle = 0;
                    angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);

                    // Emitter for Snow
                    EmitterLocation = new Vector2(random.Next(0, screenWidth), 0);
                    position = EmitterLocation;
                    color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                    lt = 2000; // 3 seconds
                    break;
                case ParticleManager.mixed:
                    texture = textures[random.Next(textures.Count)];
                    size = (float)random.NextDouble() / 2;
                    horVel = 0.0f;
                    verVel = 10.0f;
                    velocity = new Vector2(1f * (float)(random.NextDouble() * verVel - 1), 1f * (float)(random.NextDouble() * horVel - 1));
                    angle = 0;
                    angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);

                    // Emitter for Mouse
                    EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                    position = EmitterLocation;
                    color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                    lt = 2000; // 3 seconds
                    break;
               case ParticleManager.sin:
                    texture = textures[random.Next(textures.Count)];
                    size = (float)random.NextDouble() / 2;
                    horVel = 0.0f;
                    verVel = 10.0f;
                    velocity = new Vector2(verVel + (float)random.NextDouble(),  horVel + (float)random.NextDouble());
                    angle = 0;
                    angularVelocity = 3;

                    rad += 0.03f;

                    if(rad >= 2 * Math.PI)
                        rad = 0;

                    // Horizontal movement of emitter
                    EmitterLocation = new Vector2(screenWidth / 5, (screenHeight / 2) + ((float)Math.Sin(rad) * screenHeight / 3));
                    position = EmitterLocation;
                    color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                    lt = 2000; // 3 seconds
                    break;
            }

            // Return a new particle
            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, lt);
        }

        // Draw all particles
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        // Next particle texture
        public void TextureUp()
        {
            if (textureIndex < 10) //number of textures - 1
                textureIndex++;
        }

        // Last particle texture
        public void TextureDown()
        {
            if (textureIndex > 0)
                textureIndex--;
        }

        // Increas particle generation per second
        public void ParticlesPerSecondUp()
        {
            if(particlesPerFrame < 150)
                particlesPerFrame++;
        }

        // Decrease particle geneartion per second
        public void ParticlesPerSecondDown()
        {
            if(particlesPerFrame > 0)
                particlesPerFrame--;
        }

        // Next particle system
        public void ParticleManagerUp()
        {
            if(ParticleManagerIndex < 4) // number of states - 1
                ParticleManagerIndex++;

            SetParticleManagerState();
        }

        // Last particle system
        public void ParticleManagerDown()
        {
            if(ParticleManagerIndex > 0)
                ParticleManagerIndex--;

            SetParticleManagerState();
        }

        // Each number is assigned a state
        private void SetParticleManagerState()
        {
            switch(ParticleManagerIndex)
            {
                case 0:     particleManager = ParticleManager.none;     break;
                case 1:     particleManager = ParticleManager.mouse;    break;
                case 2:     particleManager = ParticleManager.snow;     break;
                case 3:     particleManager = ParticleManager.mixed;    break;
                case 4:     particleManager = ParticleManager.sin;      break;
                default:    particleManager = ParticleManager.none;     break;
            }
        }
    }
}
