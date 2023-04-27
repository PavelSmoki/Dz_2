using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;
    private bool _isAlive = true;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Dead = Animator.StringToHash("Dead");
    private static readonly int Punch = Animator.StringToHash("Punch");


    private void Update()
    {
        if (Input.GetKey(KeyCode.D) && _isAlive)
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && _isAlive)
        {
            transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) && _isAlive)
        {
            if (Input.GetKey(KeyCode.LeftShift) && _isAlive)
            {
                _rb.AddForce(transform.forward * (_moveSpeed * 1.3f), ForceMode.Acceleration);
            } else _rb.AddForce(transform.forward * _moveSpeed, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.S) && _isAlive)
        {
            _rb.AddForce(transform.forward * -_moveSpeed, ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isAlive)
        {
            _rb.AddForce(transform.up * _jumpHeight, ForceMode.Acceleration);
            _animator.SetTrigger(Jump);
        }
        
        if (Input.GetMouseButtonDown(0) && _isAlive)
        {
            _animator.SetTrigger(Punch);
        }

        _animator.SetBool(IsWalking, _rb.velocity.sqrMagnitude >= 0.1f);
        _animator.SetBool(IsRunning, _rb.velocity.sqrMagnitude >= 16f);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DeathTrigger"))
        {
            _animator.SetTrigger(Dead);
            _isAlive = false;
        }
    }
}