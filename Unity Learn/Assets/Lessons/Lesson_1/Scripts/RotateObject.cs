using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Axes _axis = Axes.X;
    [SerializeField] private float _speed = 30;

    void Update()
    {
        if (_axis == Axes.X)
        {
            transform.Rotate(_speed * Time.deltaTime, transform.rotation.y, transform.rotation.z);
        }
        else if (_axis == Axes.Y)
        {
            transform.Rotate(transform.rotation.x, _speed * Time.deltaTime, transform.rotation.z);
        }
        else if (_axis == Axes.Z)
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, _speed * Time.deltaTime);
        }
    }
}