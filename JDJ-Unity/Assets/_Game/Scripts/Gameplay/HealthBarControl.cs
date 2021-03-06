﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour {
    private Health health;
    private Slider slider;
    private GameObject sliderObj;
    public Vector3 healthbarDeltaPosition;
	// Use this for initialization
	void Start () {
        sliderObj = Instantiate(GameMode.Instance.defaultHealthBar, this.transform);
        sliderObj.GetComponent<RectTransform>().localPosition += healthbarDeltaPosition;
        slider = sliderObj.GetComponentInChildren<Slider>();
        health  = GetComponent<Health>();
        health.healthChanged.AddListener(HealthValueChanged);
        float p = health.GetPercent();
        if (p > 0.999f || p < 0.0001f)
        {
            sliderObj.SetActive(false);
        } else
        {
            sliderObj.SetActive(true);
        }
        slider.value = p;
    }
	
	private void HealthValueChanged()
    {
        float p = health.GetPercent();
        if (p > 0.999f || p < 0.0001f)
        {
            sliderObj.SetActive(false);
        }
        else
        {
            sliderObj.SetActive(true);
        }
        slider.value = p;
    }
}
