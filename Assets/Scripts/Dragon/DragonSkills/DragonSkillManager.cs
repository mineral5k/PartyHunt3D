using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkillManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.stageLevel >= 3)
        {
            gameObject.AddComponent<Breath>();    // ���� �������� �� ��ü ����
        }

        if (GameManager.Instance.stageLevel >= 6)
        {
            gameObject.AddComponent<Fireball>();  // ������ ȭ�� ������� ����
        }
    }

    
}
