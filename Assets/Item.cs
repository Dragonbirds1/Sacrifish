using System;
using System.Linq.Expressions;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemSO item;

    [SerializeField]
    private int quantity;

    private InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collect();
        }
    }
    public void Collect()
    { 
        FindFirstObjectByType<InventoryManager>().AddItem(item, 1);
    }

}
