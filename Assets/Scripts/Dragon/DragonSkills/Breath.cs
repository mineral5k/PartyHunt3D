using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Breath : MonoBehaviour
{

    Dragon dragon;

    private void Awake()
    {
        dragon = gameObject.GetComponent<Dragon>();
    }

    private void Start()
    {
        StartCoroutine(BreathAttack());
    }
    IEnumerator BreathAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(new Random().Next(4,7));
            dragon.animator.SetTrigger("Breath");
            yield return new WaitForSeconds(1.2f);
            dragon.Attack(dragon.characters[0], dragon.attack * 0.5f);
            dragon.Attack(dragon.characters[1], dragon.attack * 0.5f);
            dragon.Attack(dragon.characters[2], dragon.attack * 0.5f);
        }
    }
}
