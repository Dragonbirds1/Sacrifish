using UnityEngine;
using UnityEngine.Splines;

public class ControlManager : MonoBehaviour
{
    public SwapRods swapRods;

    public ControlChanger controlChanger;

    public RectTransform smallBarRect, wallCheck1, wallCheck2;

    public float controlBarSet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (swapRods.currentRod == swapRods.rods[0])
        {
            controlBarSet = controlChanger.numberTyped;
            smallBarRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, controlBarSet);
            wallCheck1.anchoredPosition = new Vector2(-controlBarSet / 2, wallCheck1.anchoredPosition.y);
            wallCheck2.anchoredPosition = new Vector2(controlBarSet / 2, wallCheck2.anchoredPosition.y);
        }
        else
        {
            controlBarSet = swapRods.currentRod.controlBarSize;
            smallBarRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, controlBarSet);
            wallCheck1.anchoredPosition = new Vector2(-controlBarSet / 2, wallCheck1.anchoredPosition.y);
            wallCheck2.anchoredPosition = new Vector2(controlBarSet / 2, wallCheck2.anchoredPosition.y);
        }
    }
}
