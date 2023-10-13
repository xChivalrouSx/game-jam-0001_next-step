using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : Player
{
    protected override float GetJumpSpeed()
    {
        return jumpSpeed;
    }

    protected override float GetMovementSpeed()
    {
        return movementSpeed;
    }
}
