﻿using Microsoft.Xna.Framework.Graphics;
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
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;

        public float Speed { get; set; } = 5f;
        public bool IsJumping { get; set; } = false;
        public float JumpSpeed { get; set; } = 10f;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("playerTexture");
            position = new Vector2(850, 550);
        }

        public void HandleInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            // Horizontal movement
            if (keyboardState.IsKeyDown(Keys.A))
            {
                velocity.X = -Speed;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                velocity.X = Speed;
            }
            else
            {
                velocity.X = 0;
            }
        }

        public void Update(GameTime gameTime, List<Platform> platforms)
        {
            // Update position based on velocity
            position += velocity;

            // Check for collisions with platforms
            foreach (var platform in platforms)
            {
                if (IsTouchingGround(platform))
                {
                    IsJumping = false;
                    velocity.Y = 0;
                    position.Y = platform.position.Y - texture.Height;
                }
            }

            // Handle jumping
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !IsJumping)
            {
                velocity.Y = -JumpSpeed;
                IsJumping = true;
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
