using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : Character
{
    private void Awake()
    {
        baseHealth = 80;
        baseDeffense = 20;
        baseAttack = 150;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        maxHealth = baseHealth * Mathf.Pow(1.2f, GameManager.Instance.DealerHealthLevel);
        deffense = baseDeffense * Mathf.Pow(1.2f, GameManager.Instance.DealerDeffenseLevel);
        attack = baseAttack * Mathf.Pow(1.2f, GameManager.Instance.DealerAttackLevel);

        curHealth = maxHealth;

        StartCoroutine(NormalAttack());
    }
}
