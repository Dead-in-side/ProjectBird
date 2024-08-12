public class EnemyBullet : Bullet
{
    public override void ReactToColission(IInteractable interactable)
    {
        if (interactable is Player)
        {
            ReturnToPool();
        }
    }
}
