using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishtiaryManager : MonoBehaviour
{
    public List<GameObject> buttonCavern;
    public List<GameObject> crownIsland;
    public List<GameObject> eternalDesert;
    public List<GameObject> eternalIcy;
    public List<GameObject> forgottenJungle;
    public List<GameObject> mutatedAbyss;
    public List<GameObject> northPole;

    public GameObject desertSecret, icySecret, jungleSecret, northPoleSecret;
    public GameObject outline1, outline2, outline3, outline4, outline5, outline6, outline7;
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
    }
}
