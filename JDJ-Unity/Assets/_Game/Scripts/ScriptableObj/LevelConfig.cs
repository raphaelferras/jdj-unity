using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterInfo
{
    public MonsterConfig monster;
    public List<int> possibleLanes;
    public float spawnTime;
}

[CreateAssetMenu(menuName = "JDJ/Level")]
public class LevelConfig : ScriptableObject
{
    public LevelConfig nextLevel;
    public List<MonsterInfo> monsterList;
}
