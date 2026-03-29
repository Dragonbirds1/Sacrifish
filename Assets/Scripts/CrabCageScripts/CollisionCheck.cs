using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public CrabCageFollow crabCageFollow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenCrabCage"))
        {
            crabCageFollow.canPlace = false;
            crabCageFollow.colliding = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GreenCrabCage"))
        {
            crabCageFollow.colliding = false;
        }
    }
}
