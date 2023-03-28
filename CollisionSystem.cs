using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class CollisionSystem
{
    private List<GameObject> _gameObjects = new List<GameObject>();

    private List<Rectangle> _objectAreas = new List<Rectangle>();

    public CollisionSystem(List<GameObject> listOfGameObjects)
    {
        _gameObjects = listOfGameObjects;
    }

    public void SetObjectAreas()
    {
        _objectAreas.Clear();

        foreach (GameObject _gameObject in _gameObjects)
        {
            Rectangle objectArea = _gameObject.GetRectangle();
            _objectAreas.Add(objectArea);
        }
    }

    public void CheckForCollision(GameWindow window)
    {
        List<GameObject> copy = new List<GameObject>(_gameObjects);

        foreach (GameObject _gameObject in _gameObjects)
        {
            Rectangle objectArea = _gameObject.GetRectangle();

            copy.Remove(_gameObject);
            _objectAreas.Remove(objectArea);

            foreach (Rectangle area in _objectAreas)
            {
                int index = _objectAreas.FindIndex(x => x == area);

                if (objectArea.Intersects(area))
                {
                    _gameObject.CollisionHappened();
                    copy[index].CollisionHappened();
                }
                else
                {
                    _gameObject.CollisionDidntHappen();
                    copy[index].CollisionDidntHappen();
                }
            }
            copy.Add(_gameObject);
            _objectAreas.Add(objectArea);
        }
    }
}