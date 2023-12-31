using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MayhemRush
{
    public class Enemy
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private float timer = 0f;
        public float duration = 2f;

        public Player player;
        public GameTime gameTime;


        public float Speed { get; set; } = 2f;

        public Enemy(Player player)
        {
            this.player = player;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("zombieTexture");
            position = new Vector2(200, 550);
        }

        public void HandleInput()
        {

            // Horizontal movement
            if (player.position.X - position.X < -50)
            {
                velocity.X = -Speed;
            }
            else if (player.position.X - position.X > 50)
            {
                velocity.X = Speed;
            }
            else
            {
                if(timer >= duration)
                {
                    timer %= duration;
                    player.Health -= 5;
                }
            }
        }

        public void Update(GameTime gameTime, List<Platform> platforms)
        {
            velocity.X = 0;
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            HandleInput();

            // Update position based on velocity
            position += velocity;
            this.gameTime = gameTime;

            // Check for collisions with platforms
            foreach (var platform in platforms)
            {
                if (IsTouchingGround(platform))
                {
                    velocity.Y = 0;
                    position.Y = platform.position.Y - texture.Height;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        private bool IsTouchingGround(Platform platform)
        {
            return position.X + texture.Width > platform.position.X &&
                   position.X < platform.position.X + platform.Width &&
                   position.Y + texture.Height >= platform.position.Y &&
                   position.Y < platform.position.Y;
        }
    }
}
