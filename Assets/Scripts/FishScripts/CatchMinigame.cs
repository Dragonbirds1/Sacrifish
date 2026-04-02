using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class CatchMinigame : MonoBehaviour
{
    public RectTransform smallBarRect;

    public RectTransform barrier1, barrier2, wallChecker1, wallChecker2;

    public Rect barrier1UI, barrier2UI;

    public float X;
    public float velocity;

    public float gravity = 2000f;
    public float holdForce = 3000f;
    public float maxSpeed = 1200f;

    public float minX = -422f;
    public float maxX = 422f;

    public float bounceDamping = 0.5f; // 1 = perfect bounce, <1 loses energy

    public KeyCode moveSmallBarKey;

    public bool canControl = false;

    void Update()
    {
        float smallBarPositionX = smallBarRect.anchoredPosition.x;
        float barrier1PositionX = barrier1.anchoredPosition.x;
        float barrier2PositionX = barrier2.anchoredPosition.x;
        float wallChecker1PositionX = wallChecker1.anchoredPosition.x;
        float wallChecker2PositionX = wallChecker2.anchoredPosition.x;

        if (canControl)
        {
            // APPLY FORCES
            if (Input.GetKey(moveSmallBarKey))
            {
                velocity += holdForce * Time.deltaTime;
            }
            else
            {
                velocity -= gravity * Time.deltaTime;
            }

            // Clamp velocity
            velocity = Mathf.Clamp(velocity, -maxSpeed, maxSpeed);

            // Move
            X += velocity * Time.deltaTime;

            // Clamp position (NO bounce, just stop)
            // Let the max X change base on the size of the bar if you want, for now it's fixed
            //maxX = 422f - (smallBarRect.rect.width / 3.25f);
            //minX = -422f + (smallBarRect.rect.width / 3.25f);
            // Check if wallcheckers hit the barriers, if they do bounce, if they go past the barriers, clamp and bounce
            if (X > barrier2PositionX - (smallBarRect.rect.width / 2))
            {
                X = barrier2PositionX - (smallBarRect.rect.width / 2);
                velocity = -velocity * bounceDamping; // reverse + dampen
            }
            else if (X < barrier1PositionX + (smallBarRect.rect.width / 2))
            {
                X = barrier1PositionX + (smallBarRect.rect.width / 2);
                velocity = -velocity * bounceDamping;
            }
            //if (X > barrier2PositionX)
            //{
                //X = barrier2PositionX;
                //velocity = -velocity * bounceDamping; // reverse + dampen
            //}
            //else if (X < barrier1PositionX)
            //{
                //X = barrier1PositionX;
                //velocity = -velocity * bounceDamping;
            //}

            // Apply position and for left and right of the image not the center
            smallBarRect.anchoredPosition = new Vector2(X, smallBarRect.anchoredPosition.y);

            // NOW SET IT FOR LEFT AND RIGHT OF THE IMAGE NOT THE CENTER
            wallChecker1.anchoredPosition = new Vector2(X - (smallBarRect.rect.width / 2), wallChecker1.anchoredPosition.y);
            wallChecker2.anchoredPosition = new Vector2(X + (smallBarRect.rect.width / 2), wallChecker2.anchoredPosition.y);
        }
        else if (!canControl)
        {
            return;
        }
    }
}