using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Animal dog;
    public Image hpImage;

    private void Update()
    {
        hpImage.fillAmount = dog.GetHpNormalized();
    }
}
