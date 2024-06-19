using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2X : MonoBehaviour
{
    public GameObject dogPrefab;
    bool canSpawn = true;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canSpawn = false;
            Invoke(nameof(DelaySpawn), 1f);
        }
    }

    void DelaySpawn()
    {
        canSpawn = true;
    }
}
