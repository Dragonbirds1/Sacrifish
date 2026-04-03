using UnityEngine;

public class ControlManager : MonoBehaviour
{
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
        controlBarSet = controlChanger.numberTyped;
        smallBarRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, controlBarSet);
        wallCheck1.anchoredPosition = new Vector2(-controlBarSet / 2, wallCheck1.anchoredPosition.y);
        wallCheck2.anchoredPosition = new Vector2(controlBarSet / 2, wallCheck2.anchoredPosition.y);
    }
}
