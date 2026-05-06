using UnityEngine;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{
    public KeyCode leaveKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(leaveKey))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
