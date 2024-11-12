using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Fireball : MonoBehaviour
{
    Dragon dragon;

    private void Awake()
    {
        dragon = gameObject.GetComponent<Dragon>();
    }

    private void Start()
    {
        StartCoroutine(FireBallAttack());
    }
    IEnumerator FireBallAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(new Random().Next(9, 12));
            BurningPlayer(dragon.characters[0]);
            BurningPlayer(dragon.characters[1]);
            BurningPlayer(dragon.characters[2]);
        }
    }

    void BurningPlayer(Character character)
    {
        if (character == null) return;
        character.gameObject.AddComponent<Burn>();
    }
}
