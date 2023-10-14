using Assets.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class MoveableSquare : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player") && Input.GetKey(KeyCode.LeftShift))
        {
            //
            //Vector3 direction = transform.position - playerObject.transform.position;
            //GetComponent<Rigidbody>().AddForce(direction * 100, ForceMode.Impulse);

            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            var test = playerObject.ConvertTo<SpherePlayer>();
            float horizontal = Input.GetAxis("Horizontal");
            float movementDistance = test.GetMovementSpeed() * Time.deltaTime;
            Vector3 movement = new Vector3(horizontal * movementDistance, 0f, 0f);
            transform.position += movement;
        }
    }
}
