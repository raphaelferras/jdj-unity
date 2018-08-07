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
        OnMenuLoad.goToLevel = true;
        OnMenuLoad.next = GameMode.LevelToLoad.levelPosition + 1;
        SceneManager.LoadScene("Menu");
    }
}
