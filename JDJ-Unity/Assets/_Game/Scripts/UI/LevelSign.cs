using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSign : IClickable
{
    public LevelConfig level;

    public override void OnClickObject()
    {
        GameMode.LevelToLoad = level;
        SceneManager.LoadScene("Main");
    }
}
