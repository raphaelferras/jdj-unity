using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : Singleton<GameState> {

    public enum State { GAME, PAUSE, WIN, LOSE};

    private State currentState;

    // Use this for initialization
    void Start () {
        currentState = State.GAME;
    }
	
    public State CurrentState()
    {
        return currentState;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        currentState = State.PAUSE;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        currentState = State.GAME;
    }

    public void Win()
    {
        currentState = State.WIN;
    }

    public void Lose()
    {
        currentState = State.LOSE;
    }
}
