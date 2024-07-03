using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataSeeder : MonoBehaviour
{
    bool isSaved = false;
    private void Start()
    {
        List<AnimalData> animals = new List<AnimalData>()
        {
            new AnimalData (0,1,2,2),
            new AnimalData(1,2,3,4),
            new AnimalData(2,3,4,6),
        };

        if (isSaved == false)
        {
            DataManager.Instance.SaveData(animals);
            isSaved = true;
        }
    }

}
