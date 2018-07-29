using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : Singleton<GameMode> {

    public float startLanePosition;
    public float endLanePosition;
    public float floorHeight;
    public float jellySize;
    public float JellySpeed;
    public float jellyReplaceTimer;
    public GameObject defaultHealthBar;

    public GameObject floorPrefab;
    public LanesController lanes;
    public GridController grid;

    private void Start()
    {
        lanes = Instantiate(floorPrefab).GetComponent<LanesController>();
    }
}
