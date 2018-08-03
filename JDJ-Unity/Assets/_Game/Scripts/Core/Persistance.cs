using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class SavedData
{
    public int currentLevel;
    public int coins;
}

public class Persistance : MonoBehaviour {

    public int GetCurrentLevel()
    {
        return saved.currentLevel;
    }


    public static Persistance data;

    public String filePath;

    public SavedData saved;

    // Use this for initialization
    void Awake () {
		if (data == null)
        {
            filePath = Application.persistentDataPath + "/saveddata.dat";
            DontDestroyOnLoad(gameObject);
            data = this;
            LoadData();
        } else if (data != this)
        {
            Destroy(gameObject); 
        }
	}
	
	private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        bf.Serialize(file, saved);
        file.Close();
    }

    private void LoadData()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);

            saved = (SavedData)bf.Deserialize(file);
            file.Close();
        } else
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        saved = new SavedData();
        saved.currentLevel = 1;
        saved.coins = 0;
    }

    private void OnDestroy()
    {
        Save();
    }
}
