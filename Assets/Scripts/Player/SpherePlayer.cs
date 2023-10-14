namespace Assets.Scripts
{
    public class SpherePlayer : Player
    {
        protected override float GetJumpSpeed()
        {
            return jumpSpeed;
        }

        public override float GetMovementSpeed()
        {
            return movementSpeed;
        }

    }
}