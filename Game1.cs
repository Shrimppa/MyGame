using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;

        Ball ball;

        GameWindow window;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ball = new Ball();

            ball.Initialize(GraphicsDevice, graphics);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            ball.Load();

            base.LoadContent();
        }

        protected override async void Update(GameTime gameTime)
        {    
            ball.Update(window);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            ball.Draw();

            base.Draw(gameTime);
        }
    }
}