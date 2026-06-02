using UnityEngine;
using TMPro;

public class ZoneChanger : MonoBehaviour
{
    public CatchFish catchFish;
    public GameObject[] Crown, Button, Ocean, Jungle, Growth;
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
            foreach (GameObject crown in Crown)
            {
                crown.SetActive(false);
            }
            foreach (GameObject button in Button)
            {
                button.SetActive(true);
            }
            foreach (GameObject ocean in Ocean)
            {
                ocean.SetActive(true);
            }
            showPopup = true;
            return;
        }
        else if (other.CompareTag("Ocean"))
        {
            catchFish.currentZone = catchFish.zones[1];
            catchFish.songSource.Play();
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Ocean";
            showPopup = true;
            foreach (GameObject ocean in Ocean)
            {
                ocean.SetActive(false);
            }
            foreach (GameObject jungle in Jungle)
            {
                jungle.SetActive(true);
            }
            foreach (GameObject crown in Crown)
            {
                crown.SetActive(true);
            }
            return;
        }
        else if (other.CompareTag("ButtonCavern"))
        {
            catchFish.currentZone = catchFish.zones[2];
            catchFish.songSource.Play();
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Button Cavern";
            showPopup = true;
            foreach (GameObject crown in Crown)
            {
                crown.SetActive(true);
            }
            foreach (GameObject button in Button)
            {
                button.SetActive(false);
            }
            return;
        }
        else if (other.CompareTag("ForgottenJungle"))
        {
            catchFish.currentZone = catchFish.zones[3];
            catchFish.songSource.Play();
            Debug.Log("Fishing Location: " + catchFish.currentZone.zoneName);
            popupText.text = "Forgotten Jungle";
            showPopup = true;
            foreach (GameObject jungle in Jungle)
            {
                jungle.SetActive(false);
            }
            foreach (GameObject growth in Growth)
            {
                growth.SetActive(true);
            }
            foreach (GameObject ocean in Ocean)
            {
                ocean.SetActive(true);
            }
            return;
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
            foreach (GameObject jungle in Jungle)
            {
                jungle.SetActive(true);
            }
            foreach (GameObject growth in Growth)
            {
                growth.SetActive(false);
            }
            return;
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
