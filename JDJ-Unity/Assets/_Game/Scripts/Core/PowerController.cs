using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : Singleton<PowerController> {

    public GameObject power;

    public void Spawn(int lane, PowerConfig type)
    {
        GameObject p = Instantiate(type.prefab);
        MoveInLane mil = p.GetComponent<MoveInLane>();
        mil.lane = lane;
    }
}
