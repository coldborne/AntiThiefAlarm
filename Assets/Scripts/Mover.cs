using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField, Range(50.0f, 200.0f)] private float _maxMoveSpeed;
    [SerializeField, Range(10.0f, 20.0f)] private float _moveSpeedDelta;

    [SerializeField, Min(1.0f)] private float _rotationSpeed;

    private Rigidbody _rigidbody;
    private float _moveSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        float forwardValue = Input.GetAxis(Vertical);
        float targetSpeed = forwardValue * _maxMoveSpeed;

        _moveSpeed = Mathf.MoveTowards(_moveSpeed, targetSpeed, _moveSpeedDelta * Time.fixedDeltaTime);

        Vector3 velocity = transform.forward * _moveSpeed;
        velocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = velocity;
    }

    private void Rotate()
    {
        float horizontalDirection = Input.GetAxis(Horizontal);

        float yRotationAngle = horizontalDirection * _rotationSpeed * Time.deltaTime;

        Quaternion rotationDelta = Quaternion.Euler(0.0f, yRotationAngle, 0.0f);
        Quaternion rotation = _rigidbody.rotation * rotationDelta;

        _rigidbody.MoveRotation(rotation);
    }
}