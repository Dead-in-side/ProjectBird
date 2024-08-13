using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Border : MonoBehaviour
{
    [SerializeField] private CollideDetector _collideDetector;

    private void OnEnable()
    {
        _collideDetector.CollisionIsHappened += OnColisionHappen;
    }

    private void OnDisable()
    {
        _collideDetector.CollisionIsHappened -= OnColisionHappen;
    }

    private void OnColisionHappen(IInteractable interactable)
    {
        if(interactable is IRecreatabl recreatabl)
        {
            recreatabl.ReturnToPool();
        }
    }
}
