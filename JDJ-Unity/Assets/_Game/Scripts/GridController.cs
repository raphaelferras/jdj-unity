using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {

    public int colunsCount;
    public int rowsCount;
    private float leftPosition;
    public int topPosition;
    private float jellySize;
    public List<PowerConfig> possibleJelly;
    public RectTransform backgound;
    private Rect bounds;
    private float replaceTimer;
    private JellyController[,] grid;

    // Use this for initialization
    void Start () {
        replaceTimer = -1;
        jellySize = GameMode.Instance.jellySize;
        leftPosition = ((colunsCount-1) * jellySize / 2);
        leftPosition *= -1;
        float x = leftPosition;
        float y = topPosition;
        grid = new JellyController[colunsCount, rowsCount];
        for (int i = 0; i < rowsCount; i++, y -= jellySize)
        {
            for(int j =0; j < colunsCount; j++, x += jellySize)
            {
                JellyController jelly = possibleJelly[Random.Range(0, possibleJelly.Count)].InstantiateGrid(this.transform);
                jelly.SetPosition(new Vector3(x, y, 0));
                grid[j, i] = jelly;
            }
            x = leftPosition;
        }
        backgound.localPosition = new Vector3(0, topPosition-((rowsCount-1)/2.0f)*jellySize, 0);
        backgound.sizeDelta = new Vector2(jellySize* colunsCount, jellySize* rowsCount);

        Vector2 size = Vector2.Scale(backgound.rect.size, backgound.lossyScale);
        bounds =  new Rect((Vector2)backgound.position - (size * 0.5f), size);
    }

    void Update()
    {
        CheckJellyReplace();
    }

    private void CheckJellyReplace()
    {
        if(replaceTimer > -1)
        {
            replaceTimer -= Time.deltaTime;
        }
        for (int y = rowsCount - 1; y >= 1; y--)
        {
            int startPosition = Random.Range(0, colunsCount);

            for (int _x = 0; _x < colunsCount; _x++)
            {
                int x = (_x + startPosition) % colunsCount;
                if (grid[x, y] == null)
                {
                    if (grid[x, y - 1] != null && !grid[x, y - 1].isMoving)
                    {
                        grid[x, y] = grid[x, y - 1];
                        grid[x, y - 1] = null;
                        grid[x, y].MoveTo(new Vector3(leftPosition + x * jellySize, topPosition - y * jellySize, 0));
                    }
                    else if (x > 0 && grid[x - 1, y - 1] != null && grid[x - 1, y] != null && !grid[x - 1, y - 1].isMoving)
                    {
                        grid[x, y] = grid[x - 1, y - 1];
                        grid[x - 1, y - 1] = null;
                        grid[x, y].MoveTo(new Vector3(leftPosition + x * jellySize, topPosition - y * jellySize, 0));
                    }
                    else if (x < colunsCount - 1 && grid[x + 1, y - 1] != null && grid[x + 1, y] && !grid[x + 1, y - 1].isMoving)
                    {
                        grid[x, y] = grid[x + 1, y - 1];
                        grid[x + 1, y - 1] = null;
                        grid[x, y].MoveTo(new Vector3(leftPosition + x * jellySize, topPosition - y * jellySize, 0));
                    }
                }
            }
        }
        if(replaceTimer < 0)
        {
            int startPosition = Random.Range(0, colunsCount);
            for (int _x = 0; _x < colunsCount; _x++)
            {
                int x = (_x + startPosition) % colunsCount;

                if (grid[x, 0] == null)
                {
                    JellyController jelly = possibleJelly[Random.Range(0, possibleJelly.Count)].InstantiateGrid(this.transform);
                    jelly.SetPosition(new Vector3(leftPosition + x * jellySize, topPosition + jellySize));
                    jelly.MoveTo(new Vector3(leftPosition + x * jellySize, topPosition));
                    grid[x, 0] = jelly;
                    replaceTimer = GameMode.Instance.jellyReplaceTimer;
                    return;
                }
            }
        }

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
            int x = (int)(((position.x - bounds.x) / bounds.width) * colunsCount);
            int y = (int)(((position.y - bounds.y) / bounds.height) * rowsCount);
            y = rowsCount - 1 - y;

            if (grid[x,y] != null)
            {
                PowerController.Instance.Spawn((int)x, grid[x, y].type);
                Destroy(grid[x, y].gameObject);
            }
            
            Debug.Log("x: " + x + "  y: " + y);
        }
    }
}
