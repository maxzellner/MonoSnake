using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Framework;
using MonoSnake.Entities;
using MonoSnake.Factories;

namespace MonoSnake
{
    public class GameRoot : Game
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;

        private Texture2D _texture;

        private Block _block;
        private Snake _snake;
        private Fruit _fruit;

        public GameRoot()
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _block = new Block(new Vector2(0, 0), 10, 10, Color.Azure);
            _snake = new Snake(new Vector2(100, 100), 20, 5);
            _fruit = FruitFactory.SpawnFruit();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = new Texture2D(GraphicsDevice, 1, 1);
            _texture.SetData(new [] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // if (Keyboard.GetState().IsKeyDown(Keys.W)) _snake.Move(Direction.Up, 10);
            // if (Keyboard.GetState().IsKeyDown(Keys.S)) _snake.Move(Direction.Down, 10);
            // if (Keyboard.GetState().IsKeyDown(Keys.A)) _snake.Move(Direction.Left, 10);
            // if (Keyboard.GetState().IsKeyDown(Keys.D)) _snake.Move(Direction.Right, 10);

            _snake.Move(Vector2.Lerp(_snake.Position, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y), 1.0f));

            if (Vector2.Distance(_snake.Position, _fruit.Position) <= 10.0f)
            {
                _snake.Length++;
                _fruit = FruitFactory.SpawnFruit();
                Window.Title = $"Score : {_snake.Length}";
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _snake.Draw(_spriteBatch, _texture);

            _spriteBatch.Draw(_texture, _fruit.Rectangle, _block.Color);

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}