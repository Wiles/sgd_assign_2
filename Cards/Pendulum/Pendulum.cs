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
        private double _maxAngle = .5;
        public double MaxAngle {
            get { return _maxAngle * 180/Math.PI; }
            set 
            {
                if (value > 45)
                {
                    _maxAngle = 45 * Math.PI / 180;
                }
                else if (value <= 0)
                {
                    _maxAngle = 0;
                }
                else
                {
                    _maxAngle = value * Math.PI / 180;
                }
            }
        }
        private float _length = 5;
        public float Length {
            get { return _length; }
            set 
            { 
                if (value > 10)
                {
                    _length = 10;
                }
                else if (value < 1)
                {
                    _length = 1;
                }
                else
                {
                    _length = value;
                }
             }
        }

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
            var rotation = (float)(_maxAngle * Math.Cos(Math.Sqrt(9.81 / _length) * timer.Time()));
            _sprite.Begin(Direct3D.SpriteFlags.AlphaBlend);
            _sprite.Transform = 
            Matrix.Transformation2D(
                new Vector2((float)(_sWidth / 2.0), 0.0f),          //scaling centre
                0.0f,                                               //scaling ratio
                new Vector2(_length / 5.0f, _length / 5.0f),        //scaling
                new Vector2((float)(_sWidth / 2.0), 0),             //rotation centre
                rotation,                                           //rotation
                new Vector2(0.0f, 0.0f));                           //translation

            _sprite.Draw(_texture, Rectangle.Empty, new Vector3(50, 0.0f, 0.0f), new Vector3((float) (_sWidth/2.0), 0, 0.0f), Color.White);
            _sprite.End();
            if (Math.Abs(_maxAngle - 0.0) < 0.001)
            {
                _sound.Pan = 0;
                _sound.Volume = 0;
            }
            else
            {
                _sound.Pan = -(int)(10000 * (float)((rotation / _maxAngle) * .5));
                _sound.Volume = (int)(-1000 * (Math.Abs(rotation) / (_maxAngle)));
            }
        }
    }
}
