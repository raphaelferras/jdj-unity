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
    private float animSpeed;
    public float increaseSize;
    public float acceleration;

    // Use this for initialization
    void Start () {
        rect = GetComponent<RectTransform>();
        initialScale = rect.localScale;
        ResetTimer();
    }
	
	// Update is called once per frame
	void Update () {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            angle += (animSpeed * Time.deltaTime);
            animSpeed += (acceleration*Time.deltaTime);
            if(animSpeed < 0)
            {
                animSpeed = 0.0f;
            }
            float percent = timer / animationTimer;
            percent *= increaseSize;
            float x = (((1.0f - Mathf.Abs(Mathf.Sin(angle))) * percent) + 1.0f)*initialScale.x;
            float y = (((1.0f - Mathf.Abs(Mathf.Cos(angle))) * percent) + 1.0f)*initialScale.y;
            rect.localScale = new Vector3(x,y,initialScale.z);
        }
    }

    public void ResetTimer()
    {
        timer = animationTimer;
        animSpeed = speed;
    }
}
