using TMPro;
using UnityEngine;

public class TutorialTriggerScript : MonoBehaviour
{
    [SerializeField] private GameObject canvasGameObject;
    [SerializeField] private TextMeshProUGUI messageBox;
    [SerializeField] private KeyCode keyToWait;

    private bool isShownAlready;

    private void Awake()
    {
        Hide();
        isShownAlready = false;
    }

    private void Update()
    {
        if (gameObject.activeSelf && Input.GetKey(keyToWait))
        {
            Hide();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other.tag.Contains("Player") && !isShownAlready)
        {
            if (name.Equals("TutorialJumpTrigger"))
            {
                messageBox.text = "Press 'Space' to jump.";
                isShownAlready = true;
                Show();
            }
        }
    }

    private void Hide()
    {
        canvasGameObject.SetActive(false);
    }

    private void Show()
    {
        canvasGameObject.SetActive(true);
    }
}
