using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraScript : MonoBehaviour
{
    [SerializeField] public Player _player;


    private void FixedUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
    }


}
