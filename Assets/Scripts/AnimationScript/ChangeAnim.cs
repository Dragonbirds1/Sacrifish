using UnityEngine;

public class ChangeAnim : MonoBehaviour
{
    public Animator playerAnim, OtherAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
