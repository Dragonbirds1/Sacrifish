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

    public Rods[] rods;
    public Rods currentRod;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRod = rods[8];
    }

    // Update is called once per frame
    void Update()
    {
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

    public void DevRod()
    {
        currentRod = rods[0];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void LeafRod()
    {
        currentRod = rods[1];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void FlowerRod()
    {
        currentRod = rods[2];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void WormRod()
    {
        currentRod = rods[3];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void LuckRod()
    {
        currentRod = rods[4];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void CrownRod()
    {
        currentRod = rods[5];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void JungleKingRod()
    {
        currentRod = rods[6];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void ZenithRod()
    {
        currentRod = rods[7];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void StarterRod()
    {
        currentRod = rods[8];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void VineRod()
    {
        currentRod = rods[9];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void PoisonRod()
    {
        currentRod = rods[10];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void CrystalRod()
    {
        currentRod = rods[11];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void SunRod()
    {
        currentRod = rods[12];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void RockyRod()
    {
        currentRod = rods[13];
        foreach (var rods in rods)
        {
            rods.isRod = false;
        }
    }

    public void AnchorRod()
    {
        currentRod = rods[14];
        foreach (var rods in rods)
        {
            rods.isRod = false;
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