using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public float xRotation = 0f;

    public float xSensitivity = 2f;
    public float ySensitivity = 2f;

    public bool canLook = true;

    public void ProcessLook(Vector2 input)
    {
        if (!canLook) return;

        float mouseX = Mathf.Clamp(input.x, -10f, 10f);
        float mouseY = Mathf.Clamp(input.y, -10f, 10f);

        xRotation -= mouseY * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX * xSensitivity);
    }
}