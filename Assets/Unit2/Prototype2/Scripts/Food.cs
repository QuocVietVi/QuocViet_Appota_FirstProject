using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed = 40f;

    private void Update()
    {
        if (!MainManager.instance.gameOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

    }
}
