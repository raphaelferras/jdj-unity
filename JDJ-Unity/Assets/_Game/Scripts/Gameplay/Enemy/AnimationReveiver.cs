using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReveiver : MonoBehaviour {
    private Monster monster;

	// Use this for initialization
	void Start () {
        monster = transform.parent.GetComponent<Monster>();	
	}
	
	void AttackEvent() {
		if(monster != null)
        {
            monster.AttackEvent();
        }
	}
}
