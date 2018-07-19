using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JDJ/Power")]
public class PowerConfig : ScriptableObject {

    public GameObject prefab;
    public GameObject grid;

    public JellyController InstantiateGrid(Transform parent)
    {
        JellyController j = Instantiate(grid, parent).GetComponent<JellyController>();
        j.type = this;
        return j;
    }
}
