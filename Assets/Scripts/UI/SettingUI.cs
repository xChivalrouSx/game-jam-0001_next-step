using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] Button optionsButton;
    [SerializeField] Button howToButton;
    [SerializeField] Button closeButton;
    [SerializeField] GameObject howToPanel;
    [SerializeField] GameObject optionPanel;

    private void Update()
    {
        optionsButton.onClick.AddListener(() =>
        {
            optionPanel.SetActive(true);
            howToPanel.SetActive(false);
        });
        howToButton.onClick.AddListener(() =>
        {
            optionPanel.SetActive(false);
            howToPanel.SetActive(true);
        });

        closeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
