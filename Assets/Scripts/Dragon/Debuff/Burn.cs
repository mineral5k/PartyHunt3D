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
        
    }

    void Start()
    {
        StartCoroutine(DotDamage());
        StartCoroutine(TimeOver());
        time = Time.time;
    }

    IEnumerator DotDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("½ÇÇà");
            character.CurHealth -= character.dragon.attack * 0.05f;
        }       
    }

    IEnumerator TimeOver()
    {
        yield return new WaitForSeconds(5f);
        StopCoroutine(DotDamage());
        Destroy(GetComponent<Burn>());
    }
}
