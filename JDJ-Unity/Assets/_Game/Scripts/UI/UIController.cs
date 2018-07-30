using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Singleton<UIController> {

    public GameObject pausePanel;
    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject HUD_Panel;

	// Update is called once per frame
	void Update () {
        UpdateItensVisibility();
	}

    public void UpdateItensVisibility()
    {
        GameState.State currentState = GameState.Instance.CurrentState();
        pausePanel.SetActive(currentState == GameState.State.PAUSE);
        losePanel.SetActive(currentState == GameState.State.LOSE);
        winPanel.SetActive(currentState == GameState.State.WIN);
        HUD_Panel.SetActive(currentState == GameState.State.GAME);
    }
}
