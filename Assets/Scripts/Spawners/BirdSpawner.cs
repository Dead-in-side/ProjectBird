using System.Collections;
using UnityEngine;

public class BirdSpawner : Spawner<EnemyBird>
{
    [SerializeField] private float _minDelay = 3;
    [SerializeField] private float _maxDelay = 7;
    [SerializeField] private CollideDetector _collideDetector;
    private float _offset = 8f;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void OnEnable()
    {
        _collideDetector.CollisionIsHappened += ReactToCollision;
    }

    private void OnDisable()
    {
        _collideDetector.CollisionIsHappened -= ReactToCollision;
    }

    public override Vector3 GetPosition()
    {
        return new Vector3(transform.position.x, transform.position.y + Random.Range(-_offset, _offset));
    }

    private IEnumerator SpawnCoroutine()
    {
        WaitForSeconds delay;

        bool isWork = true;

        while (isWork)
        {
            delay = new WaitForSeconds(Random.Range(_minDelay, _maxDelay));

            yield return delay;

            base.Spawn();
        }
    }

    private void ReactToCollision(IInteractable interactable)
    {
        if (interactable is EnemyBird bird)
        {
            bird.ReturnToPool();
        }

        if (interactable is Bullet bullet)
        {
            bullet.ReturnToPool();
        }
    }
}

