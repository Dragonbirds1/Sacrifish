using UnityEngine;

public class GetGround : MonoBehaviour
{
    public CastRod castRod;
    public LayerMask whatIsGround, whatIsWater;
    public Rigidbody bobberRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") && castRod.canCast == false || collision.collider.CompareTag("Water") && castRod.canCast == false)
        {
            bobberRB.isKinematic = true;
        }
    }
}
