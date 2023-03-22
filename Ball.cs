using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Ball : GameObject
{
    private bool selected;
    float ballSpeedX;
    float ballSpeedY;
    private Texture2D texture;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch batchSprite;

    private GraphicsDevice _graphicsDevice;

    private Vector2 ballPosition;

    public Ball(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics) // The initialization of the ball
    {
        _graphicsDevice = graphicsDevice;
        _graphics = graphics;

        ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,_graphics.PreferredBackBufferHeight / 2);

        ballSpeedX = 1f;
        ballSpeedY = 1f;
    }


    public virtual void LoadBall() // The loading of the ball
    {
        batchSprite = new SpriteBatch(_graphicsDevice);

        using (var fileStream = new FileStream("Content/ball.png", FileMode.Open))
        {
            texture = Texture2D.FromStream(_graphicsDevice, fileStream);
        }
    }

    public virtual void DrawBall() // The drawing of the ball
    {
        batchSprite.Begin();
        batchSprite.Draw(texture, ballPosition, null, Color.White);
        batchSprite.End();
    }

    public void LeftClickSelect(GameWindow window)
    {
        var mouseState = Mouse.GetState();
        var mousePoint = new Point(mouseState.X, mouseState.Y);
        int ballpx = (int)ballPosition.X;
        int ballpy = (int)ballPosition.Y;

        var rectangle = new Rectangle(ballpx, ballpy, this.texture.Width, this.texture.Height);

        // turn this into selecting it based on left clicking, makes it much more efficient. 

        if (rectangle.Contains(mousePoint))
        {
            selected = true;
        }
        else
        {
            selected = false;
        }
        System.Console.WriteLine(selected);
    }

    public void RightClickMove()
    {
            // while (selected == true)
            // {
            //     // On left click 
            //         if (rectangle.Contains(mousePoint))
            //         {

            //         }
            //         else
            //         {
            //             selected = false;
            //         }
            //     // On right click start moving towards mouse x, and y ballPosition.
            //     //     update ballPosition
            //     //     ballPosition = UpdatePosition(ballPosition, ballSpeedX, ballSpeedY);
            //     //         start moving
            // }
    }
}