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
                text.text = "���� ��� \n\n���� �ð�����  ���� ������ �����ϴ�.";
                break;
            case Job.Dealer:
                text.text = "Ʈ���� ��Ʈ����ũ \n\n���� �ð�����  ���� ���� �����մϴ�.";
                break;
            case Job.Healer:
                text.text = "���� ġ�� \n\n���� �ð�����  ��� �Ʊ��� ġ���մϴ�.";
                break;
        }
    }

}
