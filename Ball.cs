using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Ball : GameObject
{
    private Vector2 position = new Vector2(0, 0);

    public override void Update(GameTime gameTime)
    {
        position.X += 1;
        position.Y += 1;
        System.Console.WriteLine(position.X + ", " + position.Y);
    }

    public virtual void OnCollisionHappened(GameObject theCollidingObject)
    {
        // change my direction
    }
}