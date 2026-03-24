using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class FishtiaryManager : MonoBehaviour
{
    [Header("Locations")]
    public List<GameObject> buttonCavern;
    public List<GameObject> crownIsland;
    public List<GameObject> eternalDesert;
    public List<GameObject> eternalIcy;
    public List<GameObject> forgottenJungle;
    public List<GameObject> mutatedAbyss;
    public List<GameObject> northPole;

    [Header("Rarities")]
    public GameObject common;
    public GameObject uncommon;
    public GameObject rare;
    public GameObject superRare;
    public GameObject epic;
    public GameObject legendary;
    public GameObject mythic;
    public GameObject godly;
    public GameObject divine;
    public GameObject secret;

    [Header("GameObjects")]
    public GameObject desertSecret, icySecret, jungleSecret, northPoleSecret;
    public GameObject outline1, outline2, outline3, outline4, outline5, outline6, outline7;
    public GameObject coverBt, coverCr, coverDe, coverIc, coverJu, coverAb, coverPo;

    [Header("Bools")]
    public bool discovered1, discovered2, discovered3, discovered4, discovered5, discovered6, discovered7;
    public bool buttonCav, crownIsle, eternalDes, eternalIce, forgottenJun, mutatedAby, northPo;
    public bool setButton, setCrown, setDesert, setIcy, setJungle, setAbyss, setPole;

    [Header("TMPObjects")]
    public TextMeshProUGUI fishNameCommon, fishNameUncommon, fishNameRare, fishNameSuperRare, fishNameEpic, fishNameLegendary, fishNameMythic, fishNameGodly, fishNameDivine, fishNameSecret;
    public TextMeshProUGUI fishKgCommon, fishKgUncommon, fishKgRare, fishKgSuperRare, fishKgEpic, fishKgLegendary, fishKgMythic, fishKgGodly, fishKgDivine, fishKgSecret;
    public TextMeshProUGUI perferedWeatherCommon, perferedWeatherUncommon, perferedWeatherRare, perferedWeatherSuperRare, perferedWeatherEpic, perferedWeatherLegendary, perferedWeatherMythic, perferedWeatherGodly, perferedWeatherDivine, perferedWeatherSecret;
    public TextMeshProUGUI perferedTimeCommon, perferedTimeUncommon, perferedTimeRare, perferedTimeSuperRare, perferedTimeEpic, perferedTimeLegendary, perferedTimeMythic, perferedTimeGodly, perferedTimeDivine, perferedTimeSecret;
    public TextMeshProUGUI perferedSeasonCommon, perferedSeasonUncommon, perferedSeasonRare, perferedSeasonSuperRare, perferedSeasonEpic, perferedSeasonLegendary, perferedSeasonMythic, perferedSeasonGodly, perferedSeasonDivine, perferedSeasonSecret;
    public TextMeshProUGUI perferedBaitCommon, perferedBaitUncommon, perferedBaitRare, perferedBaitSuperRare, perferedBaitEpic, perferedBaitLegendary, perferedBaitMythic, perferedBaitGodly, perferedBaitDivine, perferedBaitSecret;

    [Header("Strings")]
    public string fishName, fishKg, perferedWeather, perferedTime, perferedSeason, perferedBait;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        desertSecret.SetActive(false);
        icySecret.SetActive(false);
        jungleSecret.SetActive(false);
        northPoleSecret.SetActive(false);
        outline1.SetActive(false);
        outline2.SetActive(false);
        outline3.SetActive(false);
        outline4.SetActive(false);
        outline5.SetActive(false);
        outline6.SetActive(false);
        outline7.SetActive(false);
        foreach (var gameObject in buttonCavern)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in crownIsland)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalDesert)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalIcy)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in forgottenJungle)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in mutatedAbyss)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in northPole)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonCavern()
    {
        foreach (var gameObject in buttonCavern)
        {
            gameObject.SetActive(true);
        }
        foreach (var gameObject in crownIsland)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalDesert)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalIcy)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in forgottenJungle)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in mutatedAbyss)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in northPole)
        {
            gameObject.SetActive(false);
        }
        outline1.SetActive(true);
        outline2.SetActive(false);
        outline3.SetActive(false);
        outline4.SetActive(false);
        outline5.SetActive(false);
        outline6.SetActive(false);
        outline7.SetActive(false);
        setButton = true;
        setCrown = false;
        setDesert = false;
        setIcy = false;
        setJungle = false;
        setAbyss = false;
        setPole = false;
    }

    public void Crown()
    {
        foreach (var gameObject in buttonCavern)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in crownIsland)
        {
            gameObject.SetActive(true);
        }
        foreach (var gameObject in eternalDesert)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalIcy)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in forgottenJungle)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in mutatedAbyss)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in northPole)
        {
            gameObject.SetActive(false);
        }
        outline1.SetActive(false);
        outline2.SetActive(true);
        outline3.SetActive(false);
        outline4.SetActive(false);
        outline5.SetActive(false);
        outline6.SetActive(false);
        outline7.SetActive(false);
        setButton = false;
        setCrown = true;
        setDesert = false;
        setIcy = false;
        setJungle = false;
        setAbyss = false;
        setPole = false;
    }

    public void Desert()
    {
        foreach (var gameObject in buttonCavern)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in crownIsland)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalDesert)
        {
            gameObject.SetActive(true);
        }
        foreach (var gameObject in eternalIcy)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in forgottenJungle)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in mutatedAbyss)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in northPole)
        {
            gameObject.SetActive(false);
        }
        outline1.SetActive(false);
        outline2.SetActive(false);
        outline3.SetActive(true);
        outline4.SetActive(false);
        outline5.SetActive(false);
        outline6.SetActive(false);
        outline7.SetActive(false);
        setButton = false;
        setCrown = false;
        setDesert = true;
        setIcy = false;
        setJungle = false;
        setAbyss = false;
        setPole = false;
    }

    public void Icy()
    {
        foreach (var gameObject in buttonCavern)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in crownIsland)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalDesert)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalIcy)
        {
            gameObject.SetActive(true);
        }
        foreach (var gameObject in forgottenJungle)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in mutatedAbyss)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in northPole)
        {
            gameObject.SetActive(false);
        }
        outline1.SetActive(false);
        outline2.SetActive(false);
        outline3.SetActive(false);
        outline4.SetActive(true);
        outline5.SetActive(false);
        outline6.SetActive(false);
        outline7.SetActive(false);
        setButton = false;
        setCrown = false;
        setDesert = false;
        setIcy = true;
        setJungle = false;
        setAbyss = false;
        setPole = false;
    }

    public void Jungle()
    {
        foreach (var gameObject in buttonCavern)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in crownIsland)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalDesert)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalIcy)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in forgottenJungle)
        {
            gameObject.SetActive(true);
        }
        foreach (var gameObject in mutatedAbyss)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in northPole)
        {
            gameObject.SetActive(false);
        }
        outline1.SetActive(false);
        outline2.SetActive(false);
        outline3.SetActive(false);
        outline4.SetActive(false);
        outline5.SetActive(true);
        outline6.SetActive(false);
        outline7.SetActive(false);
        setButton = false;
        setCrown = false;
        setDesert = false;
        setIcy = false;
        setJungle = true;
        setAbyss = false;
        setPole = false;
    }

    public void Abyss()
    {
        foreach (var gameObject in buttonCavern)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in crownIsland)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalDesert)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalIcy)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in forgottenJungle)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in mutatedAbyss)
        {
            gameObject.SetActive(true);
        }
        foreach (var gameObject in northPole)
        {
            gameObject.SetActive(false);
        }
        outline1.SetActive(false);
        outline2.SetActive(false);
        outline3.SetActive(false);
        outline4.SetActive(false);
        outline5.SetActive(false);
        outline6.SetActive(true);
        outline7.SetActive(false);
        setButton = false;
        setCrown = false;
        setDesert = false;
        setIcy = false;
        setJungle = false;
        setAbyss = true;
        setPole = false;
    }

    public void Pole()
    {
        foreach (var gameObject in buttonCavern)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in crownIsland)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalDesert)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in eternalIcy)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in forgottenJungle)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in mutatedAbyss)
        {
            gameObject.SetActive(false);
        }
        foreach (var gameObject in northPole)
        {
            gameObject.SetActive(true);
        }
        outline1.SetActive(false);
        outline2.SetActive(false);
        outline3.SetActive(false);
        outline4.SetActive(false);
        outline5.SetActive(false);
        outline6.SetActive(false);
        outline7.SetActive(true);
        setButton = false;
        setCrown = false;
        setDesert = false;
        setIcy = false;
        setJungle = false;
        setAbyss = false;
        setPole = true;
    }

    public void SetCommonFishInfo()
    {

    }

    public void SetUncommonFishInfo()
    {

    }

    public void SetRareFishInfo()
    {

    }

    public void SetSuperRareFishInfo()
    {

    }

    public void SetEpicFishInfo()
    {

    }

    public void SetLegendaryFishInfo()
    {

    }

    public void SetMythicFishInfo()
    {

    }

    public void SetGodlyFishInfo()
    {

    }

    public void SetDivineFishInfo()
    {

    }

    public void SetSecretFishInfo()
    {

    }
}
