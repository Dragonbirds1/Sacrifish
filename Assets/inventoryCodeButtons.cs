using UnityEngine;
using UnityEngine.SceneManagement;

public class inventoryCodeButtons : MonoBehaviour
{
    public void Collect(ItemSO item)
    {
        Debug.Log("Collect button clicked");
        FindFirstObjectByType<InventoryManager>().AddItem(item, 1);
        FindFirstObjectByType<Item>().OnCatch();
    }
}
