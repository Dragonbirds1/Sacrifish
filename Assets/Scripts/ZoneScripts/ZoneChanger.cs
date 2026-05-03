using UnityEngine;
using TMPro;

public class ZoneChanger : MonoBehaviour
{
    public CatchFish catchFish;
    public Animator popupAnim;
    public GameObject popup;
    public TextMeshProUGUI popupText;
    public bool showPopup;
    public float popupDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showPopup)
        {
            popupAnim.SetBool("NewArea", true);
            popupDuration -= Time.deltaTime;
            if (popupDuration <= 0)
            {
                popupAnim.SetBool("NewArea", false);
                popupDuration = 2f;
                showPopup = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CrownIsland"))
        {
            catchFish.currentZone = catchFish.zones[0];
            catchFish.songSource.Play();
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Crown Island";
            showPopup = true;
        }
        else if (other.CompareTag("Ocean"))
        {
            catchFish.currentZone = catchFish.zones[1];
            catchFish.songSource.Play();
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Ocean";
            showPopup = true;
        }
        else if (other.CompareTag("ButtonCavern"))
        {
            catchFish.currentZone = catchFish.zones[2];
            catchFish.songSource.Play();
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Button Cavern";
            showPopup = true;
        }
        else if (other.CompareTag("ForgottenJungle"))
        {
            catchFish.currentZone = catchFish.zones[3];
            catchFish.songSource.Play();
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Forgotten Jungle";
            showPopup = true;
        }
        else if (other.CompareTag("EternalIslandDesert"))
        {
            catchFish.currentZone = catchFish.zones[4];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Eternal Island Desert";
            showPopup = true;
        }
        else if (other.CompareTag("ToxicGrowth"))
        {
            catchFish.currentZone = catchFish.zones[5];
            catchFish.songSource.Play();
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Toxic Growth";
            showPopup = true;
        }
        else if (other.CompareTag("EternalIslandIcy"))
        {
            catchFish.currentZone = catchFish.zones[6];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Eternal Island Tundra";
            showPopup = true;
        }
        else if (other.CompareTag("ScorchingDeep"))
        {
            catchFish.currentZone = catchFish.zones[7];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Scorching Deep";
            showPopup = true;
        }
        else if (other.CompareTag("NorthPole"))
        {
            catchFish.currentZone = catchFish.zones[8];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "North Pole";
            showPopup = true;
        }
        else if (other.CompareTag("MutatedAbyss"))
        {
            catchFish.currentZone = catchFish.zones[9];
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Mutated Abyss";
            showPopup = true;
        }
    }
}
