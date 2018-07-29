using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSign : IClickable
{
    public override void OnClickObject()
    {
        SceneManager.LoadScene("Main");
    }
}
