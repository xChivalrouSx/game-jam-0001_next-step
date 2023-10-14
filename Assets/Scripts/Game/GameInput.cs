using UnityEngine;

public class GameInput : MonoBehaviour
{
    public Vector3 GetMovementVectorNormalized()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, 0f, vertical);
    }
}
