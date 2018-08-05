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
    public float lastCameraPosition;
    public int coins;
}

public class Persistance : MonoBehaviour {

    public static Persistance data;

    public const String filePath = "/saveddata.dat";

    public SavedData saved;

    // Use this for initialization
    void Awake () {
		if (data == null)
        {
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
        FileStream file = File.Create(Application.persistentDataPath + filePath);

        bf.Serialize(file, saved);
        file.Close();
    }

    private void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + filePath, FileMode.Open);

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

    public int GetCurrentLevel()
    {
        return saved.currentLevel;
    }

    public void SetCurrentLevel(int levelId)
    {
        if(levelId == saved.currentLevel + 1)
        {
            saved.currentLevel = levelId;
            Save();
        }
    }
}
