using UnityEngine;

public class ReloadSceneBlock : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }
}
