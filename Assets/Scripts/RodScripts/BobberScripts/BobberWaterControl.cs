using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BobberWaterControl : MonoBehaviour
{
    private Rigidbody rb;
    public bool inWater = false;
    public bool canFloat = false;
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
            //Vector3 pos = rb.position;
            //pos.y = waterLevel + floatOffset;
            //rb.position = pos;

            // Optional: zero velocity to avoid sinking
            rb.linearVelocity = Vector3.zero;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Water"))
        {
            inWater = true;
            canFloat = true;
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void ExitWater()
    {
        inWater = false;
        canFloat = false;
        rb.useGravity = true;
    }
}