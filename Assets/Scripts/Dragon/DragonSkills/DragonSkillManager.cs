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
            gameObject.AddComponent<Breath>();    // 일정 간격으로 적 전체 공격
        }

        if (GameManager.Instance.stageLevel >= 6)
        {
            gameObject.AddComponent<Fireball>();  // 적에게 화상 디버프를 남김
        }
    }

    
}
