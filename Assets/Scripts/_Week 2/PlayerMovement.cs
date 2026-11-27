using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // Complete each section marked TODO.

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Roll Settings")]
    public float rollSpeed = 10f;
    public float rollDuration = 0.5f;
    public float rollCooldown = 1f;

    private bool isDashing = false;
    private bool canDash = true;
    public bool isInvincible = false;

    [Header("Animation")]
    public Animator animator;
    public string isMovingParameter = "isMoving";
    public string rollTriggerParameter = "roll";

    [Header("Sprite")]
    public SpriteRenderer spriteRenderer;
    public bool faceRightByDefault = true;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection = Vector2.right;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (Time.timeScale == 0f) return;
        ReadMovementInput();
        HandleRollInput();
        UpdateAnimation();
        UpdateSpriteFlip();
    }

    private void ReadMovementInput()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        // These variables store the player's horizontal and vertical movement directions.
        float x = 0f;
        float y = 0f;

        // Check whether the player is holding W or the Up Arrow.
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            // Set the vertical movement direction to move up.
            y = 1f;
        }

        // TODO: Add an if statement that checks whether the player
        // is holding S or the Down Arrow.
        
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            // Set the vertical movement direction to move down.
            y = -1f;
        }



        // TODO: Add an if statement that checks whether the player
        // is holding A or the Left Arrow.
        
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            // Set the horizontal movement direction to move left.
            x = -1f;
        }



        // TODO: Add an if statement that checks whether the player
        // is holding D or the Right Arrow.

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            // Set the horizontal movement direction to move right.
            x = 1f;
        }



        // Combine the horizontal and vertical values into one movement direction.
        moveInput = new Vector2(x, y);

        // Stop diagonal movement from being faster.
        if (moveInput.sqrMagnitude > 1f)
        {
            moveInput = moveInput.normalized;
        }
        //remember the last direction the player moved in, so we can use it for rolling when the player is not moving.
        if(moveInput.sqrMagnitude > 0f)
        {
            lastMoveDirection = moveInput;
        }
    }

    private void HandleRollInput()
    {
        if (Keyboard.current == null || !canDash)
        {
            return;
        }

        // Check whether the player pressed the Left Shift key.
        if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
        {
            // Start the dash coroutine.
            StartCoroutine(Roll());
        }
    }


    //this is the same as a for loop but you can pause it and wait for a certain amount of time before continuing
    private IEnumerator Roll()
    {
        //runs on the first frame
        canDash = false;
        isDashing = true;
        isInvincible = true;
        //uses current movement direction or last movement direction if the player is not moving    
        Vector2 rollDirection = moveInput.sqrMagnitude > 0f ? moveInput : lastMoveDirection;
        rb.linearVelocity = rollDirection * rollSpeed;

        if(animator != null && !string.IsNullOrEmpty(rollTriggerParameter))
        {
            //difference between SetBool and SetTrigger is that SetTrigger will automatically reset the trigger after it has been used, while SetBool will keep the value until it is changed again.
            animator.SetTrigger(rollTriggerParameter);
        }

        //waits for 70% of the roll duration before turning off dashing and invincibility to shorten the invincibility window and make the roll feel more responsive.
        yield return new WaitForSeconds(rollDuration*0.7f);
        
        isDashing = false;
        isInvincible = false;
        yield return new WaitForSeconds(rollDuration*0.3f);

        yield return new WaitForSeconds(rollCooldown);
        canDash = true;
    }

    private void FixedUpdate()
    {   
        //prevents normal movement from overiding roll velocity
        if (isDashing)
        {
            return;
        }

        // Apply the movement direction and speed to the Rigidbody.
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void UpdateAnimation()
    {
        if (animator == null)
        {
            return;
        }

        // Check whether the player is currently moving.
        bool isMoving = moveInput.sqrMagnitude > 0f;

        // Update the movement animation.
        animator.SetBool(isMovingParameter, isMoving);
    }

    private void UpdateSpriteFlip()
    {
        if (spriteRenderer == null)
        {
            
            return;
            
        }

        // Only flip when moving left or right.
        // This prevents the sprite from flipping when moving up or down.
        if (moveInput.x > 0f)
        {
            spriteRenderer.flipX = !faceRightByDefault;
            Debug.Log("PlayerMovement:right");
        }
        else if (moveInput.x < 0f)
        {
            spriteRenderer.flipX = faceRightByDefault;
            Debug.Log("PlayerMovement:left");
        }
    }
}