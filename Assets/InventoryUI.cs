using Unity.Mathematics;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public float Rows;
    public float Collumns;
    public float CellSize = 150;
    public float CellSpacing = 25;
    public float CanvasSize = 1920;
    private void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Collumns * CellSize + CellSpacing * (Collumns - 1), Rows * CellSize + CellSpacing * (Rows - 1));
        ///rectTransform.rect.left = (CanvasSize - (CellSize * Collumns + CellSpacing * (Collumns - 1))) / 2;
        ///rectTransform.rect.top = (CanvasSize - (CellSize * Rows + CellSpacing * (Rows - 1))) / 2;
    }
    // Update is called once per frame
    public void Update()
    {
        
    }
}
