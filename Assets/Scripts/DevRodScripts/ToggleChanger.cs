using UnityEngine;

public class ToggleChanger : MonoBehaviour
{
    public PlayerMotor playerMotor;

    public GameObject devRod;

    public GameObject changer;

    public KeyCode toggleKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (devRod != null)
        {
            if (Input.GetKeyDown(toggleKey))
            {
                playerMotor.showCursor = true;
                changer.SetActive(true);
                Debug.Log("Toggled showCursor to: " + playerMotor.showCursor);
            }
        }
        else
        {
            Debug.LogWarning("Sorry, you don't own the dev rod XD");
            return;
        }
    }

    public void TurnOffChanger()
    {
        changer.SetActive(false);
         playerMotor.showCursor = false;
         Debug.Log("Toggled showCursor to: " + playerMotor.showCursor);
    }
}
