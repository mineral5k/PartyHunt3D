using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHPBar : MonoBehaviour
{
    public Character character;
    public Image characterHPBar;

    private void Awake()
    {
        characterHPBar = GetComponent<Image>();
    }

    private void Update()
    {
        characterHPBar.fillAmount = character.healthPercent;
    }
}
