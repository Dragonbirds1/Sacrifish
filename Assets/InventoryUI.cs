using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class InventoryUI : MonoBehaviour
{
    public uint Rows;
    public uint Collumns;
    private void Start()
    {
        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();

        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Collumns * gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x * (Collumns + 1), Collumns * gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x * (Collumns + 1));
    }
    // Update is called once per frame
    public void Update()
    {
        
    }
    /*public void EXIT()
    {
        //EXITs Inventory Menu
        SceneManager.LoadScene("Game");
    }*/
}
