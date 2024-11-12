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
        SkillName = "Ʈ���� ��Ʈ����ũ";
        SkillDescription = "���� �ð�����  ���� ���� �����մϴ�";
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
