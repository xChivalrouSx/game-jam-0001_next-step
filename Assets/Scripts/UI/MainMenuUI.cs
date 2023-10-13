using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button settingButton;
    [SerializeField] GameObject settingCanvas;

    private void Start()
    {
        settingCanvas.SetActive(false);
    }
    void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.Level2Scene);
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
