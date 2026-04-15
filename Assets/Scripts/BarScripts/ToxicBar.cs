using UnityEngine;
using UnityEngine.UI;

public class ToxicBar : MonoBehaviour
{
    public GameObject player;

    public GameObject toxicBar;

    public Image fillBar;

    public float maxToxicity = 100f;
    public float currentToxicity = 0f;

    public bool isInToxicArea = false;
    public bool hasToxic = false;
    public bool disableToxicAtStart;
    public bool hasGasMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fillBar.fillAmount = 0;
        if (disableToxicAtStart)
        {
            toxicBar.SetActive(false);
        }
        else
        {
            toxicBar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInToxicArea && hasToxic)
        {
            currentToxicity -= Time.deltaTime * 5f; // Adjust the rate of toxicity increase as needed`
            currentToxicity = Mathf.Clamp(currentToxicity, 0f, maxToxicity);
            fillBar.fillAmount = currentToxicity / maxToxicity;
            if (currentToxicity <= 0f)
            {
                toxicBar.SetActive(false);
                hasToxic = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (hasGasMask)
        {
            return; // If the player has a gas mask, they are immune to toxicity
        }
        if (other.gameObject == player)
        {
            toxicBar.SetActive(true);
            isInToxicArea = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (hasGasMask)
        {
            return; // If the player has a gas mask, they are immune to toxicity
        }
        if (other.gameObject == player)
        {
            currentToxicity += Time.deltaTime * 100f; // Adjust the rate of toxicity increase as needed
            currentToxicity = Mathf.Clamp(currentToxicity, 0f, maxToxicity);
            fillBar.fillAmount = currentToxicity / maxToxicity;
            isInToxicArea = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isInToxicArea = false;
            hasToxic = true;
        }
    }
}
