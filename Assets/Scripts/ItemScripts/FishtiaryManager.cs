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

    [Header("Other Lists")]
    public List<GameObject> rarityButtons;

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
    public bool discovered1, discovered2, discovered3, discovered4, discovered5, discovered6, discovered7, discovered8, discovered9, discovered10;
    public bool buttonCav, crownIsle, eternalDes, eternalIce, forgottenJun, mutatedAby, northPo;
    public bool setButton, setCrown, setDesert, setIcy, setJungle, setAbyss, setPole;

    [Header("TMPObjects")]
    public TextMeshProUGUI fishNameCommon, fishNameUncommon, fishNameRare, fishNameSuperRare, fishNameEpic, fishNameLegendary, fishNameMythic, fishNameGodly, fishNameDivine, fishNameSecret;
    public TextMeshProUGUI fishLocationCommon, fishLocationUncommon, fishLocationRare, fishLocationSuperRare, fishLocationEpic, fishLocationLegendary, fishLocationMythic, fishLocationGodly, fishLocationDivine, fishLocationSecret;
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
        common.SetActive(true);

        if (setButton)
        {
            fishNameCommon.text = "CrystalTrout";
            fishLocationCommon.text = "Button Cavern";
            fishKgCommon.text = "Kg: 0.1";
            perferedWeatherCommon.text = "Perfered Weather: Clear";
            perferedTimeCommon.text = "Perfered Time: Night";
            perferedSeasonCommon.text = "Perfered Season: Summer";
            perferedBaitCommon.text = "Perfered Bait: Crystal Flakes";
        }
        if (setCrown)
        {
            fishNameCommon.text = "Trout";
            fishLocationCommon.text = "Crown Island";
            fishKgCommon.text = "Kg: 0.07";
            perferedWeatherCommon.text = "Perfered Weather: Clear";
            perferedTimeCommon.text = "Perfered Time: Day";
            perferedSeasonCommon.text = "Perfered Season: Fall";
            perferedBaitCommon.text = "Perfered Bait: Flakes";
        }
        if (setDesert)
        {
            fishNameCommon.text = "Sand Crab";
            fishLocationCommon.text = "Eternal Desert";
            fishKgCommon.text = "Kg: 0.3";
            perferedWeatherCommon.text = "Perfered Weather: Clear";
            perferedTimeCommon.text = "Perfered Time: Day";
            perferedSeasonCommon.text = "Perfered Season: Summer";
            perferedBaitCommon.text = "Perfered Bait: None";
        }
        if (setIcy)
        {
            fishNameCommon.text = "Ice Eel";
            fishLocationCommon.text = "Eternal Icy";
            fishKgCommon.text = "Kg: 0.7";
            perferedWeatherCommon.text = "Perfered Weather: Rain";
            perferedTimeCommon.text = "Perfered Time: Night";
            perferedSeasonCommon.text = "Perfered Season: Winter";
            perferedBaitCommon.text = "Perfered Bait: Snowflakes";
        }
        if (setJungle)
        {
            fishNameCommon.text = "Snake Fish";
            fishLocationCommon.text = "Forgotten Jungle";
            fishKgCommon.text = "Kg: 0.6";
            perferedWeatherCommon.text = "Perfered Weather: Rain";
            perferedTimeCommon.text = "Perfered Time: Night";
            perferedSeasonCommon.text = "Perfered Season: Spring";
            perferedBaitCommon.text = "Perfered Bait: Mud Ball";
        }
        if (setAbyss)
        {
            fishNameCommon.text = "Shadowfin";
            fishLocationCommon.text = "Mutated Abyss";
            fishKgCommon.text = "Kg: 2.4";
            perferedWeatherCommon.text = "Perfered Weather: Foggy";
            perferedTimeCommon.text = "Perfered Time: Night";
            perferedSeasonCommon.text = "Perfered Season: Fall";
            perferedBaitCommon.text = "Perfered Bait: Mutated Worm";
        }
        if (setPole)
        {
            fishNameCommon.text = "Pole Fish";
            fishLocationCommon.text = "North Pole";
            fishKgCommon.text = "Kg: 4.0";
            perferedWeatherCommon.text = "Perfered Weather: Windy";
            perferedTimeCommon.text = "Perfered Time: Day";
            perferedSeasonCommon.text = "Perfered Season: Winter";
            perferedBaitCommon.text = "Perfered Bait: Magnet";
        }
    }

    public void SetUncommonFishInfo()
    {
        uncommon.SetActive(true);

        if (setButton)
        {
            fishNameUncommon.text = "CrystalTrout";
            fishLocationUncommon.text = "Button Cavern";
            fishKgUncommon.text = "Kg: 0.1";
            perferedWeatherUncommon.text = "Perfered Weather: Clear";
            perferedTimeUncommon.text = "Perfered Time: Night";
            perferedSeasonCommon.text = "Perfered Season: Summer";
            perferedBaitCommon.text = "Perfered Bait: Crystal Flakes";
        }
        if (setCrown)
        {
            fishNameUncommon.text = "Trout";
            fishLocationUncommon.text = "Crown Island";
            fishKgUncommon.text = "Kg: 0.07";
            perferedWeatherUncommon.text = "Perfered Weather: Clear";
            perferedTimeUncommon.text = "Perfered Time: Day";
            perferedSeasonUncommon.text = "Perfered Season: Fall";
            perferedBaitUncommon.text = "Perfered Bait: Flakes";
        }
        if (setDesert)
        {
            fishNameUncommon.text = "Sand Crab";
            fishLocationUncommon.text = "Eternal Desert";
            fishKgUncommon.text = "Kg: 0.3";
            perferedWeatherUncommon.text = "Perfered Weather: Clear";
            perferedTimeUncommon.text = "Perfered Time: Day";
            perferedSeasonUncommon.text = "Perfered Season: Summer";
            perferedBaitUncommon.text = "Perfered Bait: None";
        }
        if (setIcy)
        {
            fishNameUncommon.text = "Ice Eel";
            fishLocationUncommon.text = "Eternal Icy";
            fishKgUncommon.text = "Kg: 0.7";
            perferedWeatherUncommon.text = "Perfered Weather: Rain";
            perferedTimeUncommon.text = "Perfered Time: Night";
            perferedSeasonUncommon.text = "Perfered Season: Winter";
            perferedBaitUncommon.text = "Perfered Bait: Snowflakes";
        }
        if (setJungle)
        {
            fishNameUncommon.text = "Snake Fish";
            fishLocationUncommon.text = "Forgotten Jungle";
            fishKgUncommon.text = "Kg: 0.6";
            perferedWeatherUncommon.text = "Perfered Weather: Rain";
            perferedTimeUncommon.text = "Perfered Time: Night";
            perferedSeasonUncommon.text = "Perfered Season: Spring";
            perferedBaitUncommon.text = "Perfered Bait: Mud Ball";
        }
        if (setAbyss)
        {
            fishNameUncommon.text = "Shadowfin";
            fishLocationUncommon.text = "Mutated Abyss";
            fishKgUncommon.text = "Kg: 2.4";
            perferedWeatherUncommon.text = "Perfered Weather: Foggy";
            perferedTimeUncommon.text = "Perfered Time: Night";
            perferedSeasonUncommon.text = "Perfered Season: Fall";
            perferedBaitUncommon.text = "Perfered Bait: Mutated Worm";
        }
        if (setPole)
        {
            fishNameUncommon.text = "Pole Fish";
            fishLocationUncommon.text = "North Pole";
            fishKgUncommon.text = "Kg: 4.0";
            perferedWeatherUncommon.text = "Perfered Weather: Windy";
            perferedTimeUncommon.text = "Perfered Time: Day";
            perferedSeasonUncommon.text = "Perfered Season: Winter";
            perferedBaitUncommon.text = "Perfered Bait: Magnet";
        }
    }

    public void SetRareFishInfo()
    {
        rare.SetActive(true);

        if (setButton)
        {
            fishNameRare.text = "CrystalTrout";
            fishLocationRare.text = "Button Cavern";
            fishKgRare.text = "Kg: 0.1";
            perferedWeatherRare.text = "Perfered Weather: Clear";
            perferedTimeRare.text = "Perfered Time: Night";
            perferedSeasonRare.text = "Perfered Season: Summer";
            perferedBaitRare.text = "Perfered Bait: Crystal Flakes";
        }
        if (setCrown)
        {
            fishNameRare.text = "Trout";
            fishLocationRare.text = "Crown Island";
            fishKgRare.text = "Kg: 0.07";
            perferedWeatherRare.text = "Perfered Weather: Clear";
            perferedTimeRare.text = "Perfered Time: Day";
            perferedSeasonRare.text = "Perfered Season: Fall";
            perferedBaitRare.text = "Perfered Bait: Flakes";
        }
        if (setDesert)
        {
            fishNameRare.text = "Sand Crab";
            fishLocationRare.text = "Eternal Desert";
            fishKgRare.text = "Kg: 0.3";
            perferedWeatherRare.text = "Perfered Weather: Clear";
            perferedTimeRare.text = "Perfered Time: Day";
            perferedSeasonRare.text = "Perfered Season: Summer";
            perferedBaitRare.text = "Perfered Bait: None";
        }
        if (setIcy)
        {
            fishNameRare.text = "Ice Eel";
            fishLocationRare.text = "Eternal Icy";
            fishKgRare.text = "Kg: 0.7";
            perferedWeatherRare.text = "Perfered Weather: Rain";
            perferedTimeRare.text = "Perfered Time: Night";
            perferedSeasonRare.text = "Perfered Season: Winter";
            perferedBaitRare.text = "Perfered Bait: Snowflakes";
        }
        if (setJungle)
        {
            fishNameRare.text = "Snake Fish";
            fishLocationRare.text = "Forgotten Jungle";
            fishKgRare.text = "Kg: 0.6";
            perferedWeatherRare.text = "Perfered Weather: Rain";
            perferedTimeRare.text = "Perfered Time: Night";
            perferedSeasonRare.text = "Perfered Season: Spring";
            perferedBaitRare.text = "Perfered Bait: Mud Ball";
        }
        if (setAbyss)
        {
            fishNameRare.text = "Shadowfin";
            fishLocationRare.text = "Mutated Abyss";
            fishKgRare.text = "Kg: 2.4";
            perferedWeatherRare.text = "Perfered Weather: Foggy";
            perferedTimeRare.text = "Perfered Time: Night";
            perferedSeasonRare.text = "Perfered Season: Fall";
            perferedBaitRare.text = "Perfered Bait: Mutated Worm";
        }
        if (setPole)
        {
            fishNameRare.text = "Pole Fish";
            fishLocationRare.text = "North Pole";
            fishKgRare.text = "Kg: 4.0";
            perferedWeatherRare.text = "Perfered Weather: Windy";
            perferedTimeRare.text = "Perfered Time: Day";
            perferedSeasonRare.text = "Perfered Season: Winter";
            perferedBaitRare.text = "Perfered Bait: Magnet";
        }
    }

    public void SetSuperRareFishInfo()
    {
        superRare.SetActive(true);

        if (setButton)
        {
            fishNameSuperRare.text = "CrystalTrout";
            fishLocationSuperRare.text = "Button Cavern";
            fishKgSuperRare.text = "Kg: 0.1";
            perferedWeatherSuperRare.text = "Perfered Weather: Clear";
            perferedTimeSuperRare.text = "Perfered Time: Night";
            perferedSeasonSuperRare.text = "Perfered Season: Summer";
            perferedBaitSuperRare.text = "Perfered Bait: Crystal Flakes";
        }
        if (setCrown)
        {
            fishNameSuperRare.text = "Trout";
            fishLocationSuperRare.text = "Crown Island";
            fishKgSuperRare.text = "Kg: 0.07";
            perferedWeatherSuperRare.text = "Perfered Weather: Clear";
            perferedTimeSuperRare.text = "Perfered Time: Day";
            perferedSeasonSuperRare.text = "Perfered Season: Fall";
            perferedBaitSuperRare.text = "Perfered Bait: Flakes";
        }
        if (setDesert)
        {
            fishNameSuperRare.text = "Sand Crab";
            fishLocationSuperRare.text = "Eternal Desert";
            fishKgSuperRare.text = "Kg: 0.3";
            perferedWeatherSuperRare.text = "Perfered Weather: Clear";
            perferedTimeSuperRare.text = "Perfered Time: Day";
            perferedSeasonSuperRare.text = "Perfered Season: Summer";
            perferedBaitSuperRare.text = "Perfered Bait: None";
        }
        if (setIcy)
        {
            fishNameSuperRare.text = "Ice Eel";
            fishLocationSuperRare.text = "Eternal Icy";
            fishKgSuperRare.text = "Kg: 0.7";
            perferedWeatherSuperRare.text = "Perfered Weather: Rain";
            perferedTimeSuperRare.text = "Perfered Time: Night";
            perferedSeasonSuperRare.text = "Perfered Season: Winter";
            perferedBaitSuperRare.text = "Perfered Bait: Snowflakes";
        }
        if (setJungle)
        {
            fishNameSuperRare.text = "Snake Fish";
            fishLocationSuperRare.text = "Forgotten Jungle";
            fishKgSuperRare.text = "Kg: 0.6";
            perferedWeatherSuperRare.text = "Perfered Weather: Rain";
            perferedTimeSuperRare.text = "Perfered Time: Night";
            perferedSeasonSuperRare.text = "Perfered Season: Spring";
            perferedBaitSuperRare.text = "Perfered Bait: Mud Ball";
        }
        if (setAbyss)
        {
            fishNameSuperRare.text = "Shadowfin";
            fishLocationSuperRare.text = "Mutated Abyss";
            fishKgSuperRare.text = "Kg: 2.4";
            perferedWeatherSuperRare.text = "Perfered Weather: Foggy";
            perferedTimeSuperRare.text = "Perfered Time: Night";
            perferedSeasonSuperRare.text = "Perfered Season: Fall";
            perferedBaitSuperRare.text = "Perfered Bait: Mutated Worm";
        }
        if (setPole)
        {
            fishNameSuperRare.text = "Pole Fish";
            fishLocationSuperRare.text = "North Pole";
            fishKgSuperRare.text = "Kg: 4.0";
            perferedWeatherSuperRare.text = "Perfered Weather: Windy";
            perferedTimeSuperRare.text = "Perfered Time: Day";
            perferedSeasonSuperRare.text = "Perfered Season: Winter";
            perferedBaitSuperRare.text = "Perfered Bait: Magnet";
        }
    }

    public void SetEpicFishInfo()
    {
        epic.SetActive(true);

        if (setButton)
        {
            fishNameEpic.text = "CrystalTrout";
            fishLocationEpic.text = "Button Cavern";
            fishKgEpic.text = "Kg: 0.1";
            perferedWeatherEpic.text = "Perfered Weather: Clear";
            perferedTimeEpic.text = "Perfered Time: Night";
            perferedSeasonEpic.text = "Perfered Season: Summer";
            perferedBaitEpic.text = "Perfered Bait: Crystal Flakes";
        }
        if (setCrown)
        {
            fishNameEpic.text = "Trout";
            fishLocationEpic.text = "Crown Island";
            fishKgEpic.text = "Kg: 0.07";
            perferedWeatherEpic.text = "Perfered Weather: Clear";
            perferedTimeEpic.text = "Perfered Time: Day";
            perferedSeasonEpic.text = "Perfered Season: Fall";
            perferedBaitEpic.text = "Perfered Bait: Flakes";
        }
        if (setDesert)
        {
            fishNameEpic.text = "Sand Crab";
            fishLocationEpic.text = "Eternal Desert";
            fishKgEpic.text = "Kg: 0.3";
            perferedWeatherEpic.text = "Perfered Weather: Clear";
            perferedTimeEpic.text = "Perfered Time: Day";
            perferedSeasonEpic.text = "Perfered Season: Summer";
            perferedBaitEpic.text = "Perfered Bait: None";
        }
        if (setIcy)
        {
            fishNameEpic.text = "Ice Eel";
            fishLocationEpic.text = "Eternal Icy";
            fishKgEpic.text = "Kg: 0.7";
            perferedWeatherEpic.text = "Perfered Weather: Rain";
            perferedTimeEpic.text = "Perfered Time: Night";
            perferedSeasonEpic.text = "Perfered Season: Winter";
            perferedBaitEpic.text = "Perfered Bait: Snowflakes";
        }
        if (setJungle)
        {
            fishNameEpic.text = "Snake Fish";
            fishLocationEpic.text = "Forgotten Jungle";
            fishKgEpic.text = "Kg: 0.6";
            perferedWeatherEpic.text = "Perfered Weather: Rain";
            perferedTimeEpic.text = "Perfered Time: Night";
            perferedSeasonEpic.text = "Perfered Season: Spring";
            perferedBaitEpic.text = "Perfered Bait: Mud Ball";
        }
        if (setAbyss)
        {
            fishNameEpic.text = "Shadowfin";
            fishLocationEpic.text = "Mutated Abyss";
            fishKgEpic.text = "Kg: 2.4";
            perferedWeatherEpic.text = "Perfered Weather: Foggy";
            perferedTimeEpic.text = "Perfered Time: Night";
            perferedSeasonEpic.text = "Perfered Season: Fall";
            perferedBaitEpic.text = "Perfered Bait: Mutated Worm";
        }
        if (setPole)
        {
            fishNameEpic.text = "Pole Fish";
            fishLocationEpic.text = "North Pole";
            fishKgEpic.text = "Kg: 4.0";
            perferedWeatherEpic.text = "Perfered Weather: Windy";
            perferedTimeEpic.text = "Perfered Time: Day";
            perferedSeasonEpic.text = "Perfered Season: Winter";
            perferedBaitEpic.text = "Perfered Bait: Magnet";
        }
    }

    public void SetLegendaryFishInfo()
    {
        legendary.SetActive(true);

        if (setButton)
        {
            fishNameLegendary.text = "CrystalTrout";
            fishLocationLegendary.text = "Button Cavern";
            fishKgLegendary.text = "Kg: 0.1";
            perferedWeatherLegendary.text = "Perfered Weather: Clear";
            perferedTimeLegendary.text = "Perfered Time: Night";
            perferedSeasonLegendary.text = "Perfered Season: Summer";
            perferedBaitLegendary.text = "Perfered Bait: Crystal Flakes";
        }
        if (setCrown)
        {
            fishNameLegendary.text = "Trout";
            fishLocationLegendary.text = "Crown Island";
            fishKgLegendary.text = "Kg: 0.07";
            perferedWeatherLegendary.text = "Perfered Weather: Clear";
            perferedTimeLegendary.text = "Perfered Time: Day";
            perferedSeasonLegendary.text = "Perfered Season: Fall";
            perferedBaitLegendary.text = "Perfered Bait: Flakes";
        }
        if (setDesert)
        {
            fishNameLegendary.text = "Sand Crab";
            fishLocationLegendary.text = "Eternal Desert";
            fishKgLegendary.text = "Kg: 0.3";
            perferedWeatherLegendary.text = "Perfered Weather: Clear";
            perferedTimeLegendary.text = "Perfered Time: Day";
            perferedSeasonLegendary.text = "Perfered Season: Summer";
            perferedBaitLegendary.text = "Perfered Bait: None";
        }
        if (setIcy)
        {
            fishNameLegendary.text = "Ice Eel";
            fishLocationLegendary.text = "Eternal Icy";
            fishKgLegendary.text = "Kg: 0.7";
            perferedWeatherLegendary.text = "Perfered Weather: Rain";
            perferedTimeLegendary.text = "Perfered Time: Night";
            perferedSeasonLegendary.text = "Perfered Season: Winter";
            perferedBaitLegendary.text = "Perfered Bait: Snowflakes";
        }
        if (setJungle)
        {
            fishNameLegendary.text = "Snake Fish";
            fishLocationLegendary.text = "Forgotten Jungle";
            fishKgLegendary.text = "Kg: 0.6";
            perferedWeatherLegendary.text = "Perfered Weather: Rain";
            perferedTimeLegendary.text = "Perfered Time: Night";
            perferedSeasonLegendary.text = "Perfered Season: Spring";
            perferedBaitLegendary.text = "Perfered Bait: Mud Ball";
        }
        if (setAbyss)
        {
            fishNameLegendary.text = "Shadowfin";
            fishLocationLegendary.text = "Mutated Abyss";
            fishKgLegendary.text = "Kg: 2.4";
            perferedWeatherLegendary.text = "Perfered Weather: Foggy";
            perferedTimeLegendary.text = "Perfered Time: Night";
            perferedSeasonLegendary.text = "Perfered Season: Fall";
            perferedBaitLegendary.text = "Perfered Bait: Mutated Worm";
        }
        if (setPole)
        {
            fishNameLegendary.text = "Pole Fish";
            fishLocationLegendary.text = "North Pole";
            fishKgLegendary.text = "Kg: 4.0";
            perferedWeatherLegendary.text = "Perfered Weather: Windy";
            perferedTimeLegendary.text = "Perfered Time: Day";
            perferedSeasonLegendary.text = "Perfered Season: Winter";
            perferedBaitLegendary.text = "Perfered Bait: Magnet";
        }
    }

    public void SetMythicFishInfo()
    {
        mythic.SetActive(true);

        if (setButton)
        {
            fishNameMythic.text = "CrystalTrout";
            fishLocationMythic.text = "Button Cavern";
            fishKgMythic.text = "Kg: 0.1";
            perferedWeatherMythic.text = "Perfered Weather: Clear";
            perferedTimeMythic.text = "Perfered Time: Night";
            perferedSeasonMythic.text = "Perfered Season: Summer";
            perferedBaitMythic.text = "Perfered Bait: Crystal Flakes";
        }
        if (setDesert)
        {
            fishNameMythic.text = "Sand Crab";
            fishLocationMythic.text = "Eternal Desert";
            fishKgMythic.text = "Kg: 0.3";
            perferedWeatherMythic.text = "Perfered Weather: Clear";
            perferedTimeMythic.text = "Perfered Time: Day";
            perferedSeasonMythic.text = "Perfered Season: Summer";
            perferedBaitMythic.text = "Perfered Bait: None";
        }
        if (setIcy)
        {
            fishNameMythic.text = "Ice Eel";
            fishLocationMythic.text = "Eternal Icy";
            fishKgMythic.text = "Kg: 0.7";
            perferedWeatherMythic.text = "Perfered Weather: Rain";
            perferedTimeMythic.text = "Perfered Time: Night";
            perferedSeasonMythic.text = "Perfered Season: Winter";
            perferedBaitMythic.text = "Perfered Bait: Snowflakes";
        }
        if (setJungle)
        {
            fishNameMythic.text = "Snake Fish";
            fishLocationMythic.text = "Forgotten Jungle";
            fishKgMythic.text = "Kg: 0.6";
            perferedWeatherMythic.text = "Perfered Weather: Rain";
            perferedTimeMythic.text = "Perfered Time: Night";
            perferedSeasonMythic.text = "Perfered Season: Spring";
            perferedBaitMythic.text = "Perfered Bait: Mud Ball";
        }
        if (setAbyss)
        {
            fishNameMythic.text = "Shadowfin";
            fishLocationMythic.text = "Mutated Abyss";
            fishKgMythic.text = "Kg: 2.4";
            perferedWeatherMythic.text = "Perfered Weather: Foggy";
            perferedTimeMythic.text = "Perfered Time: Night";
            perferedSeasonMythic.text = "Perfered Season: Fall";
            perferedBaitMythic.text = "Perfered Bait: Mutated Worm";
        }
    }

    public void SetGodlyFishInfo()
    {
        godly.SetActive(true);

        if (setButton)
        {
            fishNameGodly.text = "CrystalTrout";
            fishLocationGodly.text = "Button Cavern";
            fishKgGodly.text = "Kg: 0.1";
            perferedWeatherGodly.text = "Perfered Weather: Clear";
            perferedTimeGodly.text = "Perfered Time: Night";
            perferedSeasonGodly.text = "Perfered Season: Summer";
            perferedBaitGodly.text = "Perfered Bait: Crystal Flakes";
        }
        if (setDesert)
        {
            fishNameGodly.text = "Sand Crab";
            fishLocationGodly.text = "Eternal Desert";
            fishKgGodly.text = "Kg: 0.3";
            perferedWeatherGodly.text = "Perfered Weather: Clear";
            perferedTimeGodly.text = "Perfered Time: Day";
            perferedSeasonGodly.text = "Perfered Season: Summer";
            perferedBaitGodly.text = "Perfered Bait: None";
        }
        if (setIcy)
        {
            fishNameGodly.text = "Ice Eel";
            fishLocationGodly.text = "Eternal Icy";
            fishKgGodly.text = "Kg: 0.7";
            perferedWeatherGodly.text = "Perfered Weather: Rain";
            perferedTimeGodly.text = "Perfered Time: Night";
            perferedSeasonGodly.text = "Perfered Season: Winter";
            perferedBaitGodly.text = "Perfered Bait: Snowflakes";
        }
        if (setJungle)
        {
            fishNameGodly.text = "Snake Fish";
            fishLocationGodly.text = "Forgotten Jungle";
            fishKgGodly.text = "Kg: 0.6";
            perferedWeatherGodly.text = "Perfered Weather: Rain";
            perferedTimeGodly.text = "Perfered Time: Night";
            perferedSeasonGodly.text = "Perfered Season: Spring";
            perferedBaitGodly.text = "Perfered Bait: Mud Ball";
        }
        if (setAbyss)
        {
            fishNameGodly.text = "Shadowfin";
            fishLocationGodly.text = "Mutated Abyss";
            fishKgGodly.text = "Kg: 2.4";
            perferedWeatherGodly.text = "Perfered Weather: Foggy";
            perferedTimeGodly.text = "Perfered Time: Night";
            perferedSeasonGodly.text = "Perfered Season: Fall";
            perferedBaitGodly.text = "Perfered Bait: Mutated Worm";
        }
    }

    public void SetDivineFishInfo()
    {
        divine.SetActive(true);

        if (setJungle)
        {
            fishNameDivine.text = "Snake Fish";
            fishLocationDivine.text = "Forgotten Jungle";
            fishKgDivine.text = "Kg: 0.6";
            perferedWeatherDivine.text = "Perfered Weather: Rain";
            perferedTimeDivine.text = "Perfered Time: Night";
            perferedSeasonDivine.text = "Perfered Season: Spring";
            perferedBaitDivine.text = "Perfered Bait: Mud Ball";
        }
        if (setAbyss)
        {
            fishNameDivine.text = "Shadowfin";
            fishLocationDivine.text = "Mutated Abyss";
            fishKgDivine.text = "Kg: 2.4";
            perferedWeatherDivine.text = "Perfered Weather: Foggy";
            perferedTimeDivine.text = "Perfered Time: Night";
            perferedSeasonDivine.text = "Perfered Season: Fall";
            perferedBaitDivine.text = "Perfered Bait: Mutated Worm";
        }
    }

    public void SetSecretFishInfo()
    {
        secret.SetActive(true);

        if (setDesert)
        {
            fishNameSecret.text = "Sand Crab";
            fishLocationSecret.text = "Eternal Desert";
            fishKgSecret.text = "Kg: 0.3";
            perferedWeatherSecret.text = "Perfered Weather: Clear";
            perferedTimeSecret.text = "Perfered Time: Day";
            perferedSeasonSecret.text = "Perfered Season: Summer";
            perferedBaitSecret.text = "Perfered Bait: None";
        }
        if (setIcy)
        {
            fishNameSecret.text = "Ice Eel";
            fishLocationSecret.text = "Eternal Icy";
            fishKgSecret.text = "Kg: 0.7";
            perferedWeatherSecret.text = "Perfered Weather: Rain";
            perferedTimeSecret.text = "Perfered Time: Night";
            perferedSeasonSecret.text = "Perfered Season: Winter";
            perferedBaitSecret.text = "Perfered Bait: Snowflakes";
        }
        if (setJungle)
        {
            fishNameSecret.text = "Snake Fish";
            fishLocationSecret.text = "Forgotten Jungle";
            fishKgSecret.text = "Kg: 0.6";
            perferedWeatherSecret.text = "Perfered Weather: Rain";
            perferedTimeSecret.text = "Perfered Time: Night";
            perferedSeasonSecret.text = "Perfered Season: Spring";
            perferedBaitSecret.text = "Perfered Bait: Mud Ball";
        }
        if (setPole)
        {
            fishNameSecret.text = "Pole Fish";
            fishLocationSecret.text = "North Pole";
            fishKgSecret.text = "Kg: 4.0";
            perferedWeatherSecret.text = "Perfered Weather: Windy";
            perferedTimeSecret.text = "Perfered Time: Day";
            perferedSeasonSecret.text = "Perfered Season: Winter";
            perferedBaitSecret.text = "Perfered Bait: Magnet";
        }
    }

    public void HideRarityButtons()
    {
        foreach (var gameObject in rarityButtons)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetRarities()
    {
        common.SetActive(false);
        uncommon.SetActive(false);
        rare.SetActive(false);
        superRare.SetActive(false);
        epic.SetActive(false);
        legendary.SetActive(false);
        mythic.SetActive(false);
        godly.SetActive(false);
        divine.SetActive(false);
        secret.SetActive(false);
    }
}
