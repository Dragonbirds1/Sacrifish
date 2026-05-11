using UnityEngine;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{
    public PlayerMotor playerMotor;

    public PlayerLook playerLook;

    public GameObject pauseMenu;

    public KeyCode pauseKey;

    public bool isPaused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey) && !isPaused)
        {
            pauseMenu.SetActive(true);
            playerMotor.showCursor = true;
            playerMotor.canMove = false;
            playerMotor.canJump = false;
            playerLook.canLook = false;
            isPaused = true;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        playerMotor.showCursor = false;
        playerMotor.canMove = true;
        playerMotor.canJump = true;
        playerLook.canLook = true;
        isPaused = false;
    }

    public void Settings()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
