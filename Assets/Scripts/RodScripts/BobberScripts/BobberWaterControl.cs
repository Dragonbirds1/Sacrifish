using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BobberWaterControl : MonoBehaviour
{
    private Rigidbody rb;
    private bool inWater = false;
    private float waterLevel;

    public float floatOffset = 0.1f; // Keep bobber slightly above water

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (inWater)
        {
            // Freeze rotation to prevent rolling
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            // Keep bobber at water surface
            Vector3 pos = rb.position;
            pos.y = waterLevel + floatOffset;
            rb.position = pos;

            // Optional: zero velocity to avoid sinking
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
            waterLevel = collision.contacts[0].point.y; // Y position where bobber touched water
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