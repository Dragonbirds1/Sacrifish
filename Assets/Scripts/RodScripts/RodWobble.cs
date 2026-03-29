using UnityEngine;

public class RodWobble : MonoBehaviour
{
    [Header("References")]
    public Transform player;          // player object
    public Transform cameraTransform; // player camera
    public Transform bobber;          // optional bobber for line tension

    [Header("Wobble Settings")]
    public float moveWobbleAmount = 5f;      // sway from player movement
    public float turnWobbleAmount = 5f;      // sway from camera turning (left/right)
    public float tensionWobbleAmount = 10f;  // sway from line tension
    public float maxWobbleAngle = 20f;       // max rotation on any axis

    [Header("Spring Settings")]
    public float stiffness = 10f;   // how strongly the rod reacts
    public float damping = 6f;      // how quickly wobble settles

    [Header("Line Settings")]
    public float maxLineLength = 10f; // line fully stretched
    public bool useLineTension = true;

    private Vector3 startRotation;
    private Vector3 targetRotation;
    private Vector3 currentRotation;
    private Vector3 rotationVelocity;

    private float lastCameraYaw;

    void Start()
    {
        startRotation = transform.localEulerAngles;
        currentRotation = startRotation;
        targetRotation = startRotation;

        if (cameraTransform != null)
            lastCameraYaw = cameraTransform.eulerAngles.y;
    }

    void Update()
    {
        // --- Calculate player movement wobble ---
        Vector3 playerVelocity = Vector3.zero;
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null) playerVelocity = rb.linearVelocity;

        float moveWobble = playerVelocity.magnitude * moveWobbleAmount;

        // --- Camera turn wobble (left/right) ---
        float yawDelta = 0f;
        if (cameraTransform != null)
        {
            float currentYaw = cameraTransform.eulerAngles.y;
            yawDelta = Mathf.DeltaAngle(lastCameraYaw, currentYaw); // difference since last frame
            lastCameraYaw = currentYaw;
        }

        float turnWobble = Mathf.Clamp(yawDelta * turnWobbleAmount, -maxWobbleAngle, maxWobbleAngle);

        // --- Line tension wobble ---
        float tensionWobble = 0f;
        if (useLineTension && bobber != null)
        {
            float distance = Vector3.Distance(transform.position, bobber.position);
            float tension = Mathf.Clamp01(distance / maxLineLength);
            tensionWobble = tension * tensionWobbleAmount;
        }

        // --- Combine effects ---
        // X = forward/back pitch (player movement + tension)
        // Z = roll (left/right from camera turn)
        targetRotation = new Vector3(
            Mathf.Clamp(-moveWobble - tensionWobble, -maxWobbleAngle, maxWobbleAngle),
            0f,
            turnWobble
        ) + startRotation;

        // --- Spring smoothing ---
        Vector3 delta = targetRotation - currentRotation;
        rotationVelocity += delta * stiffness * Time.deltaTime;
        rotationVelocity *= Mathf.Exp(-damping * Time.deltaTime);
        currentRotation += rotationVelocity * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(currentRotation);
    }
}