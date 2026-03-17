using UnityEngine;

public class GetGround : MonoBehaviour
{
    public CastRod castRod;
    public Rigidbody bobberRB;
    public GameObject bobber;

    public bool inWater;

    private void OnCollisionEnter(Collision collision)
    {
        if (!castRod.canCast)
        {
            if (collision.collider.CompareTag("Water"))
            {
                inWater = true;

                bobberRB.linearVelocity = Vector3.zero;
                bobberRB.angularVelocity = Vector3.zero;

                Debug.Log("Bobber hit water!");
            }

            if (collision.collider.CompareTag("Ground"))
            {
                bobberRB.linearVelocity = Vector3.zero;
                //bobberRB.isKinematic = true;
            }
        }
    }
}