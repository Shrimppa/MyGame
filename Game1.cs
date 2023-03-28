using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;

        private List<GameObject> _gameObjects = new List<GameObject>();

        Ball ball;
        Ball ball2;

        GameWindow window;

        CollisionSystem collision;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ball = new Ball();
            _gameObjects.Add(ball);
            ball2 = new Ball();
            _gameObjects.Add(ball2);

            Vector2 a1;
            a1.X = 300;
            a1.Y = 300;

            Vector2 b1;
            b1.X = 100;
            b1.Y = 100;

            ball.Initialize(GraphicsDevice, graphics, a1);

            ball2.Initialize(GraphicsDevice, graphics, b1);

            // foreach (GameObject _object in _gameObjects)
            // {
            //     _object.Initialize(GraphicsDevice, graphics);  
            // }

            collision = new CollisionSystem(_gameObjects);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            foreach (GameObject _object in _gameObjects)
            {
                _object.Load();  
            }

            base.LoadContent();
        }

        protected override async void Update(GameTime gameTime)
        {    
            foreach (GameObject _object in _gameObjects)
            {
                _object.Update(window);  
            }
            
            collision.SetObjectAreas();
            
            collision.CheckForCollision(window);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameObject _object in _gameObjects)
            {
                _object.Draw();  
            }

            base.Draw(gameTime);
        }
    }
}