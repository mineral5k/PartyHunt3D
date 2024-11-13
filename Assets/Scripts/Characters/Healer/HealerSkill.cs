using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSkill : MonoBehaviour,ICharacterSkill
{
    public string SkillName { get; set; }
    public string SkillDescription { get; set; }

    Healer healer;

    private void Awake()
    {
        SkillName = "���� ġ��";
        SkillDescription = "���� �ð�����  ��� �Ʊ��� ġ���մϴ�";
    }

    void Start()
    {
        healer = GetComponent<Healer>();
        StartCoroutine(AOEHealing());
    }

    IEnumerator AOEHealing()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            healer.Heal(healer.dragon.characters[0]);
            healer.Heal(healer.dragon.characters[1]);
            healer.Heal(healer.dragon.characters[2]);
        }
    }
}
