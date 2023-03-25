using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Ball : GameObject
{
    public override void Load() // The loading of the ball
    {
        _batchSprite = new SpriteBatch(_graphicsDevice);

        using (var fileStream = new FileStream("Content/ball.png", FileMode.Open))
        {
            _texture = Texture2D.FromStream(_graphicsDevice, fileStream);
        }
    }
}