using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Play()
    {
        //Starts Game
        SceneManager.LoadScene("Player Test");
    }
    public void Quit()
    {
        //Closes The Game
        Application.Quit();
    }
    public void Credits()
    {
        //Opens the Credits Scene
        SceneManager.LoadScene("Credits");
    }
}
