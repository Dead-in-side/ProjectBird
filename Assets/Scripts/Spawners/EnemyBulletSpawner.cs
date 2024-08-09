using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : Spawner<EnemyBullet>
{
    private Vector3 _shoterPosition;

    public override Vector3 GetPosition()=> _shoterPosition;

    public void SetShoterPosition(Vector3 position) => _shoterPosition = position;
}
