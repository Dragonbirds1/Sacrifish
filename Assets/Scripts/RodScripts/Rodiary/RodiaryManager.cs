using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UIElements;

public class RodiaryManager : MonoBehaviour
{
    public Zones[] zones;
    public Zones activeZone;

    public GameObject[] glow;

    public GameObject rodiary;

    public KeyCode toggleKey;

    public PlayerMotor playerMotor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject g in glow)
        {
            g.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            rodiary.SetActive(!rodiary.gameObject.activeSelf);
            playerMotor.showCursor = !playerMotor.showCursor;
        }
    }

    public void ButtonCavernClick()
    {
        foreach (var rod in zones[0].rods)
        {
            rod.rodSlot.gameObject.SetActive(true);
        }

        foreach (var rod in zones[1].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[2].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[3].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[4].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[5].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[6].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }
    }

    public void CrownIslandClick()
    {
        foreach (var rod in zones[0].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[1].rods)
        {
            rod.rodSlot.gameObject.SetActive(true);
        }

        foreach (var rod in zones[2].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[3].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[4].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[5].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[6].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }
    }

    public void ForgottenJungleClick()
    {
        foreach (var rod in zones[0].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[1].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[2].rods)
        {
            rod.rodSlot.gameObject.SetActive(true);
        }

        foreach (var rod in zones[3].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[4].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[5].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[6].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }
    }

    public void OceanClick()
    {
        foreach (var rod in zones[0].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[1].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[2].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[3].rods)
        {
            rod.rodSlot.gameObject.SetActive(true);
        }

        foreach (var rod in zones[4].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[5].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[6].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }
    }

    public void ToxicGrowthClick()
    {
        foreach (var rod in zones[0].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[1].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[2].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[3].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[4].rods)
        {
            rod.rodSlot.gameObject.SetActive(true);
        }

        foreach (var rod in zones[5].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[6].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }
    }

    public void RegionlessClick()
    {
        foreach (var rod in zones[0].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[1].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[2].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[3].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[4].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[5].rods)
        {
            rod.rodSlot.gameObject.SetActive(true);
        }

        foreach (var rod in zones[6].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }
    }

    public void AdminClick()
    {
        foreach (var rod in zones[0].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[1].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[2].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[3].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[4].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[5].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }

        foreach (var rod in zones[6].rods)
        {
            rod.rodSlot.gameObject.SetActive(true);
        }
    }

    public void ResetGlow()
    {
        foreach (GameObject gameObject in glow)
        {
            gameObject.SetActive(false);
        }
    }
}

[System.Serializable]
public class RodStats
{
    public string rodRarity;
    public int rodLevel;
    public int id;
}

[System.Serializable]
public class RodiaryRods
{
    public string rodName;
    public GameObject rodSlot;
    public bool unlockedRod;
    public RodStats[] rodStats;
}

[System.Serializable]
public class Zones
{
    public string zoneName;
    public string zoneId;
    public Button zoneButton;
    public RodiaryRods[] rods;
}
