using UnityEngine;

public class AnimationAndMovementController : MonoBehaviour
{
    public Transform jumpPoint;

    // personagem
    public Animator animator;
    CharacterController characterController;

    // controlar deslocamento
    Vector3 currentMovement;

    // grávidade
    float gravity = -9.8f;
    float groundedGravity = -0.05f;

    // movimento
    bool isRunning = false;
    float runningDirection = 1;
    float runningVelocity = 6.0f;

    // salto
    bool isJumping = false;
    bool isJumpPressed = false;
    float initialJumpVelocity;
    float maxJumpHeight = 4.0f;
    float maxJumpTime = 0.8f;

    // usar gancho
    bool isUseHook = false;
    float shiftHookVelocity = 2.0f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        SetupJumpVariables();
    }

    void Update()
    {
        OnRun();
        OnJump();
        OnUseHook();
        characterController.Move(currentMovement * Time.deltaTime);
        HandleGravity();
        HandleMovement();
        HandleJump();
    }
    void SetupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void OnRun()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning", true);
            isRunning = true;
            runningDirection = - 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
            isRunning = true;
            runningDirection = 1;
        }
        else
        {
            animator.SetBool("isRunning", false);
            isRunning = false;
        }
    }

    void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumpPressed = true;
        } else {
            isJumpPressed = false;
        }
    }

    void OnUseHook()
    {
        if (Input.GetMouseButtonDown(0) && jumpPoint != null) {
            isUseHook = true;
        } else {
            isUseHook = false;
        }
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

    void HandleMovement()
    {
        if (isUseHook)
        {
            Vector3 dir = jumpPoint.position - transform.position;
            currentMovement = dir.normalized * initialJumpVelocity * 1.4f;
        }


        if (characterController.isGrounded && !isUseHook)
        {
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isRunning", true);
                currentMovement.z = runningVelocity * -1;
                Vector3 look = Vector3.left - transform.position;
                transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isRunning", true);
                currentMovement.z = runningVelocity * 1;
                Vector3 look = Vector3.right - transform.position;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            }
            else
            {
                animator.SetBool("isRunning", false);
                currentMovement.z = runningVelocity * 0;
            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GroundJumper")
        {
            currentMovement.y = 50.0f;
        }
    }
}
