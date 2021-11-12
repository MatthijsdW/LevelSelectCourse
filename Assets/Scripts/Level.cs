using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int ID { get; set; }
    public string LevelName { get; set; }
    public bool Completed { get; set; }
    public int Stars { get; set; }
    public bool Locked { get; set; }

    public Level(int id, string levelName, bool completed, int stars, bool locked)
    {
        ID = id;
        LevelName = levelName;
        Completed = completed;
        Stars = stars;
        Locked = locked;
    }

    public void Complete()
    {
        Completed = true;
    }

    public void Complete(int stars)
    {
        Complete();
        Stars = stars;
    }

    public void Lock()
    {
        Locked = true;
    }

    public void Unlock()
    {
        Locked = false;
    }
}