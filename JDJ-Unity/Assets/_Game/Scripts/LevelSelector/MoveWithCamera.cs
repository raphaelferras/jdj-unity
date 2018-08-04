using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCamera : MonoBehaviour {

    public float initialCamPos = 0.0f;
    public float finalCamPos = 0.0f;
    public Vector3 initialObjectPos;
    public Vector3 finalObjectPos;

    public bool useScenePositionAsInitial;

    private float deltaPos;
    // Use this for initialization
    void Start () {
        if (useScenePositionAsInitial)
        {
            initialObjectPos = gameObject.transform.localPosition;
        }
        deltaPos = finalCamPos - initialCamPos;

    }
	
	// Update is called once per frame
	void Update () {
        float camPos = CameraController.Instance.position;
        if(camPos < initialCamPos)
        {
            gameObject.transform.localPosition = initialObjectPos;
        } else if (camPos > finalCamPos)
        {
            gameObject.transform.localPosition = finalObjectPos;
        }
        else
        {
            gameObject.transform.localPosition = initialObjectPos + ((finalObjectPos - initialObjectPos) * ((camPos - initialCamPos) / deltaPos)); 
        }
    }
}
