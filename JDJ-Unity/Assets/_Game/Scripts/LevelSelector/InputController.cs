using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    private Vector3 lastMousePosition;
    private bool isMoving = false;
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            float delta = (lastMousePosition - Input.mousePosition).y / 200.0f;
            //Debug.Log(delta);
            CameraController.Instance.SetPosition(delta);
        }
        lastMousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
            isMoving = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastMousePosition = Input.mousePosition;
            isMoving = false;
        }

        if (Input.touchCount > 0)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                // Move object across XY plane
                Debug.Log("Test!");
            }

        }
	}
}
