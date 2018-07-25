using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController> {

    CinemachineSmoothPath path;
    private GameObject cam;
    float position = 0f;
	// Use this for initialization
	void Start () {
        path = GetComponent<CinemachineSmoothPath>();
        cam = Camera.main.gameObject;
        cam.transform.position = path.EvaluatePosition(position);

    }

    public void SetPosition(float delta)
    {
        position += delta;
        if(position < path.MinPos)
        {
            position = path.MinPos;
        } 
        if(position> path.MaxPos) {
            position = path.MaxPos;

        }
        cam.transform.position = path.EvaluatePosition(position);
        //cam.m_PathPosition += delta;
    }
}
