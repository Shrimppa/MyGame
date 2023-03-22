using System.IO;
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

    public virtual void GetPosition()
    {
        // Gives the position in x and y coordinates, and gives the size of the object, gotta figure out the math here to find the area to make it so it can be clicked
    }

    // public virtual void SetLocationToMoveTo()
    // {
    //     // Sets the destination in x and y coordinates to stop the ball once it has moves maybe?
    // }

    // public virtual void OnLeftClickSelect()
    // {
    //     // You can know it's been selected if a left click is registered in the area of the circle 

    //     // I have to add this logic somewhere to call on this if left clicked in this area using GetPosition()

    //     bool selected = true;
    //     while (selected == true)
    //     {
    //         getinput // you get the input in the form of a left or right click

    //         if (click = rightClick) // find out the right terms for the clicks
    //         {
    //             OnRightClickMove();
    //         }
    //         else if (click = leftClick) // find out the right terms for the clicks
    //         {
    //             selected = false;
    //         }
    //     }
    // }

    public virtual void OnRightClickMove()
    {
        // Uses MovePosition, and SetLocationToMoveTo
    }

    public virtual Vector2 UpdatePosition(Vector2 Position, float SpeedX, float SpeedY)
    {
        Position.X = Position.X + SpeedX;
        Position.Y = Position.Y + SpeedY;
        return Position;
    }
}