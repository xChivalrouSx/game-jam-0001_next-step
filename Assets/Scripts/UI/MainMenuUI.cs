using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button settingButton;
    [SerializeField] GameObject settingCanvas;

    void Awake()
    {
        settingCanvas.SetActive(false);

        playButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.Level1Scene);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        settingButton.onClick.AddListener(() =>
        {
            settingCanvas.SetActive(true);
        });
    }
}
