using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float baseHealth;
    public float maxHealth;
    public float curHealth
    {
        get { return curHealth; }
        set 
        {
            curHealth = value;
            if (curHealth <= 0f) Die(); 
        }
    }
    public float baseDeffense;
    public float deffense;
    public float baseAttack;
    public float attack;
    public float healthPercent;
    public bool isDead = false;

    public Dragon dragon;

    public void GetAttacked()
    {
        float damage = dragon.attack - deffense;
        if (damage < 0)  damage = 0f;
        curHealth -= damage;
    }

    public void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
    

}
