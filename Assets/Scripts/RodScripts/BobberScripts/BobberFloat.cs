using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BobberFloat : MonoBehaviour
{
    public Transform rodTip;          // Rod tip
    public float maxLineLength = 3f;  // Maximum line length
    public float floatOffset = 0.1f;  // How much above water surface
    public float lineStiffness = 20f; // Pull back to max line
    public float damping = 5f;        // Smooth swing

    private Rigidbody rb;
    private bool inWater = false;
    private float waterSurfaceY = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void FixedUpdate()
    {
        if (rodTip == null) return;

        // Max line constraint
        Vector3 dir = transform.position - rodTip.position;
        float distance = dir.magnitude;

        if (distance > maxLineLength)
        {
            Vector3 targetPos = rodTip.position + dir.normalized * maxLineLength;
            Vector3 force = (targetPos - transform.position) * lineStiffness;

            rb.linearVelocity *= 1f - damping * Time.fixedDeltaTime;
            rb.AddForce(force, ForceMode.Acceleration);
        }

        // Floating on water
        if (inWater)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            Vector3 pos = rb.position;
            pos.y = Mathf.Max(pos.y, waterSurfaceY + floatOffset);
            rb.position = pos;

            rb.linearVelocity = Vector3.zero;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Water"))
        {
            inWater = true;
            waterSurfaceY = collision.contacts[0].point.y; // Use the Y where the bobber hit
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void ExitWater()
    {
        inWater = false;
        rb.useGravity = true;
    }
}