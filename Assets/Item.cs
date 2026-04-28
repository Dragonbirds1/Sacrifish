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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int leftOverItems = inventoryManager.AddItem(item, quantity);
            if (leftOverItems <= 0)
            {
                Destroy(gameObject);
            }
            else
                quantity = leftOverItems;
        }
    }
    public void OnCatch(GameObject findObject)
    {
        int leftOverItems = inventoryManager.AddItem(item, quantity);
        if (leftOverItems <= 0)
        {
            Destroy(gameObject);
        }
        else
            quantity = leftOverItems;
    }
}
