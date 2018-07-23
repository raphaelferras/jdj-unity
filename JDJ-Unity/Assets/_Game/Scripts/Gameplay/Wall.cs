using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private Health health;
    public GameObject wallBottom;
    public GameObject wallTop;

    private Vector3 wallTopInitialPosition;
    private Vector3 wallBottomInitialPosition;
    public GameObject particle;

    // Use this for initialization
    void Start () {
        health = GetComponent<Health>();
        wallTopInitialPosition = wallTop.transform.localPosition;
        wallBottomInitialPosition = wallBottom.transform.localPosition;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Hit(int damage)
    {
        GameObject obj = Instantiate(particle, this.transform.position + Vector3.up * Random.Range(-0.2f, 0.2f) +  Vector3.right * Random.Range(-0.1f, 0.1f), this.transform.rotation);
        obj.transform.localScale = obj.transform.localScale * (damage / 10.0f);
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
            wallTop.transform.localPosition = wallTopInitialPosition - ((wallTopInitialPosition - wallBottomInitialPosition) * (1-percent) * 2);
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
