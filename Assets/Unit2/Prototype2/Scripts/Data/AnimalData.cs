using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalType
{
    Doberman = 0,
    Labrador = 1,
    Bernard = 2,
}
[Serializable]
public class AnimalData 
{
    public int type;
    public float hp;
    public float speed;
    public int point;
    public AnimalData()
    {
        type = 0;
        hp = 1;
        speed = 2;
        point = 2;
    }
    public AnimalData(int type, float hp, float speed, int point)
    {
        this.type = type;
        this.hp = hp;
        this.speed = speed;
        this.point = point;
    }
}
