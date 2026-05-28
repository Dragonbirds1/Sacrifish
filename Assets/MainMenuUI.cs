using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    public Animator loadingAnim;
    public float waitTime, updateTime;
    public GameObject loadingScreen;
    public TextMeshProUGUI loadingText;
    public string loadingTextUpdater;
    public bool startLoading, startCountdown;

    private void Update()
    {
        if (startLoading)
        {
            loadingAnim.SetBool("StartSpin", true);
            loadingText.text = loadingTextUpdater;
            updateTime += Time.deltaTime;
            if (updateTime >= 0f)
            {
                loadingTextUpdater = "Loading";
            }
            if (updateTime >= 0.5f)
            {
                loadingTextUpdater = "Loading.";
            }
            if (updateTime >= 1f)
            {
                loadingTextUpdater = "Loading..";
            }
            if (updateTime >= 1.5f)
            {
                loadingTextUpdater = "Loading...";
            }
            if (updateTime >= 2f)
            {
                updateTime = 0f;
            }
        }
        if (startCountdown)
        {
            waitTime += Time.deltaTime;
            if (waitTime >= 5f)
            {
                SceneManager.LoadScene("Map");
                waitTime = 0f;
            }
        }
    }
    public void Play()
    {
        //Starts Game
        loadingScreen.SetActive(true);
        startLoading = true;
        startCountdown = true;
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
