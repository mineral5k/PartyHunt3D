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
    public int baseReward;
    public int reward;
    public bool isDead = false;
    public bool isOver=false;


    public float maxHealth;
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
    public Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        maxHealth = baseHealth * Mathf.Pow(1.2f,GameManager.Instance.stageLevel);
        deffense = baseDeffense * Mathf.Pow(1.2f, GameManager.Instance.stageLevel);
        attack = baseAttack * Mathf.Pow(1.2f, GameManager.Instance.stageLevel);
        reward = (int)Math.Round(baseReward *  Mathf.Pow(1.2f, GameManager.Instance.stageLevel));

        curHealth = maxHealth;

        StartCoroutine(NormalAttack());
        StartCoroutine(CheckLoop());            // ���� �������� ���� ���� ������ ������ �ʴ� ��Ȳ�� �����ϴ� �ڵ�
    }

    IEnumerator NormalAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(((float)(new Random().Next(100, 111))) / 100);      // 1.0~1.1 �� ���̿� �����ϰ� ����
            GetTarget()?.GetAttacked();
            animator.SetTrigger("Attack");
        }
    }

    Character GetTarget()
    {
        int i;
        for (i=0; i<2;i++)
        {
            if (characters[i] != null) return characters[i];                    // ��Ŀ, ����, ������ �켱������ ����
        }
        GameManager.Instance.gold += (int)Mathf.Round(reward * 0.5f);
        if (!isOver)
        {
            GameManager.Instance.GameOver();                                        // ��Ŀ, ������ ���� => ������ �������Ƿ� ���� ���� (������ ���� ���� ������ �������� ���ӵǴ°� ���� ����)
            isOver = true;
        }
        return null;
            
    }

    public void Attack(Character character, float attack)
    {
        
        if ((character == null) || isDead ) return;
        float damage = attack - character.deffense;
        if (damage < 0) damage = 0f;
        character.CurHealth -= damage;
    }

    public void Die()
    {
        if(isDead) return; 
        isDead = true;
        animator.SetTrigger("Death");
        GameManager.Instance.gold += reward;
        GameManager.Instance.GameClear();
    }

    IEnumerator CheckLoop()              // ���� �������� ���� ���� ������ ������ �ʴ� ��Ȳ�� �����ϴ� �ڵ�
    {
        while(true)
        {
            float hp1 = CurHealth;
            yield return new WaitForSeconds(10f);
            float hp2 = CurHealth;

            if (hp1 == hp2)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
