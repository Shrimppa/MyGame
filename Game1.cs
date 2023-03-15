using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MyGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private List<GameObject> _gameObjects = new List<GameObject>();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _gameObjects.Add(new Ball());
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        // foreach (Game gameObject in _gameObjects)
        // {
        //     gameObject.Initialize();
        // }
        base.Initialize();

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // foreach (Game gameObject in _gameObjects)
        // {
        //     gameObject.LoadContent();
        // }
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        foreach (GameObject gameObject in _gameObjects)
        {
            gameObject.Update(gameTime);
        }

        // collision detection phase
        foreach (GameObject outsideGO in _gameObjects)
        {
            // foreach (GameObject insideGO in _gameObjects)
            // {
            //     if (outsideGO.Overlaps(insideGO))
            //     {
                    
            //     }
            // }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // foreach (Game gameObject in _gameObjects)
        // {
        //     gameObject.Update();
        // }
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
