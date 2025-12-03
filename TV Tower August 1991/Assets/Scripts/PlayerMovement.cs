using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 9f;
    public float crouchSpeed = 2.5f;

    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    public float standingHeight = 1.8f;
    public float crouchingHeight = 1.0f;
    public float heightChangeSpeed = 6f;

    [Header("Stamina Settings")]
    public float maxStamina = 100f;
    public float staminaRegenRate = 20f;     // per second
    public float staminaDrainRate = 35f;     // per second
    public Slider staminaBar;                // ← Drag UI slider here

    float stamina;
    public bool isSprinting = false;
    public bool isCrouching = false;

    CharacterController cc;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        cc = gameObject.AddComponent<CharacterController>();
        cc.height = standingHeight;

        stamina = maxStamina;

        if (staminaBar != null)
            staminaBar.maxValue = maxStamina;
    }

    void Update()
    {
        // ----- Ground check -----
        isGrounded = cc.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // ----- INPUT -----
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        // ----- CROUCH -----
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        float currentSpeed = isCrouching ? crouchSpeed : walkSpeed;

        // ----- SPRINT -----
        bool wantsToSprint = Input.GetKey(KeyCode.LeftShift) && !isCrouching && z > 0f;
        isSprinting = wantsToSprint && stamina > 0f;

        if (isSprinting)
            currentSpeed = sprintSpeed;

        // Move the player
        cc.Move(move * currentSpeed * Time.deltaTime);

        // ----- JUMP -----
        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouching)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        // ----- GRAVITY -----
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        // ----- SMOOTH HEIGHT CHANGE -----
        float targetHeight = isCrouching ? crouchingHeight : standingHeight;
        cc.height = Mathf.Lerp(cc.height, targetHeight, Time.deltaTime * heightChangeSpeed);

        // ----- STAMINA SYSTEM -----
        HandleStamina();
    }

    void HandleStamina()
    {
        if (isSprinting)
        {
            stamina -= staminaDrainRate * Time.deltaTime;

            if (stamina < 0f)
                stamina = 0f;
        }
        else
        {
            stamina += staminaRegenRate * Time.deltaTime;
            if (stamina > maxStamina)
                stamina = maxStamina;
        }

        if (staminaBar != null)
            staminaBar.value = stamina;
    }
}