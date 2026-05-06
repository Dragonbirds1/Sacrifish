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

    public KeyCode[] rodSwapKeys; // This is for testing purposes, there will be no keycodes when finished.

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
        if (Input.GetKeyDown(rodSwapKeys[0]))
        {
            currentRod = rods[1];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[1]))
        {
            currentRod = rods[0];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[2]))
        {
            currentRod = rods[2];
            foreach (var rods in rods)
            {
                rods.isRod = false; 
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[3]))
        {
            currentRod = rods[3];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[4]))
        {
            currentRod = rods[4];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[5]))
        {
            currentRod = rods[5];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[6]))
        {
            currentRod = rods[6];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[7]))
        {
            currentRod = rods[7];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[8]))
        {
            currentRod = rods[8];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[9]))
        {
            currentRod = rods[9];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[10]))
        {
            currentRod = rods[10];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[11]))
        {
            currentRod = rods[11];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[12]))
        {
            currentRod = rods[12];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[13]))
        {
            currentRod = rods[13];
            foreach (var rods in rods)
            {
                rods.isRod = false;
            }
        }
        if (Input.GetKeyDown(rodSwapKeys[14]))
        {
            currentRod = rods[14];
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
    public Animator rodCastAnimator;
    public string name;
    public float rodId;
    public bool isRod;
}