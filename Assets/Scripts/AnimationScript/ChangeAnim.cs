using UnityEngine;

public class ChangeAnim : MonoBehaviour
{
    public Animator playerAnim, otherAnim;

    public bool isPlayerAnim, isOtherAnim, timerStart;

    public bool hatToggle, sharkToggle, scareToggle;

    public float timer;

    public float HatTimer, SharkTimer, ScareTimer;

    public int animNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlayerAnim = true;
        timerStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAnim)
        {
            playerAnim.enabled = true;
            otherAnim.enabled = false;
        }
        else
        {
            otherAnim.enabled = true;
            playerAnim.enabled = false;
        }

        if (timerStart)
        {
            isPlayerAnim = true; // Make the player idle animation play
            playerAnim.SetBool("PlayerReturn", false); // Reset the player return bool to false so the idle animation can play
            otherAnim.SetBool("Return", false); // Reset the other return bool to false so the idle animation can play
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                animNumber = Random.Range(0, 2); // Randomly select ethier 0, 1, or 2 for three different animations
                if (animNumber == 0)
                {
                    isPlayerAnim = true;
                    hatToggle = true;
                    sharkToggle = false;
                    scareToggle = false;
                }
                else if (animNumber == 1)
                {
                    isPlayerAnim = false;
                    sharkToggle = true;
                    scareToggle = false;
                    hatToggle = false;
                }
                else if (animNumber == 2)
                {
                    isPlayerAnim = false;
                    scareToggle = true;
                    hatToggle = false;
                    sharkToggle = false;
                }
                timer = 0f;
                timerStart = false;
            }
        }

        if (hatToggle)
        {
            playerAnim.SetBool("HatAnim", true);
            HatTimer += Time.deltaTime;
            if (HatTimer >= 11f)
            {
                hatToggle = false;
                playerAnim.SetBool("HatAnim", false);
                playerAnim.SetBool("PlayerReturn", true);
                HatTimer = 0f;
                timerStart = true;
            }
        }
        else if (sharkToggle)
        {
            otherAnim.SetBool("SharkAnim", true);
            SharkTimer += Time.deltaTime;
            if (SharkTimer >= 23f)
            {
                sharkToggle = false;
                otherAnim.SetBool("SharkAnim", false);
                otherAnim.SetBool("Return", true);
                SharkTimer = 0f;
                timerStart = true;
            }
        }
        else if (scareToggle)
        {
            otherAnim.SetBool("ScareAnim", true);
            ScareTimer += Time.deltaTime;
            if (ScareTimer >= 6f)
            {
                scareToggle = false;
                otherAnim.SetBool("ScareAnim", false);
                otherAnim.SetBool("Return", true);
                ScareTimer = 0f;
                timerStart = true;
            }
        }
    }
}
