using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeffenseBuyButton : MonoBehaviour
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
                price = (int)Mathf.Round(500 * Mathf.Pow(1.2f, GameManager.Instance.TankerDeffenseLevel));
                break;
            case Job.Dealer:
                price = (int)Mathf.Round(500 * Mathf.Pow(1.2f, GameManager.Instance.DealerDeffenseLevel));
                break;
            case Job.Healer:
                price = (int)Mathf.Round(500 * Mathf.Pow(1.2f, GameManager.Instance.HealerDeffenseLevel));
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
                GameManager.Instance.TankerDeffenseLevel++;
                break;
            case Job.Dealer:
                GameManager.Instance.DealerDeffenseLevel++;
                break;
            case Job.Healer:
                GameManager.Instance.HealerDeffenseLevel++;
                break;
        }
        ShopManager.Instance.UIUpdate();
    }
}
