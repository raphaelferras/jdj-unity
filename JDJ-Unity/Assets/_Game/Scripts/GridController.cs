using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

    public int colunsCount;
    public int rowsCount;
    private int leftPosition;
    public int topPosition;
    public int jellySize;

    public GameObject possibleJelly;

    // Use this for initialization
    void Start () {
        leftPosition = ((colunsCount-1) * jellySize / 2);
        leftPosition *= -1;
        int x = leftPosition;
        int y = topPosition;
        for (int i = 0; i < rowsCount; i++, y -= jellySize)
        {
            for(int j =0; j < colunsCount; j++, x += jellySize)
            {
                GameObject jelly = Instantiate(possibleJelly, this.transform);
                RectTransform r = jelly.GetComponent<RectTransform>();
                r.localPosition = new Vector3(x, y, 0);//, new Quaternion());
            }
            x = leftPosition;
        }
	}
	
    private void CreateNewPosition(int x, int y)
    {

    }

	// Update is called once per frame
	void Update () {
		
	}
}
