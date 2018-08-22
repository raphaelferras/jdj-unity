using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMenuLoad : MonoBehaviour {

    public static bool goToLevel = false;
    public static int next;
    public float finalSignPosition;
	void Start () {
        Time.timeScale = 1;

        CameraController.Instance.position = Persistance.data.saved.lastCameraPosition;
        if (goToLevel)
        {
            goToLevel = false;
            int level = next;

            if(level > LevelController.Instance.levelList.Count)
            {
                CameraController.Instance.SetTargetPosition(finalSignPosition);
            } else
            {
                CameraController.Instance.SetTargetPosition(LevelController.Instance.levelList[level-1].cameraPosition);
            }
        }
        else
        {
            CameraController.Instance.SetTargetPosition(Persistance.data.saved.lastCameraPosition);
        }
    }

}
