using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CastRod : MonoBehaviour
{
    /// <summary>
    /// This script will handle casting the rod.
    /// </summary>

    public PlayerMotor motor;
    public LayerMask whatIsNotWater, whatIsWater;
    public GameObject player, bobber, bobberSpawn, playerCam, bobberCasted;
    public Transform bobberLocation, bobberTransform;
    public Image fillForce;
    public Rigidbody bobberRB; // Rigidbody that will be pushed away when casted.
    public KeyCode castKey;
    public bool isCasted, isRecast, canAddForce, canRemoveForce, canChangeForce;
    public bool startCastReset, canCast, startedRetracked;
    public float castForce, maxCastForce, minCastForce, timeTillResetCast;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bobberRB.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        fillForce.fillAmount = castForce;
        if (startCastReset)
        {
            timeTillResetCast += Time.deltaTime;
            if (timeTillResetCast >= 3)
            {
                canCast = true;
                startCastReset = false;
                timeTillResetCast = 0;
            }
        }
        if (Input.GetKey(castKey) && canCast)
        {
            canChangeForce = true;
            if (canChangeForce)
            {
                if (castForce < maxCastForce && canAddForce)
                {
                    //castForce = minCastForce;
                    canRemoveForce = false;
                    castForce += Time.deltaTime;
                }
                else if (castForce >= maxCastForce || canRemoveForce)
                {
                    canAddForce = false;
                    canRemoveForce = true;
                    //castForce = maxCastForce;
                    castForce -= Time.deltaTime;
                    if (castForce <= 0)
                    {
                        canAddForce = true;
                        canRemoveForce = false;
                    }
                }
            }
        }
        else if (Input.GetKeyUp(castKey) && canCast == true)
        {
            castForce = castForce + 10;
            bobberTransform.SetParent(bobberCasted.transform);
            bobberRB.isKinematic = false;
            canChangeForce = false;
            canCast = false;
            startedRetracked = true;
            bobberRB.AddForce(bobberLocation.forward * castForce, ForceMode.Impulse);
            Debug.Log("Casted Rod! Cast Force: " + castForce);
            castForce = 0;
        }
        else if (Input.GetKey(castKey) && canCast == false)
        {
            startCastReset = true;
            if (startedRetracked)
            {
                Debug.Log("Retracked Rod!");
                bobberTransform.SetParent(playerCam.transform);
                bobberTransform.position = bobberLocation.transform.position;
                startedRetracked = false;
            }
        }
    }
}
