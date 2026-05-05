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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonCavernClick()
    {

        foreach (var rod in zones[0].rods)
        {
            rod.rodSlot.gameObject.SetActive(false);
        }
    }

    public void CrownIslandClick()
    {

    }

    public void ForgottenJungleClick()
    {

    }

    public void OceanClick()
    {

    }

    public void ToxicGrowthClick()
    {

    }

    public void RegionlessClick()
    {

    }

    public void AdminClick()
    {

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
