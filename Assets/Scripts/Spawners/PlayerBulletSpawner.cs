using UnityEngine;

public class PlayerBulletSpawner : Spawner<PlayerBullet>
{
    private float _delay = 1f;

    public void Shot()
    {
        if (_delay >= 1)
        {
            base.Spawn();

            _delay = 0;
        }
    }

    private void Update()
    {
        if (_delay < 1)
        {
            _delay += Time.deltaTime;
        }
    }
}
