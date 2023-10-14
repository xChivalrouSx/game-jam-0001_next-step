using System;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public EventHandler JumpHandler;

    [SerializeField] private GameInput gameInput;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float jumpSpeed;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheckPoint;

    private Rigidbody rigidBody;
    private Animator animator;

    public static Player Instance { get; internal set; }

    public abstract float GetMovementSpeed();

    protected abstract float GetJumpSpeed();

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one Player instance");
        }
        Instance = this;

        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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
        rigidBody.velocity = new Vector3(movementDirection.x * GetMovementSpeed(), rigidBody.velocity.y, rigidBody.velocity.z);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, GetJumpSpeed(), rigidBody.velocity.z);
    }

    private bool isGrounded()
    {
        return Physics.CheckSphere(groundCheckPoint.position, .1f, groundLayer);
    }


}