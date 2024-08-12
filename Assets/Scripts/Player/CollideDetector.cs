using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollideDetector : MonoBehaviour
{
    public event Action<IInteractable> CollisionIsHappened;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractable interactable))
        {
            CollisionIsHappened?.Invoke(interactable);
        }
    }
}