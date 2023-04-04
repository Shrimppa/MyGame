using System;
using System.Threading.Tasks;
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

        GameWindow window;

        ObjectListCreator creator;

        CollisionSystem collision;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1820;
            graphics.PreferredBackBufferHeight = 980;
            graphics.ApplyChanges();

            creator = new ObjectListCreator();

            _gameObjects = creator.GetListOfGameObjects();

            foreach (GameObject _object in _gameObjects)
            {
                _object.Initialize(GraphicsDevice, graphics, creator.GetRandomPosition(window));  
            }

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

            collision.CheckForCollision(Window);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            foreach (GameObject _object in _gameObjects)
            {
                _object.Draw();  
            }

            base.Draw(gameTime);
        }
    }
}