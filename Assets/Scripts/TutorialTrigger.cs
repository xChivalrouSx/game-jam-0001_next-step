using TMPro;
using UnityEngine;

public class TutorialTriggerScript : MonoBehaviour
{
    [SerializeField] private GameObject canvasGameObject;
    [SerializeField] private TextMeshProUGUI messageBox;
    [SerializeField] private KeyCode keyToWait;
    [SerializeField] private string pressToWhat;

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
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other.tag.Contains("Player") && !isShownAlready)
        {
            messageBox.text = "Press '" + keyToWait.ToString() + "' to " + pressToWhat + "!..";
            isShownAlready = true;
            Show();
            Time.timeScale = 0f;
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
