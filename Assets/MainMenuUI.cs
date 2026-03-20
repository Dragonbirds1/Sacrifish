using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Start()
    {
        //Starts Game
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        //Closes The Game
        Application.Quit();
    }
}
