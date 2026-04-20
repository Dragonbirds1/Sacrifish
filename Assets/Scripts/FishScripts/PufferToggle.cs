using UnityEngine;

public class PufferToggle : MonoBehaviour
{
    public Animator pufferAnimator; // Reference to the Animator component controlling the pufferfish
    public AudioSource pufferSound; // Reference to the AudioSource component for the pufferfish sound effect
    public KeyCode toggleKey;
    public float toggleCooldown; // Cooldown time in seconds between toggles
    public bool isPuffed; // Flag to track whether the pufferfish is currently puffed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey) && !isPuffed)
        {
            Augh();
        }

        if (isPuffed)
        {
            toggleCooldown -= Time.deltaTime;
            pufferAnimator.SetBool("Augh", true);
            if (toggleCooldown <= 0f)
            {
                toggleCooldown = 0.333f;
                pufferAnimator.SetBool("Augh", false);
                isPuffed = false;
            }
        }
    }

    public void Augh()
    {
        pufferSound.Play();
        isPuffed = true;
    }
}
