public class EnemyBullet : Bullet
{
    public override void ReactToColission(IInteractable interactable)
    {
        base.ReactToColission(interactable);

        if (interactable is Player)
        {
            ReturnToPool();
        }
    }
}
