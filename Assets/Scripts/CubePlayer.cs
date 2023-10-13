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

    protected override bool CanMove(Vector3 moveDirection, float moveDistance)
    {
        return !Physics.BoxCast(transform.position, new Vector3(.4f,.4f,.4f), moveDirection, transform.rotation, moveDistance);
    }
}
