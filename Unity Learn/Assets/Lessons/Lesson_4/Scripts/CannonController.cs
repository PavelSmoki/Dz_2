using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField, Range(30, 50)] private float _shootForce;
    [SerializeField] private float _barrelRotationSpeed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _spawnPos;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _cannonBarrel;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, -_rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(transform.up * _moveSpeed, ForceMode.Acceleration);
        } 
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(transform.up * -_moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _shootForce += 10f * Time.deltaTime;
            if (_shootForce >= 50f)
            {
                _shootForce = 50f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            var ball = Instantiate(_ball, _spawnPos.transform.position, Quaternion.identity);
            var ballRb = ball.GetComponent<Rigidbody>();
            ballRb.AddForce(_cannonBarrel.transform.up * _shootForce, ForceMode.Impulse);
            _shootForce = 30f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _cannonBarrel.transform.Rotate(Vector3.right, _barrelRotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _cannonBarrel.transform.Rotate(Vector3.right, -_barrelRotationSpeed * Time.deltaTime);
        }
    }
}