using System.Runtime.InteropServices;
using UnityEngine;

public class SingleMeleeAutoAttack : MonoBehaviour
{
    // Complete each section marked TODO.

    [Header("References")]
    public GameObject slashPrefab;
    public SpriteRenderer playerSpriteRenderer;

    [Header("Ultimate Attack Settings")]
    public GameObject ultimateSlashPrefab;
    public int ultimateDamage = 20;
    public float ultimateCooldown = 10f;
    public KeyCode ultimateKey = KeyCode.Q;

    private float ultimateTimer = 0f;

    [Header("Animation")]
    public Animator animator;
    public bool useAttackAnimation = true;
    public string attackTriggerName = "Attack";

    [Header("Facing")]
    public bool facingRight = true;
    public bool faceRightByDefault = true;

    [Header("Attack Settings")]
    public bool attacksEnabled = true;
    public int damage = 5;
    public float cooldown = 1f;

    [Header("Slash Position")]
    public float slashOffsetX = 1f;
    public float slashOffsetY = 0f;

    [Header("Slash Visual")]
    public bool flipSlashWhenFacingLeft = true;

    [Header("Debug")]
    public bool showDebugLogs = true;

    [Header("Debug View")]
    public float attackTimer = 0f;

    private void Start()
    {
        // TODO: Check if playerSpriteRenderer is null.
        // If it is, get the SpriteRenderer from this GameObject or its children.
        if(playerSpriteRenderer == null)
        {
            playerSpriteRenderer = GetComponent<SpriteRenderer>();
        }



        // Get the Animator if one has not been assigned.
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }

        // TODO: Set the attack timer to the cooldown value.
        attackTimer = cooldown;


        if (showDebugLogs == true)
        {
            Debug.Log("SingleMeleeAutoAttack: Started. Damage = " + damage + ", Cooldown = " + cooldown);
        }
    }

    private void Update()
    {
        UpdateFacingFromSprite();
        UpdateAutoAttack();
        UpdateUltimateAttack();
    }

    private void UpdateFacingFromSprite()
    {
        if (playerSpriteRenderer == null)
        {
            return;
        }

        // TODO: Check whether the player's sprite faces right by default.
        if (faceRightByDefault == true)
        {
            facingRight = playerSpriteRenderer.flipX == false;

        }
        else
        {
            // TODO: Set facingRight based on whether the SpriteRenderer is flipped.
            facingRight = playerSpriteRenderer.flipX == true;
        }
    }

    private void UpdateAutoAttack()
    {
        if (attacksEnabled == false)
        {
            return;
        }

        // Reduce the attack timer each frame.
        attackTimer -= Time.deltaTime;

        // When the timer reaches 0, attack and reset the timer.
        if (attackTimer <= 0f)
        {
            // TODO: Call the Attack function.

            Attack();

            // TODO: Reset attackTimer to the cooldown value.

            attackTimer = cooldown;
        }
    }

    private void UpdateUltimateAttack()
    {
        ultimateTimer -= Time.deltaTime;

        if(Input.GetKeyDown(ultimateKey) && ultimateTimer <0f)
        {
            PerformUltimateAttack();

            ultimateTimer = ultimateCooldown;
        }
    }

    private void Attack()
    {
        // TODO: Call the function that performs the melee slash.

        PerformSlash();

        // TODO: Call the function that plays the attack animation.

        PlayAttackAnimation();
    }

    private void PlayAttackAnimation()
    {
        if (useAttackAnimation == false)
        {
            return;
        }

        if (animator == null)
        {
            if (showDebugLogs == true)
            {
                Debug.LogWarning("SingleMeleeAutoAttack: No Animator found.");
            }

            return;
        }

        // Play the attack animation.
        animator.SetTrigger(attackTriggerName);

        if (showDebugLogs == true)
        {
            Debug.Log("SingleMeleeAutoAttack: Attack animation triggered.");
        }
    }

    private void PerformSlash()
    {
        if (slashPrefab == null)
        {
            if (showDebugLogs == true)
            {
                Debug.LogWarning("SingleMeleeAutoAttack: No slashPrefab assigned.");
            }

            return;
        }

        // Choose which direction the slash should appear.
        float direction = facingRight ? 1f : -1f;

        //expanded version of above
        // if (facingRight)
        // {
        //  direction = 1f;
        // } else {
        // direction = -f;
        // }

        Vector3 localSpawnPosition = new Vector3(slashOffsetX * direction, slashOffsetY, 0f);

        // Create the slash as a child of the player.
        GameObject slashObj = Instantiate(slashPrefab, transform);

        slashObj.transform.localPosition = localSpawnPosition;
        slashObj.transform.localRotation = Quaternion.identity;

        if (flipSlashWhenFacingLeft == true)
        {
            // TODO: Get the SpriteRenderer from the slash object.
            SpriteRenderer slashRenderer = slashObj.GetComponentInChildren<SpriteRenderer>();

            // TODO: Check that slashRenderer is not null.
            // If it exists, set its flipX value based on facingRight.
            if (slashRenderer != null)
            {
                slashRenderer.flipX = facingRight;
            }

        }

        // TODO: Get the MeleeSlash script from the slash object.
        MeleeSlash slash = slashObj.GetComponentInChildren<MeleeSlash>();

        // TODO: Check that slash is not null.
        // If it exists, call Initialize and give it the player's damage.
        if (slash != null)
        {
            slash.Initialize(damage);
            
        }


        if (showDebugLogs == true)
        {
            Debug.Log("SingleMeleeAutoAttack: Auto slash spawned. FacingRight = " + facingRight + ", Damage = " + damage);
        }
    }

    private void PerformUltimateAttack()
    {
        if (ultimateSlashPrefab == null)
        {
            Debug.LogWarning("No Ultimate Slash Prefab assigned!");
            return;
        }

        float direction = facingRight ? 1f : -1f;

        Vector3 spawnPosition = new Vector3(
            slashOffsetX * direction,
            slashOffsetY,
            0f
        );

        GameObject ultimateObj = Instantiate(ultimateSlashPrefab, transform);

        ultimateObj.transform.localPosition = spawnPosition;
        ultimateObj.transform.localRotation = Quaternion.identity;

        SpriteRenderer ultimateRenderer =
            ultimateObj.GetComponentInChildren<SpriteRenderer>();

        if (ultimateRenderer != null)
        {
            ultimateRenderer.flipX = !facingRight;
        }

        MeleeSlash ultimateSlash = ultimateObj.GetComponent<MeleeSlash>();

        if (ultimateSlash != null)
        {
            ultimateSlash.Initialize(ultimateDamage);
        }

        PlayAttackAnimation();

        if (showDebugLogs)
        {
            Debug.Log("ULTIMATE ATTACK ACTIVATED!");
        }
    }
    
}