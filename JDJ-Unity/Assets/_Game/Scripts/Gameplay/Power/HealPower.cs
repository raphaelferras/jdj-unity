using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPower : MonoBehaviour {

    public int healValue;

	// Use this for initialization
	void Start () {
        MoveInLane mil = GetComponent<MoveInLane>();
        GameMode.Instance.lanes.Heal(mil.lane, mil.lanesSize, healValue);
        Destroy(this.gameObject);
    }
}
