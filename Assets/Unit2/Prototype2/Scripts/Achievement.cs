using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public Text totalTimeTxt;
    public Text highScoreTxt;
    public List<Text> ammountAnimalTxt = new List<Text>();

    private void OnEnable()
    {
        var data = UIManager.Instance.playerData;
        totalTimeTxt.text = "Total Time : " + Mathf.Round(data.time).ToString() + " seconds";
        highScoreTxt.text = "High Score : " + data.highScore.ToString();
        for (int i = 0; i < ammountAnimalTxt.Count; i++)
        {
            ammountAnimalTxt[i].text = "Ammount : "  + data.ammountAnimals[i].ToString();
        }
    }
}
