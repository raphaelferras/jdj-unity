using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

    public GameObject exitWindow;
	
	// Update is called once per frame
	void Update () {
        // Get back button to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitWindow.SetActive(!exitWindow.activeSelf);
        }
    }

    public void HidePopUpMenu()
    {
        exitWindow.SetActive(false);
    }

    public void ExitGAme()
    {
        Application.Quit();
    }
}
