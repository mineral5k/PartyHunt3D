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
        SkillName = "광역 치유";
        SkillDescription = "일정 시간마다  모든 아군을 치유합니다";
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
