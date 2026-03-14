using UnityEngine;

public class DynamicFishingLine : MonoBehaviour
{
    [Header("References")]
    public Transform rodTip;
    public Rigidbody bobber;
    public LineRenderer lr;

    [Header("Line Settings")]
    public int segments = 10;          // Number of nodes in the line
    public float segmentLength = 0.2f;
    public float stiffness = 50f;
    public float damping = 5f;

    private Vector3[] nodes;
    private Vector3[] velocities;

    void Awake()
    {
        if (lr == null) lr = GetComponent<LineRenderer>();

        // Initialize nodes
        nodes = new Vector3[segments];
        velocities = new Vector3[segments];

        // Make sure LineRenderer has correct count
        lr.positionCount = segments;

        // Initialize nodes at rod tip
        for (int i = 0; i < segments; i++)
            nodes[i] = rodTip.position;

        // LineRenderer settings
        lr.useWorldSpace = true;
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
    }

    void Update()
    {
        if (rodTip == null || bobber == null || lr == null) return;

        SimulateLine(Time.deltaTime);
        UpdateLineRenderer();
    }

    void SimulateLine(float dt)
    {
        nodes[0] = rodTip.position;
        nodes[segments - 1] = bobber.position;

        for (int i = 1; i < segments - 1; i++)
        {
            Vector3 force = Vector3.zero;

            // Pull towards neighbors
            Vector3 toPrev = nodes[i - 1] - nodes[i];
            Vector3 toNext = nodes[i + 1] - nodes[i];

            force += toPrev.normalized * (toPrev.magnitude - segmentLength) * stiffness;
            force += toNext.normalized * (toNext.magnitude - segmentLength) * stiffness;

            // Gravity
            force += Physics.gravity;

            // Damping
            velocities[i] *= 1f - damping * dt;

            // Apply acceleration
            velocities[i] += force * dt;

            // Update node position
            nodes[i] += velocities[i] * dt;
        }

        // Update bobber
        bobber.position = nodes[segments - 1];
    }

    void UpdateLineRenderer()
    {
        // Ensure positionCount matches nodes
        if (lr.positionCount != segments) lr.positionCount = segments;

        for (int i = 0; i < segments; i++)
            lr.SetPosition(i, nodes[i]);
    }
}