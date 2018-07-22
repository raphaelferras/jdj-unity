using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private Health health;
    public GameObject wallBottom;
    public GameObject wallTop;

    // Use this for initialization
    void Start () {
        health = GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(int damage)
    {
        health.AddHit(damage);
        UpdateFenceAnimation();

    }

    public void Heal(int heal)
    {
        health.AddHit(-heal);
        UpdateFenceAnimation();
    }

    public void UpdateFenceAnimation()
    {
        float percent = health.GetPercent();
        if(percent < 0.50f)
        {
            wallTop.SetActive(false);
        } else
        {
            wallTop.SetActive(true);
        }
        if (percent < 0.10f)
        {
            wallBottom.SetActive(false);
        }
        else
        {
            wallBottom.SetActive(true);
        }
    }
}
