using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class GameObject
{
    Random rand;

    protected bool _selected;

    float _speedX;

    float _speedY;

    protected Texture2D _texture;

    protected Vector2 _mousePosition;

    protected GraphicsDeviceManager _graphics;

    protected SpriteBatch _batchSprite;

    protected GraphicsDevice _graphicsDevice;

    protected Vector2 _position;

    protected Rectangle _objectRectangle;

    protected bool _collisionHappened;
    
    public GameObject()
    {
        _mousePosition.X = 800;

        _mousePosition.Y = 500;
    }

    public virtual void Initialize(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics, Vector2 position) // The initialization of the object
    {
        _graphicsDevice = graphicsDevice;
        _graphics = graphics;

        _position = position;
        _speedX = 1;
        _speedY = 1;
    }

    public virtual void Load() // The loading of the object 
    {
        _batchSprite = new SpriteBatch(_graphicsDevice);

        using (var fileStream = new FileStream("Content/ball.png", FileMode.Open)) // Put the name of the object's _texture from the content folder i.e. "Content/ball.png"
        {
            _texture = Texture2D.FromStream(_graphicsDevice, fileStream);
        }
    }

    public virtual void Draw() // The drawing of the object
    {
        int px = (int)_position.X;
        int py = (int)_position.Y;

        var rectangle = new Rectangle(px, py, this._texture.Width, this._texture.Height);
        _objectRectangle = rectangle;

        _batchSprite.Begin();
        _batchSprite.Draw(_texture, _position, null, Color.White);
        _batchSprite.End();
    }

    public virtual void Update(GameWindow window) // The heart of an update for a GameObject
    {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                SelectObject(window);
            }
            
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                if (_selected == true)
                {
                    UpdateMousePosition();
                }
            }

            StartMoving();
    }

    public void StartMoving() // The magic that starts to move the objects! :)
    { 
        if (_collisionHappened == true)
        {
            Vector2 movement = CollisionMovementDirection();

            _position = UpdateObjectPosition(_position, movement.X, movement.Y); // Input CollisionDirection into movement.x, and movement.y
        }
        
        if (_collisionHappened == false)
        {
            if (_mousePosition != _position)
            {
                Vector2 movement = MovementDirection();

                _position = UpdateObjectPosition(_position, movement.X, movement.Y);
            }
        }
    }

    public void SelectObject(GameWindow window) // Selects an object if the cursor is over it.
    {
        var mouseState = Mouse.GetState();
        
        var mousePoint = new Point(mouseState.X, mouseState.Y);
        
        int px = (int)_position.X;
        
        int py = (int)_position.Y;

        var rectangle = new Rectangle(px, py, this._texture.Width, this._texture.Height);

        if (rectangle.Contains(mousePoint))
        {
            _selected = true;
        }
        
        else
        {
            _selected = false;
        }
    }

    public Vector2 MovementDirection() // Gives vector in the direction of last recorded mouse position.
    {
        Vector2 mousePos = _mousePosition;
        
        Vector2 movementVector;
        
        Vector2 Pos = _position;
        
        float MovementX = _speedX;
        
        float MovementY = _speedY;
        
        if (mousePos.X < Pos.X)
        {
            MovementX = MovementX * -1;

        }
        
        if (mousePos.Y < Pos.Y)
        {
            MovementY = MovementY * -1;
        }
        
        movementVector.X = MovementX;
        
        movementVector.Y = MovementY;
        
        return movementVector;
    }

    public Vector2 CollisionMovementDirection() // Gives a random vector.
    {
        rand = new Random();

        Vector2 movementVector;
        
        float MovementX = _speedX;
        
        float MovementY = _speedY;

        int randomNumber = rand.Next(1, 4);
        
        if (randomNumber == 1)
        {
            MovementX = MovementX * 75;

            MovementY = MovementY * -25;
        }

        if (randomNumber == 2)
        {
            MovementX = MovementX * -75;

            MovementY = MovementY * 25;
        }

        if (randomNumber == 3)
        {
            MovementX = MovementX * -25;

            MovementY = MovementY * -75;
        }

        if (randomNumber == 4)
        {
            MovementX = MovementX * 25;

            MovementY = MovementY * 75;
        }
        
        movementVector.X = MovementX;

        movementVector.Y = MovementY;
        
        return movementVector;
    }

    public void UpdateMousePosition() // Updates the mouse's position in a vector form.
    {
        var mouseState = Mouse.GetState();
        
        var mousePoint = new Vector2(mouseState.X, mouseState.Y);
        
        _mousePosition = mousePoint;
    }

    public virtual Vector2 UpdateObjectPosition(Vector2 Position, float _speedX, float _speedY) // Updates the position of the game object.
    {
        Position.X = Position.X + _speedX;
        
        Position.Y = Position.Y + _speedY;
        
        return Position;
    }

    public virtual void CollisionHappened()
    {
        _collisionHappened = true;
    }

    public virtual void CollisionDidntHappen()
    {
        _collisionHappened = false;
    }

    public virtual Rectangle GetRectangle()
    {
        return _objectRectangle;
    }
}