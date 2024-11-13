using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SkillBuyButton : MonoBehaviour
{

    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        UIUpdate();
        ShopManager.Instance.OnUIUpdateEvent += UIUpdate;
    }

    void UIUpdate()
    {
        switch (ShopManager.Instance.job)
        {
            case Job.Tanker:
                text.text = GameManager.Instance.isTankerSkillPurchased ? "판매 완료" : "10000G"; 
                break;
            case Job.Dealer:
                text.text = GameManager.Instance.isDealerSkillPurchased ? "판매 완료" : "10000G";
                break;
            case Job.Healer:
                text.text = GameManager.Instance.isHealerSkillPurchased ? "판매 완료" : "10000G";
                break;
        }
    }

    public void OnClick()
    {
        if (GameManager.Instance.gold < 10000) return;
        switch (ShopManager.Instance.job)
        {
            case Job.Tanker:
                if( GameManager.Instance.isTankerSkillPurchased) return;
                GameManager.Instance.gold -= 10000;
                GameManager.Instance.isTankerSkillPurchased = true;
                break;
            case Job.Dealer:
                if (GameManager.Instance.isDealerSkillPurchased) return;
                GameManager.Instance.gold -= 10000;
                GameManager.Instance.isDealerSkillPurchased = true;
                break;
            case Job.Healer:
                if (GameManager.Instance.isHealerSkillPurchased) return;
                GameManager.Instance.gold -= 10000;
                GameManager.Instance.isHealerSkillPurchased = true;
                break;
        }
        ShopManager.Instance.UIUpdate();
    }
}
