using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStartAnimation : MonoBehaviour {

    public Vector3 startPosition;
    public Vector3 screenPosition;
    public Vector3 endPosition;

    public float goingDownTimer;
    public float stayTimer;
    public float upTimer;

    public float timer;
    public TextMeshProUGUI titleText;
    public string title;
    private RectTransform rect;

    // Use this for initialization
    void Start () {
        rect = GetComponent<RectTransform>();
        screenPosition = rect.localPosition;
        stayTimer += goingDownTimer;
        upTimer += stayTimer;
        timer = 0.0f;
        titleText.SetText(title + GameMode.LevelToLoad.levelPosition);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer < goingDownTimer)
        {
            float percentage = timer / goingDownTimer;
            rect.localPosition = startPosition + percentage*(screenPosition-startPosition) ;

        }
        else if (timer < stayTimer)
        {
            rect.localPosition = screenPosition;
        }
        else if (timer < upTimer)
        {
            float percentage = (timer-stayTimer) / (upTimer-stayTimer);
            rect.localPosition = screenPosition + percentage * (endPosition - screenPosition);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
