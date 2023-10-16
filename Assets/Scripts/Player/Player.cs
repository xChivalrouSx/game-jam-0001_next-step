using System;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public EventHandler JumpHandler;

    [SerializeField] private GameInput gameInput;

    [SerializeField] protected float movementSpeed;

    [SerializeField] protected float jumpSpeed;
    [SerializeField] protected float wallJumpCooldown;

    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheckPoint;

    [SerializeField] protected LayerMask wallLayer;
    [SerializeField] protected Transform wallCheckPointLeft;
    [SerializeField] protected Transform wallCheckPointRight;

    private Rigidbody rigidBody;
    private Animator animator;

    private Change change;

    public static Player Instance { get; internal set; }

    public abstract float GetMovementSpeed();

    protected abstract float GetJumpSpeed();

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one Player instance");
        }
        Instance = this;

        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        change = GameObject.FindFirstObjectByType<Change>();
    }

    public void InAnimation()
    {
        animator.SetTrigger("In");
    }

    public void OutAnimation()
    {
        animator.SetTrigger("Out");
    }

    void Update()
    {
        Vector3 movementDirection = gameInput.GetMovementVectorNormalized();

        if (wallJumpCooldown > 0.2f)
        {
            float velocityZ = change.Is2D ? rigidBody.velocity.z : movementDirection.z * GetMovementSpeed();
            rigidBody.velocity = new Vector3(movementDirection.x * GetMovementSpeed(), rigidBody.velocity.y, velocityZ);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, GetJumpSpeed(), rigidBody.velocity.z);
        }
        else if (OnWall(out bool isRight) && !IsGrounded())
        {
            rigidBody.velocity = new Vector3((isRight ? -1 : 1) * 6, 10, rigidBody.velocity.z);
            wallJumpCooldown = 0;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheckPoint.position, .1f, groundLayer);
    }

    private bool OnWall(out bool isRight)
    {
        isRight = Physics.CheckSphere(wallCheckPointRight.position, .1f, wallLayer);
        return Physics.CheckSphere(wallCheckPointLeft.position, .1f, wallLayer) || isRight;
    }


}