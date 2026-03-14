using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public Transform rodTip;       // Where the line starts (rod tip)
    public Transform bobber;       // The bobber
    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        if (lr != null)
        {
            lr.positionCount = 2;  // start and end
        }
    }

    void Update()
    {
        if (lr != null && bobber != null && rodTip != null)
        {
            Vector3 midPoint = (rodTip.position + bobber.position) / 2 + Vector3.up * 0.2f;
            lr.positionCount = 3;
            lr.SetPosition(0, rodTip.position);
            lr.SetPosition(1, midPoint);
            lr.SetPosition(2, bobber.position);
        }
    }
}