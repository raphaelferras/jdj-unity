using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyController : MonoBehaviour {

    private float jellySize;
    private Vector3 nextPosition;
    public PowerConfig type;
    private RectTransform rect;
    private float jellySpeed;
    public bool isMoving = false;
    private void Awake()
    {
        jellySize = GameMode.Instance.jellySize;
        jellySpeed = GameMode.Instance.JellySpeed;
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(jellySize, jellySize);
        isMoving = false;
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (!isMoving)
        {
            return;
        }
        Vector3 direction = nextPosition - rect.localPosition;
        float value = jellySpeed * Time.deltaTime;
        if (direction.magnitude > jellySpeed)
        {
            direction = direction.normalized * jellySpeed;
        } else
        {
            isMoving = false;
        }

        rect.localPosition = rect.localPosition + direction;

    }

    public void MoveTo(Vector3 position)
    {
        nextPosition = position;
        isMoving = true;
    }

    public void SetPosition(Vector3 position)
    {
        rect.localPosition = position;
        nextPosition = position;
        isMoving = false;
    }


}
