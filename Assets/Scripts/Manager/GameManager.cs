using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int stageLevel = 1;

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
