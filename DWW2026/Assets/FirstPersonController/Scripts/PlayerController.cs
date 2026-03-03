using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    // Player controls
    private PlayerInput playerInput;

    // Any actions you have go here
    // If your game doesn't include jumping you can fairly easily remove it from this script
    public InputAction move, look, jump;

    // Rigidbody
    public Rigidbody rigidBody;

    [Header("Movement")]
    public float maxMoveSpeed = 5;
    public float accelerationTime = 1;
    float moveSpeed, acceleration;
    bool walking = false, decelerate = false;
    Vector3 movement = Vector3.zero;

    [Header("Jumping")]
    public float jumpHeight = 1.2f;

    [Header("Gravity")]
    public float gravity = -25;
    public bool grounded = true;
    public float groundedOffset = -0.14f;
    public float groundedRadius = 0.5f;
    public LayerMask groundLayers;
    public float terminalVelocity = 53.0f;
    public float fallMultiplier = 3.5f;

    [Header("Cinemachine")]
    public GameObject cinemachineCameraTarget;
    public float rotationSpeed = 1.0f;
    public float topClamp = 90.0f;
    public float bottomClamp = -90.0f;
    private float cinemachineTargetPitch;
    private float rotationVelocity;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Calculate acceleration
        acceleration = maxMoveSpeed / accelerationTime;

        // Hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        move = playerInput.Player.Move;
        move.Enable();

        look = playerInput.Player.Look;
        look.Enable();

        jump = playerInput.Player.Jump;
        jump.Enable();
        jump.performed += JumpInput;
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        jump.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Player isn't walking
        if (move.ReadValue<Vector3>() == Vector3.zero)
        {
            // Just stopped walking
            if (walking)
            {
                walking = false;
                decelerate = true;
            }
        }
        // Player is walking
        else
        {
            movement = move.ReadValue<Vector3>();

            // Start walking
            if (!walking) walking = true;
        }
    }

    private void FixedUpdate()
    {
        // Ground check
        grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z), groundedRadius, groundLayers);

        // Apply drag
        rigidBody.linearDamping = grounded ? 1 : 2.5f;

        Walk();
        Gravity();
    }

    void Walk()
    {
        // Walk
        if (walking)
        {
            // Accelerate until max speed is reached
            if (moveSpeed < maxMoveSpeed) moveSpeed += acceleration * Time.fixedDeltaTime;
            else moveSpeed = maxMoveSpeed;
        }
        // Decelerate
        else if (decelerate)
        {
            // Decelerate until stopped
            if (moveSpeed > 0) moveSpeed -= acceleration * Time.fixedDeltaTime;
            else
            {
                moveSpeed = 0;
                decelerate = false;
                movement = Vector3.zero;
            }
        }

        // Normallized to prevent the player from going faster when moving diagonally
        // Preserve vertical movement
        Vector3 horizontalVelocity = movement.normalized * moveSpeed;
        rigidBody.linearVelocity = new Vector3(horizontalVelocity.x, rigidBody.linearVelocity.y, horizontalVelocity.z);
    }

    // Jump
    void Jump()
    {
        if (!grounded) return;

        // Reset vertical velocity so jumps are consistent
        rigidBody.linearVelocity = new Vector3(rigidBody.linearVelocity.x, 0f, rigidBody.linearVelocity.z);

        // Calculate jump force using physics formula
        float jumpForce = Mathf.Sqrt(jumpHeight * -2f * gravity);

        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        grounded = false;
    }

    // Jump Input
    private void JumpInput(InputAction.CallbackContext context)
    {
        if (context.performed) Jump();
    }

    // Gravity
    void Gravity()
    {
        float yVelocity = rigidBody.linearVelocity.y;

        if (grounded && yVelocity < 0)
        {
            rigidBody.linearVelocity = new Vector3(rigidBody.linearVelocity.x, -2f, rigidBody.linearVelocity.z);
            return;
        }

        // Apply normal gravity while jumping
        if (yVelocity > 0)
        {
            rigidBody.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        }
        // Apply stronger gravity when falling
        else
        {
            rigidBody.AddForce(Vector3.up * gravity * fallMultiplier, ForceMode.Acceleration);
        }

        // Clamp terminal velocity
        if (rigidBody.linearVelocity.y < -terminalVelocity)
        {
            rigidBody.linearVelocity = new Vector3(rigidBody.linearVelocity.x, -terminalVelocity, rigidBody.linearVelocity.z);
        }
    }

    public void LateUpdate()
    {
        CameraRotation();
    }

    // Camera rotation
    private void CameraRotation()
    {
        // If there is an input
        if (look.ReadValue<Vector2>().sqrMagnitude >= 0.01f)
        {
            // Get the camera value
            Vector2 cameraValue = look.ReadValue<Vector2>();
            cinemachineTargetPitch += cameraValue.y * rotationSpeed;
            rotationVelocity = cameraValue.x * rotationSpeed;

            // Clamp our pitch rotation
            cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, bottomClamp, topClamp);

            // Update Cinemachine camera target pitch
            cinemachineCameraTarget.transform.localRotation = Quaternion.Euler(cinemachineTargetPitch, 0.0f, 0.0f);

            // rotate the player left and right
            transform.Rotate(Vector3.up * rotationVelocity);
        }
    }

    // Clamps rotation
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

}
