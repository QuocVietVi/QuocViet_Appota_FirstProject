using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public GameObject road;
    public Transform currentRoad;
    private float horizontalInput;
    private float forwardInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up,turnSpeed * horizontalInput * Time.deltaTime );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            Vector3 spawnPos = new Vector3(currentRoad.position.x, currentRoad.position.y, currentRoad.position.z + 200);
            GameObject newRoad = Instantiate(road, spawnPos, road.transform.rotation);
            currentRoad = newRoad.transform;
            Destroy(other.gameObject);
        }
    }
}
