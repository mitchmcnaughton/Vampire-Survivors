using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class UltimateAttack : MonoBehaviour
{

    [Header("References")]
    public GameObject slashPrefab;
    public SpriteRenderer playerSpriteRederer;

    [Header("Animation")]
    public Animator animator;
    public bool useAttackAnimation = true;
    public string attackTriggerName = "Attack";

    [Header("Facing")]
    public bool facingRight = true;
    public bool faceRightbyDefault = true;

    [Header("Attack Settings")]
    public bool attacksEnable3d = true;
    public int damage = 5;

    [Header("Slash Position")]
    public float slashOffsetX = 0f;
    public float slashOffsetY = 0f;

    [Header("Slash Visual")]
    public bool flipSlashWhenFacingLeft;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
