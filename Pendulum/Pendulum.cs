using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;
using Direct3D = Microsoft.DirectX.Direct3D;

namespace Pend
{
    class Pendulum
    {
        private readonly Direct3D.Sprite _sprite;
        private readonly Direct3D.Texture _texture;
        private readonly Direct3D.Device _graphics;
        private readonly SecondaryBuffer _sound;
        private readonly int _sWidth;
        private const double MaxAngle = .5;
        private const float Length = 5;

        public Pendulum(Direct3D.Device g, Size gSize, Direct3D.Texture texture, SecondaryBuffer sound)
        {
            _sWidth = gSize.Width;
            _graphics = g;
            _sprite = new Direct3D.Sprite(_graphics);
            _texture = texture;
            _sound = sound;
        }

        public void Move(Timer timer)
        {
            var rotation = (float) (MaxAngle*Math.Cos(Math.Sqrt(9.81/Length)*timer.Time()));
            _sprite.Begin(Direct3D.SpriteFlags.AlphaBlend);
            Matrix tranz = 
            Matrix.Transformation2D(
                new Vector2((float)(_sWidth / 2.0), 0.0f),          //scaling centre
                0.0f,                                               //scaling ratio
                new Vector2(Length / 5.0f, Length / 5.0f),          //scaling
                new Vector2((float)(_sWidth / 2.0), 0),             //rotation centre
                rotation,                                           //rotation
                new Vector2(0.0f, 0.0f));                           //translation

            _sprite.Transform = tranz;
            _sprite.Draw(_texture, Rectangle.Empty, new Vector3(50, 0.0f, 0.0f), new Vector3((float) (_sWidth/2.0), 0, 0.0f), Color.White);
            _sprite.End();

            _sound.Pan = -(int) (10000 * (float)((rotation / MaxAngle) * .5));
            _sound.Volume = (int) (-1000 * (Math.Abs(rotation)/(MaxAngle)));
        }
    }
}