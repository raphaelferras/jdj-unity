using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesController : MonoBehaviour {

    public int lanesCount;

    public GameObject lanePrefab;
    public GameObject lanePrefab2;
    public float startPos = -2.5f;
    public float zposition = 25.5f;
    private float delta;
    // Use this for initialization
    void Start () {
        float x = startPos;
        delta = (startPos * -2)/(lanesCount-1);
		for (int i =0; i < lanesCount; i++, x+= delta)
        {
            GameObject lane;
            if(i %2 == 0) {
                lane = Instantiate(lanePrefab, this.transform);
            } else
            {
                lane = Instantiate(lanePrefab2, this.transform);
            }
            Vector3 pos = lane.transform.position;
            pos.Set(x, pos.y, zposition);
            lane.transform.position = pos;
            Vector3 scale = lane.transform.localScale;
            scale.Set(delta, scale.y, scale.z);
            lane.transform.localScale = scale;
        }
    }


    public float GetXPosition(int lane)
    {
        return startPos + lane * delta;
    }
}
