using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMenuLoad : MonoBehaviour {

	void Start () {
        Time.timeScale = 1;
        CameraController.Instance.position = Persistance.data.saved.lastCameraPosition;
        CameraController.Instance.SetTargetPosition(Persistance.data.saved.lastCameraPosition);
    }

}
