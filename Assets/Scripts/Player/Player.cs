using System;
using UnityEngine;

public class Player : MonoBehaviour, IInteractable
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private BirdMover _mover;
    [SerializeField] private CollideDetector _detector;
    [SerializeField] private PlayerBulletSpawner _bulletSpawner;

    public event Action GameOver;

    private void OnEnable()
    {
        _inputReader.JumpButtonPressed += _mover.Jump;
        _inputReader.ShotButtonPressed += _bulletSpawner.SetMoveDirectionForObjects;
        _inputReader.ShotButtonPressed += _bulletSpawner.Shot;

        _detector.CollisionIsHappened += ReactToColission;
    }

    private void OnDisable()
    {
        _inputReader.JumpButtonPressed -= _mover.Jump;
        _inputReader.ShotButtonPressed -= _bulletSpawner.Shot;

        _detector.CollisionIsHappened -= ReactToColission;
    }

    private void ReactToColission(IInteractable interactableObject)
    {
        GameOver?.Invoke();
    }

    public void Restart()
    {
        _bulletSpawner.Reset();
        _mover.Reset();
    }
}