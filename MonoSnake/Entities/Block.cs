using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoSnake.Entities
{
    internal class Block
    {
        private Vector2 _position;
        private int _w;
        private int _h;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _w, _h);
            }
        }
        public Color Color;

        public Block(Vector2 startingPosition, int w, int h, Color color)
        {
            _position = startingPosition;
            _w = w;
            _h = h;
            Color = color;
        }

        public void Move(Direction direction, int pixels = 1)
        {
            switch (direction)
            {
                case Direction.Left:
                    _position.X -= pixels;
                    break;
                case Direction.Right:
                    _position.X += pixels;
                    break;
                case Direction.Up:
                    _position.Y -= pixels;
                    break;
                case Direction.Down:
                    _position.Y += pixels;
                    break;
                default:
                    break;
            }
        }
    }
}
