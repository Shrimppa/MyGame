using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class ObjectCreator
{
    Random rand;

    public GameObject CreateBaseGameObject()
    {
        GameObject gameObject = new GameObject();
        
        return gameObject;
    }

    public GameObject CreateBallGameObject()
    {
        Ball gameObject = new Ball();
        
        return gameObject;
    }

    public Vector2 GetRandomPosition(GameWindow window)
    {
        Vector2 randomVector;

        rand = new Random();

        randomVector.X = rand.Next(0, 1720);
        
        randomVector.Y = rand.Next(0,880);

        return randomVector;
    }
}