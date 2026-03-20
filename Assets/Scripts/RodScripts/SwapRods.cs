using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class SwapRods : MonoBehaviour
{
    public BobberDangling bobberDangling;
    public BobberOnLine bobberOnLine;
    public BobberHanging bobberHanging;
    public FishingLineRenderer fishingLineRenderer;

    public KeyCode rodSwapKey, rodSwapKey2;

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
        bobberOnLine.rodTip = currentRod.rodTip;
        bobberHanging.rodTip = currentRod.rodTip;
        fishingLineRenderer.rodTip = currentRod.rodTip;
        currentRod.rodModel.SetActive(true);
        currentRod.isRod = true;
        foreach (var rods in rods)
        {
            if (rods.isRod == false)
            {
                rods.rodModel.SetActive(false);
            }
        }
    }

    public void SwapRod()
    {
        if (Input.GetKeyDown(rodSwapKey))
        {
            currentRod = rods[1];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKey2))
        {
            currentRod = rods[0];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
    }
}

[System.Serializable]
public class Rods
{
    public Transform rodTip;
    public GameObject rodModel;
    public string name;
    public float rodId;
    public bool isRod;
}