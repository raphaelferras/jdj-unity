using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : Singleton<PowerController> {

    public GameObject power;

    public void Spawn(int lane, PowerConfig type, int count)
    {
        IEnumerator coroutine = CreateNewPower(lane,type,count);

        StartCoroutine(coroutine);
    }

    private IEnumerator CreateNewPower(int lane, PowerConfig type, int count)
    {
        for (int i =0; i < count; i++)
        {
            GameObject p = Instantiate(type.prefab);
            MoveInLane mil = p.GetComponent<MoveInLane>();
            mil.lane = lane;
            yield return new WaitForSeconds(.2f);
        }
    }
}
