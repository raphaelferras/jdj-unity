using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSign : IClickable
{
    public int id;
    public GameObject padlocker;
    public bool isClickable = false;

   void Start()
    {
        if( id <= LevelController.Instance.CurrentLevel())
        {
            isClickable = true;
            padlocker.SetActive(false);
        } else
        {
            isClickable = false;
            padlocker.SetActive(true);
        }
    }

    public override void OnClickObject()
    {
        if (isClickable)
        {
            LevelController.Instance.PlayLevel(id);
        } else
        {
            TextAnimation ta = padlocker.GetComponent<TextAnimation>();
            ta.ResetTimer();
        }
    }
}
