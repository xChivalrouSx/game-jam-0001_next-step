public class CubePlayer : Player
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
