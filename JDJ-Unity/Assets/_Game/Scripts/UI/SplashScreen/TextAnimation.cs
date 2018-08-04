using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour {

    private RectTransform rect;
    private Vector3 initialScale;

    private float angle = 0.0f;
    private float timer = 0.0f;
    public float animationTimer;
    public float speed;
    public float increaseSize;
    public float acceleration;

    // Use this for initialization
    void Start () {
        rect = GetComponent<RectTransform>();
        initialScale = rect.localScale;
        timer = animationTimer;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer > 0.0f)
        {
            angle += (speed * Time.deltaTime);
            speed += (acceleration*Time.deltaTime);
            if(speed < 0)
            {
                speed = 0.0f;
            }
            float percent = timer / animationTimer;
            percent *= increaseSize;
            float x = (((1.0f - Mathf.Sin(angle)) * percent) + 1.0f)*initialScale.x;
            float y = (((1.0f - Mathf.Cos(angle)) * percent) + 1.0f)*initialScale.y;
            rect.localScale = new Vector3(x,y,initialScale.z);

        }


    }
}
