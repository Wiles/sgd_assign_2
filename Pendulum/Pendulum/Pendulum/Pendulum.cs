using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pendulum
{
    class Pendulum
    {
        private Texture2D _circle;

        public void Initialize(Texture2D circle)
        {
            _circle = circle;
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_circle, new Vector2(50, 50), Color.Red );
        }
    }
}
