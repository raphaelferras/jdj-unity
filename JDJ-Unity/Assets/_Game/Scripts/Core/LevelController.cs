using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public List<LevelConfig> levelList;
    
    public LevelConfig lastLoaded;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Initialize();
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void Initialize()
    {
        int position = 1;
        LevelConfig previous = null;
        foreach (LevelConfig lc in levelList)
        {
            lc.levelPosition = position;
            position++;
            if (previous != null)
            {
                previous.nextLevel = lc;
            }
            previous = lc;
        }
        previous.nextLevel = null;
    }

    public int CurrentLevel()
    {
        return Persistance.data.GetCurrentLevel();
    }

    public LevelConfig LastLoadedLevel()
    {
        return lastLoaded;
    }

    public void PlayLevel(int id)
    {
        if( id <= CurrentLevel())
        {
            Persistance.data.saved.lastCameraPosition = CameraController.Instance.position;
            GameMode.LevelToLoad = levelList[id-1];
            SceneManager.LoadScene("Main");
        } else
        {
            throw new Exception("You can not play this level " + id + "  maxLevel: " + CurrentLevel());
        }
    }

    public void LevelPassed(int id)
    {
        if (id == CurrentLevel())
        {
            Persistance.data.SetCurrentLevel(id+1);
        }
    }
}