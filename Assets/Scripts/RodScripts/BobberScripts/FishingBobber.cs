using UnityEngine;

public class FishingBobber : MonoBehaviour
{
    public LayerMask waterLayer;

    public float floatHeight = 0.05f;
    public float buoyancy = 12f;
    public float waterDrag = 4f;

    public float biteChance = 0.002f;
    public float biteForce = 0.3f;

    public GameObject splashFX;

    Rigidbody rb;
    bool inWater;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 2f, waterLayer))
        {
            if (!inWater)
            {
                inWater = true;

                if (splashFX)
                    Instantiate(splashFX, transform.position, Quaternion.identity);
            }

            float waterSurface = hit.point.y + floatHeight;
            float difference = waterSurface - transform.position.y;

            rb.AddForce(Vector3.up * difference * buoyancy, ForceMode.Acceleration);
            rb.linearDamping = waterDrag;

            SimulateFishBite();
        }
        else
        {
            inWater = false;
            rb.linearDamping = 0;
        }
    }

    void SimulateFishBite()
    {
        if (Random.value < biteChance)
        {
            rb.AddForce(Vector3.down * biteForce, ForceMode.Impulse);
            Debug.Log("Fish Bite!");
        }
    }
}