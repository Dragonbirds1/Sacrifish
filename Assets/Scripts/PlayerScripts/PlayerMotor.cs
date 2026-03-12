using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;
    private bool lerpCrouch;
    private bool crouching;
    private float crouchTimer;
    private bool sprinting;
    public bool canSprint = true;
    public GameObject player;
    public bool canMove = true;
    public bool canJump = true;
    public float currentSpeed; // For red light green light game to get if the player is moving or not.
    public Vector3 moveDirection = Vector3.zero;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        // always set the current speed to the player's velocity magnitude for red light green light game.
        //currentSpeed = playerVelocity.x;
        if (canSprint == false)
        {
            sprinting = false;
            speed = 5;
        }
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
            }
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        if (canSprint == true)
        {
            sprinting = !sprinting;
            if (sprinting)
            {
                speed = 8;
            }
            else
            {
                speed = 5;
            }
        }
        else if (canSprint == false)
        {
            sprinting = false;
            speed = 5;
        }
    }

    // Receive the inputs for our InputManager.cs and apply them to our character controller.
    public void ProcessMove(Vector2 input)
    {
        if (canMove == true)
        {
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            // Update current Speed based on the player's movement input
            currentSpeed = moveDirection.magnitude * speed;
            playerVelocity.y += gravity * Time.deltaTime;
            if (isGrounded && playerVelocity.y < 0)
                playerVelocity.y = -2f;
            controller.Move(playerVelocity * Time.deltaTime);
            //Debug.Log(playerVelocity.y);
        }
    }

    public void Jump()
    {
        if (canJump == true)
        {
            if (isGrounded)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        }
    }
}
