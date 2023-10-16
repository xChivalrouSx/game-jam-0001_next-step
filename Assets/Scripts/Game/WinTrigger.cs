using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winUI;

    private void Awake()
    {
        winUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player") && !winUI.activeInHierarchy)
        {
            winUI.gameObject.SetActive(true);
        }
    }
}
