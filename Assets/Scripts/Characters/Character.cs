using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Character : MonoBehaviour
{
    public float baseHealth;
    public float maxHealth;
    public float curHealth;
    public bool isShield;
    public float CurHealth
    {
        get { return curHealth; }
        set 
        {
            curHealth = value;
            if (curHealth > maxHealth) curHealth = maxHealth;
            if (curHealth <= 0f) Die(); 
        }
    }

    public float baseDeffense;
    public float deffense;
    public float baseAttack;
    public float attack;
    public float healthPercent => curHealth / maxHealth;
    public bool isDead = false;

    public Dragon dragon;


    protected virtual void Start()
    {
        
    }
    public void GetAttacked()
    {
        float damage = dragon.attack - deffense;
        if (damage < 0)  damage = 0f;
        if (isShield)
        {
            damage = 0f;
            isShield = false;
        }
        CurHealth -= damage;
    }

    public void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
    
    public void Attack()
    {
        float damage = attack - dragon.deffense;
        if (damage < 0) damage = 0f;
        dragon.CurHealth -= damage;
    }
    protected IEnumerator NormalAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(((float)(new Random().Next(100, 111))) / 100);
            Attack();
        }

    }

}
