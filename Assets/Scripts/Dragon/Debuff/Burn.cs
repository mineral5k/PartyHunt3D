using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDebuff
{

}

public class Burn : MonoBehaviour,IDebuff
{
    Character character;
    float time;
    private void Awake()
    {
        character = GetComponent<Character>();
        time = Time.time;
    }


    IEnumerator DotDamage()
    {
        while (Time.time - time >9.9f)
        {
            yield return new WaitForSeconds(0.5f);
            character.CurHealth -= character.dragon.attack * 0.1f;
        }

        Destroy(GetComponent<Burn>());
    }
}
