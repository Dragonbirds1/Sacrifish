using UnityEngine;

public class ChangeAnim : MonoBehaviour
{
    public Animator playerAnim;
    public Animator otherAnim;

    private float timer;
    private bool playing;

    void Start()
    {
        // Force both to idle at start
        playerAnim.Play("Idle", 0, 0f);
        otherAnim.Play("Idle", 0, 0f);
    }

    void Update()
    {
        if (playing) return;

        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            timer = 0f;
            playing = true;

            int anim = Random.Range(0, 3);

            if (anim == 0)
            {
                playerAnim.SetBool("HatAnim", true);
                Invoke(nameof(EndAnim), 11f);
            }
            else if (anim == 1)
            {
                otherAnim.SetBool("SharkAnim", true);
                Invoke(nameof(EndAnim), 23f);
            }
            else
            {
                otherAnim.SetBool("ScareAnim", true);
                Invoke(nameof(EndAnim), 6f);
            }
        }
    }

    void EndAnim()
    {
        // TURN OFF ALL ANIMATIONS (critical fix)
        playerAnim.SetBool("HatAnim", false);
        otherAnim.SetBool("SharkAnim", false);
        otherAnim.SetBool("ScareAnim", false);

        // FORCE BOTH BACK TO IDLE (this is what you were missing)
        playerAnim.Play("Idle", 0, 0f);
        otherAnim.Play("Idle", 0, 0f);

        playing = false;
    }
}