using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoSnake.Entities;

namespace MonoSnake.Factories
{
    public static class FruitFactory
    {
        
        public static Fruit SpawnFruit()
        {
            int boundX = 100;
            int boundY = 100;
            Random random = new Random();

            return new Fruit(new Vector2(random.Next(0, boundX), random.Next(0, boundY)), 20, 20, Color.Red);
        }
    }
}