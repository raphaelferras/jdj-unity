using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public void Start()
    {
        if(GameMode.LevelToLoad.nextLevel == null)
        {
            Destroy(this.gameObject);
        }
    }

    public void GoToNextLevel()
    {
        GameMode.LevelToLoad = GameMode.LevelToLoad.nextLevel;

        SceneManager.LoadScene("Main");

    }
}
