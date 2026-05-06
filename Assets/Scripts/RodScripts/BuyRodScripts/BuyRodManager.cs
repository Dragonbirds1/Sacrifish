using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class BuyRodManager : MonoBehaviour
{
    public SwapRods swapRods;

    public CatchFish catchFish;

    [Header("Rod Information")]

    public string rodName;
    
    public int rodPrice;

    [Header("Keybinds")]

    public KeyCode buyRodKey;

    [Header("Debug")]

    public float distanceToBuyRod;

    public GameObject player;

    public GameObject boat;

    public GameObject fakeBoat;

    [Header("UI")]

    public TextMeshProUGUI rodNameText;

    public TextMeshProUGUI rodPriceText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= distanceToBuyRod)
        {
            rodNameText.text = rodName;
            rodPriceText.text = rodPrice + "Ɍ";
            if (Input.GetKeyDown(buyRodKey))
            {
                if (catchFish.reckelsToAdd >= rodPrice)
                {
                    catchFish.reckelsToAdd -= rodPrice;

                    Debug.Log("Bought " + rodName);

                    boat.SetActive(true);

                    fakeBoat.SetActive(false);
                }

                else if (catchFish.reckelsToAdd < rodPrice)
                {
                    Debug.Log("Not enough reckels to buy " + rodName);
                }
            }
        }
        else
        {
            rodNameText.text = "";
            rodPriceText.text = "";
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToBuyRod);
    }
}
