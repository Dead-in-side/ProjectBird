using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidbody2D;
    private Quaternion _rotationMax;
    private Quaternion _rotationMin;
    private Vector3 _startPosition;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D> ();
    }

    private void Start()
    {
        _rotationMin = Quaternion.Euler(0,0,_minRotationZ);
        _rotationMax = Quaternion.Euler(0,0,_maxRotationZ);
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotationMin, _rotationSpeed*Time.deltaTime);
    }

    public void Jump()
    {
        transform.rotation = _rotationMax;

        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.velocity = Vector2.zero;
    }
}

