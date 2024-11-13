using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerSkill : MonoBehaviour,ICharacterSkill
{
    public string SkillName { get; set; }
    public string SkillDescription { get; set; }

    Character character;

    private void Awake()
    {
        SkillName = "���� ���";
        SkillDescription = "���� �ð�����  ���� ������ �����ϴ�.";
    }

    void Start()
    {
        character = GetComponent<Character>();
        StartCoroutine(Block());
    }

    IEnumerator Block()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            character.isShield = true;
        }
    }
}
