using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField, Min(1.0f)] private float _rotationSpeed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Rotate();
        }

        private void Rotate()
        {
            float horizontalDirection = _inputReader.GetHorizontalDirection();

            float yRotationAngle = horizontalDirection * _rotationSpeed * Time.deltaTime;

            Quaternion rotationDelta = Quaternion.Euler(0.0f, yRotationAngle, 0.0f);
            Quaternion rotation = _rigidbody.rotation * rotationDelta;

            _rigidbody.MoveRotation(rotation);
        }
    }
}