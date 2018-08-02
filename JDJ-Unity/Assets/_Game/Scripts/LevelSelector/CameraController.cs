using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController> {

    CinemachineSmoothPath path;
    private GameObject cam;
    private float position = 0f;
    private float targetPosition = 0f;
    private Vector3 direction ;
    private float targetDirection;

    public float hysteresis;

    // Use this for initialization
    void Start () {
        path = GetComponent<CinemachineSmoothPath>();
        cam = Camera.main.gameObject;
        cam.transform.position = path.EvaluatePosition(position);
        cam.transform.forward = path.EvaluatePosition(position + 0.01f) - cam.transform.position;
    }

    private void Update()
    {
        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        position += (targetPosition - position) * hysteresis;

        cam.transform.position = path.EvaluatePosition(position);
        Quaternion rot = Quaternion.LookRotation(path.EvaluatePosition(position + 0.01f) - cam.transform.position);
        Vector3 euler = rot.eulerAngles;
        cam.transform.rotation = Quaternion.Euler(20, euler.y, euler.z);

    }

    public void SetPosition(float delta)
    {
        targetPosition += delta;
        if(targetPosition < path.MinPos)
        {
            targetPosition = path.MinPos;
        } 
        if(targetPosition > path.MaxPos) {
            targetPosition = path.MaxPos;

        }
        //cam.m_PathPosition += delta;
    }
}
