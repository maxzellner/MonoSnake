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

        public int Length;
        public Direction LastDirection;

        public Vector2 Position => new Vector2(_snakeHead.Rectangle.Center.X,_snakeHead.Rectangle.Center.Y); 
        
        public Snake(Vector2 startingLocation, int thickness, int startingLength)
        {
            _snakeHead = new Block(startingLocation, thickness, thickness, Color.Red);
            _snakeBody = new List<Block>();
            _thickness = thickness;
            Length = startingLength;
        }

        // public void Move(Direction direction, int pixels = 1)
        // {
        //     LastDirection = direction;
        //     _snakeHead.Move(direction, pixels);
        // }

        public void Move(Vector2 newPosition)
        {
            if (Vector2.Distance(_snakeHead.Position, newPosition) >= _thickness)
            {
                _snakeBody.Add(new Block(_snakeHead));
            }
            
            if (_snakeBody.Count > this.Length)
            {
                _snakeBody.RemoveRange(0, this.Length);
            }

            _snakeHead.Move(newPosition);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, _snakeHead.Rectangle, Color.DarkBlue);

            foreach (var item in _snakeBody)
            {
                spriteBatch.Draw(texture, item.Rectangle, Color.DarkSalmon);
            }
        }
    }
}
