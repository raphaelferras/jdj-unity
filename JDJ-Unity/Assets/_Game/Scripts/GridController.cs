using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {

    public int colunsCount;
    public int rowsCount;
    private int leftPosition;
    public int topPosition;
    public int jellySize;
    public GameObject possibleJelly;
    public RectTransform backgound;
    private Rect bounds;

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
                r.localPosition = new Vector3(x, y, 0);
                r.sizeDelta = new Vector2(jellySize, jellySize);
            }
            x = leftPosition;
        }
        backgound.localPosition = new Vector3(0, topPosition-((rowsCount-1)/2.0f)*jellySize, 0);
        backgound.sizeDelta = new Vector2(jellySize* colunsCount, jellySize* rowsCount);

        Vector2 size = Vector2.Scale(backgound.rect.size, backgound.lossyScale);
        bounds =  new Rect((Vector2)backgound.position - (size * 0.5f), size);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = eventData.position;
        if (bounds.Contains(position))
        {
            float x = ((position.x - bounds.x) / bounds.width) * colunsCount;
            float y = ((position.y - bounds.y) / bounds.height) * rowsCount;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 position = eventData.position;
        if (bounds.Contains(position))
        {
            float x = ((position.x - bounds.x) / bounds.width) * colunsCount;
            float y = ((position.y - bounds.y) / bounds.height) * rowsCount;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector2 position = eventData.position;
        if (bounds.Contains(position))
        {
            float x = ((position.x - bounds.x) / bounds.width) * colunsCount;
            float y = ((position.y - bounds.y) / bounds.height) * rowsCount;
            PowerController.Instance.Spawn((int) x);
        }
    }
}
