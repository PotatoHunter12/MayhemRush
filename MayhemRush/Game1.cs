using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MayhemRush
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Player player;
        private List<Platform> platforms;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Initialize your game objects here
            player = new Player();
            platforms = new List<Platform>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            // Load platform textures here
        }

        protected override void Update(GameTime gameTime)
        {
            // Handle player input here
            player.HandleInput();
            player.Update(gameTime, platforms);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw game objects here
            spriteBatch.Begin();
            player.Draw(spriteBatch);

            foreach (var platform in platforms)
            {
                platform.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}