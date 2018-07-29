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
    public bool isSelected = false;
    public RectTransform animateRect;
    private Vector3 initialScale;
    private float value;
    public float deltaSize;
    private bool isIncreasing;

    private void Awake()
    {
        jellySize = GameMode.Instance.jellySize;
        jellySpeed = GameMode.Instance.JellySpeed;
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(jellySize, jellySize);
        isMoving = false;
        initialScale = animateRect.localScale;
        isIncreasing = true;
    }

    private void Update()
    {
        UpdatePosition();
        SelectedAnimation();
    }

    private void UpdatePosition()
    {
        if (!isMoving)
        {
            return;
        }
        Vector3 direction = nextPosition - rect.localPosition;
        float value = jellySpeed * Time.deltaTime;
        if (direction.magnitude > value)
        {
            direction = direction.normalized * value;
        } else
        {
            isMoving = false;
        }

        rect.localPosition = rect.localPosition + direction;

    }

    private void SelectedAnimation()
    {
        if (!isSelected)
        {
            value = 1.0f;
            animateRect.localScale = initialScale;
            return;
        }
        if (isIncreasing)
        {
            value +=Time.deltaTime;
            if(value >= 1.0f + deltaSize)
            {
                isIncreasing = false;
            }
        }
        else
        {
            value -= Time.deltaTime;
            if (value <= 1.0f)
            {
                isIncreasing = true;
            }
        }

        animateRect.localScale = initialScale * value;
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

    public void SetSelected(bool value)
    {
        isSelected = value;
    }

}
