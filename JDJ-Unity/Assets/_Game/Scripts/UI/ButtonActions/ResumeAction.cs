using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeAction : MonoBehaviour {

    public void Resume()
    {
        GameState.Instance.Resume();
    }
}
