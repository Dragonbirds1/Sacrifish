using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class CatchFish : MonoBehaviour
{
    public CastRod castRod;
    public BobberWaterControl bobberWaterControl;
    public CatchMinigame catchMinigame;
    public FishBarAI fishBarAI;
    public TMP_InputField luckInputField;
    public GameObject catchBar;
    public float timeTillCatch; // Timer Floats
    public float rodCatchTime; // Object Floats
    public bool fishCaught;
    public bool isDevRod;
    public bool fishOnLine;
    public string fishRarityName;

    public FishingZone[] zones;
    public FishingZone currentZone;

    public float playerLuck; // = 0.1f;
    public float rodBonus; // = 0.05f;
    public float baitBonus; // = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        catchBar.SetActive(false);
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

                    CatchTheFish();
                    
                    fishCaught = true;
                }
                timeTillCatch = 0;
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

    void CatchTheFish()
    {
        fishOnLine = true;

        catchBar.SetActive(true);

        float luck = 0f;

        // 🎲 Roll rarity from zone
        string rarity = RollFish(currentZone.rarities, luck);

        // 🎣 Get FishBarAI (your minigame)
        fishBarAI.Setup(currentZone, rarity);

        Debug.Log("Caught: " + rarity + " fish in " + currentZone.zoneName);
    }
}

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
    public float difficulty;
    public FishRarity[] rarities;
}
