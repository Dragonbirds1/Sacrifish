using UnityEngine;

public class ZoneChanger : MonoBehaviour
{
    public CatchFish catchFish;

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
        if (other.CompareTag("CrownIsland"))
        {
            catchFish.currentZone = catchFish.zones[0];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
        else if (other.CompareTag("Ocean"))
        {
            catchFish.currentZone = catchFish.zones[1];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
        else if (other.CompareTag("ButtonCavern"))
        {
            catchFish.currentZone = catchFish.zones[2];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
        else if (other.CompareTag("ForgottenJungle"))
        {
            catchFish.currentZone = catchFish.zones[3];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
        else if (other.CompareTag("EternalIslandDesert"))
        {
            catchFish.currentZone = catchFish.zones[4];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
        else if (other.CompareTag("ToxicGrowth"))
        {
            catchFish.currentZone = catchFish.zones[5];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
        else if (other.CompareTag("EternalIslandIcy"))
        {
            catchFish.currentZone = catchFish.zones[6];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
        else if (other.CompareTag("ScorchingDeep"))
        {
            catchFish.currentZone = catchFish.zones[7];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
        else if (other.CompareTag("NorthPole"))
        {
            catchFish.currentZone = catchFish.zones[8];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
        else if (other.CompareTag("MutatedAbyss"))
        {
            catchFish.currentZone = catchFish.zones[9];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
        }
    }
}
