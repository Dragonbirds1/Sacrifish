using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1f;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetKeyDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0f;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite);
                return;
            }
        }
    }
}
