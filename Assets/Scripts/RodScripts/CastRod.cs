using UnityEngine;
using UnityEngine.UI;

public class CastRod : MonoBehaviour
{
    public PlayerMotor motor;

    public GameObject playerCam;
    public Transform bobberLocation;
    public Transform bobberTransform;
    public GameObject bobberCasted;

    public Rigidbody bobberRB;

    public Image fillForce;

    public KeyCode castKey = KeyCode.Mouse0;

    public float castForce;
    public float maxCastForce = 20f;
    public float minCastForce = 2f;

    public float chargeSpeed = 1.5f;

    public bool isCharging;
    public bool isCasted;
    public bool canCast = true;

    float chargeDir = 1f;
    float cooldownTimer;

    void Start()
    {
        bobberRB.isKinematic = true;
        bobberTransform.SetParent(playerCam.transform);
        bobberTransform.position = bobberLocation.position;
    }

    void Update()
    {
        UpdateCooldown();
        UpdateUI();

        if (canCast && !isCasted)
        {
            HandleCharging();
        }

        if (Input.GetKeyUp(castKey) && isCharging)
        {
            Cast();
        }

        if (isCasted && Input.GetKeyDown(castKey))
        {
            Retract();
        }
    }

    void HandleCharging()
    {
        if (Input.GetKey(castKey))
        {
            isCharging = true;

            castForce += chargeDir * chargeSpeed * Time.deltaTime;

            if (castForce >= maxCastForce)
            {
                castForce = maxCastForce;
                chargeDir = -1;
            }

            if (castForce <= minCastForce)
            {
                castForce = minCastForce;
                chargeDir = 1;
            }
        }
    }

    void Cast()
    {
        isCharging = false;
        isCasted = true;
        canCast = false;

        bobberTransform.SetParent(bobberCasted.transform);

        bobberRB.isKinematic = false;
        bobberRB.linearVelocity = Vector3.zero;

        bobberRB.AddForce(bobberLocation.forward * castForce, ForceMode.Impulse);

        Debug.Log("Casted Rod! Force: " + castForce);

        castForce = 0;
    }

    void Retract()
    {
        Debug.Log("Retracted Rod!");

        bobberRB.isKinematic = true;
        bobberRB.linearVelocity = Vector3.zero;

        bobberTransform.SetParent(playerCam.transform);
        bobberTransform.position = bobberLocation.position;

        isCasted = false;

        cooldownTimer = 0;
    }

    void UpdateCooldown()
    {
        if (!canCast)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= 1.5f)
            {
                canCast = true;
                cooldownTimer = 0;
            }
        }
    }

    void UpdateUI()
    {
        fillForce.fillAmount = castForce / maxCastForce;
    }
}