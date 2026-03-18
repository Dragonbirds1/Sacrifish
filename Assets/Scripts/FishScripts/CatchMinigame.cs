using UnityEngine;

public class CatchMinigame : MonoBehaviour
{
    public RectTransform smallBarRect;

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
            if (X > maxX)
            {
                X = maxX;
                velocity = -velocity * bounceDamping; // reverse + dampen
            }
            else if (X < minX)
            {
                X = minX;
                velocity = -velocity * bounceDamping;
            }

            // Apply position
            smallBarRect.anchoredPosition = new Vector2(X, smallBarRect.anchoredPosition.y);
        }
        else if (!canControl)
        {
            return;
        }
    }
}