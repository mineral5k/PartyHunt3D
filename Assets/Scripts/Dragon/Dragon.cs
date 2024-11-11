using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public float baseHealth = 1000f;
    public float baseDeffense = 50f;
    public float baseAttack = 100f;

    private float maxHealth;
    public float curHealth;
    public float deffense;
    public float attack;

    

    private void Awake()
    {
        maxHealth = baseHealth * Mathf.Pow(1.2f,GameManager.Instance.stageLevel);
        deffense = baseDeffense * Mathf.Pow(1.2f, GameManager.Instance.stageLevel);
        attack = baseAttack * Mathf.Pow(1.2f, GameManager.Instance.stageLevel);

        curHealth = maxHealth;
       
    }
}
