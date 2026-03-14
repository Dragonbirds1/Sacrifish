using UnityEngine;

/// <summary>
/// Attach this script to an empty GameObject.
/// Assign two GameObjects in the Inspector to draw a line between them.
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class DrawLineBetweenObjects : MonoBehaviour
{
    public Transform objectA; // First object
    public Transform objectB; // Second object

    private LineRenderer lineRenderer;

    void Awake()
    {
        // Get or add LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Configure LineRenderer appearance
        lineRenderer.positionCount = 2; // Only two points needed
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
    }

    void Update()
    {
        // Validate references
        if (objectA == null || objectB == null)
        {
            Debug.LogWarning("DrawLineBetweenObjects: Missing object references.");
            return;
        }

        // Update line positions every frame
        lineRenderer.SetPosition(0, objectA.position);
        lineRenderer.SetPosition(1, objectB.position);
    }
}
