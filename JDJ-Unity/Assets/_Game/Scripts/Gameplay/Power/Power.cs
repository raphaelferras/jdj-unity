using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

    public int damage;
    private PowerHitInfo powerHitInfo;

    private void Start()
    {
        powerHitInfo = new PowerHitInfo();
        powerHitInfo.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        IHitable ih = other.gameObject.GetComponent<IHitable>();
        if (ih != null)
        {
            ih.Hit(powerHitInfo);
            Destroy(this.gameObject);
        }
    }
}
