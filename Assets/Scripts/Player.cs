using UnityEngine;
using static UnityEditor.Progress;

public abstract class Player : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 10f;
    [SerializeField] public float jumpSpeed = 5f;
    private Rigidbody rb;
    private Vector3 jumpVector;
    private bool isGrounded;

    protected abstract float GetMovementSpeed();
    protected abstract float GetJumpSpeed();
    protected abstract bool CanMove(Vector3 moveDirection, float moveDistance);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpVector = new Vector3(0f, 1f);
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
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
