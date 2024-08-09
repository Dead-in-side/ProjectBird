using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IRecreatabl
{
    [SerializeField] private Pool<T> _pool;
    [SerializeField] private Vector3 _direction;

    public void Spawn()
    {
        T spawnedObject = _pool.GetObject();
        spawnedObject.Init(GetPosition());
        spawnedObject.SetDirection(_direction);
    }

    public virtual Vector3 GetPosition() => transform.position;

    public void SetMoveDirectionForObjects() => _direction = (transform.position - transform.parent.position).normalized;

    public void Reset() => _pool.Reset();
}
