using UnityEngine;

public class FishingLineRenderer : MonoBehaviour
{
    public Transform rodTip;      // Rod tip of the fishing rod
    public Transform bobber;      // Bobber transform
    public LineRenderer lr;

    [Header("Line Settings")]
    public int segments = 10;        // Number of points in line
    public float sagHeight = 0.2f;   // Max sag in the middle

    public float maxLineLength = 3f; // Maximum rope length

    void Start()
    {
        if (lr == null) lr = GetComponent<LineRenderer>();
        lr.positionCount = segments;
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
        lr.useWorldSpace = true;
    }

    void Update()
    {
        if (rodTip == null || bobber == null || lr == null) return;

        Vector3 dir = bobber.position - rodTip.position;
        float distance = Mathf.Min(dir.magnitude, maxLineLength); // Clamp distance to max line
        Vector3 lineEnd = rodTip.position + dir.normalized * distance;

        for (int i = 0; i < segments; i++)
        {
            float t = i / (float)(segments - 1); // 0 → 1
            Vector3 point = Vector3.Lerp(rodTip.position, lineEnd, t);

            // Add sag: maximum in middle
            float sag = Mathf.Sin(t * Mathf.PI) * sagHeight;
            point.y -= sag;

            lr.SetPosition(i, point);
        }
    }
}