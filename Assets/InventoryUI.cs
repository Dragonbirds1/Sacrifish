using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class InventoryUI : MonoBehaviour
{
    public uint Rows;
    public float Collumns;
    private void Start()
    {
        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();

        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Rows * gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x * (Rows + 1), Rows * gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x * (Rows + 1));
    }
    // Update is called once per frame
    public void Update()
    {
        if (Mathf.Round(transform.childCount / Rows) != (transform.childCount / Rows))
        {
            //Collumns = Mathf.Round(transform.childCount / Rows) + 1;
            Collumns = (transform.childCount / (float)Rows) + 1;
        }
        else
        {
            Collumns = (transform.childCount / (float)Rows);
        }
    }
    /*public void EXIT()
    {
        //EXITs Inventory Menu
        SceneManager.LoadScene("Game");
    }*/
}
