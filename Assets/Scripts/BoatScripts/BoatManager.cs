using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BoatManager : MonoBehaviour
{
    public PlayerMotor playerMotor;

    public PlayerLook playerLook;

    public GameObject player;

    public GameObject boat;

    //public CharacterController boatController;

    // Stop using CharacterController.Move so the boat can float on water and not be affected by gravity when in the boat.
    public Rigidbody boatRigidbody;

    public Transform boatSeat;

    public float interactionRange;

    public float speed = 5f;

    public float currentSpeed;

    public float acceleration; // This is for the boat to gradually speed up and slow down instead of instantly changing speed.

    public float gravity = -9.8f;

    public bool isInBoat;

    public KeyCode interactKey;

    public Vector3 moveDirection = Vector3.zero;

    private Vector3 playerVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInBoat)
        {
            player.transform.position = boatSeat.position;
            player.transform.rotation = Quaternion.Lerp(boatSeat.transform.rotation, boatSeat.transform.rotation, 0);
        }

        if (Vector3.Distance(player.transform.position, transform.position) <= interactionRange)
        {
            if (Input.GetKeyDown(interactKey) && !isInBoat)
            {
                playerMotor.canMove = false;
                player.transform.position = boatSeat.position;
                player.transform.rotation = boatSeat.rotation;
                isInBoat = true;
            }
            else if (Input.GetKeyDown(interactKey) && isInBoat)
            {
                playerMotor.canMove = true;
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                isInBoat = false;
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {
        if (isInBoat)
        {
            moveDirection.x = -input.y;
            moveDirection.z = input.x;
            //boatController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            // Stop using CharacterController.Move so the boat can float on water and not be affected by gravity when in the boat.
            // Make it so force mode acceleration is the acceleration we set in the inspector so the boat can gradually speed up and slow down instead of instantly changing speed.
            // make it speed up and slow down based on the acceleration variable we set in the inspector instead of instantly changing speed.
            boatRigidbody.AddForce(transform.TransformDirection(moveDirection) * speed * Time.deltaTime, ForceMode.Acceleration);
            // Update current Speed based on the player's movement input
            currentSpeed = moveDirection.magnitude * speed;
            playerVelocity.y += gravity * Time.deltaTime;
            //if (isGrounded && playerVelocity.y < 0)
                //playerVelocity.y = -2f;
            //boatController.Move(playerVelocity * Time.deltaTime);
            // Do the same here
            //boatRigidbody.AddForce(Vector3.up * playerVelocity.y, ForceMode.Acceleration);
            //Debug.Log(playerVelocity.y);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
