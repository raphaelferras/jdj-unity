using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int hp;
    public UnityEvent healthChanged;
    public UnityEvent death;

	void Start () {
        hp = maxHealth;
	}

    public void AddHit(int value)
    {
        if(value != 0)
        {
            hp -= value;
            hp = Mathf.Clamp(hp, 0, maxHealth);
            NotifyLifeChanged();
        }
    }

    private void NotifyLifeChanged()
    {
        if(healthChanged != null)
        {
            healthChanged.Invoke();
        }
    }

    private void NotifyDeath()
    {
        if (death != null)
        {
            death.Invoke();
        }
    }

    public float GetPercent()
    {
        return ((float)hp) / maxHealth;
    }
}
