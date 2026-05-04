using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class CatchFish : MonoBehaviour
{
    public CastRod castRod;
    public PlayerMotor playerMotor;
    public BobberWaterControl bobberWaterControl;
    public CatchMinigame catchMinigame;
    public FishBarAI fishBarAI;
    public MerchantManager merchantManager;
    public TempInventoryManager tempInventoryManager;
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
    public string rarityName;
    public int reckelsToAdd;

    public FishingZone[] zones;
    public FishingZone currentZone;

    public float playerLuck; // = 0.1f;
    public float rodBonus; // = 0.05f;
    public float baitBonus; // = 0.05f;

    private GameObject fishClone;

    public AudioSource songSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        catchBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        songSource.clip = currentZone.zoneSong;
        if (!songSource.isPlaying)
        {
            songSource.Play();
        }
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

                    playerMotor.canMove = false;

                    playerMotor.canJump = false;

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
                    // Spawn the fish model and make the fish mover in the model move to the fish spawn point
                    fishClone = Instantiate(rarities[i].fishModel, fishSpawn.transform.position, Quaternion.identity);
                    // Make it so the fish model is a child of the fishSpawn object
                    fishClone.transform.SetParent(fishSpawn.transform);
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

        playerMotor.canJump = true;

        playerMotor.canMove = true;

        // BUTTON CAVERN ZONE
        if (zones[0].rarities[0].isCaught)
        {
            zones[0].rarities[0].howManyPlayerHasCaught++;
            zones[0].rarities[0].isCaught = false;
            zones[0].rarities[0].moveToInventory = true;
        }
        else if (zones[0].rarities[1].isCaught)
        {
            zones[0].rarities[1].howManyPlayerHasCaught++;
            zones[0].rarities[1].isCaught = false;
            zones[0].rarities[1].moveToInventory = true;
        }
        else if (zones[0].rarities[2].isCaught)
        {
            zones[0].rarities[2].howManyPlayerHasCaught++;
            zones[0].rarities[2].isCaught = false;
            zones[0].rarities[2].moveToInventory = true;
        }

        // CROWN ISLAND ZONE
        else if (zones[1].rarities[0].isCaught)
        {
            zones[1].rarities[0].howManyPlayerHasCaught++;
            zones[1].rarities[0].isCaught = false;
            zones[1].rarities[0].moveToInventory = true;
        }
        else if (zones[1].rarities[1].isCaught)
        {
            zones[1].rarities[1].howManyPlayerHasCaught++;
            zones[1].rarities[1].isCaught = false;
            zones[1].rarities[1].moveToInventory = true;
        }
        else if (zones[1].rarities[2].isCaught)
        {
            zones[1].rarities[2].howManyPlayerHasCaught++;
            zones[1].rarities[2].isCaught = false;
            zones[1].rarities[2].moveToInventory = true;
        }

        // FORGOTTEN JUNGLE ZONE
        else if (zones[2].rarities[0].isCaught)
        {
            zones[2].rarities[0].howManyPlayerHasCaught++;
            zones[2].rarities[0].isCaught = false;
            zones[2].rarities[0].moveToInventory = true;
        }
        else if (zones[2].rarities[1].isCaught)
        {
            zones[2].rarities[1].howManyPlayerHasCaught++;
            zones[2].rarities[1].isCaught = false;
            zones[2].rarities[1].moveToInventory = true;
        }
        else if (zones[2].rarities[2].isCaught)
        {
            zones[2].rarities[2].howManyPlayerHasCaught++;
            zones[2].rarities[2].isCaught = false;
            zones[2].rarities[2].moveToInventory = true;
        }

        // OCEAN ZONE
        else if (zones[3].rarities[0].isCaught)
        {
            zones[3].rarities[0].howManyPlayerHasCaught++;
            zones[3].rarities[0].isCaught = false;
            zones[3].rarities[0].moveToInventory = true;
        }
        else if (zones[3].rarities[1].isCaught)
        {
            zones[3].rarities[1].howManyPlayerHasCaught++;
            zones[3].rarities[1].isCaught = false;
            zones[3].rarities[1].moveToInventory = true;
        }
        else if (zones[3].rarities[2].isCaught)
        {
            zones[3].rarities[2].howManyPlayerHasCaught++;
            zones[3].rarities[2].isCaught = false;
            zones[3].rarities[2].moveToInventory = true;
        }

        // TOXIC GROWTH ZONE
        else if (zones[4].rarities[0].isCaught)
        {
            zones[4].rarities[0].howManyPlayerHasCaught++;
            zones[4].rarities[0].isCaught = false;
            zones[4].rarities[0].moveToInventory = true;
        }
        else if (zones[4].rarities[1].isCaught)
        {
            zones[4].rarities[1].howManyPlayerHasCaught++;
            zones[4].rarities[1].isCaught = false;
            zones[4].rarities[1].moveToInventory = true;
        }
        else if (zones[4].rarities[2].isCaught)
        {
            zones[4].rarities[2].howManyPlayerHasCaught++;
            zones[4].rarities[2].isCaught = false;
            zones[4].rarities[2].moveToInventory = true;
        }
        // Add the fish to an empty slot in the inventory and set the slot stats to the fish stats
        Debug.Log("Caught: " + rarity + " " + rarityName + " fish in " + currentZone.zoneName);
        GetCaughtFish();
    }

    public void FailedCatch()
    {
        playerMotor.canJump = true;

        playerMotor.canMove = true;

        foreach (var rarity in currentZone.rarities)
        {
            rarity.isCaught = false; // Reset all rarities in the current zone to not caught
        }
    }

    public void GetCaughtFish()
    {
        // Make it so the script checks for the caught fish and sets the stats of the caught fish in the inventory to the stats of the caught fish in the catchfish script
        foreach (var rarity in currentZone.rarities)
        {
            if (rarity.moveToInventory)
            {
                // Get the stat from TempInventoryManager and set it to the stat of the caught fish in the inventory
                tempInventoryManager.AddFishToInventory(rarity.fishName, rarity.howManyPlayerHasCaught);
                Debug.Log("Added " + rarity.fishName + " fish to inventory with value " + rarity.howManyPlayerHasCaught);
                Destroy(fishClone);


                // Reset the moveToInventory flag
                rarity.moveToInventory = false;
            }
        }
    }

    public void SellAllFish()
    {
        foreach (var rarity in currentZone.rarities)
        {
            if (rarity.howManyPlayerHasCaught > 0)
            {
                Debug.Log("Sold " + rarity.howManyPlayerHasCaught + " " + rarity.fishName + " fish for " + (rarity.value * rarity.howManyPlayerHasCaught) + " coins.");
                reckelsToAdd += rarity.value * rarity.howManyPlayerHasCaught;
                rarity.howManyPlayerHasCaught = 0;
                //Destroy(fishClone);
                // Make it so the TempInventoryManager script checks for the sold fish and subtracts the quantity of the sold fish from the inventory
                tempInventoryManager.SellAllFishFromInventory(rarity.fishName, rarity.howManyPlayerHasCaught);
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
    public string fishName;
    public float chance; // percent
    public int value; // sell price
    public int howManyPlayerHasCaught; // for stats
    public bool isCaught; // for stats
    public bool moveToInventory; // for stats
    public GameObject fishModel;
}

[System.Serializable]
public class FishingZone
{
    public string zoneName;
    public float difficulty;
    public AudioClip zoneSong;
    public FishRarity[] rarities;
}
