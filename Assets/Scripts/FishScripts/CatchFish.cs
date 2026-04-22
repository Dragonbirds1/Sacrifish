using JetBrains.Annotations;
using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class CatchFish : MonoBehaviour
{
    public CastRod castRod;
    public BobberWaterControl bobberWaterControl;
    public CatchMinigame catchMinigame;
    public FishBarAI fishBarAI;
    public MerchantManager merchantManager;
    public TMP_InputField luckInputField;
    public TextMeshProUGUI reckels;
    public GameObject catchBar;
    public GameObject fishSpawn;
    public GameObject bobber;
    public float timeTillCatch; // Timer Floats
    public float rodCatchTime; // Object Floats
    public bool fishCaught;
    public bool isDevRod;
    public bool fishOnLine;
    public string fishRarityName;
    public string rarity;
    public int reckelsToAdd;

    public FishingZone[] zones;
    public FishingZone currentZone;

    public float playerLuck; // = 0.1f;
    public float rodBonus; // = 0.05f;
    public float baitBonus; // = 0.05f;

    private GameObject fishClone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        catchBar.SetActive(false);

        foreach (var rarity in currentZone.rarities)
        {
            fishClone = Instantiate(rarity.fishModel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        reckels.text = "Ɍ: " + reckelsToAdd.ToString();
        if (bobberWaterControl.inWater == true && castRod.isCasted)
        {
            bobber.transform.rotation = Quaternion.Euler(-90, 0, 0);
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
                if (rarities[i].fishModel != null)
                {
                    Instantiate(rarities[i].fishModel, fishSpawn.transform.position, Quaternion.identity, fishSpawn.transform);
                    // Make it so the fish model is a child of the fishSpawn object
                }

                rarities[i].isCaught = true; // Mark this rarity as caught for stats

                return rarities[i].name;
            }
        }
        return rarities[0].name;
    }

    public void CatchTheFish()
    {
        fishOnLine = true;

        catchBar.SetActive(true);

        float luck = 0f;

        // 🎲 Roll rarity from zone
        rarity = RollFish(currentZone.rarities, luck);

        // 🎣 Get FishBarAI (your minigame)
        fishBarAI.Setup(currentZone, rarity);
    }

    public void CaughtFish()
    {
        merchantManager.haveFish = true;

        // BUTTON CAVERN ZONE
        if (zones[0].rarities[0].isCaught)
        {
            zones[0].rarities[0].howManyPlayerHasCaught++;
            zones[0].rarities[0].isCaught = false;
        }
        else if (zones[0].rarities[1].isCaught)
        {
            zones[0].rarities[1].howManyPlayerHasCaught++;
            zones[0].rarities[1].isCaught = false;
        }
        else if (zones[0].rarities[2].isCaught)
        {
            zones[0].rarities[2].howManyPlayerHasCaught++;
            zones[0].rarities[2].isCaught = false;
        }

        // CROWN ISLAND ZONE
        else if (zones[1].rarities[0].isCaught)
        {
            zones[1].rarities[0].howManyPlayerHasCaught++;
            zones[1].rarities[0].isCaught = false;
        }
        else if (zones[1].rarities[1].isCaught)
        {
            zones[1].rarities[1].howManyPlayerHasCaught++;
            zones[1].rarities[1].isCaught = false;
        }
        else if (zones[1].rarities[2].isCaught)
        {
            zones[1].rarities[2].howManyPlayerHasCaught++;
            zones[1].rarities[2].isCaught = false;
        }

        // FORGOTTEN JUNGLE ZONE
        else if (zones[2].rarities[0].isCaught)
        {
            zones[2].rarities[0].howManyPlayerHasCaught++;
            zones[2].rarities[0].isCaught = false;
        }
        else if (zones[2].rarities[1].isCaught)
        {
            zones[2].rarities[1].howManyPlayerHasCaught++;
            zones[2].rarities[1].isCaught = false;
        }
        else if (zones[2].rarities[2].isCaught)
        {
            zones[2].rarities[2].howManyPlayerHasCaught++;
            zones[2].rarities[2].isCaught = false;
        }

        // OCEAN ZONE
        else if (zones[3].rarities[0].isCaught)
        {
            zones[3].rarities[0].howManyPlayerHasCaught++;
            zones[3].rarities[0].isCaught = false;
        }
        else if (zones[3].rarities[1].isCaught)
        {
            zones[3].rarities[1].howManyPlayerHasCaught++;
            zones[3].rarities[1].isCaught = false;
        }
        else if (zones[3].rarities[2].isCaught)
        {
            zones[3].rarities[2].howManyPlayerHasCaught++;
            zones[3].rarities[2].isCaught = false;
        }

        // TOXIC GROWTH ZONE
        else if (zones[4].rarities[0].isCaught)
        {
            zones[4].rarities[0].howManyPlayerHasCaught++;
            zones[4].rarities[0].isCaught = false;
        }
        else if (zones[4].rarities[1].isCaught)
        {
            zones[4].rarities[1].howManyPlayerHasCaught++;
            zones[4].rarities[1].isCaught = false;
        }
        else if (zones[4].rarities[2].isCaught)
        {
            zones[4].rarities[2].howManyPlayerHasCaught++;
            zones[4].rarities[2].isCaught = false;
        }
            Debug.Log("Caught: " + rarity + " fish in " + currentZone.zoneName);
    }

    public void FailedCatch()
    {
        foreach (var rarity in currentZone.rarities)
        {
            rarity.isCaught = false; // Reset all rarities in the current zone to not caught
        }
    }

    public void SellAllFish()
    {
        foreach (var rarity in currentZone.rarities)
        {
            if (rarity.howManyPlayerHasCaught > 0)
            {
                Debug.Log("Sold " + rarity.howManyPlayerHasCaught + " " + rarity.name + " fish for " + (rarity.value * rarity.howManyPlayerHasCaught) + " coins.");
                reckelsToAdd += rarity.value; //* rarity.howManyPlayerHasCaught;
                rarity.howManyPlayerHasCaught--;
                Destroy(fishClone);
            }
            else
            {
                Debug.Log("No " + rarity.name + " fish to sell.");
                merchantManager.haveFish = false;
            }
        }
    }
}

[System.Serializable]
public class FishRarity
{
    public string name;
    public float chance; // percent
    public int value; // sell price
    public int howManyPlayerHasCaught; // for stats
    public bool isCaught; // for stats
    public GameObject fishModel;
}

[System.Serializable]
public class FishingZone
{
    public string zoneName;
    public float difficulty;
    public FishRarity[] rarities;
}
