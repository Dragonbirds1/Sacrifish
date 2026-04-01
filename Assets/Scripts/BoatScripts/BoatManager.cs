using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BoatManager : MonoBehaviour
{
    public PlayerMotor playerMotor;

    public PlayerLook playerLook;

    public GameObject player;

    public GameObject boat;

    public CharacterController boatController;

    public Transform boatSeat;

    public float interactionRange;

    public float speed = 5f;

    public float currentSpeed;

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
            boatController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            // Update current Speed based on the player's movement input
            currentSpeed = moveDirection.magnitude * speed;
            playerVelocity.y += gravity * Time.deltaTime;
            //if (isGrounded && playerVelocity.y < 0)
                //playerVelocity.y = -2f;
            boatController.Move(playerVelocity * Time.deltaTime);
            //Debug.Log(playerVelocity.y);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
