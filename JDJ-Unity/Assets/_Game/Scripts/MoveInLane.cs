using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInLane : MonoBehaviour {

    public float speed;
    public int lanesSize = 1;
    public int lane;
    public float position;
    public float lanePos;
    private float endPos;
    private float startPos;
    private float yPosition;

    private Monster monster;

    public bool lastMoveSet;

    private void Start()
    {
        startPos = GameMode.Instance.startLanePosition;
        position = startPos ;
        endPos = GameMode.Instance.endLanePosition;
        lanePos = GameMode.Instance.lanes.GetXPosition(lane, lanesSize);
        yPosition = GameMode.Instance.floorHeight;
        this.transform.position = new Vector3(lanePos, yPosition, position);
        monster = GetComponent<Monster>();
        lastMoveSet = true;

        if (monster != null)
        {
            monster.SetMove(true);
        }
    }

    private void Update()
    {
        position -= speed;
        if (position < endPos)
        {
            position = endPos;
            if (monster != null)
            {
                if (lastMoveSet != false)
                {
                    monster.SetMove(false);
                    lastMoveSet = false;
                }
                monster.Attack();
            }
        }
        else
        {
            if (lastMoveSet != true && monster != null)
            {
                monster.SetMove(true);
                lastMoveSet = true;
            }
        }

        if (position >= startPos)
        {
            position = startPos;

        }
        this.transform.position = new Vector3(lanePos, yPosition, position);
    }
}
