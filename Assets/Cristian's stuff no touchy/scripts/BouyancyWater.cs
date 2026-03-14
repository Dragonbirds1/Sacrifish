using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;




[RequireComponent(typeof(Rigidbody))]
public class WaterBuoyant : MonoBehaviour
{

   
    public float UnderWaterDrag = 3f;
    public float UnderWaterAngularDrag = 1f;
    public float AirDrag = 0f;
    public float AirAngularDrag = 0.05f;
    public float FloatingPower = 15f;
    public float WaterHeight = 0f;

    Rigidbody m_Rigidbody;

    int FloatersUnderWater;
    bool Underwater;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        float difference = transform.position.y - WaterHeight;

        if (difference < 0)
        {
            m_Rigidbody.AddForceAtPosition(Vector3.up * FloatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);
            if (!Underwater)
            {
                Underwater = true;
                SwitchedState(true);
            }
        }
        else if (Underwater)
        {
            Underwater = false;
            SwitchedState(false);
        }
    }

    void SwitchedState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_Rigidbody.linearDamping = UnderWaterDrag;
            m_Rigidbody.angularDamping = UnderWaterAngularDrag;
        }
        else
        {
            m_Rigidbody.linearDamping = AirDrag;
            m_Rigidbody.angularDamping = AirAngularDrag;
        }
    }


}