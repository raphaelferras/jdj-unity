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
    public bool power;
    public float wallPosition;

    private void Start()
    {
        startPos = GameMode.Instance.startLanePosition;
        if (power)
        {
            position = GameMode.Instance.endLanePosition;
        }
        else
        {
            position = GameMode.Instance.startLanePosition;
        }
        endPos = GameMode.Instance.endLanePosition;
        lanePos = GameMode.Instance.lanes.GetXPosition(lane, lanesSize);
        wallPosition = GameMode.Instance.lanes.zWallPosition;
        yPosition = GameMode.Instance.floorHeight;
        this.transform.position = new Vector3(lanePos, yPosition, position);
        monster = GetComponent<Monster>();
        lastMoveSet = true;

        if (monster != null)
        {
            monster.SetMove(true);
        }
        BoxCollider c = GetComponent<BoxCollider>();
        if (c != null)
        {
            float laneSize = GameMode.Instance.lanes.GetLaneSize();
            c.size = new Vector3(laneSize*lanesSize, laneSize * lanesSize, laneSize * lanesSize);
        }
    }

    private void Update()
    {
        float delta = speed * Time.deltaTime;
        if (position > wallPosition && position - delta < wallPosition && GameMode.Instance.lanes.HasWall(lane,lanesSize))
        {
            if (lastMoveSet != false)
            {
                monster.SetMove(false);
                lastMoveSet = false;
            }
            monster.AttackWall();
            return;
        }
        position -= delta;
        if (position <= endPos)
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
            if (power)
            {
                Destroy(this.gameObject);
            }
        }
        this.transform.position = new Vector3(lanePos, yPosition, position);
    }
}
