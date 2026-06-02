using UnityEngine;

public class InteractionToggle : MonoBehaviour
{
    public PlayerMotor playerMotor; // Reference to the PlayerMotor script to control player movement
    public PlayerLook playerLook; // Reference to the PlayerLook script to control player camera rotation
    public CastRod castRod; // Reference to the CastRod script to control fishing rod interactions

    public GameObject interactionUI; // Reference to the UI element that prompts the player to interact

    public Transform playerTransform, playerCamTransform; // Reference to the player's transform for proximity checks (if needed)

    public KeyCode interactionKey; // Key to press for interaction

    public bool isToggled; // Flag to track whether the interaction is currently toggled

    public bool isOff; // Flag to track whether the interaction is currently toggled off

    public Quaternion originalPlayerRotation; // Store the original player rotation

    public Quaternion originalCamRotation; // Store the original camera rotation

    public Quaternion storedPlayerRotation; // Store the player rotation when the interaction is toggled on
    public Quaternion storedCamRotation; // Store the camera rotation when the interaction is toggled on

    public float timeTillReset = 1.5f; // Time in seconds until the interaction resets (if needed)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interactionUI.SetActive(isToggled); // Show or hide the interaction UI based on the toggle state

        originalCamRotation = playerCamTransform.rotation; // Store the original camera rotation at the start

        originalPlayerRotation = playerTransform.rotation; // Store the original player rotation at the start

        originalPlayerRotation = playerTransform.rotation; // Update the original player rotation when the interaction key is pressed

        if (Input.GetKeyDown(interactionKey) && isToggled)
        {
            isOff = true; // Set the isOff flag to true when the interaction is toggled off
        }

        if (Input.GetKeyDown(interactionKey))
        {
            if (!isToggled)
            {
                storedCamRotation = playerCamTransform.rotation; // Store the camera rotation when the interaction key is pressed
                storedPlayerRotation = playerTransform.rotation; // Store the player rotation when the interaction key is pressed
            }
            isToggled = !isToggled; // Toggle the interaction state
            playerMotor.canJump = !isToggled; // Enable or disable player jumping based on the toggle state
            playerMotor.canMove = !isToggled; // Enable or disable player movement based on the toggle state
            playerMotor.showCursor = isToggled; // Show or hide the cursor based on the toggle state
            castRod.canCast = !isToggled; // Enable or disable fishing rod interactions based on the toggle state
            playerLook.canLook = false; // Disable player camera rotation when the interaction is toggled on
        }

        if (isToggled)
        {
            // Additional logic for when the interaction is toggled on can be added here
            // For example, you could check for proximity to certain objects or trigger specific events
            // Make it so the player and camera smoothly go to the rotation given.
            playerCamTransform.rotation = Quaternion.Lerp(playerCamTransform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f); // Smoothly rotate camera to the desired rotation
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f); // Smoothly rotate player to the desired rotation
        }

        if (isOff)
        {
            // Additional logic for when the interaction is toggled off can be added here
            // For example, you could reset certain states or trigger specific events
            // Make it so the player and camera smoothly go back to their original rotation.
            playerCamTransform.rotation = Quaternion.Lerp(playerCamTransform.rotation, storedCamRotation, Time.deltaTime * 5f); // Smoothly rotate camera back to original rotation

            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, storedPlayerRotation, Time.deltaTime * 5f); // Smoothly rotate player back to original rotation

            timeTillReset -= Time.deltaTime; // Decrease the time until reset

            if (timeTillReset <= 0f)
            {
                playerLook.canLook = true; // Re-enable player camera rotation after the specified time
                isOff = false; // Reset the isOff flag after the specified time
                timeTillReset = 1.5f; // Reset the timer for the next toggle off
            }
        }
    }
}
