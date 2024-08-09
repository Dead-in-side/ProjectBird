public class PlayerBullet : Bullet
{
    public override void ReactToColission(IInteractable interactable)
    {
        base.ReactToColission(interactable);

        if(interactable is EnemyBird)
        {
            ReturnToPool();
        }
    }

    public override void Move()
    {
        base.Move();
    }
}
