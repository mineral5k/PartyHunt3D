using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthLevelText : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UIUpdate();
        ShopManager.Instance.OnUIUpdateEvent += UIUpdate;
    }

    private void UIUpdate()
    {
        switch (ShopManager.Instance.job)
        {
            case Job.Tanker:
                text.text = "Lv." + GameManager.Instance.TankerHealthLevel.ToString();
                break;
            case Job.Dealer:
                text.text = "Lv." + GameManager.Instance.DealerHealthLevel.ToString();
                break;
            case Job.Healer:
                text.text = "Lv." + GameManager.Instance.HealerHealthLevel.ToString();
                break;
        }
    }
}
