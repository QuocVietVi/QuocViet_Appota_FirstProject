using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatDelay = 2;
    private PlayerController3 playerController;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatDelay);
        playerController = GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    void SpawnObstacle()
    {
        if(playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }

    }
}
