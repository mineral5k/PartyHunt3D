using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int stageLevel = 1;
    public int gold = 0;

    [Header("Tanker Level")]
    public int TankerHealthLevel = 0;
    public int TankerAttackLevel = 0;
    public int TankerDeffenseLevel = 0;

    [Header("Dealer Level")]
    public int DealerHealthLevel = 0;
    public int DealerAttackLevel = 0;
    public int DealerDeffenseLevel = 0;

    [Header("Healer Level")]
    public int HealerHealthLevel = 0;
    public int HealerAttackLevel = 0;
    public int HealerDeffenseLevel = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(Instance != null )
            {
                Destroy(gameObject);
            }
        }
    }

    public void GameOver()
    {
        stageLevel--;
        SceneManager.LoadScene("SampleScene");
    }

    public void GameClear()
    {
        stageLevel++;
        SceneManager.LoadScene("SampleScene");
    }
   
}
