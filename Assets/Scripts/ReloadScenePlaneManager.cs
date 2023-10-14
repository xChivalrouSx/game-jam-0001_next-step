using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScenePlaneManager : MonoBehaviour
{
    [SerializeField] public string sceneName;
    [SerializeField] public Player _player;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
