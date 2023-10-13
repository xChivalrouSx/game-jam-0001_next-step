using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Player : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 10f;
    [SerializeField] public float jumpSpeed = 5f;
    protected abstract float GetMovementSpeed();
    protected abstract float GetJumpSpeed();



    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal * Time.deltaTime * GetMovementSpeed(), vertical * Time.deltaTime * GetJumpSpeed(), 0f);
        transform.position += movement;
    }


}
