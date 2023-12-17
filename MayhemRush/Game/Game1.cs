using Android.Icu.Number;
using Android.Media.Effect;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using static Android.Icu.Text.Transliterator;
using static Android.Webkit.WebStorage;

namespace MayhemRush
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D texture;
        private Texture2D whiteRectangle;
        public Player player;
        public Enemy enemy;
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
            enemy = new Enemy(player);
            platforms = new List<Platform>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            enemy.LoadContent(Content);
            texture = Content.Load<Texture2D>("platformTexture");
            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
            // Load platform textures here
        }

        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime, platforms);
            enemy.Update(gameTime, platforms);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw game objects here
            spriteBatch.Begin();
            spriteBatch.Draw(whiteRectangle, new Rectangle(0, 750, 2500, 200),Color.Chocolate);
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            foreach (var platform in platforms)
            {
                platform.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}