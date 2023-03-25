using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class GameObject
{

    protected int x = 0;

    protected bool _selected;

    float _speedX;

    float _speedY;

    protected Texture2D _texture;

    protected Vector2 _mousePosition;

    protected GraphicsDeviceManager _graphics;

    protected SpriteBatch _batchSprite;

    protected GraphicsDevice _graphicsDevice;

    protected Vector2 _position;

    public virtual void Initialize(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics) // The initialization of the object
    {
        _graphicsDevice = graphicsDevice;
        _graphics = graphics;

        _position = new Vector2(_graphics.PreferredBackBufferWidth / 2,_graphics.PreferredBackBufferHeight / 2);

        _speedX = 1f;
        _speedY = 1f;
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
                    x = 1;
                }
            }

            StartMoving(x);
    }

    public void StartMoving(int start_if_greater_than_0) // The magic that starts to move the objects! :)
    {
        
        // if (_collisionHappened == false)
        if (_mousePosition != _position)
        {
            if (start_if_greater_than_0 > 0)
            {
                Vector2 movement = MovementDirection();

                _position = UpdatePosition(_position, movement.X, movement.Y);
            }
        }
        // // if (_collisionHappened == true)
        // else if (start_if_greater_than_0 > 0)
        // {
        //     Vector2 movement = MovementDirection(); // Use another class to get CollisionDirection - doesn't use mouse position, uses other object's position.

        //     _position = UpdatePosition(_position, movement.X, movement.Y); // Input CollisionDirection into movement.x, and movement.y
        // }
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

    public void UpdateMousePosition() // Updates the mouse's position in a vector form.
    {
        var mouseState = Mouse.GetState();
        var mousePoint = new Vector2(mouseState.X, mouseState.Y);
        _mousePosition = mousePoint;
    }

    public virtual Vector2 UpdatePosition(Vector2 Position, float _speedX, float _speedY) // Updates the position of the game object.
    {
        Position.X = Position.X + _speedX;
        Position.Y = Position.Y + _speedY;
        return Position;
    }
}