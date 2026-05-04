using UnityEngine;
using UnityEngine.SceneManagement;

public class Code : MonoBehaviour
{
    public void Back()
    {
        //Opens the Credits Scene
        SceneManager.LoadScene("Credits");
    }
}
