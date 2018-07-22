using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ParticleSystem parts = GetComponent<ParticleSystem>();
        Destroy(this.gameObject, parts.main.duration);
    }
}
