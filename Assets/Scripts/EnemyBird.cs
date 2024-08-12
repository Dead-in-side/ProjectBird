using System;
using System.Collections;
using UnityEngine;

public class EnemyBird : MonoBehaviour, IRecreatabl
{
    [SerializeField] private ScriptableEnemy _enemy;
    [SerializeField] private CollideDetector _collideDetector;
    [SerializeField] private Transform _shooterTransform;

    private EnemyBulletSpawner _bulletSpawner;
    private Vector3 _direction;

    public event Action<IRecreatabl> ObjectReadyToComeBack;

    private void OnEnable()
    {
        _collideDetector.CollisionIsHappened += ReactToColission;
    }

    private void OnDisable()
    {
        _collideDetector.CollisionIsHappened -= ReactToColission;
    }

    private void Update()
    {
        Move();
    }

    public void Init(Vector3 position)
    {
        gameObject.SetActive(true);

        transform.position = position;

        StartCoroutine(ShotCoroutine());
    }

    public void SetBulletSpawner(EnemyBulletSpawner bulletSpawner) => _bulletSpawner = bulletSpawner;

    public void ReturnToPool()
    {
        ObjectReadyToComeBack?.Invoke(this);
    }

    public void EndTheLife()
    {
        gameObject.SetActive(false);
    }

    public void SetDirection(Vector3 direction) => _direction = direction;

    private void Move()
    {
        transform.Translate(_direction * _enemy.Speed * Time.deltaTime);
    }

    private void ReactToColission(IInteractable interactable)
    {
        if (interactable is PlayerBullet)
        {
            ReturnToPool();
        }
    }

    private IEnumerator ShotCoroutine()
    {
        WaitForSeconds delay;

        while (enabled)
        {
            delay = new WaitForSeconds(UnityEngine.Random.Range(_enemy.MinDelay, _enemy.MaxDelay));

            _bulletSpawner.SetShoterPosition(_shooterTransform.position);

            _bulletSpawner.Spawn();

            yield return delay;
        }
    }
}
