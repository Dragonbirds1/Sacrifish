using UnityEngine;

public class CatchMinigame : MonoBehaviour
{
    public GameObject catchBar;
    public GameObject fishBar;
    public GameObject smallBar;
    public RectTransform smallBarRect;
    public float X, speed;
    public bool increasing, decreasing;
    public KeyCode moveSmallBarKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveSmallBarKey))
        {
            decreasing = false;
            X += Time.deltaTime * speed;
            smallBarRect.anchoredPosition = new Vector2(X, smallBarRect.anchoredPosition.y);
            if (X >= 422f)
            {
                X = 422f;
            }
        }
        else if (Input.GetKeyUp(moveSmallBarKey))
        {
            decreasing = true;
        }

        if (decreasing)
        {
            X -= Time.deltaTime * speed;
            smallBarRect.anchoredPosition = new Vector2(X, smallBarRect.anchoredPosition.y);
            if (X <= -422f)
            {
                X = -422f;
            }
        }
    }
}
