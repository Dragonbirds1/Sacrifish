using UnityEngine;
using TMPro;

public class KeybindChanger : MonoBehaviour
{
    /// <summary>
    /// This script will be responsible for changing the keybinds of the game.
    /// When the player clicks on a keybind in the settings menu, this script will be called to change the keybind to the new key that the player has selected.
    /// </summary>
    
    public KeyCode newKeybind; // The new keybind that the player has selected

    public KeyCode oldKeybind; // The default keybind that the player has before changing it to the new keybind

    public string keybindKeyName; // The name of the keybind that is being changed (e.g. "E", "F", "R", etc.)

    public bool isWaitingForInput = false; // Flag to track whether the script is currently waiting for the player to input a new keybind

    public TextMeshProUGUI keybindText; // The TextMeshProUGUI component that displays the current keybind in the settings menu

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keybindKeyName = newKeybind.ToString(); // Update the keybind key name to the new keybind that the player has selected

        if (isWaitingForInput)
        {

            // Set the new keybind to the key that the player has pressed
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    newKeybind = keyCode; // Set the new keybind to the key that the player has pressed
                    Debug.Log("New keybind for " + keybindKeyName + " is " + newKeybind.ToString());
                    keybindText.text = newKeybind.ToString(); // Update the text in the settings menu to display the new keybind
                    isWaitingForInput = false; // Set the flag to false to indicate that the script is no longer waiting for input
                    break; // Exit the loop after finding the key that was pressed
                }
            }

        }
    }

    public void WaitForInput()
    {
        isWaitingForInput = true; // Set the flag to true to indicate that the script is now waiting for the player to input a new keybind
    }
}
