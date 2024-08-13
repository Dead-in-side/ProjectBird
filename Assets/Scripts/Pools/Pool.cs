using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour, IRecreatabl
{
    [SerializeField] private List<T> _spawnedObjectPrefabs;

    private Queue<T> _objectsQueue = new();
    private List<T> _createdObjects = new();

    public T GetObject()
    {
        T spawnedObject;

        if (_objectsQueue.Count > 0)
        {
            spawnedObject = _objectsQueue.Dequeue();
        }
        else
        {
            spawnedObject = CreateObject();
        }

        spawnedObject.ObjectReadyToComeBack += TakeObject;

        return spawnedObject;
    }

    public void TakeObject(IRecreatabl recreatabl)
    {
        if (recreatabl is T spawnedObject)
        {
            spawnedObject.ObjectReadyToComeBack -= TakeObject;

            spawnedObject.Die();

            _objectsQueue.Enqueue(spawnedObject);
        }
    }

    public virtual T CreateObject()
    {
        T createdObject =   Instantiate(GetRandomPrefab());
        _createdObjects.Add(createdObject);
        return createdObject;
    }

    public T GetRandomPrefab() => _spawnedObjectPrefabs[Random.Range(0, _spawnedObjectPrefabs.Count)];

    public void AddToList(T obj)=>_createdObjects.Add(obj);

    public virtual void Reset()
    {
        foreach(var obj in _createdObjects)
        {
            obj.ReturnToPool();
        }
    }
}
