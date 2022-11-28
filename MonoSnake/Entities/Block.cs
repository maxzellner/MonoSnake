using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoSnake.Entities
{
    public class Block
    {
        private int _w;
        private int _h;
        private Vector2 _position;
        public Vector2 Position => _position;
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

        public Block(Block block)
        {
            _position = block._position;
            _w = block._w;
            _h = block._h;
            Color = block.Color;
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
        public void Move(Vector2 newPosition)
        {
            _position = newPosition;
        }
    }
}
