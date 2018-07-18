using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : Singleton<GameMode> {

    public float startLanePosition;
    public float endLanePosition;
    public float floorHeight;

    public GameObject floorPrefab;
    public GameObject gridPrefab;
    public LanesController lanes;
    public GridController grid;

    private void Start()
    {
        lanes = Instantiate(floorPrefab).GetComponent<LanesController>();
        grid = Instantiate(gridPrefab).GetComponent<GridController>();
    }
}
