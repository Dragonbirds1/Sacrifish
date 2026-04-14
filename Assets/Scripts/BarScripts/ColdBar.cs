using UnityEngine;
using UnityEngine.UI;

public class ColdBar : MonoBehaviour
{
    public GameObject player;

    public GameObject coldBar;

    public Image fillBar;

    public float maxCold = 100f;
    public float currentCold = 0f;

    public bool isInColdArea = false;
    public bool hasCold = false;
    public bool disableColdAtStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fillBar.fillAmount = 0;
        if (disableColdAtStart)
        {
            coldBar.SetActive(false);
        }
        else
        {
            coldBar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInColdArea && hasCold)
        {
            currentCold -= Time.deltaTime * 5f; // Adjust the rate of cold increase as needed`
            currentCold = Mathf.Clamp(currentCold, 0f, maxCold);
            fillBar.fillAmount = currentCold / maxCold;
            if (currentCold <= 0f)
            {
                coldBar.SetActive(false);
                hasCold = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            coldBar.SetActive(true);
            isInColdArea = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            currentCold += Time.deltaTime * 5f; // Adjust the rate of cold increase as needed
            currentCold = Mathf.Clamp(currentCold, 0f, maxCold);
            fillBar.fillAmount = currentCold / maxCold;
            isInColdArea = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isInColdArea = false;
            hasCold = true;
        }
    }
}
