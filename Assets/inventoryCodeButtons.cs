using UnityEngine;
using UnityEngine.SceneManagement;

public class inventoryCodeButtons : MonoBehaviour
{
    public void Collect()
    {
        //EXITs Inventory Menu
        SceneManager.LoadScene("Main Menu");
    }
}
