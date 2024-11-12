using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanker : Character
{
     
    private void Awake()
    {
        baseHealth = 150;
        baseDeffense = 50;
        baseAttack = 80;
    }
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
        maxHealth = baseHealth * Mathf.Pow(1.2f, GameManager.Instance.TankerHealthLevel);
        deffense = baseDeffense * Mathf.Pow(1.2f, GameManager.Instance.TankerDeffenseLevel);
        attack = baseAttack * Mathf.Pow(1.2f, GameManager.Instance.TankerAttackLevel);
        if (GameManager.Instance.isTankerSkillPurchased) gameObject.AddComponent<TankerSkill>();

        curHealth = maxHealth;

        StartCoroutine(NormalAttack());

    }

}
