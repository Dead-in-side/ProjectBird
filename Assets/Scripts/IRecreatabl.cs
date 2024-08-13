using System;
using UnityEngine;

public interface IRecreatabl: IInteractable
{
    public event Action<IRecreatabl> ObjectReadyToComeBack;

    public void Init(Vector3 position);

    public void Die();

    public void SetDirection(Vector3 direction);

    public void ReturnToPool();
}
