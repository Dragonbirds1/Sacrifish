using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TempInventoryManager : MonoBehaviour
{
    public CatchFish catchFish;
    public Slot[] hotbarSlots;
    public Slot[] inventorySlots;
    public Canvas canvas;
    public KeyCode openInventoryKey;
    public GameObject inventoryBackground;

    void Start()
    {
        inventoryBackground.SetActive(false);
        // Spawn more slots that are for the inventory not the hotbar and make them so they are hidden until the player opens the inventory and make it so they are in a grid layout and make it so they are not on top of each other
        inventorySlots = new Slot[40]; // Example inventory size
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            // Make it so if the slot colum is greater than 5, it goes to the next row
            inventorySlots[i] = new Slot();
            inventorySlots[i].slotBackground = Instantiate(Resources.Load<Image>("SlotBackground"), canvas.transform); // Assuming you have a prefab named "SlotBackground" in a Resources folder
            int column = i % 10; // This will give us the column limit to tell the script to go to the next row after 10 columns
            int row = i / 10;
            inventorySlots[i].slotBackground.rectTransform.anchoredPosition = new Vector2(-550 + (column * 120), 300 - (row * 170)); // Adjust the position as needed
            inventorySlots[i].slotBackground.gameObject.SetActive(false); // Hide the slots until the player opens the inventory
        }

        // Now make the hotBar

        hotbarSlots = new Slot[6]; // Example hotbar size
                                       // Make it spawn the image of the slot so the player can see it and know where to put the fish and the text and the quantity of the fish in the inventory
        
       
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i] = new Slot();
            // Add the slot background image to the ui canvas
            hotbarSlots[i].slotBackground = Instantiate(Resources.Load<Image>("SlotBackground"), canvas.transform); // Assuming you have a prefab named "SlotBackground" in a Resources folder
            // Move the slot so they are not on top of each other
            hotbarSlots[i].slotBackground.rectTransform.anchoredPosition = new Vector2(-310 + (i * 120), -450); // Adjust the position as needed
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
        foreach (var slot in hotbarSlots)
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
            // Now make it so if the slot is empty, it clears the text of the tmp
            else
            {
                TextMeshProUGUI[] textComponents = slot.slotBackground.GetComponentsInChildren<TextMeshProUGUI>();
                if (textComponents.Length >= 2)
                {
                    textComponents[0].text = ""; // Clear item name
                    textComponents[1].text = ""; // Clear item quantity
                }
            }
        }
    foreach (var slot2 in inventorySlots)
            {
                if (!slot2.isEmpty)
                {
                    // Assuming the slot background has a child TextMeshProUGUI component for the item name and quantity
                    TextMeshProUGUI[] textComponents = slot2.slotBackground.GetComponentsInChildren<TextMeshProUGUI>();
                    if (textComponents.Length >= 2)
                    {
                        textComponents[0].text = slot2.item.itemName; // Set item name
                        textComponents[1].text = slot2.item.quantity.ToString(); // Set item quantity
                    }
                }
                // Now make it so if the slot is empty, it clears the text of the tmp
                else
                {
                    TextMeshProUGUI[] textComponents = slot2.slotBackground.GetComponentsInChildren<TextMeshProUGUI>();
                    if (textComponents.Length >= 2)
                    {
                        textComponents[0].text = ""; // Clear item name
                        textComponents[1].text = ""; // Clear item quantity
                    }
                }
            }

            // Check if the player presses the open inventory key and if they do, toggle the visibility of the inventory slots
            if (Input.GetKeyDown(openInventoryKey))
            {
                foreach (var slot2 in inventorySlots)
                {
                    slot2.slotBackground.gameObject.SetActive(!slot2.slotBackground.gameObject.activeSelf);
                }
                inventoryBackground.SetActive(!inventoryBackground.activeSelf);
            }
    }

    private bool AreAllSlotsFull()
    {
        foreach (var slot in hotbarSlots)
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

        // Check if all hotbar slots are full and if they are, start adding the fish to the inventory slots instead of the hotbar slots
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (hotbarSlots[i].isEmpty)
            {
                hotbarSlots[i].item = fishToAdd;
                break;
            }
            else if (hotbarSlots[i].item.itemName == fishName)
            {
                hotbarSlots[i].item.quantity++;
                break;
            }
            else if (i == hotbarSlots.Length - 1) // If we are at the last hotbar slot and all slots are full, add the fish to the inventory
            {
                for (int j = 0; j < inventorySlots.Length; j++)
                {
                    if (inventorySlots[j].isEmpty)
                    {
                        inventorySlots[j].item = fishToAdd;
                        break;
                    }
                    else if (inventorySlots[j].item.itemName == fishName)
                    {
                        inventorySlots[j].item.quantity++;
                        break;
                    }
                }
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

    public void SellAllFishFromInventory(string fishName, int quantity)
    {
        // Create a method that sells the fish from the inventory and removes it from the inventory
        // Only get the HowManyPlayerHasCaught from the CatchFish script and update the quantity of the fish in the inventory and if the quantity is 0, remove the fish from the inventory
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (!inventorySlots[i].isEmpty)
            {
                // - the quantity of the fish in the inventory by the quantity of the fish that the player has caught
                inventorySlots[i].item.quantity = 0;

                inventorySlots[i].item.itemName = ""; // Clear the item name
            }
        }

        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (!hotbarSlots[i].isEmpty)
            {
                // - the quantity of the fish in the inventory by the quantity of the fish that the player has caught
                hotbarSlots[i].item.quantity = 0;

                hotbarSlots[i].item.itemName = ""; // Clear the item name
            }
        }
    }
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
