using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winUI;

    private void Start()
    {
        //winUI = GameObject.FindFirstObjectByType<WinUI>();
        //winUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player") && !winUI.activeSelf)
        {
            winUI.SetActive(true);
        }
    }
}
