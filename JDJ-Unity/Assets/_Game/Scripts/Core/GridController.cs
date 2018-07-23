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
    private bool[,] selected;
    private PowerConfig selectedType;
    private int lastSelectedX;
    private int lastSelectedY;
    private int selectCount;
    public GameObject jellyContainer;
    public GameObject jellyCounter;

    // Use this for initialization
    void Start () {
        replaceTimer = -1;
        jellySize = GameMode.Instance.jellySize;
        leftPosition = ((colunsCount-1) * jellySize / 2);
        leftPosition *= -1;
        float x = leftPosition;
        float y = topPosition;
        grid = new JellyController[colunsCount, rowsCount];
        selected = new bool[colunsCount, rowsCount];
        for (int i = 0; i < rowsCount; i++, y -= jellySize)
        {
            for(int j =0; j < colunsCount; j++, x += jellySize)
            {
                JellyController jelly = possibleJelly[Random.Range(0, possibleJelly.Count)].InstantiateGrid(jellyContainer.transform);
                jelly.SetPosition(new Vector3(x, y, 0));
                grid[j, i] = jelly;
                selected[j, i] = false;
            }
            x = leftPosition;
        }
        backgound.localPosition = new Vector3(0, topPosition-((rowsCount-1)/2.0f)*jellySize, 0);
        backgound.sizeDelta = new Vector2(jellySize* colunsCount, jellySize* rowsCount);

        Vector2 size = Vector2.Scale(backgound.rect.size, backgound.lossyScale);
        bounds =  new Rect((Vector2)backgound.position - (size * 0.5f), size);
        selectCount = 0;
        jellyCounter.SetActive(false);
    }

    private void RemoveGridSelection()
    {
        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < colunsCount; j++)
            {
                if (selected[j, i])
                {
                    selected[j, i] = false;
                    grid[j, i].SetSelected(false);
                }
            }
        }
        selectCount = 0;
        GameMode.Instance.lanes.RemoveHightlight();
        jellyCounter.SetActive(false);

    }

    void Update()
    {
        if (GameState.Instance.CurrentState() != GameState.State.GAME)
        {
            return;
        }
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
                    JellyController jelly = possibleJelly[Random.Range(0, possibleJelly.Count)].InstantiateGrid(jellyContainer.transform);
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
        if (GameState.Instance.CurrentState() != GameState.State.GAME)
        {
            return;
        }
        if (selectedType != null)
        {
            HandleTouch(eventData);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameState.Instance.CurrentState() != GameState.State.GAME)
        {
            return;
        }
        HandleTouch(eventData);
    }

    private void HandleTouch(PointerEventData eventData)
    {
        Vector2 position = eventData.position;
        if (bounds.Contains(position))
        {
            int x, y;
            GetPosition(position, out x, out y);
            if (selectedType!= null && (Mathf.Abs(x-lastSelectedX) > 1 || Mathf.Abs(y - lastSelectedY) > 1))
            {
                return;
            }
            if (grid[x, y] != null && !grid[x, y].isMoving && !selected[x, y] && (selectedType == null || selectedType == grid[x, y].type))
            {
                lastSelectedX = x;
                lastSelectedY = y;
                selected[x, y] = true;
                selectCount++;
                grid[x, y].SetSelected(true);
                if (selectedType == null)
                {
                    selectedType = grid[x, y].type;
                }
                if(selectCount >= 3)
                {
                    GameMode.Instance.lanes.Hightlight(x);
                }
                jellyCounter.SetActive(true);
                jellyCounter.GetComponentInChildren<Text>().text = selectCount.ToString();
                jellyCounter.transform.position = grid[x, y].transform.position + Vector3.up*(jellySize / 2.0f);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (GameState.Instance.CurrentState() != GameState.State.GAME)
        {
            return;
        }
        if (selectedType != null)
        {
            if (selectCount >= 3)
            {
                PowerController.Instance.Spawn(lastSelectedX, selectedType, selectCount -2);
                ClearSelectedGrid();
            }
        }
        RemoveGridSelection();
        selectedType = null;
    }

    private void ClearSelectedGrid()
    {
        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < colunsCount; j++)
            {
                if (selected[j, i])
                {
                    selected[j, i] = false;
                    grid[j, i].SetSelected(false);
                    Destroy(grid[j, i].gameObject);
                }
            }
        }
        selectCount = 0;
    }

    private void GetPosition(Vector2 pos, out int x, out int y)
    {
        x = (int)(((pos.x - bounds.x) / bounds.width) * colunsCount);
        y = (int)(((pos.y - bounds.y) / bounds.height) * rowsCount);
        y = rowsCount - 1 - y;
    }
}
