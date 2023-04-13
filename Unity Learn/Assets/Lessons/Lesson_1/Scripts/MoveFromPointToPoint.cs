using UnityEngine;

public class MoveFromPointToPoint : MonoBehaviour
{
    private Vector3 _a;
    [SerializeField] private Vector3 _b;
    [Range(0, 1)] public float value;
    private bool _isForward = true;

    void Start()
    {
        _a = transform.position;
    }

    private void Update()
    {
        if (_isForward)
        {
            Move();
            value += 0.005f;
        }
        else
        {
            Move();
            value -= 0.005f;
        }

        if (value >= 1)
        {
            _isForward = false;
        }

        if (value < 0)
        {
            _isForward = true;
        }
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(_a, _b, value);
    }
}