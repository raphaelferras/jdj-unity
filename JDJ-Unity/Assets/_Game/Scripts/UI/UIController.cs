using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Singleton<UIController> {

    public GameObject pause_Panel;
    public GameObject HUD_Panel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateItensVisibility();
	}

    public void UpdateItensVisibility()
    {
        GameState.State currentState = GameState.Instance.CurrentState();
        pause_Panel.SetActive(currentState == GameState.State.PAUSE);
        HUD_Panel.SetActive(currentState == GameState.State.GAME);
    }
}
