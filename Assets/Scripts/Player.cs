using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public EventHandler JumpHandler;

    Rigidbody rb;

    private float moveSpeed = 10f;
    public bool canMove = true;

    public static Player Instance { get; internal set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one Player instance");
        }
        Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //HandleMovement(); horizontal ve vertical alýnarak yeniden yapýldý
        if(canMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal * Time.deltaTime * moveSpeed, vertical * Time.deltaTime * moveSpeed, 0f);
            transform.position += movement;
            JumpHandler?.Invoke(this, EventArgs.Empty);
        }
    }

    private void HandleMovement()
    {
        Vector3 movementDirectory = GetMovement();
        transform.position += movementDirectory;
    }

    public Vector3 GetMovement()
    {
        Vector3 inputVector = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x -= 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x += 1;
        }
        return inputVector.normalized;
    }
}
