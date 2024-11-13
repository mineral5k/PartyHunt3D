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
        data.stageLevel = stageLevel;
        data.gold = gold;

        data.TankerHealthLevel = TankerDeffenseLevel;
        data.TankerAttackLevel = TankerAttackLevel;
        data.TankerDeffenseLevel = TankerDeffenseLevel;
        data.isTankerSkillPurchased = isTankerSkillPurchased;

        data.DealerHealthLevel = DealerHealthLevel;
        data.DealerAttackLevel = DealerAttackLevel;
        data.DealerDeffenseLevel = DealerDeffenseLevel;
        data.isDealerSkillPurchased = isDealerSkillPurchased;


        data.HealerHealthLevel = HealerHealthLevel;
        data.HealerAttackLevel = HealerAttackLevel;
        data.HealerDeffenseLevel = HealerDeffenseLevel;
        data.isHealerSkillPurchased = isHealerSkillPurchased;

        var saveData = JsonUtility.ToJson(data);

        Debug.Log(saveData);

        Debug.Log(Application.persistentDataPath + "/UserData.txt");
        File.WriteAllText(Application.persistentDataPath + "/UserData.txt", saveData);
    }

    public void Load()
    {
        string loadData = File.ReadAllText(Application.persistentDataPath + "/UserData.txt");

        data = JsonUtility.FromJson<Data>(loadData);


        stageLevel = data.stageLevel;
        gold = data.gold;

        TankerHealthLevel = data.TankerHealthLevel;
        TankerAttackLevel = data.TankerAttackLevel;
        TankerDeffenseLevel = data.TankerDeffenseLevel;
        isTankerSkillPurchased = data.isTankerSkillPurchased;

        DealerHealthLevel = data.DealerHealthLevel;
        DealerAttackLevel = data.DealerAttackLevel;
        DealerDeffenseLevel = data.DealerDeffenseLevel;
        isDealerSkillPurchased = data.isDealerSkillPurchased;


        HealerHealthLevel = data.HealerHealthLevel;
        HealerAttackLevel = data.HealerAttackLevel;
        HealerDeffenseLevel = data.HealerDeffenseLevel;
        isHealerSkillPurchased = data.isHealerSkillPurchased;
    }
}
