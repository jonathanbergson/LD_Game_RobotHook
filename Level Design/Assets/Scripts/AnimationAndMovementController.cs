using UnityEngine;

public class AnimationAndMovementController : MonoBehaviour
{
    public Animator animator;
    CharacterController characterController;

    // variables to store player input values
    Vector3 currentMovement;

    // gravity variables
    float gravity = -9.8f;
    float groundedGravity = -0.05f;

    // jump variables
    bool isJumpPressed = false;
    float initialJumpVelocity;
    float maxJumpHeight = 2.0f;
    float maxJumpTime = 0.5f;
    bool isJumping = false;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        SetupJumpVariables();
    }

    void Update()
    {
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
        Debug.Log(characterController.isGrounded);
        if (!isJumping && characterController.isGrounded && isJumpPressed) {
            animator.SetBool("isJumping", true);
            isJumping = true;
            currentMovement.y = initialJumpVelocity;
        } else if (isJumping && characterController.isGrounded && !isJumpPressed) {
            isJumping = false;
        }
    }
}
