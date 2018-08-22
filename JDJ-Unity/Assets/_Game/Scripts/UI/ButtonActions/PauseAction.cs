using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAction : MonoBehaviour {

    private void Update()
    {
        // Get back button to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameState.Instance.Pause();
        }
    }

    public void Pause ()
    {
        GameState.Instance.Pause();
    }
}
