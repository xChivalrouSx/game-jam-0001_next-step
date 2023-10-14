using UnityEngine;

public class GameInput : MonoBehaviour
{
    public Vector3 GetMovementVectorNormalized()
    {
        //Vector3 inputVector = new Vector3(0, 0, 0);
        //if (Input.GetKey(KeyCode.W))
        //{
        //    inputVector.z += 1;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    inputVector.z -= 1;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    inputVector.x -= 1;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    inputVector.x += 1;
        //}
        //return inputVector.normalized;

        float horizontal = Input.GetAxis("Horizontal");
        return new Vector3(horizontal, 0f, 0f);
    }
}
