using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float time;
    public int highScore;
    public Dictionary<int, int> ammountAnimals;

    public PlayerData()
    {
        time = 0;
        highScore = 0;
        ammountAnimals = new Dictionary<int, int>
        {
            { 0, 0 },
            { 1, 0 },
            { 2, 0 }
        };
    }

    public PlayerData(float time, int highScore, Dictionary<int,int> ammountAnimals)
    {
        this.time = time;
        this.highScore = highScore;
        this.ammountAnimals = ammountAnimals;
    }
}
