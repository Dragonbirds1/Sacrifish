using UnityEngine;
using UnityEngine.UI;

public class FishBarAI : MonoBehaviour
{
    public CatchFish catchFish; // reference to your fishing system

    public CatchMinigame catchMinigame; // reference to your catchBar script

    public CastRod castRod;

    public GameObject catchBar;

    [Header("Fish Info")]
    public FishingZone currentZone;
    public string fishRarity;

    [Header("UI")]
    public RectTransform fishRect;
    public RectTransform smallBarRect; // the "sweet spot" bar
    public Image progressBar;          // UI progress bar

    [Header("Movement")]
    public float X;
    public float velocity;
    public float minX = -422f;
    public float maxX = 422f;
    public float originalPosX;
    public float originalPosY;

    private float moveSpeed;
    private float acceleration;
    private float decisionTimeMin;
    private float decisionTimeMax;

    private float targetX;
    private float decisionTimer;
    public float timeTillStart;

    public bool startMinigame;
    public bool alreadyAt10;

    [Header("Catch System")]
    [Range(0f, 100f)]
    public float progress = 0f; // 0 = lost, 100 = caught
    public float progressSpeed = 30f; // per second when inside/outside bar

    void Update()
    {
        if (!catchFish.fishOnLine) return;

        progress = Mathf.Clamp(progress, 0f, 100f);
        if (progressBar != null)
            progressBar.fillAmount = progress / 100f;

        if (catchFish.fishOnLine && startMinigame == false)
        {
            timeTillStart += Time.deltaTime;
            if (alreadyAt10 == false)
            {
                castRod.canRetract = false;
                progress += 10 * Time.deltaTime;
                fishRect.anchoredPosition = new Vector2(originalPosX, originalPosY);
                smallBarRect.anchoredPosition = new Vector2(originalPosX, originalPosY);
                X = 0;
                catchMinigame.X = 0;
                if (progress >= 10)
                {
                    alreadyAt10 = true;
                }
            }
            if (timeTillStart >= 3f)
            {
                startMinigame = true;
                timeTillStart = 0f;
            }
        }

        if (startMinigame)
        {
            catchMinigame.canControl = true;

            // --- Fish Movement ---
            decisionTimer -= Time.deltaTime;
            if (decisionTimer <= 0f)
                PickNewTarget();

            float distance = targetX - X;
            float slowFactor = Mathf.Clamp01(Mathf.Abs(distance) / 200f);
            float direction = Mathf.Sign(distance);
            velocity += direction * acceleration * slowFactor * Time.deltaTime;

            if (IsHighTierFish())
                velocity += Random.Range(-300f, 300f) * Time.deltaTime;

            velocity = Mathf.Clamp(velocity, -moveSpeed, moveSpeed);
            X += velocity * Time.deltaTime;
            X = Mathf.Clamp(X, minX, maxX);
            fishRect.anchoredPosition = new Vector2(X, fishRect.anchoredPosition.y);

            // --- Progress Logic ---
            if (IsFishInsideSmallBar())
            {
                progress += progressSpeed * Time.deltaTime;
            }
            else
            {
                progress -= progressSpeed * Time.deltaTime;
            }

            // --- Win / Lose ---
            if (progress >= 100f)
            {
                Debug.Log("Fish Caught!");
                catchFish.fishOnLine = false;
                startMinigame = false;
                alreadyAt10 = false;
                catchMinigame.canControl = false;
                catchBar.SetActive(false);
                castRod.canRetract = true;
                castRod.Retract();
                catchFish.timeTillCatch = 0;
            }
            else if (progress <= 0f)
            {
                Debug.Log("Fish Escaped!");
                catchFish.fishOnLine = false;
                startMinigame = false;
                alreadyAt10 = false;
                catchMinigame.canControl = false;
                catchBar.SetActive(false);
                castRod.canRetract = true;
                castRod.Retract();
                catchFish.timeTillCatch = 0;
            }
        }
    }

    void PickNewTarget()
    {
        targetX = Random.Range(minX, maxX);
        decisionTimer = Random.Range(decisionTimeMin, decisionTimeMax);
    }

    void ApplyDifficulty()
    {
        float zoneDiff = currentZone.difficulty;
        float rarityMult = GetRarityMultiplier();
        float final = zoneDiff * rarityMult;

        if (currentZone.zoneName == "Crown Island" || currentZone.zoneName == "Ocean")
            final = Mathf.Min(final, 1.5f);

        moveSpeed = 400f + (final * 120f);
        acceleration = 800f + (final * 250f);

        decisionTimeMin = Mathf.Clamp(1.5f - final * 0.1f, 0.2f, 2f);
        decisionTimeMax = Mathf.Clamp(2.5f - final * 0.15f, 0.3f, 3f);

        float randomFactor = Random.Range(0.9f, 1.1f);
        moveSpeed *= randomFactor;
        acceleration *= randomFactor;
    }

    float GetRarityMultiplier()
    {
        float mult = 1f;
        switch (fishRarity)
        {
            case "Common": mult = 0.8f; break;
            case "Uncommon": mult = 0.9f; break;
            case "Rare": mult = 1.0f; break;
            case "SuperRare": mult = 1.1f; break;
            case "Epic": mult = 1.2f; break;
            case "Legendary": mult = 1.35f; break;
            case "Mythic": mult = 1.5f; break;
            case "Godly": mult = 1.7f; break;
            case "Divine": mult = 1.9f; break;
            case "Secret": mult = 2.2f; break;
        }

        if (currentZone.zoneName == "Crown Island" || currentZone.zoneName == "Ocean")
            mult *= 0.7f;

        return mult;
    }

    bool IsHighTierFish()
    {
        return fishRarity == "Legendary" || fishRarity == "Mythic" ||
               fishRarity == "Godly" || fishRarity == "Divine" ||
               fishRarity == "Secret";
    }

    bool IsFishInsideSmallBar()
    {
        float fishPos = fishRect.anchoredPosition.x;
        float barMin = smallBarRect.anchoredPosition.x - smallBarRect.rect.width / 2;
        float barMax = smallBarRect.anchoredPosition.x + smallBarRect.rect.width / 2;
        return fishPos >= barMin && fishPos <= barMax;
    }

    public void Setup(FishingZone zone, string rarity)
    {
        currentZone = zone;
        fishRarity = rarity;
        progress = 0f; // reset progress
        ApplyDifficulty();
    }
}