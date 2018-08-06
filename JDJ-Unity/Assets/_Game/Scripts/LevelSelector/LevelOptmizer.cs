using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapEnabledInterval
{
    public GameObject mapContainer;
    public float startPosition;
    public float endPosition;
}

public class LevelOptmizer : MonoBehaviour {

    public List<MapEnabledInterval> mapEnable;

	
	// Update is called once per frame
	void Update () {
        CheckIfHaveToEnable();
	}

    private void CheckIfHaveToEnable()
    {
        float camPosition = CameraController.Instance.position;
        foreach(MapEnabledInterval me in mapEnable)
        {
            if(camPosition > me.startPosition && camPosition < me.endPosition)
            {
                me.mapContainer.SetActive(true);
            } else
            {
                me.mapContainer.SetActive(false);
            }
        }
    }
}
