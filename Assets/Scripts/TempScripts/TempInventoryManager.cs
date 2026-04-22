using System.Collections.Generic;
using UnityEngine;

public class TempInventoryManager : MonoBehaviour
{
    public CatchFish catchFish;
    public Slot[] inventorySlots;

    void Start()
    {
        inventorySlots = new Slot[10]; // Example inventory size
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = new Slot();
        }

        // Check if all slots are full and if they are, add a new slot
        //if (AreAllSlotsFull())
        //{
        //    AddNewSlot();
        //}
    }

    void Update()
    {
        
    }

    private bool AreAllSlotsFull()
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.isEmpty)
            {
                return false;
            }
        }
        return true;
    }

    //public void AddNewSlot()
    //{
        //Slot[] newInventorySlots = new Slot[inventorySlots.Length + 1];
        //for (int i = 0; i < inventorySlots.Length; i++)
        //{
            //newInventorySlots[i] = inventorySlots[i];
        //}
        //newInventorySlots[newInventorySlots.Length - 1] = new Slot();
        //inventorySlots = newInventorySlots;
    //}
}

public class InventoryItem
{
    public string itemName;
    public int quantity;
    public InventoryItem(string name, int qty)
    {
        itemName = name;
        quantity = qty;
    }
}

public class Slot
{
    public InventoryItem item;
    public bool isEmpty => item == null;
}
