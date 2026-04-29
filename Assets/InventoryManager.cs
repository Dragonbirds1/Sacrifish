using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryView;
    public bool menuActivated;
    public ItemSlot[] itemSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActivated)
        {
            Time.timeScale = 1f;
            InventoryView.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetKeyDown(KeyCode.E) && !menuActivated)
        {
            Time.timeScale = 0f;
            InventoryView.SetActive(true);
            menuActivated = true;
        }
    }
    public int AddItem(ItemSO item, int quantity)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull)
                continue;

            if ((itemSlot[i].item != null && itemSlot[i].item == item) || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(item, quantity);

                if (leftOverItems > 0)
                    leftOverItems = AddItem(item, leftOverItems);

                return leftOverItems;
            }
        }

        return quantity;
    }
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
