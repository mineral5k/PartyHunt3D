using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Dragon : MonoBehaviour
{
    public float baseHealth = 1000f;
    public float baseDeffense = 50f;
    public float baseAttack = 100f;
    public int baseReward = 1000;
    public int reward;


    private float maxHealth;
    public float curHealth;
    public float CurHealth
    {
        get { return curHealth; }
        set
        {
            curHealth = value;
            if (curHealth <= 0f) Die();
        }
    } 
    public float healthPercent => curHealth / maxHealth;
    public float deffense;
    public float attack;
    public Character[] characters = new Character[3];

    

    private void Start()
    {
        maxHealth = baseHealth * Mathf.Pow(1.2f,GameManager.Instance.stageLevel);
        deffense = baseDeffense * Mathf.Pow(1.2f, GameManager.Instance.stageLevel);
        attack = baseAttack * Mathf.Pow(1.2f, GameManager.Instance.stageLevel);
        reward = (int)Math.Round(baseReward *  Mathf.Pow(1.2f, GameManager.Instance.stageLevel));

        curHealth = maxHealth;

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(((float)(new Random().Next(100, 111))) / 100);      // 1.0~1.1 초 사이에 랜덤하게 실행
            GetTarget()?.GetAttacked();
        }
    }

    Character GetTarget()
    {
        int i;
        for (i=0; i<2;i++)
        {
            if (characters[i] != null) return characters[i];                    // 탱커, 딜러, 힐러의 우선순위로 공격
        }
        GameManager.Instance.GameOver();                                        // 탱커, 딜러가 없다 => 힐러만 남았으므로 게임 오버 (힐러의 힐로 인해 무한히 스테이지 지속되는걸 막기 위함)
        return null;
            
    }

    public void Die()
    {
        GameManager.Instance.gold += reward;
        GameManager.Instance.GameClear();
    }

   
}
