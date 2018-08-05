using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public RectTransform pointer;
    public bool isEnabled;

    public List<Vector3> path;
    public float speed;
    private float pos;

    // Use this for initialization
    void Start () {
        pos = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
        pos += speed * Time.deltaTime;
        if (pos > path.Count-1)
        {
            pos -= path.Count - 1;
        }
        int index = (int) pos;
        float percent = pos - index;
        pointer.position = path[index] + (path[index+1] - path[index]) * percent;
    }
}
