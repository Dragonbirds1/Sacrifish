using UnityEngine;

public class BoatLook : MonoBehaviour
{
    public BoatManager boatManager;

    public GameObject boatCam;
    private float xRotation = 0f;

    public float xSensitivity = 2f;
    public float ySensitivity = 2f;

    public bool canLook = true;

    public void ProcessLook(Vector2 input)
    {
        if (!boatManager.isInBoat) return;
        
        float mouseX = Mathf.Clamp(input.x, -10f, 10f);
        //float mouseY = Mathf.Clamp(input.y, -10f, 10f);

        //xRotation -= mouseY * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        boatCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX * xSensitivity);
    }
}