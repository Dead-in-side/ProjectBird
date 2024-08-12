public class PlayerBullet : Bullet
{
    public override void ReactToColission(IInteractable interactable)
    { 
        if(interactable is EnemyBird)
        {
            ReturnToPool();
        }
    }
}
