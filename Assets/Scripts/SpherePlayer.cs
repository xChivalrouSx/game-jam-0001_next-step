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

    }
}