using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : Singleton<GameMode> {

    public static LevelConfig LevelToLoad { get; set; }


    public float startLanePosition;
    public float endLanePosition;
    public float floorHeight;
    public float jellySize;
    public float JellySpeed;
    public float jellyReplaceTimer;
    public GameObject defaultHealthBar;

    public LevelConfig defaultLevel;

    public GameObject floorPrefab;
    public LanesController lanes;
    public GridController grid;


    private void Awake()
    {
        if (LevelToLoad == null)
        {
            LevelToLoad = defaultLevel;
        }
    }

    private void Start()
    {

        lanes = Instantiate(floorPrefab).GetComponent<LanesController>();

    }
}
