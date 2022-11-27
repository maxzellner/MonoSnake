using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoSnake.Entities;

namespace MonoSnake
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _texture;

        private Block _block;
        private Snake _snake;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _block = new Block(new Vector2(0, 0), 10, 10, Color.Azure);
            _snake = new Snake(new Vector2(100, 100), 20);

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

            if (Keyboard.GetState().IsKeyDown(Keys.W)) _block.Move(Direction.Up, 10);
            if (Keyboard.GetState().IsKeyDown(Keys.S)) _block.Move(Direction.Down, 10);
            if (Keyboard.GetState().IsKeyDown(Keys.A)) _block.Move(Direction.Left, 10);
            if (Keyboard.GetState().IsKeyDown(Keys.D)) _block.Move(Direction.Right, 10);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_texture, _block.Rectangle, _block.Color);

            _snake.Draw(_spriteBatch, _texture);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}