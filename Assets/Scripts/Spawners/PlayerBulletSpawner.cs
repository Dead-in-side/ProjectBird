using UnityEngine;

public class PlayerBulletSpawner : Spawner<PlayerBullet>
{
    private float _delay = 1f;
    private float _timeForShot = 1f;

    public void Shot()
    {
        if (_delay >= _timeForShot)
        {
            Spawn();

            _delay = 0;
        }
    }

    private void Update()
    {
        if (_delay < _timeForShot)
        {
            _delay += Time.deltaTime;
        }
    }
}
