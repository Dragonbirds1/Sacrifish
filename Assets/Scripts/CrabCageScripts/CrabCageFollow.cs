using Unity.VisualScripting;
using UnityEngine;

public class CrabCageFollow : MonoBehaviour
{
    /// <summary>
    /// This script will make the CrabCage follow the players mouse position.
    /// </summary>

    public GameObject greenCrabCage;

    public MeshRenderer greenCrabCageRenderer;

    public Material originalMat, denyMat;

    public LayerMask groundLayerMask, waterLayerMask;

    public Vector3 greenCrabCagePos;

    public Vector3 mousePos;

    public Vector3 worldPos;

    public float distanceFromCamera;

    public float rayRange;

    public bool canPlace;

    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("CAMERA IS NULL!!!!!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        greenCrabCage.transform.position = greenCrabCagePos;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;

        // Perform the raycast

        //if (Physics.Raycast(ray, out hit, rayRange, groundLayerMask))
        //{
        //    greenCrabCageRenderer.material = denyMat;
        //    greenCrabCagePos = hit.point;
        //    canPlace = false;
        //}

        if (Physics.Raycast(ray, out hit, rayRange, waterLayerMask))
        {
            greenCrabCageRenderer.material = originalMat;
            greenCrabCagePos = hit.point;
            canPlace = true;
        }
        else
        {
            greenCrabCageRenderer.material = denyMat;
        }
    }
}
