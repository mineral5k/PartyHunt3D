using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerSkill :MonoBehaviour, ICharacterSkill
{
    public string SkillName { get; set; }
    public string SkillDescription { get; set; }

    Character character;

    private void Awake()
    {
        SkillName = "트리플 스트라이크";
        SkillDescription = "일정 시간마다  적을 세번 공격합니다";
    }
    
    void Start()
    {
        character = GetComponent<Character>();
        StartCoroutine(TripleStrike());
    }

    IEnumerator TripleStrike()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            character.Attack();
            character.Attack();
            character.Attack();
        }
    }
}
