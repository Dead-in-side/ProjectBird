using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IRecreatabl
{
    [SerializeField, Range(0, 100)] private float _speed;
    [SerializeField] private CollideDetector _collideDetector;

    private float _lifeTime = 10f;
    private float _startLifeTIme;
    private Vector3 _direction;

    public event Action<IRecreatabl> ObjectReadyToComeBack;

    private void Awake()
    {
        _startLifeTIme = _lifeTime;
    }

    private void OnEnable()
    {
        _collideDetector.CollisionIsHappened += ReactToColission;
    }

    private void OnDisable()
    {
        _collideDetector.CollisionIsHappened -= ReactToColission;
    }

    private void Update()
    {
        Move();

        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0 && gameObject.TryGetComponent(out IRecreatabl recreatable))
        {
            ObjectReadyToComeBack?.Invoke(recreatable);
        }
    }

    public void Init(Vector3 position)
    {
        _lifeTime = _startLifeTIme;

        gameObject.SetActive(true);

        transform.position = position;
    }

    public void EndTheLife()
    {
        gameObject.SetActive(false);
    }

    public void ReturnToPool()
    {
        if (gameObject.TryGetComponent(out IRecreatabl recreatable))
        {
            ObjectReadyToComeBack?.Invoke(recreatable);
        }
    }

    public void SetDirection(Vector3 direction) => _direction = direction;

    public virtual void Move()
    {
        transform.Translate(_direction*_speed*Time.deltaTime);
    }

    public virtual void ReactToColission(IInteractable interactable)
    {
        
    }
}
