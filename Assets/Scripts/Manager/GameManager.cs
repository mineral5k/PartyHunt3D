using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data
{
    public int stageLevel = 0;
    public int gold = 0;

    public int TankerHealthLevel = 0;
    public int TankerAttackLevel = 0;
    public int TankerDeffenseLevel = 0;
    public bool isTankerSkillPurchased = false;

    public int DealerHealthLevel = 0;
    public int DealerAttackLevel = 0;
    public int DealerDeffenseLevel = 0;
    public bool isDealerSkillPurchased = false;


    public int HealerHealthLevel = 0;
    public int HealerAttackLevel = 0;
    public int HealerDeffenseLevel = 0;
    public bool isHealerSkillPurchased = false;
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Data data = new Data();
    public int stageLevel 
    {
        get { return data.stageLevel; }
        set { data.stageLevel = value; }
    }
    public int gold
    {
        get { return data.gold; }
        set { data.gold = value; }
    }

    public int TankerHealthLevel
    {
        get { return data.TankerHealthLevel; }
        set { data.TankerHealthLevel = value; }
    }
    public int TankerAttackLevel 
    {
        get { return data.TankerAttackLevel; }
        set {data.TankerAttackLevel = value; }
    }
    public int TankerDeffenseLevel
    {
        get { return data.TankerDeffenseLevel; }
        set { data.TankerDeffenseLevel = value; }
    }
    public bool isTankerSkillPurchased
    {
        get { return data.isTankerSkillPurchased; }
        set {data.isTankerSkillPurchased = value; }
    }

    public int DealerHealthLevel
    {
        get { return data.DealerHealthLevel; }
        set {data.DealerHealthLevel = value; }
    }
    public int DealerAttackLevel
    {
        get { return data.DealerAttackLevel; }
        set {data.DealerAttackLevel = value; }
    }
    public int DealerDeffenseLevel
    {
        get { return data.DealerDeffenseLevel; }
        set {data.DealerDeffenseLevel = value; }
    }
    public bool isDealerSkillPurchased
    {
        get { return data.isDealerSkillPurchased; }
        set { data.isDealerSkillPurchased = value; }
    }


    public int HealerHealthLevel
    {
        get { return data.HealerHealthLevel; }
        set {data.HealerHealthLevel = value; }
    }
    public int HealerAttackLevel
    {
        get { return data.HealerAttackLevel; }
        set {data.HealerAttackLevel = value; }
    }
    public int HealerDeffenseLevel
    {
        get { return data.HealerDeffenseLevel; }
        set { data.HealerDeffenseLevel = value; }
    }
    public bool isHealerSkillPurchased
    {
        get { return data.isHealerSkillPurchased; }
        set {data.isHealerSkillPurchased = value; }
    }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (File.Exists(Application.persistentDataPath + "/UserData.txt"))
            {
                Load();
            }
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
        Invoke("Restart", 0.5f);
        Save();
    }

    public void GameClear()
    {
        stageLevel++;
        Invoke("Restart", 2.5f);
        Save();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Save()
    {
      
        var saveData = JsonUtility.ToJson(data);

        Debug.Log(saveData);

        Debug.Log(Application.persistentDataPath + "/UserData.txt");
        File.WriteAllText(Application.persistentDataPath + "/UserData.txt", saveData);
    }

    public void Load()
    {
        string loadData = File.ReadAllText(Application.persistentDataPath + "/UserData.txt");

        data = JsonUtility.FromJson<Data>(loadData);


        
    }
}
