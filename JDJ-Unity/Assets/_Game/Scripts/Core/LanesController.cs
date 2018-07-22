using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesController : MonoBehaviour {

    public int lanesCount;

    public GameObject lanePrefab;
    public GameObject lanePrefab2;
    public GameObject highlight;
    public float startPos = -2.5f;
    public float zposition = 25.5f;
    private float delta;
    public GameObject floor;
    public GameObject wallPrefab;
    private GameObject[] lanes;
    private Wall[] walls;

    // Use this for initialization
    void Start () {
        lanes = new GameObject[lanesCount];
        walls = new Wall[lanesCount];
        float x = startPos;
        delta = (startPos * -2)/(lanesCount-1);
        float yPosition = GameMode.Instance.floorHeight;
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
            pos.Set(x, yPosition - 0.04f, zposition);
            lane.transform.position = pos;
            Vector3 scale = lane.transform.localScale;
            scale.Set(delta, scale.y, scale.z);
            lane.transform.localScale = scale;
            lanes[i] = lane;
            GameObject wall = Instantiate(wallPrefab, this.transform);
            Vector3 posWall = wall.transform.position;
            posWall.Set(x, posWall.y, posWall.z);
            wall.transform.position = posWall;
            walls[i] = wall.GetComponent<Wall>();
        }
        floor.transform.position = new Vector3(floor.transform.position.x, yPosition - 0.05f, floor.transform.position.z);
        highlight = Instantiate(highlight, this.transform);
        Vector3 pos2 = highlight.transform.position;
        pos2.Set(x, yPosition - 0.03f, zposition);
        highlight.transform.position = pos2;
        Vector3 scale2 = highlight.transform.localScale;
        scale2.Set(delta, scale2.y, scale2.z);
        highlight.transform.localScale = scale2;
        RemoveHightlight();
    }


    public float GetXPosition(int lane)
    {
        return startPos + lane * delta;
    }

    public float GetXPosition(int lane, int size)
    {
        return startPos + lane * delta + ((size-1) * delta)/2.0f;
    }

    public float GetLaneSize()
    {
        return delta;
    }

    public void Hightlight(int lane)
    {
        highlight.SetActive(true);
        Vector3 pos = highlight.transform.position;
        pos.Set(startPos+ lane*delta, pos.y, zposition);
        highlight.transform.position = pos;
    }

    public void RemoveHightlight()
    {
        highlight.SetActive(false);
    }

    public void Attack(int lane, int size, int damage)
    {
        for(int i = lane; i < lane+size; i++)
        {
            walls[i].Hit(damage);
        }
    }
}
