using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TempInventoryManager : MonoBehaviour
{
    public CatchFish catchFish;
    public Slot[] inventorySlots;
    public Canvas canvas;

    void Start()
    {
        inventorySlots = new Slot[10]; // Example inventory size
                                       // Make it spawn the image of the slot so the player can see it and know where to put the fish and the text and the quantity of the fish in the inventory
        
       
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = new Slot();
            // Add the slot background image to the ui canvas
            inventorySlots[i].slotBackground = Instantiate(Resources.Load<Image>("SlotBackground"), canvas.transform); // Assuming you have a prefab named "SlotBackground" in a Resources folder
            // Move the slot so they are not on top of each other
            inventorySlots[i].slotBackground.rectTransform.anchoredPosition = new Vector2(50 + (i * 120), -50); // Adjust the position as needed
        }

        // Check if all slots are full and if they are, add a new slot
        //if (AreAllSlotsFull())
        //{
        //    AddNewSlot();
        //}
    }

    void Update()
    {
        // Make it so the script checks for a tmp inside of the resources folder and goes inside the slotbackground and checks for a tmp inside of the slotbackground and if it finds one, it updates the text of the tmp to the name of the fish and the quantity of the fish in the inventory
            foreach (var slot in inventorySlots)
            {
                if (!slot.isEmpty)
                {
                    // Assuming the slot background has a child TextMeshProUGUI component for the item name and quantity
                    TextMeshProUGUI[] textComponents = slot.slotBackground.GetComponentsInChildren<TextMeshProUGUI>();
                    if (textComponents.Length >= 2)
                    {
                        textComponents[0].text = slot.item.itemName; // Set item name
                        textComponents[1].text = slot.item.quantity.ToString(); // Set item quantity
                    }
                }
            }
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

    // Create an AddFishToInventory method that takes in the name of the fish and the quantity and adds it to the inventory
    public void AddFishToInventory(string fishName, int quantity)
    {
        // Get the rarity.name and rarity.quantity of the fish from the CatchFish script
        InventoryItem fishToAdd = new InventoryItem(fishName, quantity);
        // Add the fish to the first empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].isEmpty)
            {
                inventorySlots[i].item = fishToAdd;
                break;
            }
            // If the fish is already in the inventory, add the quantity to the existing item
            else if (inventorySlots[i].item.itemName == fishName)
            {
                inventorySlots[i].item.quantity++;
                break;
            }
        }
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

[System.Serializable]

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

[System.Serializable]

public class Slot
{
    // Make the SlotBackground = to a prefab;
    public Image slotBackground;

    public InventoryItem item;

    public bool isEmpty => item == null || item.quantity <= 0;
}
