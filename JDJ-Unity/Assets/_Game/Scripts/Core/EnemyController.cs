using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public List<GameObject> enemyList;

    public float deltaTime;
    private float timer;

    private void Start()
    {
        timer = deltaTime;
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer += deltaTime;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyList[Random.Range(0,enemyList.Count)]);
        MoveInLane mil = enemy.GetComponent<MoveInLane>();
        mil.speed *= Random.Range(0.8f,1.2f);
        mil.lane = Random.Range(0, GameMode.Instance.lanes.lanesCount + 1 - mil.lanesSize);
    }
}
