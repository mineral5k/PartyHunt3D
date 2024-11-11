using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldText : MonoBehaviour
{
    TextMeshProUGUI goldText;

    private void Awake()
    {
        goldText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        ShopManager.Instance.OnUIUpdateEvent += UIUpdate;
        goldText.text = "Gold: " + GameManager.Instance.gold.ToString();

    }
   

    private void UIUpdate()
    {
        goldText.text = "Gold: " + GameManager.Instance.gold.ToString();

    }
}
