using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WaterBuoyant : MonoBehaviour
{
    public float UnderWaterDrag = 3f;
    public float UnderWaterAngularDrag = 1f;
    public float AirDrag = 0f;
    public float AirAngularDrag = 0.05f;
    public float FloatingPower = 15f;
    public CastRod castRod;
    public BobberWaterControl bobberWaterControl;

    [Header("Water Plane Reference")]
    public Transform waterPlane;
    public Renderer waterRenderer;

    [Header("Tilt Settings")]
    public float tiltSpeed = 5f;
    public float sampleOffset = 0.5f;

    Rigidbody m_Rigidbody;
    bool Underwater;

    float FlowSpeed;
    Vector2 FlowDirection;
    float WaveSpread;
    float WaveHight;
    float MaxHight;
    Material waterMat;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        if (waterRenderer == null && waterPlane != null)
            waterRenderer = waterPlane.GetComponent<Renderer>();

        if (waterRenderer != null)
            waterMat = waterRenderer.material;
    }

    void ReadShaderParams()
    {
        if (waterMat == null) return;
        FlowSpeed = waterMat.GetFloat("_FlowSpeed");
        FlowDirection = waterMat.GetVector("_FlowDirection");
        WaveSpread = waterMat.GetFloat("_WaveSpread");
        WaveHight = waterMat.GetFloat("_WaveHight");
        MaxHight = waterMat.GetFloat("_MaxHight");
    }

    Vector2 WorldToUV(Vector3 worldPos)
    {
        Vector3 localPos = waterPlane != null
            ? waterPlane.InverseTransformPoint(worldPos)
            : worldPos;

        return new Vector2(localPos.x / 10f + 0.5f, localPos.z / 10f + 0.5f);
    }

    float GetWaveHeightAtPosition(Vector3 worldPos)
    {
        float baseY = waterPlane != null ? waterPlane.position.y : 0f;

        Vector2 uv = WorldToUV(worldPos);
        Vector2 offset = FlowDirection * FlowSpeed * Time.time;
        float uvX = uv.x + offset.x;
        float uvY = uv.y + offset.y;

        float noise = Mathf.PerlinNoise(uvX * WaveSpread, uvY * WaveSpread);
        float powered = Mathf.Pow(noise, WaveHight);
        float inverted = 1f - powered;
        float clamped = Mathf.Clamp(inverted, 0f, MaxHight);

        return baseY + clamped;
    }

    Vector3 GetWaveNormal(Vector3 worldPos)
    {
        float h = GetWaveHeightAtPosition(worldPos);
        float hR = GetWaveHeightAtPosition(worldPos + Vector3.right * sampleOffset);
        float hF = GetWaveHeightAtPosition(worldPos + Vector3.forward * sampleOffset);

        Vector3 tangentX = new Vector3(sampleOffset, hR - h, 0f);
        Vector3 tangentZ = new Vector3(0f, hF - h, sampleOffset);

        return Vector3.Cross(tangentZ, tangentX).normalized;
    }

    private void FixedUpdate()
    {
        ReadShaderParams();

        float waveY = GetWaveHeightAtPosition(transform.position);
        float difference = transform.position.y - waveY;

        // ALWAYS apply force toward the wave surface — both up AND down
        // Negative difference = below water -> force pushes UP
        // Positive difference = above water -> force pushes DOWN

        if (castRod.isCasted == true && bobberWaterControl.canFloat == true)
        {
            m_Rigidbody.AddForceAtPosition(
            Vector3.up * FloatingPower * -difference,
            transform.position,
            ForceMode.Force
            );
        }

        // Tilt to match wave surface
        Vector3 waveNormal = GetWaveNormal(transform.position);
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, waveNormal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * tiltSpeed);

        // Switch drag based on whether we're below or above the wave
        if (difference < 0)
        {
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