using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class SkillInfoText : MonoBehaviour
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

    void UIUpdate()
    {
        switch (ShopManager.Instance.job)
        {
            case Job.Tanker:
                text.text = "방패 들기 \n\n일정 시간마다  다음 공격을 막습니다.";
                break;
            case Job.Dealer:
                text.text = "트리플 스트라이크 \n\n일정 시간마다  적을 세번 공격합니다.";
                break;
            case Job.Healer:
                text.text = "광역 치유 \n\n일정 시간마다  모든 아군을 치유합니다.";
                break;
        }
    }

}
