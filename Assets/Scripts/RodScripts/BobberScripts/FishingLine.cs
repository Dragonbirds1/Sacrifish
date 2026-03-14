using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public Transform rodTip;    // Rod tip transform
    public Transform bobber;    // Bobber transform
    public int segments = 5;    // Number of points in the line
    public float sagHeight = 0.2f; // How much the line bends downward

    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = segments;
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
        lr.useWorldSpace = true;
    }

    void Update()
    {
        if (rodTip == null || bobber == null) return;

        // Positions along the line
        for (int i = 0; i < segments; i++)
        {
            float t = i / (float)(segments - 1); // 0 to 1
            Vector3 point = Vector3.Lerp(rodTip.position, bobber.position, t);

            // Apply sag: maximum at the middle of the line
            float sag = Mathf.Sin(t * Mathf.PI) * sagHeight;
            point.y -= sag;

            lr.SetPosition(i, point);
        }
    }
}