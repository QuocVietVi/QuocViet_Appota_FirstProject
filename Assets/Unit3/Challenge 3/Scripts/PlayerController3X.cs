using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3X : MonoBehaviour
{
    public bool gameOver = false;
    public float floatForce;
    public AudioClip explodeSound;
    public AudioClip moneySound;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    public AudioClip bounceSound;

    private float gravityModifier = 2.5f;
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    private float maxY = 14;
    private float minY = 1.4f;
    private bool isLow = true;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLow )
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        if (transform.position.y > maxY)
        {
            isLow = false;
        }
        else
        {
            isLow = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * 7, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

    }

}
