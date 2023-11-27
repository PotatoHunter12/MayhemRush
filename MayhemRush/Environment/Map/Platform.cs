using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayhemRush
{
    public class Platform
    {
        private Texture2D texture;
        public Vector2 position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("platformTexture");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
