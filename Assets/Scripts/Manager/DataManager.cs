using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/UserData.txt"))
        {
            Load();
        }
    }
    public void Save()
    {
        var saveData = JsonUtility.ToJson(this);

        Debug.Log(saveData);

        Debug.Log(Application.persistentDataPath + "/UserData.txt");
        File.WriteAllText(Application.persistentDataPath + "/UserData.txt", saveData);
    }

    public void Load()
    {
        string loadData = File.ReadAllText(Application.persistentDataPath + "/UserData.txt");

        GameManager gm = JsonUtility.FromJson<GameManager>(loadData);
    }
}
