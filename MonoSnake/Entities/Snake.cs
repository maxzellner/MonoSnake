using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoSnake.Entities
{
    public class Snake
    {
        private Block _snakeHead;
        private List<Block> _snakeBody;

        private int _thickness;

        public Direction LastDirection;

        public int Length => _snakeBody.Count + 1;
        
        public Snake(Vector2 startingLocation, int thickness) //, int startingLength)
        {
            _snakeHead = new Block(startingLocation, thickness, thickness, Color.Red);
            //_snakeBody.
            _thickness = thickness;
        }

        public void Move(Direction direction)
        {
            LastDirection = direction;
            _snakeHead.Move(direction);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, _snakeHead.Rectangle, Color.DarkBlue);
        }
    }
}
