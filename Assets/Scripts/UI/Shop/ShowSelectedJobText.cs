using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowSelectedJobText : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ShopManager.Instance.OnUIUpdateEvent += UIUpdate;
        UIUpdate();
    }

    void UIUpdate()
    {
        switch (ShopManager.Instance.job)
        {
            case Job.Tanker:
                text.text = "≈ ƒø ªÛ¡°";
                break;
            case Job.Dealer:
                text.text = "µÙ∑Ø ªÛ¡°";
                break;
            case Job.Healer:
                text.text = "»˙∑Ø ªÛ¡°";
                break;
        }
    }
}
