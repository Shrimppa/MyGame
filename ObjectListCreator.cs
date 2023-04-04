using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class ObjectListCreator : ObjectCreator
{
    private List<GameObject> _gameObjects = new List<GameObject>();

    public ObjectListCreator()
    {
        ObjectListUseful(75);
    }

    private void ObjectListUseful(int NumberOfObjectsToCreate)
    {
        while (NumberOfObjectsToCreate != 0)
        {
            GameObject ball = CreateBallGameObject();
            _gameObjects.Add(ball);
            NumberOfObjectsToCreate -= 1;
        }
    }

    public List<GameObject> GetListOfGameObjects()
    {
        return _gameObjects;
    }
}