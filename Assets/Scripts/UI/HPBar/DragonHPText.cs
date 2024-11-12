using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragonHPText : MonoBehaviour
{
    public Dragon dragon;
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = $"LV : {GameManager.Instance.stageLevel+1}  {dragon.CurHealth} / {dragon.maxHealth}";
    }

}
