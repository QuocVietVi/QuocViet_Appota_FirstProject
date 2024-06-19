using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft3 : MonoBehaviour
{
    private float speed = 10;
    private PlayerController3 playerController;
    private float leftBound = -15;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    private void Update()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }
}
