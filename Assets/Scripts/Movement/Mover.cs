using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;

        [SerializeField, Range(50.0f, 200.0f)] private float _maxSpeed;
        [SerializeField, Range(10.0f, 20.0f)] private float _speedDelta;

        private Rigidbody _rigidbody;
        private float _speed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float forwardValue = _inputReader.GetVerticalDirection();
            float targetSpeed = forwardValue * _maxSpeed;

            _speed = Mathf.MoveTowards(_speed, targetSpeed, _speedDelta * Time.fixedDeltaTime);

            Vector3 velocity = transform.forward * _speed;
            velocity.y = _rigidbody.velocity.y;

            _rigidbody.velocity = velocity;
        }
    }
}