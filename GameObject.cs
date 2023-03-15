using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class GameObject
{
    public virtual void Update(GameTime gameTime)
    {
        throw new System.Exception("not implemented in base class");
    }

    public virtual void OnCollisionHappened(GameObject theCollidingObject)
    {
        
    }
}