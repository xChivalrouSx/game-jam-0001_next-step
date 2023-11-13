using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    [SerializeField] private Button nextButton;

    private void Awake()
    {
        nextButton.onClick.AddListener(() =>
        {
            Loader.Load((Loader.Scene)(Int32.Parse(SceneManager.GetActiveScene().name.Split('_', StringSplitOptions.RemoveEmptyEntries)[1]) + 1));
        });
    }
}
