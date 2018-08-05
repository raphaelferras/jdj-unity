using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float swipeSpeed = 0.1f;
    public float maxTimeForClick = 0.2f;
    public float maxDist = 0.2f;


    private Vector3 lastMousePosition;
    private bool isMoving = false;
    private float startMovingTime;

	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
            isMoving = true;
            startMovingTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastMousePosition = Input.mousePosition;
            if(Time.time - startMovingTime < maxTimeForClick && (lastMousePosition - Input.mousePosition).magnitude < maxDist)
            {
                HandleClick(lastMousePosition);
            }
            isMoving = false;
        }
        if (isMoving)
        {
            float delta = ((lastMousePosition - Input.mousePosition).y) * swipeSpeed;
            //Debug.Log(delta);
            CameraController.Instance.SetPosition(delta);
            lastMousePosition = Input.mousePosition;
        }


    }

    private void HandleClick(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        // Create a particle if hit
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            IClickable obj = hitInfo.collider.GetComponent<IClickable>();
            if (obj != null)
            {
                obj.OnClickObject();
            }
        }
            
    }
}
