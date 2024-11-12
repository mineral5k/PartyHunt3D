using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackBuyButton : MonoBehaviour
{
    TextMeshProUGUI text;
    public int price;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
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
                price = (int)Mathf.Round(500 * Mathf.Pow(1.2f, GameManager.Instance.TankerAttackLevel));
                break;
            case Job.Dealer:
                price = (int)Mathf.Round(500 * Mathf.Pow(1.2f, GameManager.Instance.DealerAttackLevel));
                break;
            case Job.Healer:
                price = (int)Mathf.Round(500 * Mathf.Pow(1.2f, GameManager.Instance.HealerAttackLevel));
                break;
        }
        text.text = price.ToString();

    }

    public void OnClick()
    {
        if (GameManager.Instance.gold < price) return;
        
        GameManager.Instance.gold -= price;
        switch (ShopManager.Instance.job)
        {
            case Job.Tanker:
                GameManager.Instance.TankerAttackLevel++;
                break;
            case Job.Dealer:
                GameManager.Instance.DealerAttackLevel++;
                break;
            case Job.Healer:
                GameManager.Instance.HealerAttackLevel++;
                break;
        }
        ShopManager.Instance.UIUpdate();
    }
}
