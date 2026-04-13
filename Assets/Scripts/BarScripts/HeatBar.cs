using UnityEngine;
using UnityEngine.UI;

public class HeatBar : MonoBehaviour
{
    public GameObject player;

    public GameObject heatBar;

    public Image fillBar;

    public float maxHeat = 100f;
    public float currentHeat = 0f;

    public bool isInHeatArea = false;
    public bool hasHeat = false;
    public bool disableHeatAtStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fillBar.fillAmount = 0;
        if (disableHeatAtStart)
        {
            heatBar.SetActive(false);
        }
        else
        {
            heatBar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInHeatArea && hasHeat)
        {
            currentHeat -= Time.deltaTime * 5f; // Adjust the rate of heat increase as needed`
            currentHeat = Mathf.Clamp(currentHeat, 0f, maxHeat);
            fillBar.fillAmount = currentHeat / maxHeat;
            if (currentHeat <= 0f)
            {
                heatBar.SetActive(false);
                hasHeat = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            heatBar.SetActive(true);
            isInHeatArea = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            currentHeat += Time.deltaTime * 5f; // Adjust the rate of heat increase as needed
            currentHeat = Mathf.Clamp(currentHeat, 0f, maxHeat);
            fillBar.fillAmount = currentHeat / maxHeat;
            isInHeatArea = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isInHeatArea = false;
            hasHeat = true;
        }
    }
}
