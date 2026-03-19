using Unity.Mathematics;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public float Rows;
    public float Collumns;
    public float CellSize = 150;
    public float CellSpacing = 25;
    public float CanvasSize = 1920;
    // Update is called once per frame
    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        //rectTransform.rect.left = (CanvasSize - (CellSize * Collumns + CellSpacing * (Collumns - 1))) / 2;
    }
}
