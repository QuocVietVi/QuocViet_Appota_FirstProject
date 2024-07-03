using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Animal dog = GetComponent<Animal>();
            if (dog._hp > 1)
            {
                dog._hp--;

            }
            else
            {
                var main = MainManager.instance;
                if (!main.gameOver)
                {
                    main.score += dog._point;
                    main.scoreTxt.text = "Score : " + main.score;
                    main.playerData.ammountAnimals[(int)dog.type]++;
                    DataManager.Instance.SaveData(main.playerData);
                    Destroy(gameObject);
                }

            }
            Destroy(other.gameObject);
        }
      

    }
}
