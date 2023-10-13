using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] public Player _player;


    private void Update()
    {
        //ofset = transform.position - _player.transform.position;
        //transform.position = _player.transform.position + ofset;
        Vector3 moveCam = new Vector3(_player.transform.position.x, 0, 0);
        transform.position = moveCam + new Vector3(0,0, -10);
    }
}
