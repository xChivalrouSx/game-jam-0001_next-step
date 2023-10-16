namespace Assets.Scripts
{
    public class PlayerSphere : Player
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