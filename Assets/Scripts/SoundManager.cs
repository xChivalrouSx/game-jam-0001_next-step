using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip jumpAudioClip;
    private void Start()
    {
        Player.Instance.JumpHandler += Player_Jump; 
    }

    private void Player_Jump(object sender, System.EventArgs e)
    {
        PlaySound(jumpAudioClip, Player.Instance.transform.position, 1f);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
