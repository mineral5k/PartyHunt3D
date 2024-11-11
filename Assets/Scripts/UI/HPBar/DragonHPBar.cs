using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonHPBar : MonoBehaviour
{
    public Dragon dragon;
    Image dragonHPBar;

    private void Awake()
    {
        dragonHPBar = GetComponent<Image>();
    }

    private void Update()
    {
        dragonHPBar.fillAmount = dragon.healthPercent;
    }
}
