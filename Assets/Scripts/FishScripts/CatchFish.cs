using UnityEngine;
using TMPro;

public class CatchFish : MonoBehaviour
{
    public CastRod castRod;
    public BobberWaterControl bobberWaterControl;
    public float timeTillCatch; // Timer Floats
    public float rodCatchTime; // Object Floats
    public bool fishCaught;
    public float commonChance, uncommonChance, rareChance, superRareChance;
    public float epicChance, legendaryChance, mythicChance, godlyChance, divineChance, secretChance;
    public string fishRarityName, commonFishName, uncommonFishName, rareFishName, superRareFishName;
    public string epicFishName, legendaryFishName, mythicFishName, godlyFishName, divineFishName, secretFishName;

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
                    float fishRarity = Random.Range(0f, 1f);
                    if (fishRarity <= commonChance && fishRarity > uncommonChance)
                    {
                        fishRarityName = commonFishName;
                    }
                    else if (fishRarity <= uncommonChance && fishRarity > rareChance)
                    {
                        fishRarityName = uncommonFishName;
                    }
                    else if (fishRarity <= rareChance && fishRarity > superRareChance)
                    {
                        fishRarityName = rareFishName;
                    }
                    else if (fishRarity <= superRareChance && fishRarity > epicChance)
                    {
                        fishRarityName = superRareFishName;
                    }
                    else if (fishRarity <= epicChance && fishRarity > legendaryChance)
                    {
                        fishRarityName = epicFishName;
                    }
                    else if (fishRarity <= legendaryChance && fishRarity > mythicChance)
                    {
                        fishRarityName = legendaryFishName;
                    }
                    else if (fishRarity <= mythicChance && fishRarity > godlyChance)
                    {
                        fishRarityName = mythicFishName;
                    }
                    else if (fishRarity <= godlyChance && fishRarity > divineChance)
                    {
                        fishRarityName = godlyFishName;
                    }
                    else if (fishRarity <= divineChance && fishRarity > secretChance)
                    {
                        fishRarityName = divineFishName;
                    }
                    else if (fishRarity <= secretChance)
                    {
                        fishRarityName = secretFishName;
                    }
                    
                    Debug.Log("Caught a " + fishRarityName + " Fish");
                    fishCaught = true;
                }
                timeTillCatch = 0;
                castRod.Retract();
            }
        }
    }
}
