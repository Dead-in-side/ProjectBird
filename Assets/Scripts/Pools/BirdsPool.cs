using UnityEngine;

public class BirdsPool : Pool<EnemyBird>
{
    [SerializeField] private EnemyBulletSpawner _bulletSpawner;

    public override EnemyBird CreateObject()
    {
        EnemyBird enemy = Instantiate(GetRandomPrefab());
        enemy.SetBulletSpawner(_bulletSpawner);
        AddToList(enemy);

        return enemy;
    }

    public override void Reset()
    {
        base.Reset();

        _bulletSpawner.Reset();
    }
}

