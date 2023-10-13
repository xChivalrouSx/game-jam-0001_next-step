using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 10f;
    [SerializeField] public float jumpSpeed = 5f;
    private Rigidbody rb;
    private Vector3 jumpVector;
    private bool isGrounded;

    protected abstract float GetMovementSpeed();
    protected abstract float GetJumpSpeed();
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
        Vector3 movement = new Vector3(horizontal * Time.deltaTime * GetMovementSpeed(), 0f, 0f);
        transform.position += movement;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpVector * GetJumpSpeed(), ForceMode.Impulse);
        }
    }




}
