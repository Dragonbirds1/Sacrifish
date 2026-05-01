using UnityEngine;
using UnityEngine.SceneManagement;

public class inventoryCodeButtons : MonoBehaviour
{
    public void Collect(ItemSO item)
    {
        FindFirstObjectByType<InventoryManager>().AddItem(item, 1);
    }
}
