using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Healer : Character
{
    public ParticleSystem myParticle;

    private void Awake()
    {
        baseHealth = 120;
        baseDeffense = 30;
        baseAttack = 40;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        maxHealth = baseHealth * Mathf.Pow(1.2f, GameManager.Instance.HealerHealthLevel);
        deffense = baseDeffense * Mathf.Pow(1.2f, GameManager.Instance.HealerDeffenseLevel);
        attack = baseAttack * Mathf.Pow(1.2f, GameManager.Instance.HealerAttackLevel);

        curHealth = maxHealth;
        if (GameManager.Instance.isHealerSkillPurchased) gameObject.AddComponent<HealerSkill>();
        StartCoroutine(NormalHeal());
    }

    Character GetHealTarget()
    {
        int target =1;
        float minHealthPercent = 1.1f;
        for (int i = 0; i < 3; i++)
        {
            if ((dragon.characters[i] == null)|| dragon.characters[i].isDead) continue;
            
            if(dragon.characters[i].healthPercent<minHealthPercent)
            {
                target = i;
                minHealthPercent = dragon.characters[i].healthPercent;
            }
        }

        return dragon.characters[target];
    }

    public void Heal(Character character)
    {
        if (character == null) return;
        animator.SetTrigger("Heal");
        character.CurHealth += attack;
        ParticleSystem ps = Instantiate(myParticle, character.transform.position, Quaternion.identity);
        Destroy(ps.gameObject,1f);
    }

    IEnumerator NormalHeal()
    {
        while (true)
        {
             yield return new WaitForSeconds(new Random().Next(100, 111) / 100f);
             Heal(GetHealTarget());
        }
    }
}
