using Unity.VisualScripting;
using UnityEngine;

public class CrabCageFollow : MonoBehaviour
{
    /// <summary>
    /// This script will make the CrabCage follow the players mouse position.
    /// </summary>

    public GameObject greenCrabCage;

    public GameObject player;

    public GameObject crabCagePrefab;

    public MeshRenderer greenCrabCageRenderer;

    public Material originalMat, denyMat;

    public LayerMask groundLayerMask, waterLayerMask;

    public Vector3 greenCrabCagePos;

    public Vector3 mousePos;

    public Vector3 worldPos;

    public KeyCode placeKey;

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

        // 1. Get the target position
        Vector3 targetPosition = player.transform.position;

        // 2. Set the target position's Y-coordinate to the current object's Y-coordinate
        targetPosition.y = greenCrabCage.transform.position.y;

        // 3. Use LookAt with the modified position
        greenCrabCage.transform.LookAt(targetPosition);

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
            canPlace = false;
        }

        if (canPlace)
        {
            if (Input.GetKeyDown(placeKey))
            {
                Instantiate(crabCagePrefab, greenCrabCagePos, greenCrabCage.transform.rotation);
            }
        }
        else if (!canPlace)
        {
            return;
        }
    }
}
