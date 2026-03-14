using UnityEngine;

public class BobberFloat : MonoBehaviour
{
    public float waterLevel = 0f;
    public float waveHeight = 0.2f;
    public float waveFrequency = 0.5f;
    public float waveSpeed = 1.5f;
    public float floatOffset = 0.03f;
    public float followSpeed = 8f;

    public Rigidbody rb;

    private bool inWater = false;

    void Start()
    {
        rb.isKinematic = true; // start kinematic so it doesn't fall
    }

    void FixedUpdate()
    {
        if (inWater)
        {
            // Bob with shader wave
            float wave = Mathf.Sin((transform.position.x + transform.position.z) * waveFrequency + Time.time * waveSpeed) * waveHeight;
            float targetHeight = waterLevel + wave + floatOffset;

            Vector3 pos = transform.position;
            pos.y = Mathf.Lerp(pos.y, targetHeight, Time.fixedDeltaTime * followSpeed);
            transform.position = pos;
        }
    }

    // Call when bobber hits water
    public void EnterWater()
    {
        inWater = true;
        rb.isKinematic = true; // stop physics, follow wave
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    // Call when bobber is retracted
    public void ResetBobber(Transform rodTip)
    {
        inWater = false;
        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = rodTip.position;
        transform.rotation = rodTip.rotation;
    }
}