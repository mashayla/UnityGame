using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController2 : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public int maxHP = 1000; // Maximum HP
    private int currentHP; // Current HP 
    public bool hasPills = false; // Flag to check if the player has pills

    [SerializeField]
    private StatusController theStatusController;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController characterController;
    public static PlayerController2 instance; // Static instance property

    public Weapon weapon;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        theStatusController = FindObjectOfType<StatusController>();

        // Initialize current HP to max HP
        currentHP = maxHP;
    }

    public void IncreaseHP(int amount)
    {
        if (hasPills)
        {
            currentHP += amount;
            currentHP = Mathf.Clamp(currentHP, 0, maxHP); // Ensure HP doesn't exceed max
            hasPills = false; // Reset the pills flag
        }
    }

    public void ReduceHPByPercentage(float percentage)
    {
        // Calculate the amount of HP to reduce
        int reduceAmount = Mathf.RoundToInt(currentHP * percentage);

        // Reduce the current HP
        currentHP -= reduceAmount;

        // Ensure current HP doesn't fall below 0
        currentHP = Mathf.Max(currentHP, 0);

        // If the player's HP is 0, then the player is dead
        if (currentHP == 0)
        {
            // Handle player death here
            canMove = false;
        }
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (theStatusController.getCurrentSP() <= 0)
        {
            isRunning = false;
        }

        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (isRunning)
        {
            theStatusController.DecreaseStamina(10);
        }

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded && theStatusController.getCurrentSP() > 0)
        {
            moveDirection.y = jumpPower;
            theStatusController.DecreaseStamina(50);
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (theStatusController.IsPlayerDead())
        {
            canMove = false;
        }
    }
}