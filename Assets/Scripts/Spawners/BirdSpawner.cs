using System.Collections;
using UnityEngine;

public class BirdSpawner : Spawner<EnemyBird>
{
    [SerializeField] private float _minDelay = 3;
    [SerializeField] private float _maxDelay = 7;
    private float _offset = 8f;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
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
}

