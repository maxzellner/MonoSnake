using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoSnake.Entities
{
    public class Fruit : Block
    {
        public Fruit(Block block) : base(block)
        {
        }

        public Fruit(Vector2 startingPosition, int w, int h, Color color) : base(startingPosition, w, h, color)
        {
            
        }
    }
}