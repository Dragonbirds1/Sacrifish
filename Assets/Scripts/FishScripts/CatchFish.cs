using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class CatchFish : MonoBehaviour
{
    public CastRod castRod;
    public BobberWaterControl bobberWaterControl;
    public CatchMinigame catchMinigame;
    public TMP_InputField luckInputField;
    public float timeTillCatch; // Timer Floats
    public float rodCatchTime; // Object Floats
    public bool fishCaught;
    public bool isDevRod;
    public string fishRarityName;

    [System.Serializable]
    public class FishRarity
    {
        public string name;
        public float chance; // percent
    }

    [System.Serializable]
    public class FishingZone
    {
        public string zoneName;
        public FishRarity[] rarities;
    }

    public FishingZone[] zones;
    public FishingZone currentZone;

    public float playerLuck; // = 0.1f;
    public float rodBonus; // = 0.05f;
    public float baitBonus; // = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bobberWaterControl.inWater == true)
        {
            timeTillCatch += Time.deltaTime;
            if (timeTillCatch >= rodCatchTime)
            {
                if (fishCaught == false)
                {
                    float luck = playerLuck + rodBonus + baitBonus; // = 0.2f

                    string fish = RollFish(currentZone.rarities, luck);
                    
                    fishCaught = true;
                }
                timeTillCatch = 0;
                castRod.Retract();
            }
        }
    }

    string RollFish(FishRarity[] rarities, float luckMultiplier)
    {
        float total = 0f;

        // Create modified chances
        float[] modified = new float[rarities.Length];

        for (int i = 0; i < rarities.Length; i++)
        {
            float weight = rarities[i].chance;

            // 🎯 Key idea:
            // Lower tiers get reduced, higher tiers get boosted
            float rarityFactor = (float)i / (rarities.Length - 1);

            // Apply luck curve
            weight *= Mathf.Lerp(1f - luckMultiplier, 1f + luckMultiplier, rarityFactor);

            modified[i] = weight;
            total += weight;
        }

        // Normalize + roll
        float roll = Random.value * total;
        float cumulative = 0f;

        for (int i = 0; i < modified.Length; i++)
        {
            cumulative += modified[i];
            if (roll <= cumulative)
            {
                Debug.Log("A " + rarities[i].name + " Fish is on your line");
                return rarities[i].name;
            }
        }
        return rarities[0].name;
    }
}
