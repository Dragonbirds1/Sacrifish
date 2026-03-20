using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SwapRods : MonoBehaviour
{
    public BobberDangling bobberDangling;

    public KeyCode rodSwapKey;

    public Rods[] rods;
    public Rods currentRod;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRod = rods[0];
    }

    // Update is called once per frame
    void Update()
    {
        SwapRod();
        bobberDangling.rodTip = currentRod.rodTip;
    }

    public void SwapRod()
    {
        if (Input.GetKeyDown(rodSwapKey))
        {
            
        }
    }

    string ActiveRod(RodInfo[] rodInfo)
    {
        return rodInfo[0].name;
    }
}

[System.Serializable]
public class Rods
{
    public Transform rodTip;
    public GameObject rodModel;
    public RodInfo[] rodInfo;
    
}

[System.Serializable]
public class RodInfo
{
    public string name;
    public float rodId;
}