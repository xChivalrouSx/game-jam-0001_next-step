using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpherePlayer : Player
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
            return !Physics.SphereCast(transform.position, .49f, moveDirection, out _, moveDistance);
        }

    }
}