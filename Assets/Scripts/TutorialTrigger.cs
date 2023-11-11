using TMPro;
using UnityEngine;

public class TutorialTriggerScript : MonoBehaviour
{
    [SerializeField] private GameObject canvasGameObject;
    [SerializeField] private TextMeshProUGUI messageBox;
    [SerializeField] private KeyCode keyToWait;
    [SerializeField] private string pressToWhat;
    [SerializeField] private string customMessage;

    private bool isShownAlready;

    private void Awake()
    {
        Hide();
        isShownAlready = false;
    }

    private void Update()
    {
        if (gameObject.activeSelf && (Input.GetKey(keyToWait) || (KeyCode.RightArrow == keyToWait && Input.GetKey(KeyCode.D))))
        {
            Hide();
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player") && !isShownAlready)
        {
            messageBox.text = string.IsNullOrWhiteSpace(customMessage) ? "Press '" + keyToWait.ToString() + "' to " + pressToWhat + "!.." : customMessage;
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
