using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BobberOnLine : MonoBehaviour
{
    public Transform rodTip;        // Rod tip transform
    public float maxLineLength = 3f;  // Maximum distance from rod tip
    public float linePullSpeed = 5f;  // How fast bobber is pulled back
    public float slackTolerance = 0.05f; // Allow a tiny slack for realism

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rodTip == null) return;

        Vector3 dir = transform.position - rodTip.position;
        float distance = dir.magnitude;

        // Only pull bobber if it's beyond max line minus slack
        float allowedDistance = maxLineLength - slackTolerance;

        if (distance > allowedDistance)
        {
            Vector3 targetPos = rodTip.position + dir.normalized * allowedDistance;

            // Smoothly pull bobber toward allowed max distance
            rb.MovePosition(Vector3.Lerp(rb.position, targetPos, linePullSpeed * Time.fixedDeltaTime));
        }
    }
}