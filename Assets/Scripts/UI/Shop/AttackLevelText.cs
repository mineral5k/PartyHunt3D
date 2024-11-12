using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackLevelText : MonoBehaviour
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
                text.text = "Lv." + GameManager.Instance.TankerAttackLevel.ToString();
                break;
            case Job.Dealer:
                text.text = "Lv." + GameManager.Instance.DealerAttackLevel.ToString();
                break;
            case Job.Healer:
                text.text = "Lv." + GameManager.Instance.HealerAttackLevel.ToString();
                break;
        }
    }
}
