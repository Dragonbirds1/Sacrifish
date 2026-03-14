using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BobberDangling : MonoBehaviour
{
    [Header("Line Settings")]
    public Transform rodTip;          // Rod tip anchor
    public float maxLineCasted; //= 3f;  // Max length when casted
    public float maxLineIdle; //= 1f;   // Max length when not casted
    public float lineStiffness = 20f; // Spring strength
    public float damping = 5f;        // Smooth swing

    [HideInInspector] public bool isCasted = false; // Set from CastRod script

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void FixedUpdate()
    {
        if (rodTip == null) return;

        // Choose max line depending on cast state
        float maxLineLength = isCasted ? maxLineCasted : maxLineIdle;

        Vector3 dir = transform.position - rodTip.position;
        float distance = dir.magnitude;

        if (distance > maxLineLength)
        {
            Vector3 targetPos = rodTip.position + dir.normalized * maxLineLength;

            // Spring force
            Vector3 force = (targetPos - transform.position) * lineStiffness;

            // Damping
            rb.linearVelocity *= 1f - damping * Time.fixedDeltaTime;

            rb.AddForce(force, ForceMode.Acceleration);
        }
    }
}