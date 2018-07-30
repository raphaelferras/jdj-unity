using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private GameObject enemyContainer;
    private float timer;
    private int currentMonster;
    private LevelConfig currentLevel;

    public List<GameObject> enemies;

    private void Start()
    {
        enemyContainer = new GameObject("EnemyContainer");
        timer = 0.0f;
        currentMonster = 0;
        currentLevel = GameMode.LevelToLoad;
    }

    // Update is called once per frame
    void Update () {
        enemies.RemoveAll(item => item == null);
        timer += Time.deltaTime;

        while(currentMonster < currentLevel.monsterList.Count &&  timer > currentLevel.monsterList[currentMonster].spawnTime)
        {
            SpawnEnemy(currentLevel.monsterList[currentMonster].monster.prefab,
                currentLevel.monsterList[currentMonster].possibleLanes[Random.Range(0, currentLevel.monsterList[currentMonster].possibleLanes.Count)]);
            currentMonster++;
        }
        if (currentMonster >= currentLevel.monsterList.Count && enemies.Count == 0) {
            GameState.Instance.Win();
            Destroy(this);
        }
    }

    private void SpawnEnemy(GameObject prefab, int lane)
    {
        GameObject enemy = Instantiate(prefab, enemyContainer.transform );
        MoveInLane mil = enemy.GetComponent<MoveInLane>();
        mil.lane = lane;
        enemies.Add(enemy);
    }
}
