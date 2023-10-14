using System;
using UnityEngine;
using static UnityEditor.Progress;

public abstract class Player : MonoBehaviour
{
    public EventHandler JumpHandler;
    [SerializeField] public float movementSpeed = 10f;
    [SerializeField] public float jumpSpeed = 5f;
    private Rigidbody rb;
    private Renderer renderer;
    private Vector3 jumpVector;
    private bool isGrounded;
    private Animator animator;

    public static Player Instance { get; internal set; }

    protected abstract float GetMovementSpeed();
    protected abstract float GetJumpSpeed();
    protected abstract bool CanMove(Vector3 moveDirection, float moveDistance);
    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one Player instance");
        }
        Instance = this;
        rb = GetComponent<Rigidbody>();
        renderer = GetComponentInChildren<Renderer>();
        jumpVector = new Vector3(0f, 1f);
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

    void OnCollisionStay(Collision collision)
    {
        Vector3 bottom = renderer.bounds.center;
        bottom.y -= renderer.bounds.extents.y;
        float minDist = float.PositiveInfinity;
        float angle = 180f;
        for (int i = 0; i < collision.contactCount; i++)
        {
            var contact = collision.GetContact(i);
            var tempDist = Vector3.Distance(contact.point, bottom);
            if (tempDist < minDist)
            {
                angle = Vector3.Angle(transform.up, contact.normal);
            }
        }
        if (angle <= 45f) isGrounded = true;
        else isGrounded = false;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float movementDistance = GetMovementSpeed() * Time.deltaTime;
        Vector3 movement = new Vector3(horizontal * movementDistance, 0f, 0f);
        bool canMove = CanMove(movement, movementDistance);
        if (!canMove)
        {
            Vector3 movementX = new Vector3(movement.x, 0f, 0f);
            canMove = movement.x != 0 && CanMove(movementX, movementDistance);
            if (canMove)
            {
                movement = movementX;
            }
            else
            {
                Vector3 movementZ = new Vector3(0, 0, movement.z);
                canMove = movement.z != 0 && CanMove(movementZ, movementDistance);
                if (canMove)
                {
                    movement = movementZ;
                }
            }
        }
        else
        {
        }
        if (canMove)
        {
            transform.position += movement;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpVector * GetJumpSpeed(), ForceMode.Impulse);
            JumpHandler?.Invoke(this, EventArgs.Empty);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject[] moveableObjects = GameObject.FindGameObjectsWithTag("Moveable");
            foreach (var item in moveableObjects)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GameObject[] moveableObjects = GameObject.FindGameObjectsWithTag("Moveable");
            foreach (var item in moveableObjects)
            {
                item.GetComponent<Rigidbody>().isKinematic = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject[] moveableObjects = GameObject.FindGameObjectsWithTag("Moveable");
            foreach (var item in moveableObjects)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GameObject[] moveableObjects = GameObject.FindGameObjectsWithTag("Moveable");
            foreach (var item in moveableObjects)
            {
                item.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }




}