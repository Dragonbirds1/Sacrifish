using UnityEngine;

public class BobberHanging : MonoBehaviour
{
    public Transform rodTip;       // Rod tip transform
    public Rigidbody bobber;       // Bobber Rigidbody
    public float maxLineLength = 3f; // Maximum line length
    public float sagStiffness = 10f; // How strongly the bobber is pulled back within max length

    void FixedUpdate()
    {
        if (rodTip == null || bobber == null) return;

        Vector3 dir = bobber.position - rodTip.position;
        float distance = dir.magnitude;

        // If bobber exceeds max line length, pull it back
        if (distance > maxLineLength)
        {
            Vector3 targetPos = rodTip.position + dir.normalized * maxLineLength;

            // Smoothly pull bobber back along line
            bobber.MovePosition(Vector3.Lerp(bobber.position, targetPos, sagStiffness * Time.fixedDeltaTime));
        }
    }
}