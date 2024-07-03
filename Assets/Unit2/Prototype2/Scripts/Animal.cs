using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float speed;
    public float _hp;
    public AnimalType type;
    public int _point;
    private float maxHp;

    private void Start()
    {
        var listData = MainManager.instance.animalData;
        for (int i = 0; i < listData.Count; i++)
        {
            if (listData[i].type == (int)type)
            {
                _hp = listData[i].hp;
                speed = listData[i].speed;
                _point = listData[i].point;

            }
        }
        maxHp = _hp;
    }
    private void Update()
    {
        if (!MainManager.instance.gameOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

    }

    public float GetHpNormalized()
    {
        return _hp / maxHp;
    }
}
