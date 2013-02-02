using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Pendulum
{
    class Pendulum
    {
        private Texture2D _texture;
        private Vector2 _postion;
        private float _rotation;
        private SoundEffectInstance _whoosh;
        private Boolean right = false;
        private float _maxAngle;

        public int Width
        {
            get { return _texture.Width; }
        }

        public int Height
        {
            get { return _texture.Height; }
        }

        public void Initialize(Texture2D texture, Vector2 position, SoundEffect whoosh, float initialAngle)
        {
            _texture = texture;
            _postion = position;
            _whoosh = whoosh.CreateInstance();
            _maxAngle = initialAngle;
            _rotation = _maxAngle;
            _whoosh.IsLooped = true;
            _whoosh.Play();
        }

        public void Update(GameTime gameTime)
        {
            _rotation = (float)(_maxAngle * Math.Cos(Math.Sqrt(9.81 / 50) * gameTime.TotalGameTime.TotalSeconds));
            
            _whoosh.Pan = -(float)((_rotation/_maxAngle) * .5);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _postion, null, Color.White, _rotation,
            new Vector2((int)(Width / 2.0), 0), 1f, SpriteEffects.None, 0f);
        }
    }
}
