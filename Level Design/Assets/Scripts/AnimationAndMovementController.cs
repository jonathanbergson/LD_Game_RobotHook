using UnityEngine;

public class AnimationAndMovementController : MonoBehaviour
{
    Animator animator;
    CharacterController characterController;

    // variables to store player input values
    Vector3 currentMovement;

    // gravity variables
    float gravity = -9.8f;
    float groundedGravity = -0.05f;

    // movemente variables
    bool isRunning = false;
    int isRunningPressed = 0;
    float runningVelocity = 6.0f;

    // jump variables
    bool isJumping = false;
    bool isJumpPressed = false;
    float initialJumpVelocity;
    float maxJumpHeight = 4.0f;
    float maxJumpTime = 0.6f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        SetupJumpVariables();
    }

    void Update()
    {
        OnMovement();
        OnJump();
        characterController.Move(currentMovement * Time.deltaTime);
        HandleGravity();
        HandleJump();
    }

    void HandleGravity()
    {
        if (characterController.isGrounded) {
            animator.SetBool("isJumping", false);
            currentMovement.y = groundedGravity;
        } else {
            currentMovement.y += gravity * Time.deltaTime;
        }
    }

    void OnMovement()
    {
        if (Input.GetKey(KeyCode.A)) {
            animator.SetBool("isRunning", true);
            currentMovement.z = runningVelocity * -1;
            Vector3 look = Vector3.left - transform.position;
            transform.rotation =  Quaternion.LookRotation(Vector3.back, Vector3.up);
        } else if (Input.GetKey(KeyCode.D)) {
            animator.SetBool("isRunning", true);
            currentMovement.z = runningVelocity * 1;
            Vector3 look = Vector3.right - transform.position;
            transform.rotation =  Quaternion.LookRotation(Vector3.forward, Vector3.up);
        } else {
            animator.SetBool("isRunning", false);
            currentMovement.z = runningVelocity * 0;
        }
    }

    void SetupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumpPressed = true;
        } else {
            isJumpPressed = false;
        }
    }

    void HandleJump()
    {
        if (!isJumping && characterController.isGrounded && isJumpPressed) {
            animator.SetBool("isJumping", true);
            isJumping = true;
            currentMovement.y = initialJumpVelocity;
        } else if (isJumping && characterController.isGrounded && !isJumpPressed) {
            isJumping = false;
        }
    }
}
