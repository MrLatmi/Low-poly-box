using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 90f;

    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _friction = 70f;
    [SerializeField] private float _maxSpeed = 20f;

    private bool _isGrounded;
    private float _horizontalInput;
    private float _verticalVelocity;

    private void Update()
    {
        if (_isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Apply friction to slow down the player when not moving
        if (_horizontalInput == 0f)
        {
            _rigidbody.velocity = new Vector3(
                Mathf.MoveTowards(_rigidbody.velocity.x, 0f, _friction * Time.fixedDeltaTime),
                _rigidbody.velocity.y,
                0f
            );
        }

        // Apply movement
        Vector3 horizontalVelocity = new Vector3(_horizontalInput, 0f, 0f) * _speed;
        Vector3 velocity = new Vector3(
            Mathf.Clamp(_rigidbody.velocity.x + horizontalVelocity.x * Time.fixedDeltaTime, -_maxSpeed, _maxSpeed),
            _rigidbody.velocity.y,
            0f
        );

        // Apply velocity change with AddForce
        _rigidbody.AddForce(velocity - _rigidbody.velocity, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        if (normal.y > 0.7f)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}
