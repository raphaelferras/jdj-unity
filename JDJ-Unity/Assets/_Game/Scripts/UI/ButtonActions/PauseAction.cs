using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAction : MonoBehaviour {

    public void Pause ()
    {
        GameState.Instance.Pause();
    }
}
